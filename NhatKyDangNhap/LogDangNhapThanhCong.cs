using DoAnBanHang_cuahangxemay.Data_Table;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnBanHang_cuahangxemay.NhatKyDangNhap
{
    public class LogDangNhapThanhCong
    {
        public int LogID { get; set; }
        public int? NhanVienID { get; set; }
        public DateTime? TimeLogIn { get; set; }
        public DateTime? TimeLogOut { get; set; }
        public string? IP { get; set; }

        public virtual NhanVien NhanVien{ get; set; } = null!;
    }
    [NotMapped]
    public class DanhSach_LogDangNhapThanhCong
    {
        public int LogID { get; set; }
        public int? NhanVienID { get; set; }
        public string? TenNhanVien { get; set; }
        public DateTime? TimeLogIn { get; set; }
        public DateTime? TimeLogOut { get; set; }
        public string? IP { get; set; }
    }
}
