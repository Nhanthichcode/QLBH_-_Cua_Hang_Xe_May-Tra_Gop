using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnBanHang_cuahangxemay.Data_Table
{
    public class HoaDon
    {
        public int HoaDonID { get; set; }
        public int IsDeleted { get; set; } 
        public int KhachHangID { get; set; }
        public int NhanVienID { get; set; }
        public DateTime NgayLap {  get; set; }
        public string? PhuongThucThanhToan { get; set; }
        public string? TrangThai { get; set; }
        public string? GhiChuHoaDon {  get; set; }
        public virtual KhachHang KhachHang { get; set; } = null!;
        public virtual NhanVien NhanVien { get; set; } = null!;
        public virtual ObservableCollectionListSource<TraGop> TraGop { get; } = new();
        public virtual ObservableCollectionListSource<ThanhToan> ThanhToan { get; } = new();
        public virtual ObservableCollectionListSource<HoaDon_ChiTiet> HoaDon_ChiTiet { get; } = new();
    }

    [NotMapped]
    public class DanhSachHoaDon
    {
        public int HoaDonID { get; set; }
        public int IsDeleted { get; set; }
        public int KhachHangID { get; set; }
        public string? TenKhachHang { get; set; }
        public int NhanVienID { get; set; }
        public string? TenNhanVien { get; set; }
        public decimal TongTien { get; set; }
        public DateTime? NgayLap { get; set; }
        public string? PhuongThucThanhToan { get; set; }
        public string? TrangThai { get; set; }
        public int TrangThaiValue
        {
            get => (int)Enum.Parse(typeof(enum_ThongTin.enum_HoaDon), TrangThai);
            set => TrangThai = ((enum_ThongTin.enum_HoaDon)value).ToString();
        }
        public string TrangThaiVietnamese
        {
            get
            {
                if (Enum.TryParse(typeof(enum_ThongTin.enum_HoaDon), TrangThai, out var enumValue))
                {
                    return ((enum_ThongTin.enum_HoaDon)enumValue).GetDescription(); // Sử dụng GetDescription() để lấy mô tả
                }
                return TrangThai; // Nếu không chuyển đổi được thì trả về giá trị gốc
            }
        }
        public int PhuongThucThanhToanValue
        {
            get => (int)Enum.Parse(typeof(enum_ThongTin.enum_PhuongThucThanhToan), PhuongThucThanhToan);
            set => PhuongThucThanhToan = ((enum_ThongTin.enum_PhuongThucThanhToan)value).ToString();
        }
        public string PhuongThucThanhToanVietnamese
        {
            get
            {
                if (Enum.TryParse(typeof(enum_ThongTin.enum_PhuongThucThanhToan), PhuongThucThanhToan, out var enumValue))
                {
                    return ((enum_ThongTin.enum_PhuongThucThanhToan)enumValue).GetDescription(); // Sử dụng GetDescription() để lấy mô tả
                }
                return PhuongThucThanhToan; // Nếu không chuyển đổi được thì trả về giá trị gốc
            }
        }
        public string? GhiChuHoaDon { get; set; }
    }
}
