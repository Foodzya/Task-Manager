using System;
using Taskmanager.Data.Entities;

namespace Taskmanager.Controllers.ViewModels
{
    public class TodolistViewModel
    {
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }

        public static TodolistViewModel MapTodolist(TodoList todolist)
        {
            if (todolist != null)
            {
                return new TodolistViewModel()
                { 
                    Title = todolist.Title,
                    CreationDate = Convert.ToDateTime(todolist.CreationDate) 
                };
            }
            
            throw new NullReferenceException("TodoList was null");
        }
    }
}