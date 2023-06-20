using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NEAPINE.Models
{
    public partial class quanlyhoadonContext : DbContext
    {
        public quanlyhoadonContext()
        {
        }

        public quanlyhoadonContext(DbContextOptions<quanlyhoadonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitiethoadon> Chitiethoadons { get; set; }
        public virtual DbSet<Hanghoa> Hanghoas { get; set; }
        public virtual DbSet<Hoadon> Hoadons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DUY2505\\MSSQLSERVER01;Database=quanlyhoadon;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Chitiethoadon>(entity =>
            {
                entity.HasKey(e => new { e.Sohd, e.Mahang });

                entity.ToTable("chitiethoadon");

                entity.HasIndex(e => e.Mahang, "IX_chitiethoadon_mahang");

                entity.Property(e => e.Sohd)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sohd");

                entity.Property(e => e.Mahang)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("mahang");

                entity.Property(e => e.Dongia).HasColumnName("dongia");

                entity.Property(e => e.Soluong).HasColumnName("soluong");

                entity.HasOne(d => d.MahangNavigation)
                    .WithMany(p => p.Chitiethoadons)
                    .HasForeignKey(d => d.Mahang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_chitiethoadon_hanghoa");

                entity.HasOne(d => d.SohdNavigation)
                    .WithMany(p => p.Chitiethoadons)
                    .HasForeignKey(d => d.Sohd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_chitiethoadon_hoadon");
            });

            modelBuilder.Entity<Hanghoa>(entity =>
            {
                entity.HasKey(e => e.Mahang);

                entity.ToTable("hanghoa");

                entity.Property(e => e.Mahang)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("mahang");

                entity.Property(e => e.Dongia).HasColumnName("dongia");

                entity.Property(e => e.Dvt)
                    .HasMaxLength(50)
                    .HasColumnName("dvt");

                entity.Property(e => e.Tenhang)
                    .HasMaxLength(50)
                    .HasColumnName("tenhang");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.Sohd);

                entity.ToTable("hoadon");

                entity.Property(e => e.Sohd)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sohd");

                entity.Property(e => e.Ngaylaphd)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaylaphd");

                entity.Property(e => e.Tenkh)
                    .HasMaxLength(50)
                    .HasColumnName("tenkh");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
