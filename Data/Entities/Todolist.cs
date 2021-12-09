using System.Collections.Generic;

namespace Taskmanager.Data.Entities
{
    public partial class TodoList
    {
        public TodoList()
        {
            TodoItems = new HashSet<TodoItem>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string CreationDate { get; set; }
        public long UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<TodoItem> TodoItems { get; set; }
    }
}
