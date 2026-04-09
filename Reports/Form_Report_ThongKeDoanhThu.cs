using DoAnBanHang_cuahangxemay.Data_Table;
using DocumentFormat.OpenXml.InkML;
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
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using static DoAnBanHang_cuahangxemay.Reports.DataSet_thongKe;
using static DoAnBanHang_cuahangxemay.Data_Table.enum_ThongTin;
using Microsoft.EntityFrameworkCore;

namespace DoAnBanHang_cuahangxemay.Reports
{
    public partial class Form_Report_ThongKeDoanhThu : Form
    {
        string trangThai;
        public Form_Report_ThongKeDoanhThu()
        {
            InitializeComponent();
            InitializeReportViewer();

        }
        AppDbContext context = new AppDbContext();
        DataSet_thongKe.DTS_thongKeDoanhThuDataTable _ThongKeDoanhsDataTable = new DataSet_thongKe.DTS_thongKeDoanhThuDataTable();

        string reportsFolder = Application.StartupPath.Replace("bin\\Debug\\net8.0-windows", "Reports");
        private ReportViewer reportViewer;
        private void InitializeReportViewer()
        {
            // Khởi tạo ReportViewer với kích thước và vị trí phù hợp
            reportViewer = new ReportViewer
            {
                Dock = DockStyle.Fill,
                ZoomMode = ZoomMode.PageWidth,
                Visible = false
            };
            panel_rePort.Controls.Add(reportViewer);
            reportViewer.BringToFront();
        }
        private void LoadReportData(DateTime fromDate, DateTime toDate, string description)
        {
            try
            {
                decimal thanhTien;
                reportViewer.Visible = false;
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.ReportEmbeddedResource = "DoAnBanHang_cuahangxemay.Reports.Report_thongKeDoanhThu.rdlc";
                if (reportViewer == null)
                {
                    MessageBox.Show("Không tìm thấy report");
                    return;
                }
                var query = context.HoaDon.AsQueryable();

                query = query.Where(r => r.NgayLap >= fromDate && r.NgayLap <= toDate);

                var danhSachDoanhThu = query.Select(r => new DanhSachHoaDon
                {
                    HoaDonID = r.HoaDonID,
                    NhanVienID = r.NhanVienID,
                    TenNhanVien = r.NhanVien.HoVaTen,
                    KhachHangID = r.KhachHangID,
                    TenKhachHang = r.KhachHang.HoVaTen,
                    NgayLap = r.NgayLap,
                    TongTien = r.HoaDon_ChiTiet.Sum(ct => ct.SoLuongBan * ct.DonGia),
                    
                }).ToList();

                thanhTien = danhSachDoanhThu.Sum(r => r.TongTien);
                string tongTien = "Tổng tiền: " + thanhTien.ToString("N2") + " VNĐ";
                _ThongKeDoanhsDataTable.Clear();
                foreach (var row in danhSachDoanhThu)
                {
                    _ThongKeDoanhsDataTable.AddDTS_thongKeDoanhThuRow(
                        row.HoaDonID,
                        row.KhachHangID,
                        row.TenKhachHang,
                        row.NhanVienID,
                        row.TenNhanVien,
                        row.TongTien,
                        row.NgayLap ?? DateTime.Now);
                }

                ReportDataSource reportDataSource = new ReportDataSource
                {
                    Name = "DTS_thongKeDoanhThu",
                    Value = _ThongKeDoanhsDataTable
                };

                IList<ReportParameter> param = new List<ReportParameter>
                {
                        new ReportParameter("MoTaKetQuaHienThi", description),
                        new ReportParameter("TongDoanhThu", tongTien),
                };

                // Thiết lập tham số và hiển thị báo cáo


                reportViewer.LocalReport.DataSources.Add(reportDataSource);
                reportViewer.LocalReport.SetParameters(param);
                //reportViewer.LocalReport.SetParameters(new ReportParameter("MoTaKetQuaHienThi", description));

                reportViewer.Top = (int)(this.ClientSize.Height * 0.2);  // Cách đỉnh 20%
                reportViewer.Height = (int)(this.ClientSize.Height * 0.8); // Chiếm 80% chiều cao
                reportViewer.Width = this.ClientSize.Width; // Chiếm toàn bộ chiều ngang

                reportViewer.RefreshReport();
                reportViewer.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form_Report_ThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            BindEnumToComboBox(typeof(enum_ThongTin.enum_HoaDon), comboBox_trangThaiHoaDon);
            LoadReportData(dtp_tuNgay.MinDate, DateTime.MaxValue, "(Tất cả thời gian)");
        }

        private void btn_showSelected_Click(object sender, EventArgs e)
        {
            comboBox_trangThaiHoaDon.SelectedIndex = -1;
            if (dtp_tuNgay.Value > dtp_denNgay.Value || dtp_tuNgay.Value == dtp_denNgay.Value)
            {
                MessageBox.Show("Ngày bắt đầu xem doanh thu phải có trước ngày cuối cùng cần xem !!", "Lỗi Chọn Ngày", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (dtp_denNgay.Value > DateTime.Now || dtp_tuNgay.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày cần xem không được lớn hơn ngày hiện tại", "Chọn sai ngày", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            LoadReportData(dtp_tuNgay.Value.Date, dtp_denNgay.Value.Date,
               $"Từ ngày {dtp_tuNgay.Value:dd/MM/yyyy}\nđến ngày {dtp_denNgay.Value:dd/MM/yyyy}");
        }

        private void btn_showAll_Click(object sender, EventArgs e)
        {
            Form_Report_ThongKeDoanhThu_Load(sender, e);
        }

        private void pic_out_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadReportData_theoKhachHang(int tmp, string description)
        {
            try
            {
                decimal thanhTien;
                reportViewer.Visible = false;
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.ReportEmbeddedResource = "DoAnBanHang_cuahangxemay.Reports.Report_thongKeDoanhThu.rdlc";
                if (reportViewer == null)
                {
                    MessageBox.Show("Không tìm thấy report");
                    return;
                }
                var query = context.HoaDon
                           .Include(r => r.NhanVien)
                           .Include(r => r.KhachHang)
                           .Include(r => r.HoaDon_ChiTiet)
                           .AsQueryable();
                //if (comboBox_trangThaiHoaDon.SelectedIndex != -1)
                //{
                var danhSachDoanhThu = query.Select(r => new DanhSachHoaDon
                {
                    HoaDonID = r.HoaDonID,
                    NhanVienID = r.NhanVienID,
                    TenNhanVien = r.NhanVien.HoVaTen,
                    KhachHangID = r.KhachHangID,
                    TenKhachHang = r.KhachHang.HoVaTen,
                    NgayLap = r.NgayLap,
                    TongTien = r.HoaDon_ChiTiet.Sum(ct => ct.SoLuongBan * ct.DonGia),
                }).OrderByDescending(r => r.TongTien).ToList();

                if (tmp == 0)
                {
                    danhSachDoanhThu = danhSachDoanhThu.OrderByDescending(r => r.TongTien).ToList();
                }
                else { danhSachDoanhThu = danhSachDoanhThu.OrderBy(r => r.TongTien).ToList(); }


                thanhTien = danhSachDoanhThu.Sum(r => r.TongTien);
                string tongTien = "Tổng tiền: " + thanhTien.ToString("N2") + " VNĐ";
                _ThongKeDoanhsDataTable.Clear();
                foreach (var row in danhSachDoanhThu)
                {
                    _ThongKeDoanhsDataTable.AddDTS_thongKeDoanhThuRow(
                        row.HoaDonID,
                        row.KhachHangID,
                        row.TenKhachHang,
                        row.NhanVienID,
                        row.TenNhanVien,
                        row.TongTien,
                        row.NgayLap ?? DateTime.Now);
                }

                ReportDataSource reportDataSource = new ReportDataSource
                {
                    Name = "DTS_thongKeDoanhThu",
                    Value = _ThongKeDoanhsDataTable
                };

                IList<ReportParameter> param = new List<ReportParameter>
                {
                        new ReportParameter("MoTaKetQuaHienThi", description),
                        new ReportParameter("TongDoanhThu", tongTien),
                };

                // Thiết lập tham số và hiển thị báo cáo


                reportViewer.LocalReport.DataSources.Add(reportDataSource);
                reportViewer.LocalReport.SetParameters(param);
                //reportViewer.LocalReport.SetParameters(new ReportParameter("MoTaKetQuaHienThi", description));

                reportViewer.Top = (int)(this.ClientSize.Height * 0.2);  // Cách đỉnh 20%
                reportViewer.Height = (int)(this.ClientSize.Height * 0.8); // Chiếm 80% chiều cao
                reportViewer.Width = this.ClientSize.Width; // Chiếm toàn bộ chiều ngang

                reportViewer.RefreshReport();
                reportViewer.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox_trangThaiHoaDon_SelectionChangeCommitted(object sender, EventArgs e)
        {
            trangThai = enum_ThongTin.GetDescription((enum_ThongTin.enum_HoaDon)comboBox_trangThaiHoaDon.SelectedValue).ToString();
            LoadReportData_TheoTrangThai(trangThai);
        }
        private void LoadReportData_TheoTrangThai(string trangthai)
        {
            try
            {
                decimal thanhTien;
                reportViewer.Visible = false;
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.ReportEmbeddedResource = "DoAnBanHang_cuahangxemay.Reports.Report_thongKeDoanhThu.rdlc";
                if (reportViewer == null)
                {
                    MessageBox.Show("Không tìm thấy report");
                    return;
                }
                var query = context.HoaDon.AsQueryable();

                if (((enum_ThongTin.enum_HoaDon)comboBox_trangThaiHoaDon.SelectedValue).ToString().Equals(enum_ThongTin.enum_HoaDon.DaHuy.ToString()))
                {
                    query = query.Where(t => t.TrangThai.ToString().Equals(enum_ThongTin.enum_HoaDon.DaHuy.ToString()));
                }
                else if (((enum_ThongTin.enum_HoaDon)comboBox_trangThaiHoaDon.SelectedValue).ToString().Equals(enum_ThongTin.enum_HoaDon.ChuaThanhToan.ToString()))
                {
                    query = query.Where(t => t.TrangThai.ToString().Equals(enum_ThongTin.enum_HoaDon.ChuaThanhToan.ToString()));
                }
                else if (((enum_ThongTin.enum_HoaDon)comboBox_trangThaiHoaDon.SelectedValue).ToString().Equals(enum_ThongTin.enum_HoaDon.DangThanhToan.ToString()))
                {
                    query = query.Where(t => t.TrangThai.ToString().Equals(enum_ThongTin.enum_HoaDon.DangThanhToan.ToString()));
                }
                else if (((enum_ThongTin.enum_HoaDon)comboBox_trangThaiHoaDon.SelectedValue).ToString().Equals(enum_ThongTin.enum_HoaDon.DaThanhToan.ToString()))
                {
                    query = query.Where(t => t.TrangThai.ToString().Equals(enum_ThongTin.enum_HoaDon.DaThanhToan.ToString()));
                }
                else if (((enum_ThongTin.enum_HoaDon)comboBox_trangThaiHoaDon.SelectedValue).ToString().Equals(enum_ThongTin.enum_HoaDon.DaKhoiPhuc.ToString()))
                {
                    query = query.Where(t => t.TrangThai.ToString().Equals(enum_ThongTin.enum_HoaDon.DaKhoiPhuc.ToString()));
                }

                var danhSachDoanhThu = query.Select(r => new DanhSachHoaDon
                {
                    HoaDonID = r.HoaDonID,
                    NhanVienID = r.NhanVienID,
                    TenNhanVien = r.NhanVien.HoVaTen,
                    KhachHangID = r.KhachHangID,
                    TenKhachHang = r.KhachHang.HoVaTen,
                    NgayLap = r.NgayLap,
                    TongTien = r.HoaDon_ChiTiet.Sum(ct => ct.SoLuongBan * ct.DonGia),                    
                }).ToList();

                thanhTien = danhSachDoanhThu.Sum(r => r.TongTien);
                string tongTien = "Tổng tiền: " + thanhTien.ToString("N2") + " VNĐ";
                _ThongKeDoanhsDataTable.Clear();
                foreach (var row in danhSachDoanhThu)
                {
                    _ThongKeDoanhsDataTable.AddDTS_thongKeDoanhThuRow(
                        row.HoaDonID,
                        row.KhachHangID,
                        row.TenKhachHang,
                        row.NhanVienID,
                        row.TenNhanVien,
                        row.TongTien,
                        row.NgayLap ?? DateTime.Now);
                }

                ReportDataSource reportDataSource = new ReportDataSource
                {
                    Name = "DTS_thongKeDoanhThu",
                    Value = _ThongKeDoanhsDataTable
                };

                IList<ReportParameter> param = new List<ReportParameter>
                {
                        new ReportParameter("MoTaKetQuaHienThi", trangthai),
                        new ReportParameter("TongDoanhThu", tongTien),
                };

                // Thiết lập tham số và hiển thị báo cáo


                reportViewer.LocalReport.DataSources.Add(reportDataSource);
                reportViewer.LocalReport.SetParameters(param);
                //reportViewer.LocalReport.SetParameters(new ReportParameter("MoTaKetQuaHienThi", description));

                reportViewer.Top = (int)(this.ClientSize.Height * 0.2);  // Cách đỉnh 20%
                reportViewer.Height = (int)(this.ClientSize.Height * 0.8); // Chiếm 80% chiều cao
                reportViewer.Width = this.ClientSize.Width; // Chiếm toàn bộ chiều ngang

                reportViewer.RefreshReport();
                reportViewer.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải báo cáo trạng thái: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chb_countUp_CheckedChanged(object sender, EventArgs e)
        {
            chb_countDown.Checked = false;
            LoadReportData_theoKhachHang(1, "Sắp Xếp Tăng Theo Doanh Thu");
        }

        private void chb_countDown_CheckedChanged(object sender, EventArgs e)
        {
            chb_countUp.Checked = false;

            LoadReportData_theoKhachHang(0, "Sắp Xếp Giảm Theo Doanh Thu");
        }
    }
}
