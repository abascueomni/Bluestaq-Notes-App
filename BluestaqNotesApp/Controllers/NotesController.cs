using BluestaqNotesApp.Data;
using BluestaqNotesApp.DTOs;
using BluestaqNotesApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    private readonly NotesDbContext _db;
    public NotesController(NotesDbContext db) => _db = db;

    // GET /api/notes
    [HttpGet]
    public async Task<ActionResult<List<NotesDto>>> GetAll()
    {
        var notes = await _db.Notes.ToListAsync();
        return Ok(notes.Select(MapToDto)); //return the full list of notes
    }

    // GET /api/notes/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<NotesDto>> GetById(int id)
    {
        var note = await _db.Notes.FirstOrDefaultAsync(p => p.Id == id);
        if (note == null) return NotFound(); //throw an error we didn't find the note with the given Id
        return Ok(MapToDto(note)); //return the single requested note
    }
    // POST /api/notes
    [HttpPost]
    public async Task<IActionResult> CreateNote([FromBody] CreateNoteRequest request)
    {
        //put the request in a new note
        var note = new Note
        {
            Content = request.Content,
            CreatedAt = DateTimeOffset.UtcNow
        };

        //add the new note to the database
        _db.Notes.Add(note);
        //save the database
        await _db.SaveChangesAsync();
        //return result
        return CreatedAtAction(nameof(GetById), new { id = note.Id }, MapToDto(note));
    }
    //POST /api/notes/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        Note? note = await _db.Notes.FindAsync(id);
        //did not find the note return an error
        if (note == null) return NotFound();
        //delete the found note
        _db.Remove(note);
        //save the changes
        await _db.SaveChangesAsync();
        //return result
        return NoContent();
    }

    //Map Note to NoteDto
    private NotesDto MapToDto(Note note)
    {
        return new NotesDto
        {
            Id = note.Id,
            Content = note.Content,
            CreatedAt = note.CreatedAt
        };
    }

}