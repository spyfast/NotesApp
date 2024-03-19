using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Notes.Database.Interfaces;
using Notes.Models;

namespace Notes.Database.Repositories;

/// <summary>
///     Репозиторий заметок.
/// </summary>
/// <param name="ctx">Контекст <see cref="DatabaseContext" /></param>
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public class NoteRepository(DatabaseContext ctx) : IRepository<Note> {
    public async Task<IEnumerable<Note>> GetAllAsync() {
        // AsNoTracking используется для отключения отслеживания изменений, что увеличивает производительность
        return await ctx.Notes.AsNoTracking().ToListAsync();
    }

    public async Task<Note?> GetAsync(int id) {
        return await ctx.Notes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateAsync(Note item) {
        if (await ctx.Notes.AsNoTracking().AnyAsync(x => x.Title == item.Title))
            throw new InvalidOperationException("Точно такая же запись уже существует");

        // Валидация модели перед сохранением
        var validationResults = item.Validate().ToList();
        if (validationResults.Count != 0) {
            var errors = string.Join(Environment.NewLine,
                validationResults.Select(vr => vr.ErrorMessage));
            throw new ValidationException(errors);
        }

        await ctx.Notes.AddAsync(item);
        await ctx.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(Note item) {
        // Ищем в бд, т.к. объект может быть отключен от контекста и не отслеживаться
        var note = await ctx.Notes.FindAsync(item.Id);
        if (note == null) return false;

        var entry = ctx.Notes.Remove(note);
        // после сохранения, entry.State мутирует в EntityState.Detached, поэтому сохраняет в переменную
        var state = entry.State;

        await ctx.SaveChangesAsync();

        return state == EntityState.Deleted;
    }
}