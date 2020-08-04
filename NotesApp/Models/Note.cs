using System;

namespace NotesApp.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime LastChange { get; set; }
    }
}