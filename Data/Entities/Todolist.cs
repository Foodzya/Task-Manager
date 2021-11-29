using System.Collections.Generic;

namespace Taskmanager.Data.Entities
{
    public partial class Todolist
    {
        public Todolist()
        {
            Todoitems = new HashSet<Todoitem>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Creationdate { get; set; }
        public long Userid { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Todoitem> Todoitems { get; set; }
    }
}
