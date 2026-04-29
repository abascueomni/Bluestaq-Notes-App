using Microsoft.EntityFrameworkCore;
using BluestaqNotesApp.Models;
namespace BluestaqNotesApp.Data
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options)
            : base(options) { }

        public DbSet<Note> Notes => Set<Note>();
    }
}