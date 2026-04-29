using System.ComponentModel.DataAnnotations;

namespace BluestaqNotesApp.Models;

//a note object for modeling note
public class Note
{
    public int Id { get; set; } //primary key

    [MinLength(1)]
    [Required]
    public string Content { get; set; } = string.Empty; //content of the note
    public DateTimeOffset CreatedAt { get; set; } //date time note was created
}