using System;
using Taskmanager.Data.Entities;

namespace Taskmanager.Controllers.ViewModels
{
    public class TodolistViewModel
    {
        public string Title { get; set; }
        public long? Userid { get; set; }

        public static TodolistViewModel MapTodolist(Todolist todolist)
        {
            if (todolist != null)
            {
                return new TodolistViewModel(){ Title = todolist.Title, Userid = todolist.Userid };
            }
            
            throw new Exception("Todolist is empty");
        }
    }
}