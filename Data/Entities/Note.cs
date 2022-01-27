using System.Collections.Generic;

namespace Taskmanager.Data.Entities
{
    public partial class Note
    {
        public Note()
        {
            TodoItems = new HashSet<TodoItem>();
        }

        public long Id { get; set; }
        public string Body { get; set; }
        public long TodoItemId { get; set; }

        public virtual TodoItem TodoItem { get; set; }
        public virtual ICollection<TodoItem> TodoItems { get; set; }
    }
}
