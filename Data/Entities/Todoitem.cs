using System.Collections.Generic;

namespace Taskmanager.Data.Entities
{
    public partial class TodoItem
    {
        public TodoItem()
        {
            Notes = new HashSet<Note>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public long IsFinished { get; set; }
        public string DeadlineDate { get; set; }
        public long? PriorityId { get; set; }
        public long? NoteId { get; set; }
        public long TodoListId { get; set; }

        public virtual Note Note { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual TodoList TodoList { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
