using BluestaqNotesApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NotesDbContext>(options =>
    options.UseSqlite("Data Source=notes.db"));

//find all api controllers
builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<NotesDbContext>();
    db.Database.EnsureCreated(); //if the db doesn't exist yet then create it
}

//map all api controllers to their routes
app.MapControllers();

app.Run();

// Required for WebApplicationFactory integration testing
public partial class Program { }