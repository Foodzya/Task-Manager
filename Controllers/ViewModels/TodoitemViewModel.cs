using System;
using Taskmanager.Data.Entities;

namespace Taskmanager.Controllers.ViewModels
{
    public class TodoitemViewModel
    {
        public string Title { get; set; }
        public bool IsFinished { get; set; }
        public DateTime DeadlineDate { get; set; }
        public long? PriorityId { get; set; }

        public static TodoitemViewModel MapTodoitem(TodoItem todoitem)
        {
            if (todoitem != null)
            {
                return new TodoitemViewModel
                { 
                    Title = todoitem.Title, 
                    IsFinished = todoitem.IsFinished == 1, 
                    DeadlineDate = Convert.ToDateTime(todoitem.DeadlineDate), 
                    PriorityId = todoitem.PriorityId};
            }

            throw new NullReferenceException("TodoItem was null");
        }
    }
}