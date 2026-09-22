using CloudNotes.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloudNotes.Controllers
{
    [ApiController]
    [Route("note")]
    public class NoteController : ControllerBase
    {

        private static IList<Note> _notes = new List<Note>()
        {
            new Note(){Description = "note sur les fondamantal de c#"} ,
            new Note(){Description= "note sur les POO de c#"},
            new Note(){Description= "note Angular"},
            new Note(){Description= "note Azure"}
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_notes);
        }

        [HttpPost]
        public IActionResult Post(string description)
        {
            _notes.Add(new Note() { Description = description });
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Guid id, string description)
        {
            Note? note = _notes.SingleOrDefault(n => n.Id == id);
            if (note is null)
                return BadRequest();
            note.Description = description;
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            Note? note = _notes.SingleOrDefault(n => n.Id == id);
            if (note is null)
                return BadRequest();
            _notes.Remove(note);
            return Ok();
        }

    }
}
