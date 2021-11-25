using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Taskmanager.Data.Entities
{
    [Table("PRIORITIES")]
    [Index(nameof(Title), IsUnique = true)]
    public partial class Priority
    {
        public Priority()
        {
            Todoitems = new HashSet<Todoitem>();
        }

        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Required]
        [Column("TITLE")]
        public string Title { get; set; }

        [InverseProperty(nameof(Todoitem.Priority))]
        public virtual ICollection<Todoitem> Todoitems { get; set; }
    }
}
