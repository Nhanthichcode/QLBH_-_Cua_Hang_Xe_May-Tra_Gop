using DoAnBanHang_cuahangxemay;
using DoAnBanHang_cuahangxemay.NhatKyDangNhap;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnBanHang_cuahangxemay.Data_Table
{
    public class AppDbContext : DbContext
    {
        public DbSet<KhuVuc> KhuVuc { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<HangSanXuat> HangSanXuat { get; set; }
        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<TraGop> TraGop { get; set; }
        public DbSet<ThanhToan> ThanhToan { get; set; }
        public DbSet<HoaDon_ChiTiet> HoaDon_ChiTiet { get; set; }
        public DbSet<LogDangNhapThanhCong> LogDangNhapThanhCongs { get; set; }

        private readonly IConfiguration _configuration;


        public AppDbContext() : base(new DbContextOptions<AppDbContext>()) { }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình khóa chính
            modelBuilder.Entity<KhuVuc>().HasKey(h => h.KhuVucID);
            modelBuilder.Entity<SanPham>().HasKey(s => s.SanPhamID);
            modelBuilder.Entity<HangSanXuat>().HasKey(h => h.HangSanXuatID);
            modelBuilder.Entity<NhanVien>().HasKey(n => n.NhanVienID);
            modelBuilder.Entity<KhachHang>().HasKey(k => k.KhachHangID);
            modelBuilder.Entity<HoaDon>().HasKey(h => h.HoaDonID);
            modelBuilder.Entity<TraGop>().HasKey(t => t.TraGopID);
            modelBuilder.Entity<ThanhToan>().HasKey(t => t.ThanhToanID);
            modelBuilder.Entity<HoaDon_ChiTiet>().HasKey(h => h.HoaDonChiTietID);
            modelBuilder.Entity<LogDangNhapThanhCong>().HasKey(h => h.LogID);

            // Cấu hình khóa ngoại và quan hệ

            //8 . KhachHang - KhuVuc
            // 1. HoaDon - KhachHang
            modelBuilder.Entity<HoaDon>()
                .HasOne(h => h.KhachHang)
                .WithMany(k => k.HoaDon)
                .HasForeignKey(h => h.KhachHangID);

            // 2. HoaDon - NhanVien
            modelBuilder.Entity<HoaDon>()
                .HasOne(h => h.NhanVien)
                .WithMany(n => n.HoaDon)
                .HasForeignKey(h => h.NhanVienID);

            // 3. HoaDon_ChiTiet - HoaDon
            modelBuilder.Entity<HoaDon_ChiTiet>()
                .HasOne(h => h.HoaDon)
                .WithMany(h => h.HoaDon_ChiTiet)
                .HasForeignKey(h => h.HoaDonID);

            // 4. HoaDon_ChiTiet - SanPham
            modelBuilder.Entity<HoaDon_ChiTiet>()
                .HasOne(h => h.SanPham)
                .WithMany(s => s.HoaDon_ChiTiet)
                .HasForeignKey(h => h.SanPhamID);

            // 5. SanPham - HangSanXuat
            modelBuilder.Entity<SanPham>()
                .HasOne(s => s.HangSanXuat)
                .WithMany(h => h.SanPham)
                .HasForeignKey(s => s.HangSanXuatID);

            // 6. TraGop - HoaDon
            modelBuilder.Entity<TraGop>()
                .HasOne(t => t.HoaDon)
                .WithMany(h => h.TraGop)
                .HasForeignKey(t => t.HoaDonID);

            // 7. ThanhToan - HoaDon
            modelBuilder.Entity<ThanhToan>()
                .HasOne(t => t.HoaDon)
                .WithMany(h => h.ThanhToan)
                .HasForeignKey(t => t.HoaDonID);
            modelBuilder.Entity<KhachHang>()
                   .HasOne(t => t.KhuVuc)
                   .WithMany(h => h.KhachHang)
                   .HasForeignKey(t => t.KhuVucID);
                //9 . NhanVien - KhuVuc
           modelBuilder.Entity<NhanVien>()
               .HasOne(t => t.KhuVuc)
               .WithMany(h => h.NhanVien)
               .HasForeignKey(t => t.KhuVucID);
            //10 . LogDangNhap - NhanVien
            modelBuilder.Entity<LogDangNhapThanhCong>()
              .HasOne(t => t.NhanVien)
              .WithMany(h => h.LogDangNhapThanhCong)
              .HasForeignKey(t => t.NhanVienID);


        }
    }
}
