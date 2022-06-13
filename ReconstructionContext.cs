using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Реконструирование
{
    public partial class ReconstructionContext : DbContext
    {
        public ReconstructionContext()
        {
        }

        public ReconstructionContext(DbContextOptions<ReconstructionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<TaskStatus> TaskStatuses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=Reconstruction;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.CreatingUserId).HasColumnName("CreatingUserID");

                entity.Property(e => e.TaskStatusId).HasColumnName("TaskStatusID");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.CreatingUser)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.CreatingUserId)
                    .HasConstraintName("FK__Task__CreatingUs__3C69FB99");

                entity.HasOne(d => d.TaskStatus)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TaskStatusId)
                    .HasConstraintName("FK__Task__TaskStatus__3B75D760");
            });

            modelBuilder.Entity<TaskStatus>(entity =>
            {
                entity.ToTable("TaskStatus");

                entity.Property(e => e.TaskStatusId).HasColumnName("TaskStatusID");

                entity.Property(e => e.StatusType).HasMaxLength(15);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Login, "UQ__User__5E55825BD4D14231")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Login).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(25);

                entity.Property(e => e.Password).HasMaxLength(30);

                entity.Property(e => e.Patronymic).HasMaxLength(25);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.Property(e => e.Surname).HasMaxLength(25);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
