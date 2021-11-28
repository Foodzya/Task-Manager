using System.Collections.Generic;
using Taskmanager.Data.Entities;

namespace Taskmanager.Controllers.InputModels
{
    public class TodolistInputModel 
    {
        public string Title { get; set; }
        public User User { get; set; }
    }
}