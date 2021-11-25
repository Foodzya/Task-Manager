using Microsoft.EntityFrameworkCore;
using Taskmanager.Data.Entities;

#nullable disable

namespace Taskmanager.Data.Context
{
    public partial class TaskManagerContext : DbContext
    {
        public TaskManagerContext()
        {
        }

        public TaskManagerContext(DbContextOptions<TaskManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }
        public virtual DbSet<Todoitem> Todoitems { get; set; }
        public virtual DbSet<Todolist> Todolists { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todoitem>(entity =>
            {
                entity.HasOne(d => d.Note)
                    .WithMany(p => p.Todoitems)
                    .HasForeignKey(d => d.Noteid)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Priority)
                    .WithMany(p => p.Todoitems)
                    .HasForeignKey(d => d.Priorityid)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
