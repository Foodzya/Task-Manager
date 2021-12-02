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
        public bool IsFinished { get; set; }
        public DateTime DeadlineDate { get; set; }
        [RegularExpression(@"^[0-9]{1,3}$", ErrorMessage = "Indicate priority from 1 to 3")] 
        public long? PriorityId { get; set; }

        public static Todoitem MapTodoitem(TodoitemInputModel inputModel)
        {
            if (inputModel != null)
            {
                Todoitem newTodoitem = new Todoitem()
                {
                    Title = inputModel.Title,
                    Isfinished = inputModel.IsFinished ? 1 : 0,
                    Deadlinedate = inputModel.DeadlineDate.ToString("yyyy/MM/dd hh:mm:ss.fff"),
                    Priorityid = inputModel.PriorityId                     
                };

                return newTodoitem;
            }
            
            throw new NullReferenceException();
        }
    }
}