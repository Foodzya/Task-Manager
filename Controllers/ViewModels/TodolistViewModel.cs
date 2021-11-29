using System;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Controllers.ViewModels
{
    public class TodolistViewModel
    {
        public string Title { get; set; }
        public string Creationdate { get; set; }

        public static TodolistViewModel MapTodolist(Todolist todolist)
        {
            if (todolist != null)
            {
                return new TodolistViewModel(){ Title = todolist.Title, Creationdate = todolist.Creationdate };
            }
            
            throw new Exception("Todolist is empty");
        }
    }
}