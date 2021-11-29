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
                entity.ToTable("NOTES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasColumnName("BODY");
            });

            modelBuilder.Entity<Priority>(entity =>
            {
                entity.ToTable("PRIORITIES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("TITLE");
            });

            modelBuilder.Entity<Todoitem>(entity =>
            {
                entity.ToTable("TODOITEMS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Deadlinedate).HasColumnName("DEADLINEDATE");

                entity.Property(e => e.Isfinished)
                    .HasColumnType("TINYINT")
                    .HasColumnName("ISFINISHED");

                entity.Property(e => e.Noteid).HasColumnName("NOTEID");

                entity.Property(e => e.Priorityid).HasColumnName("PRIORITYID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("TITLE");

                entity.Property(e => e.Todolistid).HasColumnName("TODOLISTID");

                entity.HasOne(d => d.Note)
                    .WithMany(p => p.Todoitems)
                    .HasForeignKey(d => d.Noteid)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Priority)
                    .WithMany(p => p.Todoitems)
                    .HasForeignKey(d => d.Priorityid);

                entity.HasOne(d => d.Todolist)
                    .WithMany(p => p.Todoitems)
                    .HasForeignKey(d => d.Todolistid);
            });

            modelBuilder.Entity<Todolist>(entity =>
            {
                entity.ToTable("TODOLISTS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Creationdate)
                    .IsRequired()
                    .HasColumnName("CREATIONDATE");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("TITLE");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Todolists)
                    .HasForeignKey(d => d.Userid);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.HasIndex(e => e.Email, "IX_USERS_EMAIL")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("USERNAME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
