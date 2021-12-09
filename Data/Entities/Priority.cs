using System.Collections.Generic;

namespace Taskmanager.Data.Entities
{
    public partial class Priority
    {
        public Priority()
        {
            TodoItems = new HashSet<TodoItem>();
        }

        public long Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<TodoItem> TodoItems { get; set; }
    }
}
