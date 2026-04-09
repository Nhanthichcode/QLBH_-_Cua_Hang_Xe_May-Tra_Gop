using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnBanHang_cuahangxemay.NhatKyDangNhap
{

    public class LoginLog
    {
        public string? ThoiGian { get; set; }  // Lưu dưới dạng string để giữ nguyên format
        public string? TenDangNhap { get; set; }
        public string? IP { get; set; }
        public string? LyDo { get; set; }
    }
}
