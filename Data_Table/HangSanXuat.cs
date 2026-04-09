using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnBanHang_cuahangxemay.Data_Table
{
    public class HangSanXuat
    {
        public int HangSanXuatID { get; set; }
        public string? TenHangSanXuat { get; set; }
        public string? TrangThai { get; set; }
        public virtual ObservableCollectionListSource<SanPham> SanPham { get; } = new();
    }
    [NotMapped]
    public class DanhSachHangSanXuat
    {
        public int HangSanXuatID { get; set; }
        public string? TenHangSanXuat { get; set; }
        public string? TrangThai { get; set; }
        public string TrangThaiVietnamese
        {
            get
            {
                if (Enum.TryParse(typeof(enum_ThongTin.enum_TrangThai_HSX), TrangThai, out var enumValue))
                {
                    return ((enum_ThongTin.enum_TrangThai_HSX)enumValue).GetDescription(); // Sử dụng GetDescription() để lấy mô tả
                }
                return TrangThai; // Nếu không chuyển đổi được thì trả về giá trị gốc
            }
        }
        public int TrangThaiValue
        {
            get => (int)Enum.Parse(typeof(enum_ThongTin.enum_TrangThai_HSX), TrangThai);
            set => TrangThai = ((enum_ThongTin.enum_TrangThai_HSX)value).ToString();
        }
    }
}
