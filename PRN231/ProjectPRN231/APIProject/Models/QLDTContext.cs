using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIProject.Models
{
    public partial class QLDTContext : DbContext
    {
        public QLDTContext()
        {
        }

        public QLDTContext(DbContextOptions<QLDTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DeTai> DeTais { get; set; } = null!;
        public virtual DbSet<GiangVien> GiangViens { get; set; } = null!;
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; } = null!;
        public virtual DbSet<SinhVien> SinhViens { get; set; } = null!;
        public virtual DbSet<SinhVienDangKyDeTai> SinhVienDangKyDeTais { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =localhost; database = QLDT;uid=sa;pwd=sa;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeTai>(entity =>
            {
                entity.HasKey(e => e.IdDeTai)
                    .HasName("PK__De_tai__ED6A0B2D7D6FA83F");

                entity.ToTable("De_tai");

                entity.Property(e => e.IdDeTai).HasColumnName("id_de_tai");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.IdGiangVien).HasColumnName("id_giang_vien");

                entity.Property(e => e.IdSinhVien).HasColumnName("id_sinh_vien");

                entity.Property(e => e.MoTa).HasColumnName("mo_ta");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.TenDeTai)
                    .HasMaxLength(255)
                    .HasColumnName("ten_de_tai");

                entity.HasOne(d => d.IdGiangVienNavigation)
                    .WithMany(p => p.DeTais)
                    .HasForeignKey(d => d.IdGiangVien)
                    .HasConstraintName("FK_De_tai_Giang_vien");

                entity.HasOne(d => d.IdSinhVienNavigation)
                    .WithMany(p => p.DeTais)
                    .HasForeignKey(d => d.IdSinhVien)
                    .HasConstraintName("FK_De_tai_Sinh_vien");
            });

            modelBuilder.Entity<GiangVien>(entity =>
            {
                entity.HasKey(e => e.IdGiangVien)
                    .HasName("PK__Giang_vi__2DBD5DEC40B2D30E");

                entity.ToTable("Giang_vien");

                entity.Property(e => e.IdGiangVien).HasColumnName("id_giang_vien");

                entity.Property(e => e.ChucVu)
                    .HasMaxLength(50)
                    .HasColumnName("chuc_vu");

                entity.Property(e => e.IdNguoiDung).HasColumnName("id_nguoi_dung");

                entity.Property(e => e.Khoa)
                    .HasMaxLength(50)
                    .HasColumnName("khoa");

                entity.Property(e => e.Ten)
                    .HasMaxLength(50)
                    .HasColumnName("ten");

                entity.HasOne(d => d.IdNguoiDungNavigation)
                    .WithMany(p => p.GiangViens)
                    .HasForeignKey(d => d.IdNguoiDung)
                    .HasConstraintName("FK_Giang_vien_Nguoi_dung");
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasKey(e => e.IdNguoiDung)
                    .HasName("PK__Nguoi_du__75D6A11EB6E3F5B5");

                entity.ToTable("Nguoi_dung");

                entity.HasIndex(e => e.TenNguoiDung, "UQ__Nguoi_du__073A9BE60C8AFC44")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Nguoi_du__AB6E6164213F5E9C")
                    .IsUnique();

                entity.Property(e => e.IdNguoiDung).HasColumnName("id_nguoi_dung");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(255)
                    .HasColumnName("mat_khau");

                entity.Property(e => e.TenNguoiDung)
                    .HasMaxLength(50)
                    .HasColumnName("ten_nguoi_dung");

                entity.Property(e => e.VaiTro).HasColumnName("vai_tro");
            });

            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.HasKey(e => e.IdSinhVien)
                    .HasName("PK__Sinh_vie__66ECB4351C32C80A");

                entity.ToTable("Sinh_vien");

                entity.Property(e => e.IdSinhVien).HasColumnName("id_sinh_vien");

                entity.Property(e => e.IdNguoiDung).HasColumnName("id_nguoi_dung");

                entity.Property(e => e.Khoa)
                    .HasMaxLength(50)
                    .HasColumnName("khoa");

                entity.Property(e => e.Lop)
                    .HasMaxLength(20)
                    .HasColumnName("lop");

                entity.Property(e => e.Ten).HasMaxLength(100);

                entity.HasOne(d => d.IdNguoiDungNavigation)
                    .WithMany(p => p.SinhViens)
                    .HasForeignKey(d => d.IdNguoiDung)
                    .HasConstraintName("FK__Sinh_vien__id_ng__2C3393D0");
            });

            modelBuilder.Entity<SinhVienDangKyDeTai>(entity =>
            {
                entity.HasKey(e => e.IdDangKy)
                    .HasName("PK__Sinh_vie__79E6435D217CD091");

                entity.ToTable("Sinh_vien_Dang_ky_De_tai");

                entity.Property(e => e.IdDangKy).HasColumnName("id_dang_ky");

                entity.Property(e => e.Diem).HasColumnName("diem");

                entity.Property(e => e.GhiChu).HasColumnName("ghi_chu");

                entity.Property(e => e.IdDeTai).HasColumnName("id_de_tai");

                entity.Property(e => e.IdSinhVien).HasColumnName("id_sinh_vien");

                entity.HasOne(d => d.IdDeTaiNavigation)
                    .WithMany(p => p.SinhVienDangKyDeTais)
                    .HasForeignKey(d => d.IdDeTai)
                    .HasConstraintName("FK__Sinh_vien__id_de__32E0915F");

                entity.HasOne(d => d.IdSinhVienNavigation)
                    .WithMany(p => p.SinhVienDangKyDeTais)
                    .HasForeignKey(d => d.IdSinhVien)
                    .HasConstraintName("FK__Sinh_vien__id_si__31EC6D26");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
