using Microsoft.EntityFrameworkCore;
using Taskmanager.Data.Entities;

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
        public virtual DbSet<TodoItem> TodoItems { get; set; }
        public virtual DbSet<TodoList> TodoLists { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Name=ConnectionStrings:TodolistDatabase");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("integer");

                entity.Property(e => e.Body).IsRequired();

                entity.HasOne(d => d.TodoItem)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.TodoItemId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Priority>(entity =>
            {
                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<TodoItem>(entity =>
            {
                entity.Property(e => e.IsFinished).HasColumnType("TINYINT");

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Note)
                    .WithMany(p => p.TodoItems)
                    .HasForeignKey(d => d.NoteId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Priority)
                    .WithMany(p => p.TodoItems)
                    .HasForeignKey(d => d.PriorityId);

                entity.HasOne(d => d.TodoList)
                    .WithMany(p => p.TodoItems)
                    .HasForeignKey(d => d.TodoListId);
            });

            modelBuilder.Entity<TodoList>(entity =>
            {
                entity.Property(e => e.CreationDate).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TodoLists)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "IX_Users_Email")
                    .IsUnique();

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Username).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
