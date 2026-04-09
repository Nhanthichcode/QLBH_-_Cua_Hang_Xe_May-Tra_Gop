using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnBanHang_cuahangxemay.Data_Table
{
    public class KhuVuc
    {
        public int KhuVucID { get; set; }
        public string? TenKhuVuc { get; set; }
        public virtual ObservableCollectionListSource<NhanVien> NhanVien { get; } = new();
        public virtual ObservableCollectionListSource<KhachHang> KhachHang { get; } = new();
    }
}
