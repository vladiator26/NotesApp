using System.Collections.Generic;
using NotesApp.Models;

namespace NotesApp
{
    public class ApplicationContext
    {
        public List<Note> Notes { get; set; }
    }
}