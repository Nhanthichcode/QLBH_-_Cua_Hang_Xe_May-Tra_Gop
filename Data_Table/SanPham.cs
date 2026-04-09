using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DoAnBanHang_cuahangxemay.Data_Table.enum_ThongTin;

namespace DoAnBanHang_cuahangxemay.Data_Table
{
    public class SanPham
    {
        public int SanPhamID { get; set; }
        public string? TenSanPham { get; set; }
        public int HangSanXuatID { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuongTon { get; set; }
        public int NamSX { get; set; }
        public string? MoTa { get; set; }
        public string? TrangThai { get; set; }
        public string? HinhAnh { get; set; }
        public virtual HangSanXuat HangSanXuat { get; set; } = null!;
        public virtual ObservableCollectionListSource<HoaDon_ChiTiet> HoaDon_ChiTiet { get; } = new();
    }
    [NotMapped]
    public class DanhSachSanPham
    {
        public int SanPhamID { get; set; }
        public int HangSanXuatID { get; set; }
        public string? TenHangSanXuat { get; set; }
        public string? TenSanPham { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuongTon { get; set; }
        public int NamSX { get; set; }
        public string MoTa { get; set; }
        public string? TrangThai { get; set; }
        public int TrangThaiValue
        {
            get => (int)Enum.Parse(typeof(enum_SanPham_TrangThai), TrangThai);
            set => TrangThai = ((enum_SanPham_TrangThai)value).ToString();
        }
        public string TrangThaiVietnamese
        {
            get
            {
                if (Enum.TryParse(typeof(enum_ThongTin.enum_SanPham_TrangThai), TrangThai, out var enumValue))
                {
                    return ((enum_ThongTin.enum_SanPham_TrangThai)enumValue).GetDescription(); // Sử dụng GetDescription() để lấy mô tả
                }
                return TrangThai; // Nếu không chuyển đổi được thì trả về giá trị gốc
            }
        }
        public string? HinhAnh { get; set; }

    }
}
