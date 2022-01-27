using System;
using Taskmanager.Data.Entities;

namespace Taskmanager.Controllers.ViewModels
{
    public class TodoListViewModel
    {
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }

        public static TodoListViewModel MapTodoList(TodoList todoList)
        {
            if (todoList != null)
            {
                return new TodoListViewModel
                { 
                    Title = todoList.Title,
                    CreationDate = Convert.ToDateTime(todoList.CreationDate) 
                };
            }
            
            throw new NullReferenceException("TodoList was null");
        }
    }
}