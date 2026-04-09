using DoAnBanHang_cuahangxemay.Data_Table;
using DoAnBanHang_cuahangxemay.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;
using System.Drawing;
using System.IO;

using static DoAnBanHang_cuahangxemay.Reports.DataSet_thongKe;

namespace DoAnBanHang_cuahangxemay.Reports
{
    public partial class Form_inHoaDon : Form
    {
        AppDbContext context = new AppDbContext();
        DataSet_thongKe.DanhSachHoaDon_ChiTIetDataTable _danhSachHoaDon_ChiTIetRows = new DataSet_thongKe.DanhSachHoaDon_ChiTIetDataTable();

        string reportsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
        private ReportViewer reportViewer;
        int hoaDon_ID;
        public Form_inHoaDon(int HoaDonID)
        {
            InitializeComponent();
            this.hoaDon_ID = HoaDonID;
            //InitializeReportViewer();
        }

        private void Form_inHoaDon_Load(object sender, EventArgs e)
        {
            if (hoaDon_ID <= 0)
            {
                MessageBox.Show("Hóa đơn không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var oldReport = this.Controls.OfType<ReportViewer>().FirstOrDefault();
                if (oldReport != null)
                {
                    this.Controls.Remove(oldReport);
                    oldReport.Dispose();
                }

                var hoaDon = context.HoaDon.Include(r => r.HoaDon_ChiTiet)
                                           .Where(r => r.HoaDonID == hoaDon_ID)
                                           .SingleOrDefault();

                if (hoaDon == null || hoaDon.HoaDon_ChiTiet == null)
                {
                    MessageBox.Show("Dữ liệu hóa đơn không đầy đủ.");
                    return;
                }

                string reportPath = Path.Combine(reportsFolder, "Report_InDanhSachHoaDon_ChiTiet.rdlc");
                if (!File.Exists(reportPath))
                {
                    MessageBox.Show($"Không tìm thấy file báo cáo: {reportPath}");
                    return;
                }

                var hoaDonChiTiet = context.HoaDon_ChiTiet.Where(r => r.HoaDonID == hoaDon_ID).Select(r => new DanhSachHoaDon_ChiTiet
                {
                    HoaDonChiTietID = r.HoaDonChiTietID,
                    HoaDonID = r.HoaDonID,
                    SanPhamID = r.SanPhamID,
                    TenSanPham = r.SanPham.TenSanPham,
                    SoLuongBan = r.SoLuongBan,
                    DonGia = r.DonGia,
                    ThanhTien = r.SoLuongBan * r.DonGia,
                }).ToList();

                if (hoaDonChiTiet == null || hoaDonChiTiet.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu hóa đơn.");
                    return;
                }

                _danhSachHoaDon_ChiTIetRows.Clear();
                foreach (var row in hoaDonChiTiet)
                {
                    _danhSachHoaDon_ChiTIetRows.AddDanhSachHoaDon_ChiTIetRow(
                        row.HoaDonChiTietID,
                        row.HoaDonID,
                        row.SanPhamID,
                        row.TenSanPham,
                        row.SoLuongBan,
                        row.DonGia,
                        row.ThanhTien
                       );
                }

                ReportDataSource reportDataSource = new ReportDataSource
                {
                    Name = "DTS_InHoaDon",  // Đảm bảo trùng với tên DataSet trong báo cáo
                    Value = _danhSachHoaDon_ChiTIetRows
                };

                ReportViewer reportViewer1 = new ReportViewer
                {
                    Dock = DockStyle.Fill,
                    LocalReport = { ReportPath = reportPath }
                };

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                var kh = context.KhachHang.Where(i => i.KhachHangID == hoaDon.KhachHangID).FirstOrDefault();
                var nv = context.NhanVien.Where(n => n.NhanVienID == hoaDon.NhanVienID).FirstOrDefault();
                // Kiểm tra null và thiết lập các tham số
                string nguoiMuaTen = kh?.HoVaTen ?? "Không xác định";
                string nguoiMuaDiaChi = kh?.DiaChiThuongTru ?? "Long Xuyên - An Giang";
                string nguoiMuaMST = kh?.STK_NganHang ?? "01020304050607";
                string nguoiBanTen = nv?.HoVaTen ?? "Lê Trí Nhàn";
                string nguoiBanDiaChi = "Việt Nam";
                string nguoiBanMST = "10121314151617";

                // Tính tổng tiền với kiểm tra null
                decimal tongTienValue = hoaDon?.HoaDon_ChiTiet?.Sum(r => r?.SoLuongBan * r?.DonGia) ?? 0;
                //string tongTien = tongTienValue.ToString("N0");

                // Tạo danh sách tham số
                IList<ReportParameter> param = new List<ReportParameter>
                    {
                        new ReportParameter("NgayLap", hoaDon?.NgayLap.ToString("dd/MM/yyyy") ?? DateTime.Now.ToString("dd/MM/yyyy")),
                        new ReportParameter("NguoiMua_ten", nguoiMuaTen),
                        new ReportParameter("NguoiBan_ten", nguoiBanTen),
                        new ReportParameter("NguoiBan_diachi", nguoiBanDiaChi),
                        new ReportParameter("NguoiBan_masothue", nguoiBanMST),
                        new ReportParameter("NguoiMua_masothue", nguoiMuaMST),
                        new ReportParameter("NguoiMua_diachi", nguoiMuaDiaChi),
                        new ReportParameter("TongTien", tongTienValue.ToString()),
                    };

                //byte[] qrCodeImage = ConvertBitmapToBytes(GenerateQRCode($"Hóa đơn số: HD{hoaDon?.HoaDonID}, Số tiền: {tongTienValue} VND, Nhân viên lập: {nguoiBanTen}, Khách hàng: {nguoiMuaTen}"));

                //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("QRCodeData", qrCodeImage));
                // Thiết lập tham số và hiển thị báo cáo
                reportViewer1.LocalReport.SetParameters(param);
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;

                // Thêm ReportViewer vào panel và làm mới
                panel_boDy.Controls.Add(reportViewer1);
                reportViewer1.RefreshReport();
                reportViewer1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Có thể ghi log lỗi ở đây nếu cần
            }
        }


        private void pic_logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

