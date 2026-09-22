using CloudNotes.Context;
using CloudNotes.Dto;
using CloudNotes.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CloudNotes.Controllers
{
    [ApiController]
    [Route("note")]
    public class NoteController(CloudNotesDbContext context) : ControllerBase
    {

        private CloudNotesDbContext _context = context;


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Note> _notes = _context.Notes.ToList();
                return Ok(_notes);
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpPost]
        public IActionResult Post(AddNotesDto dto)
        {
            try
            {
                Note note = new Note()
                {
                    Titre = dto.Titre,
                    Content = dto.Content
                };

                _context.Notes.Add(note);
                _context.SaveChanges();
                return Ok();
            }
        
            catch{
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put(ModdifierNoteDto dto)
        {
            try{
                Note? note = _context.Notes.SingleOrDefault(n => n.Id == dto.Id);

                if (note is null)
                    return BadRequest();

                note.Titre = dto.Titre;
                note.Content = dto.Content;
                _context.SaveChanges();
                return Ok(); 
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try{
                Note? note = _context.Notes.SingleOrDefault(n => n.Id == id);
                if (note is null)
                    return BadRequest();
                _context.Notes.Remove(note);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
