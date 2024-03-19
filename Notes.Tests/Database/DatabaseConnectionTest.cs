using Microsoft.EntityFrameworkCore;
using Notes.Database;
using Notes.Models;

namespace Notes.Tests.Database;

public class DatabaseConnectionTest {
    [Fact]
    public async Task ConnectToDatabase() {
        var ctx = new DatabaseContext("Data Source=connect_db_test.db;", true);
        await ctx.Notes.AddAsync(new Note {
            Title = "Test",
            Description = "Test description",
            CreatedAt = DateTime.Now
        });

        await ctx.SaveChangesAsync();

        var note = await ctx.Notes.FirstOrDefaultAsync();
        Assert.NotNull(note);
    }

    [Fact]
    public async Task DeleteNote() {
        var ctx = new DatabaseContext("Data Source=connect_db_test.db;", true);

        var note = new Note {
            Title = "Test",
            Description = "Test description",
            CreatedAt = DateTime.Now
        };
        ctx.Notes.Add(note);

        await ctx.SaveChangesAsync();

        ctx.Notes.Remove(note);
        await ctx.SaveChangesAsync();

        Assert.DoesNotContain(note, ctx.Notes);
    }

    [Fact]
    public async Task GetNoteById() {
        var ctx = new DatabaseContext("Data Source=connect_db_test.db;", true);

        var note = new Note {
            Title = "Test", Description = "Test description", CreatedAt = DateTime.Now
        };
        ctx.Notes.Add(note);

        await ctx.SaveChangesAsync();

        var retrievedNote = await ctx.Notes.FindAsync(note.Id);
        Assert.Equal(note, retrievedNote);
    }

    [Fact]
    public async Task GetAllNotes() {
        var ctx = new DatabaseContext("Data Source=connect_db_test.db;", true);

        var note1 = new Note { Title = "Test1", Description = "Test description1", CreatedAt = DateTime.Now };
        var note2 = new Note { Title = "Test2", Description = "Test description2", CreatedAt = DateTime.Now };
        ctx.Notes.AddRange(note1, note2);

        await ctx.SaveChangesAsync();

        var notes = await ctx.Notes.ToListAsync();
        Assert.Equal(2, notes.Count);
    }
}