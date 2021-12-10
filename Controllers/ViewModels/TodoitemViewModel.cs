using System;
using Taskmanager.Data.Entities;

namespace Taskmanager.Controllers.ViewModels
{
    public class TodoItemViewModel
    {
        public string Title { get; set; }
        public bool IsFinished { get; set; }
        public DateTime DeadlineDate { get; set; }
        public long? PriorityId { get; set; }

        public static TodoItemViewModel MapTodoItem(TodoItem todoItem)
        {
            if (todoItem != null)
            {
                return new TodoItemViewModel
                { 
                    Title = todoItem.Title, 
                    IsFinished = todoItem.IsFinished == 1, 
                    DeadlineDate = Convert.ToDateTime(todoItem.DeadlineDate), 
                    PriorityId = todoItem.PriorityId};
            }

            throw new NullReferenceException("TodoItem was null");
        }
    }
}