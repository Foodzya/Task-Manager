using System;
using Taskmanager.Data.Entities;

namespace Taskmanager.Controllers.ViewModels
{
    public class PriorityViewModel
    {
        public string Title { get; set; }

        public static PriorityViewModel MapPriority(Priority priority)
        {
            if (priority != null)
            {
                return new PriorityViewModel{ Title = priority.Title };
            }

            throw new NullReferenceException();
        }
    }
}