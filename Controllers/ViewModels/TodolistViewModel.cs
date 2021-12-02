using System;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Controllers.ViewModels
{
    public class TodolistViewModel
    {
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }

        public static TodolistViewModel MapTodolist(Todolist todolist)
        {
            if (todolist != null)
            {
                return new TodolistViewModel()
                { 
                    Title = todolist.Title,
                    CreationDate = Convert.ToDateTime(todolist.Creationdate) 
                };
            }
            
            throw new NullReferenceException();
        }
    }
}