using System.Collections.Generic;

namespace Taskmanager.Data.Entities
{
    public partial class Todoitem
    {
        public Todoitem()
        {
            Notes = new HashSet<Note>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public long Isfinished { get; set; }
        public string Deadlinedate { get; set; }
        public long? Priorityid { get; set; }
        public long? Noteid { get; set; }
        public long Todolistid { get; set; }

        public virtual Note Note { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual Todolist Todolist { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
