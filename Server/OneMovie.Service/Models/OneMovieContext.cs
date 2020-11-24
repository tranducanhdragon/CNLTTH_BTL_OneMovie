using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OneMovie.Service.Models
{
    public partial class OneMovieContext : DbContext
    {
        public OneMovieContext()
        {
        }

        public OneMovieContext(DbContextOptions<OneMovieContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<BoPhim> BoPhims { get; set; }
        public virtual DbSet<DanhGium> DanhGia { get; set; }
        public virtual DbSet<DaoDien> DaoDiens { get; set; }
        public virtual DbSet<DienVien> DienViens { get; set; }
        public virtual DbSet<DienVienPhanPhim> DienVienPhanPhims { get; set; }
        public virtual DbSet<GoiVip> GoiVips { get; set; }
        public virtual DbSet<LichSuXem> LichSuXems { get; set; }
        public virtual DbSet<LuuPhim> LuuPhims { get; set; }
        public virtual DbSet<MuaVip> MuaVips { get; set; }
        public virtual DbSet<Nsx> Nsxes { get; set; }
        public virtual DbSet<NsxBoPhim> NsxBoPhims { get; set; }
        public virtual DbSet<PhanHoi> PhanHois { get; set; }
        public virtual DbSet<PhanPhim> PhanPhims { get; set; }
        public virtual DbSet<QuocGiaBoPhim> QuocGiaBoPhims { get; set; }
        public virtual DbSet<QuocGium> QuocGia { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }
        public virtual DbSet<TheLoaiBoPhim> TheLoaiBoPhims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=bo-dinh;Database=OneMoviewCH5;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BinhLuan>(entity =>
            {
                entity.HasKey(e => e.TaiKhoan);

                entity.ToTable("BinhLuan");

                entity.Property(e => e.TaiKhoan)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.ThoiGian)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.TaiKhoanNavigation)
                    .WithOne(p => p.BinhLuan)
                    .HasForeignKey<BinhLuan>(d => d.TaiKhoan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BinhLuan_TaiKhoan");
            });

            modelBuilder.Entity<BoPhim>(entity =>
            {
                entity.HasKey(e => e.MaBp);

                entity.ToTable("BoPhim");

                entity.Property(e => e.MaBp).HasColumnName("MaBP");

                entity.Property(e => e.MaDd).HasColumnName("MaDD");

                entity.Property(e => e.TenBp).HasColumnName("TenBP");

                entity.HasOne(d => d.MaDdNavigation)
                    .WithMany(p => p.BoPhims)
                    .HasForeignKey(d => d.MaDd)
                    .HasConstraintName("FK_BoPhim_DaoDien");
            });

            modelBuilder.Entity<DanhGium>(entity =>
            {
                entity.HasKey(e => e.TaiKhoan);

                entity.Property(e => e.TaiKhoan)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.MaPhim).HasMaxLength(255);

                entity.HasOne(d => d.MaPhimNavigation)
                    .WithMany(p => p.DanhGiaNavigation)
                    .HasForeignKey(d => d.MaPhim)
                    .HasConstraintName("FK_DanhGia_PhanPhim");

                entity.HasOne(d => d.TaiKhoanNavigation)
                    .WithOne(p => p.DanhGium)
                    .HasForeignKey<DanhGium>(d => d.TaiKhoan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DanhGia_TaiKhoan");
            });

            modelBuilder.Entity<DaoDien>(entity =>
            {
                entity.HasKey(e => e.MaDd);

                entity.ToTable("DaoDien");

                entity.Property(e => e.MaDd).HasColumnName("MaDD");

                entity.Property(e => e.TenDd)
                    .HasMaxLength(200)
                    .HasColumnName("TenDD");
            });

            modelBuilder.Entity<DienVien>(entity =>
            {
                entity.HasKey(e => e.MaDv);

                entity.ToTable("DienVien");

                entity.Property(e => e.MaDv).HasColumnName("MaDV");

                entity.Property(e => e.TenDv)
                    .HasMaxLength(200)
                    .HasColumnName("TenDV");
            });

            modelBuilder.Entity<DienVienPhanPhim>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DienVien_PhanPhim");

                entity.Property(e => e.MaDv).HasColumnName("MaDV");

                entity.Property(e => e.MaPp)
                    .HasMaxLength(255)
                    .HasColumnName("MaPP");

                entity.HasOne(d => d.MaDvNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaDv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DienVien_PhanPhim_DienVien");

                entity.HasOne(d => d.MaPpNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaPp)
                    .HasConstraintName("FK_DienVien_PhanPhim_PhanPhim");
            });

            modelBuilder.Entity<GoiVip>(entity =>
            {
                entity.HasKey(e => e.Idgoi);

                entity.ToTable("GoiVip");

                entity.Property(e => e.Idgoi)
                    .ValueGeneratedNever()
                    .HasColumnName("IDGoi");

                entity.Property(e => e.TenGoi).HasMaxLength(200);
            });

            modelBuilder.Entity<LichSuXem>(entity =>
            {
                entity.HasKey(e => e.TaiKhoan);

                entity.ToTable("LichSuXem");

                entity.Property(e => e.TaiKhoan)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.MaPhim).HasMaxLength(255);

                entity.Property(e => e.ThoiGian)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.MaPhimNavigation)
                    .WithMany(p => p.LichSuXems)
                    .HasForeignKey(d => d.MaPhim)
                    .HasConstraintName("FK_LichSuXem_PhanPhim");

                entity.HasOne(d => d.TaiKhoanNavigation)
                    .WithOne(p => p.LichSuXem)
                    .HasForeignKey<LichSuXem>(d => d.TaiKhoan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LichSuXem_TaiKhoan");
            });

            modelBuilder.Entity<LuuPhim>(entity =>
            {
                entity.HasKey(e => e.TaiKhoan);

                entity.ToTable("LuuPhim");

                entity.Property(e => e.TaiKhoan)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.MaPhim).HasMaxLength(255);

                entity.Property(e => e.ThoiGian)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.MaPhimNavigation)
                    .WithMany(p => p.LuuPhims)
                    .HasForeignKey(d => d.MaPhim)
                    .HasConstraintName("FK_LuuPhim_PhanPhim");

                entity.HasOne(d => d.TaiKhoanNavigation)
                    .WithOne(p => p.LuuPhim)
                    .HasForeignKey<LuuPhim>(d => d.TaiKhoan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LuuPhim_TaiKhoan");
            });

            modelBuilder.Entity<MuaVip>(entity =>
            {
                entity.HasKey(e => new {e.TaiKhoan, e.Idgoi });

                entity.ToTable("MuaVip");

                entity.Property(e => e.TaiKhoan)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Idgoi).HasColumnName("IDGoi");

                entity.Property(e => e.NgayMua)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdgoiNavigation)
                    .WithMany(p => p.MuaVips)
                    .HasForeignKey(d => d.Idgoi)
                    .HasConstraintName("FK_MuaVip_GoiVip");

                entity.HasOne(d => d.TaiKhoanNavigation)
                    .WithOne(p => p.MuaVip)
                    .HasForeignKey<MuaVip>(d => d.TaiKhoan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MuaVip_TaiKhoan");
            });

            modelBuilder.Entity<Nsx>(entity =>
            {
                entity.HasKey(e => e.MaNsx);

                entity.ToTable("NSX");

                entity.Property(e => e.MaNsx).HasColumnName("MaNSX");

                entity.Property(e => e.TenNsx)
                    .HasMaxLength(200)
                    .HasColumnName("TenNSX");
            });

            modelBuilder.Entity<NsxBoPhim>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("NSX_BoPhim");

                entity.Property(e => e.MaBp).HasColumnName("MaBP");

                entity.Property(e => e.MaNsx).HasColumnName("MaNSX");

                entity.HasOne(d => d.MaBpNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaBp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NSX_BoPhim_BoPhim");

                entity.HasOne(d => d.MaNsxNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaNsx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NSX_BoPhim_NSX");
            });

            modelBuilder.Entity<PhanHoi>(entity =>
            {
                entity.HasKey(e => e.TaiKhoan);

                entity.ToTable("PhanHoi");

                entity.Property(e => e.TaiKhoan)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.ThoiGian).HasColumnType("datetime");

                entity.HasOne(d => d.TaiKhoanNavigation)
                    .WithOne(p => p.PhanHoi)
                    .HasForeignKey<PhanHoi>(d => d.TaiKhoan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhanHoi_TaiKhoan");
            });

            modelBuilder.Entity<PhanPhim>(entity =>
            {
                entity.HasKey(e => e.MaPhim);

                entity.ToTable("PhanPhim");

                entity.Property(e => e.MaPhim).HasMaxLength(255);

                entity.Property(e => e.DanhGia).HasDefaultValueSql("((3))");

                entity.Property(e => e.LuotXem).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaBp).HasColumnName("MaBP");

                entity.Property(e => e.NamXb)
                    .HasColumnType("datetime")
                    .HasColumnName("NamXB");

                entity.Property(e => e.PhimVip).HasDefaultValueSql("((0))");

                entity.Property(e => e.Tap).HasDefaultValueSql("((1))");

                entity.Property(e => e.ThoiLuong).HasMaxLength(100);

                entity.HasOne(d => d.MaBpNavigation)
                    .WithMany(p => p.PhanPhims)
                    .HasForeignKey(d => d.MaBp)
                    .HasConstraintName("FK_PhanPhim_BoPhim");
            });

            modelBuilder.Entity<QuocGiaBoPhim>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("QuocGia_BoPhim");

                entity.Property(e => e.MaBp).HasColumnName("MaBP");

                entity.Property(e => e.MaQg).HasColumnName("MaQG");

                entity.HasOne(d => d.MaBpNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaBp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuocGia_BoPhim_BoPhim");

                entity.HasOne(d => d.MaQgNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaQg)
                    .HasConstraintName("FK_QuocGia_BoPhim_QuocGia");
            });

            modelBuilder.Entity<QuocGium>(entity =>
            {
                entity.HasKey(e => e.MaQg);

                entity.Property(e => e.MaQg).HasColumnName("MaQG");

                entity.Property(e => e.TenQg)
                    .HasMaxLength(200)
                    .HasColumnName("TenQG");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.TaiKhoan1)
                    .HasName("PK_TaiKhoanUser");

                entity.ToTable("TaiKhoan");

                entity.Property(e => e.TaiKhoan1)
                    .HasMaxLength(50)
                    .HasColumnName("TaiKhoan")
                    .IsFixedLength(true);

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.HoTen).HasMaxLength(150);

                entity.Property(e => e.LoaiTk).HasColumnName("LoaiTK");

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(50)
                    .HasColumnName("SDT")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TheLoai>(entity =>
            {
                entity.HasKey(e => e.MaTl);

                entity.ToTable("TheLoai");

                entity.Property(e => e.MaTl).HasColumnName("MaTL");

                entity.Property(e => e.TenTl)
                    .HasMaxLength(200)
                    .HasColumnName("TenTL");
            });

            modelBuilder.Entity<TheLoaiBoPhim>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TheLoai_BoPhim");

                entity.Property(e => e.MaBp).HasColumnName("MaBP");

                entity.Property(e => e.MaTl).HasColumnName("MaTL");

                entity.HasOne(d => d.MaBpNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaBp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TheLoai_BoPhim_BoPhim");

                entity.HasOne(d => d.MaTlNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaTl)
                    .HasConstraintName("FK_TheLoai_BoPhim_TheLoai");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
