using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class TicketSystemnewContext : DbContext
    {
        public TicketSystemnewContext()
        {
        }

        public TicketSystemnewContext(DbContextOptions<TicketSystemnewContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<EscalationProcess> EscalationProcesses { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserTicketUpdate> UserTicketUpdates { get; set; } = null!;

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=JURICA-SCHšLE;Database=TicketSystem(new);Trusted_Connection=True;");
            }
        }
       */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<EscalationProcess>(entity =>
            {
                entity.ToTable("escalation_process");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TicketId).HasColumnName("ticket_id");

                entity.Property(e => e.TriggerReason)
                    .HasMaxLength(255)
                    .HasColumnName("trigger_reason");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.EscalationProcesses)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_escalation_ticket");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("ticket");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(6)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Priority)
                    .HasMaxLength(255)
                    .HasColumnName("priority");

                entity.Property(e => e.State)
                    .HasMaxLength(255)
                    .HasColumnName("state");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ticket_category");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ticket_user");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Roles).HasColumnName("roles");

                entity.Property(e => e.TelephoneNumber)
                    .HasMaxLength(255)
                    .HasColumnName("telephone_number");
            });

            modelBuilder.Entity<UserTicketUpdate>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("user_ticket_update");

                entity.Property(e => e.ChangedColumn)
                    .HasMaxLength(255)
                    .HasColumnName("changed_column");

                entity.Property(e => e.Reason)
                    .HasMaxLength(255)
                    .HasColumnName("reason");

                entity.Property(e => e.TicketId).HasColumnName("ticket_id");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(6)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Ticket)
                    .WithMany()
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_update_ticket");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_update_user");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
