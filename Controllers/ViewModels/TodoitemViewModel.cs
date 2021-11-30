using System;
using Taskmanager.Data.Entities;

namespace Taskmanager.Controllers.ViewModels
{
    public class TodoitemViewModel
    {
        public string Title { get; set; }
        public long Isfinished { get; set; }
        public string Deadlinedate { get; set; }
        public long? PriorityId { get; set; }

        public static TodoitemViewModel MapTodoitem(Todoitem todoitem)
        {
            if (todoitem != null)
            {
                return new TodoitemViewModel{ Title = todoitem.Title, Isfinished = todoitem.Isfinished, Deadlinedate = todoitem.Deadlinedate, PriorityId = todoitem.Priorityid};
            }

            throw new Exception("Todoitem is empty");
        }
    }
}