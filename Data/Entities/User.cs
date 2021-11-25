using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Taskmanager.Data.Entities
{
    [Table("USERS")]
    [Index(nameof(Email), IsUnique = true)]
    public partial class User
    {
        public User()
        {
            Todolists = new HashSet<Todolist>();
        }

        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Required]
        [Column("USERNAME")]
        public string Username { get; set; }
        [Required]
        [Column("EMAIL")]
        public string Email { get; set; }
        [Required]
        [Column("PASSWORD")]
        public string Password { get; set; }

        [InverseProperty(nameof(Todolist.User))]
        public virtual ICollection<Todolist> Todolists { get; set; }
    }
}
