using System;
using System.ComponentModel.DataAnnotations;
using Taskmanager.Data.Entities;

namespace Taskmanager.Controllers.InputModels
{
    public class TodoitemInputModel
    {
        [Required]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "Todoitem must be between 1 and 3 characters")]
        public string Title { get; set; }
        [RegularExpression(@"^[0-9]{0,1}$", ErrorMessage = "IsFinished can have 0 or 1 value")] 
        public long Isfinished { get; set; }
        [RegularExpression(@"^\d\d\d\d-(0?[1-9]|1[0-2])-(0?[1-9]|[12][0-9]|3[01]) (00|[0-9]|1[0-9]|2[0-3]):([0-9]|[0-5][0-9]):([0-9]|[0-5][0-9])\.(\d{3})$")]
        public string Deadlinedate { get; set; }
        [RegularExpression(@"^[0-9]{1,3}$", ErrorMessage = "Indicate priority from 1 to 3")] 
        public long? Priorityid { get; set; }

        public static Todoitem MapTodoitem(TodoitemInputModel inputModel)
        {
            if (inputModel != null)
            {
                return new Todoitem(){ Title = inputModel.Title, Deadlinedate = inputModel.Deadlinedate, Isfinished = inputModel.Isfinished, Priorityid = inputModel.Priorityid };
            }
            
            throw new Exception("Todoitem was null");
        }
    }
}