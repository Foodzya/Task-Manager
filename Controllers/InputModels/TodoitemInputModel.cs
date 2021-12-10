using System;
using System.ComponentModel.DataAnnotations;
using Taskmanager.Data.Entities;

namespace Taskmanager.Controllers.InputModels
{
    public class TodoItemInputModel
    {
        [Required]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "TodoItem must be between 1 and 300 characters")]
        public string Title { get; set; }
        public bool IsFinished { get; set; }
        public DateTime DeadlineDate { get; set; }
        [Range(1, 3, ErrorMessage = "Indicate priority from 1 to 3")] 
        public long? PriorityId { get; set; }

        public static TodoItem MapTodoitem(TodoItemInputModel inputModel)
        {
            if (inputModel != null)
            {
                TodoItem todoItem = new TodoItem()
                {
                    Title = inputModel.Title,
                    IsFinished = inputModel.IsFinished ? 1 : 0,
                    DeadlineDate = inputModel.DeadlineDate.ToString("yyyy/MM/dd hh:mm:ss.fff"),
                    PriorityId = inputModel.PriorityId                     
                };

                return todoItem;
            }
            
            throw new NullReferenceException("TodoItemInputModel was null");
        }
    }
}