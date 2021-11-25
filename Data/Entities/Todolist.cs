using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Taskmanager.Data.Entities
{
    [Table("TODOLISTS")]
    public partial class Todolist
    {
        public Todolist()
        {
            Todoitems = new HashSet<Todoitem>();
        }

        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Required]
        [Column("TITLE")]
        public string Title { get; set; }
        [Required]
        [Column("CREATIONDATE")]
        public string Creationdate { get; set; }
        [Column("USERID")]
        public long Userid { get; set; }

        [ForeignKey(nameof(Userid))]
        [InverseProperty("Todolists")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Todoitem.Todolist))]
        public virtual ICollection<Todoitem> Todoitems { get; set; }
    }
}
