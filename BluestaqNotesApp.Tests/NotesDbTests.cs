using Microsoft.EntityFrameworkCore;
using Xunit;
using BluestaqNotesApp.Data;
using BluestaqNotesApp.Models;

namespace BluestaqNotesApp.Tests;

public class NotesDbTests
{
    [Fact]
    public void Can_Add_And_Retrieve_Note()
    {
        var options = new DbContextOptionsBuilder<NotesDbContext>()
            .UseInMemoryDatabase("NotesDb_Test")
            .Options;

        using var context = new NotesDbContext(options);

        var note = new Note
        {
            Content = "hello",
            CreatedAt = DateTimeOffset.UtcNow
        };

        context.Notes.Add(note);
        context.SaveChanges();

        var saved = context.Notes.FirstOrDefault();

        Assert.NotNull(saved);
        Assert.Equal("hello", saved!.Content);
    }
}