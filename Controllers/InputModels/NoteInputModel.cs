using System;
using System.ComponentModel.DataAnnotations;
using Taskmanager.Data.Entities;

namespace Taskmanager.Controllers.InputModels
{
    public class NoteInputModel 
    {
        [Required]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "Note must be between 1 and 300 characters")]
        public string Body { get; set; }
    
        public static Note MapNote(NoteInputModel inputModel)
        {
            if (inputModel != null)
            {
                return new Note{ Body = inputModel.Body };
            }

            throw new NullReferenceException("Input model was null");
        }
    }
}