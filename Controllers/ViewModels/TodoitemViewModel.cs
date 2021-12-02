using System;
using System.Globalization;
using Taskmanager.Data.Entities;

namespace Taskmanager.Controllers.ViewModels
{
    public class TodoitemViewModel
    {
        public string Title { get; set; }
        public bool IsFinished { get; set; }
        public DateTime DeadlineDate { get; set; }
        public long? PriorityId { get; set; }

        public static TodoitemViewModel MapTodoitem(Todoitem todoitem)
        {
            if (todoitem != null)
            {
                return new TodoitemViewModel
                { 
                    Title = todoitem.Title, 
                    IsFinished = todoitem.Isfinished == 1 ? true : false, 
                    DeadlineDate = Convert.ToDateTime(todoitem.Deadlinedate), 
                    PriorityId = todoitem.Priorityid};
            }

            throw new NullReferenceException();
        }
    }
}