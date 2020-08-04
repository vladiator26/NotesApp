using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Models;

namespace NotesApp.Controllers
{
    [ApiController]
    [Route("api/notes")]
    public class NotesController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        public NotesController()
        {
            if (db.Notes.Any()) return;
            db.Notes.Add(new Note {Description = "abrakadabra", LastChange = DateTime.Now});
            db.Notes.Add(new Note {Description = "lorem ipsum sit amet", LastChange = DateTime.Now});
            db.Notes.Add(new Note {Description = "Hi!", LastChange = DateTime.Now});
        }
        
        [HttpGet]
        public IEnumerable<Note> Get()
        {
            return db.Notes.ToList();
        }
 
        [HttpGet("{id}")]
        public Note Get(int id)
        {
            Note note = db.Notes.FirstOrDefault(x => x.Id == id);
            return note;
        }
 
        [HttpPost]
        public IActionResult Post(Note note)
        {
            db.Notes.Add(note);
            return Ok(note);
        }
 
        [HttpPut]
        public IActionResult Put(Note note)
        {
            Note updateNote = db.Notes.FirstOrDefault(item => item.Id == note.Id);
            if (updateNote != null)
            {
                updateNote.Description = note.Description;
            }
            return Ok(note);
        }
 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Note note = db.Notes.FirstOrDefault(x => x.Id == id);
            if (note != null)
            {
                db.Notes.Remove(note);
            }
            return Ok(note);
        }
    }
}