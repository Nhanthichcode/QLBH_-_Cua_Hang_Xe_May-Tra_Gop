using DoAnBanHang_cuahangxemay.NhatKyDangNhap;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnBanHang_cuahangxemay.Data_Table
{
    public class NhanVien
    {
        public int NhanVienID { get; set; }
        public int? KhuVucID { get; set; }
        public string HoVaTen { get; set; }
        public string? DienThoai { get; set; }
        public string? DiaChi { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public bool QuyenHan { get; set; }
        //public int 

        public virtual KhuVuc KhuVuc { get; set; } = null!;
        public virtual ObservableCollectionListSource<LogDangNhapThanhCong> LogDangNhapThanhCong { get; } = new();
        public virtual ObservableCollectionListSource<HoaDon> HoaDon { get; } = new();
    }
}
