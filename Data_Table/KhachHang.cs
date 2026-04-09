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
    public class KhachHang
    {
        public int KhachHangID { get; set; }
        public int KhuVucID { get; set; }
        public string HoVaTen { get; set; }
        public int GioiTinh { get; set; }
        public DateTime? NgaySinh {  get; set; }
        public string? CCCD { get; set; }
        public DateTime? NgayCapCCCD { get; set; }
        public string? NoiCapCCCD { get; set; }
        public string? DienThoai { get; set; }
        public string? Email { get; set; }
        public string? DiaChiThuongTru { get; set; }
        public string? DiaChiLienHe { get; set; }
        public string? NgheNghiep { get; set; }
        public string? NoiLamViec { get; set; }
        public decimal? ThuNhap { get; set; }
        public string? STK_NganHang { get; set; }
        public string? TenNganHang { get; set; }
        public int? CreditScore { get; set; } = 0;
        public string? AnhChanDung { get; set; } 
        public decimal HanMucTinDung { get; set; } = 0;

        public virtual KhuVuc KhuVuc { get; set; } = null!;
        public virtual ObservableCollectionListSource<HoaDon> HoaDon { get; } = new();
    }
}
