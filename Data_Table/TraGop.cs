using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnBanHang_cuahangxemay.Data_Table
{
    public class TraGop
    {
        public int TraGopID { get; set; }
        public int HoaDonID { get; set; }
        public int SoKyHan { get; set; } // Tổng số kỳ hạn
        public int KyTra { get; set; } // Kỳ trả hiện tại
        public decimal laiSuat { get; set; }
        public decimal SoTienGoc { get; set; }
        public decimal SoTienLai { get; set; }
        public decimal SoTienConLai { get; set; } // Thêm trường này
        public DateTime NgayDenHan { get; set; } // Thêm ngày đến hạn
        public string? TrangThai { get; set; }
        public DateTime? NgayThanhToan { get; set; } // Thêm ngày đến hạn
        public virtual HoaDon HoaDon { get; set; } = null!;
    }
    [NotMapped]
    public class DanhSachTraGop
    {
        public int TraGopID { get; set; }
        public int HoaDonID { get; set; }
        public int KhachHangID { get; set; }
        public string HoVaTen { get; set; }
        public int SoKyHan { get; set; } // Tổng số kỳ hạn
        public int KyTra { get; set; } // Kỳ trả hiện tại
        public decimal laiSuat { get; set; }
        public decimal SoTienGoc { get; set; }
        public decimal SoTienLai { get; set; }
        public decimal soTienCanDong { get; set; } // Số tiền cần đóng
        public decimal SoTienConLai { get; set; } // Thêm trường này
        public DateTime NgayDenHan { get; set; } // Thêm ngày đến hạn
        public string? GhiChuHoaDon { get; set; }
        public string? TrangThaiTraGop{ get; set; }
        public string? TrangThai { get; set; }
        public int TrangThaiTraGopValue
        {
            get => (int)Enum.Parse(typeof(enum_ThongTin.enum_TrangThaiThanhToan), TrangThai);
            set => TrangThai = ((enum_ThongTin.enum_TrangThaiThanhToan)value).ToString();
        }
        public string TrangThaiTraGopVietNamenamese
        {
            get
            {
                if (Enum.TryParse(typeof(enum_ThongTin.enum_TrangThaiThanhToan), TrangThai, out var enumValue))
                {
                    return ((enum_ThongTin.enum_TrangThaiThanhToan)enumValue).GetDescription(); // Sử dụng GetDescription() để lấy mô tả
                }
                return TrangThai; // Nếu không chuyển đổi được thì trả về giá trị gốc
            }
        }
        public int TrangThaiValue
        {
            get => (int)Enum.Parse(typeof(enum_ThongTin.enum_HoaDon), TrangThaiTraGop);
            set => TrangThaiTraGop = ((enum_ThongTin.enum_HoaDon)value).ToString();
        }
        public string TrangThaiVietnamese
        {
            get
            {
                if (Enum.TryParse(typeof(enum_ThongTin.enum_HoaDon), TrangThaiTraGop, out var enumValue))
                {
                    return ((enum_ThongTin.enum_HoaDon)enumValue).GetDescription(); // Sử dụng GetDescription() để lấy mô tả
                }
                return TrangThaiTraGop; // Nếu không chuyển đổi được thì trả về giá trị gốc
            }
        }
        public DateTime? NgayThanhToan { get; set; } // Thêm ngày đến hạn
        public string DisplayText { get; set; }
    }
}
