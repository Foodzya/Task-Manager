using System;
using Taskmanager.Data.Entities;

namespace Taskmanager.Controllers.ViewModels
{
    public class NoteViewModel 
    {
        public string Body { get; set; }

        public static NoteViewModel MapNote(Note note)
        {
            if (note != null)
            {
                return new NoteViewModel{ Body = note.Body };
            }

            throw new NullReferenceException("Note was null");
        }
    }
}