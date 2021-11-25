using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Taskmanager.Data.Entities
{
    [Table("TODOITEMS")]
    public partial class Todoitem
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Required]
        [Column("TITLE")]
        public string Title { get; set; }
        [Column("ISFINISHED", TypeName = "TINYINT")]
        public long Isfinished { get; set; }
        [Required]
        [Column("DEADLINEDATE")]
        public string Deadlinedate { get; set; }
        [Column("PRIORITYID")]
        public long Priorityid { get; set; }
        [Column("NOTEID")]
        public long Noteid { get; set; }
        [Column("TODOLISTID")]
        public long Todolistid { get; set; }

        [ForeignKey(nameof(Noteid))]
        [InverseProperty("Todoitems")]
        public virtual Note Note { get; set; }
        [ForeignKey(nameof(Priorityid))]
        [InverseProperty("Todoitems")]
        public virtual Priority Priority { get; set; }
        [ForeignKey(nameof(Todolistid))]
        [InverseProperty("Todoitems")]
        public virtual Todolist Todolist { get; set; }
    }
}
