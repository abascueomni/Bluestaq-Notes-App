using BluestaqNotesApp.Models;
namespace BluestaqNotesApp.DTOs;

public class NotesDto
{
    public int Id { get; set; } //primary key
    public string Content { get; set; } = string.Empty; //content of the note
    public DateTimeOffset CreatedAt { get; set; } //date time note was created
}