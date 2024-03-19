using System.ComponentModel.DataAnnotations;
using Notes.Database;
using Notes.Database.Repositories;
using Notes.Models;

namespace Notes.Tests.Database;

/// <summary>
///     Тестирование валидатора моделей
/// </summary>
public class ValidatorModelsTest {
    [Fact]
    public async Task ValidateNoteModel() {
        var ctx = new DatabaseContext("Data Source=validator_db_test.db;", true);
        var noteRepository = ctx.GetRepository<NoteRepository>();

        var note = new Note {
            Title = "Test", Description = "Test description", CreatedAt = DateTime.Now
        };

        await noteRepository.CreateAsync(note);
    }

    [Fact]
    public async Task FailValidateNoteModel() {
        var ctx = new DatabaseContext("Data Source=validator_db_test.db;", true);
        var noteRepository = ctx.GetRepository<NoteRepository>();

        var note = new Note {
            Title = "1", CreatedAt = DateTime.Now
        };

        var exception = await Assert.ThrowsAsync<ValidationException>(() => noteRepository.CreateAsync(note));
        Assert.Equal(typeof(ValidationException), exception.GetType());
    }
}