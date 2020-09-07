using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolLife.Models
{
    public partial class ManagementContext : DbContext
    {
        public ManagementContext()
        {
        }

        public ManagementContext(DbContextOptions<ManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=Management;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasKey(e => e.RollNo)
                    .HasName("PK__Attendan__7886D5A0EDDEA1E8");

                entity.Property(e => e.RollNo).ValueGeneratedNever();

                entity.Property(e => e.Attendance1)
                    .IsRequired()
                    .HasColumnName("Attendance")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.Class)
                    .HasName("PK__Students__E81871BD1890FBC6");

                entity.Property(e => e.Class).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.RollNoNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.RollNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inv_RollNo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
