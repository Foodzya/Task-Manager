using System.Collections.Generic;

namespace Taskmanager.Data.Entities
{
    public partial class Priority
    {
        public Priority()
        {
            Todoitems = new HashSet<Todoitem>();
        }

        public long Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Todoitem> Todoitems { get; set; }
    }
}
