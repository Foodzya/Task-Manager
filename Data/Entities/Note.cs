using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Taskmanager.Data.Entities
{
    [Table("NOTES")]
    public partial class Note
    {
        public Note()
        {
            Todoitems = new HashSet<Todoitem>();
        }

        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Required]
        [Column("BODY")]
        public string Body { get; set; }

        [InverseProperty(nameof(Todoitem.Note))]
        public virtual ICollection<Todoitem> Todoitems { get; set; }
    }
}
