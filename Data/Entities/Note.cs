using System.Collections.Generic;

namespace Taskmanager.Data.Entities
{
    public partial class Note
    {
        public Note()
        {
            Todoitems = new HashSet<Todoitem>();
        }

        public long Id { get; set; }
        public string Body { get; set; }
        public long Todoitemid { get; set; }

        public virtual Todoitem Todoitem { get; set; }
        public virtual ICollection<Todoitem> Todoitems { get; set; }
    }
}
