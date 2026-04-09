using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnBanHang_cuahangxemay.Data_Table
{
    public class ThanhToan
    {
        public int ThanhToanID { get; set; }
        public int HoaDonID { get; set; }
        public decimal SoTienThanhToan { get; set; }
        public DateTime NgayLap { get; set; }
        public DateTime? NgayThanhToan { get; set; }
        public string? PhuongThucThanhToan { get; set; }
        public string? TrangThaiHoaDon { get; set; }
        public string? TrangThaiThanhToan { get; set; }
        public string? GhiChuHoaDon { get; set; }
        public virtual HoaDon HoaDon { get; set; } = null!;
    }
    [NotMapped]
    public class DanhSachThanhToan
    {
        public int ThanhToanID { get; set; }
        public int HoaDonID { get; set; }
        public int KhachHangID {  get; set; }
        public string TenKhachHang { get; set; }
        public int NhanVienID { get; set; }
        public string TenNhanVien { get; set; }
        public decimal SoTienThanhToan { get; set; }
        public string? PhuongThucThanhToan { get; set; }
        public DateTime NgayLap { get; set; }
        public DateTime? NgayThanhToan { get; set; }
        public string? GhiChuHoaDon { get; set; }
        public string? TrangThaiHoaDon { get; set; }
        public string? TrangThaiThanhToan { get; set; }
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
        // hóa đơn
        public int TrangThaiHoaDonValue
        {
            get => (int)Enum.Parse(typeof(enum_ThongTin.enum_HoaDon), TrangThaiHoaDon);
            set => TrangThaiHoaDon = ((enum_ThongTin.enum_HoaDon)value).ToString();
        }
        public string TrangThaiHoaDonVietnamese
        {
            get
            {
                if (Enum.TryParse(typeof(enum_ThongTin.enum_HoaDon), TrangThaiHoaDon, out var enumValue))
                {
                    return ((enum_ThongTin.enum_HoaDon)enumValue).GetDescription(); // Sử dụng GetDescription() để lấy mô tả
                }
                return TrangThaiHoaDon; // Nếu không chuyển đổi được thì trả về giá trị gốc
            }
        }
        public int TrangThaiThanhToanValue //thanh toán
        {
            get => (int)Enum.Parse(typeof(enum_ThongTin.enum_TrangThaiThanhToan), TrangThaiThanhToan);
            set => TrangThaiThanhToan = ((enum_ThongTin.enum_TrangThaiThanhToan)value).ToString();
        }
        public string TrangThaiThanhtoanVietnamese
        {
            get
            {
                if (Enum.TryParse(typeof(enum_ThongTin.enum_TrangThaiThanhToan), TrangThaiThanhToan, out var enumValue))
                {
                    return ((enum_ThongTin.enum_TrangThaiThanhToan)enumValue).GetDescription(); // Sử dụng GetDescription() để lấy mô tả
                }
                return TrangThaiThanhToan; // Nếu không chuyển đổi được thì trả về giá trị gốc
            }
        }
    }
}
