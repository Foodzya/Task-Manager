using System.Collections.Generic;

namespace Taskmanager.Data.Entities
{
    public partial class User
    {
        public User()
        {
            Todolists = new HashSet<Todolist>();
        }

        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Todolist> Todolists { get; set; }
    }
}
