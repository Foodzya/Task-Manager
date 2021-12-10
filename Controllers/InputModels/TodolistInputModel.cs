using System;
using System.ComponentModel.DataAnnotations;
using Taskmanager.Data.Entities;

namespace Taskmanager.Controllers.InputModels
{
    public class TodoListInputModel 
    {
        [Required(ErrorMessage = "Todolist title cannot be blank")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Todolist's title must be between 1 and 100 characters")]
        public string Title { get; set; }

        public static TodoList MapTodolist(TodoListInputModel inputModel)
        {
            if (inputModel != null)
            {
                return new TodoList() { Title = inputModel.Title };
            }

            throw new NullReferenceException("TodoListInputModel was null");
        }
    }
}