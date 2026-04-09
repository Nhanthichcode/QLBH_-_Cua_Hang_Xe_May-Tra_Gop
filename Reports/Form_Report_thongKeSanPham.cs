using ClosedXML;
using DoAnBanHang_cuahangxemay.Data_Table;
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

namespace DoAnBanHang_cuahangxemay.Reports
{
    public partial class Form_Report_thongKeSanPham : Form
    {
        public Form_Report_thongKeSanPham()
        {
            InitializeComponent();
            InitializeReportViewer();
            LoadDataComboBox();
        }
        AppDbContext context = new AppDbContext();
        DataSet_thongKe.DTS_thongKeSanPhamDataTable _ThongKeSanPhamDataTable = new DataSet_thongKe.DTS_thongKeSanPhamDataTable();

        int hsxID = 0;
        int spID = 0;
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
            panel_boDy.Controls.Add(reportViewer);
            reportViewer.BringToFront();
        }
        void LoadDataComboBox()
        {
            var danhSachHangSanXuat = context.HangSanXuat.ToList();
            danhSachHangSanXuat.Insert(0, new HangSanXuat { HangSanXuatID = 0, TenHangSanXuat = "-Chọn hãng sản xuất-" });

            cbb_hangSanXuat.DataSource = danhSachHangSanXuat;
            cbb_hangSanXuat.DisplayMember = "TenHangSanXuat";
            cbb_hangSanXuat.ValueMember = "HangSanXuatID";

            var danhSachSanPham = context.SanPham.ToList();
            danhSachSanPham.Insert(0, new SanPham { SanPhamID = 0, TenSanPham = "-Chọn sản phẩm-" });

            cbb_tenSanPham.DataSource = danhSachSanPham;
            cbb_tenSanPham.DisplayMember = "TenSanPham";
            cbb_tenSanPham.ValueMember = "SanPhamID";

        }
        private void Form_Report_thongKeSanPham_Load(object sender, EventArgs e)
        {
            LoadReportData(0, 0, "Tất cả sán phẩm");
        }
        private void LoadReportData(int IDsanPham, int IDhangSanXuat, string description)
        {
            try
            {
                reportViewer.Visible = false;
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.ReportEmbeddedResource = "DoAnBanHang_cuahangxemay.Reports.Report_thongKeSanPham.rdlc";
                if (reportViewer == null)
                {
                    MessageBox.Show("Không tìm thấy report");
                    return;
                }
                var query = context.SanPham.AsQueryable();

                if (IDsanPham == 0 && IDhangSanXuat == 0)
                {
                    query = query.Where(r => r.SanPhamID != 0);
                }
                else if (IDsanPham != 0 && IDhangSanXuat == 0)
                {
                    query = query.Where(r => r.SanPhamID == IDsanPham);
                }
                else
                {
                    query = query.Where(r => r.HangSanXuatID == IDhangSanXuat);
                }

                var danhSachSanPham = query.Select(r => new DanhSachSanPham
                {
                    SanPhamID = r.SanPhamID,
                    HangSanXuatID = r.HangSanXuatID,
                    TenHangSanXuat = r.HangSanXuat.TenHangSanXuat,
                    TenSanPham = r.TenSanPham,
                    GiaBan = r.GiaBan,
                    SoLuongTon = r.SoLuongTon,
                    NamSX = r.NamSX,
                    MoTa = r.MoTa,
                    TrangThai = r.TrangThai,
                    HinhAnh = r.HinhAnh,
                }).ToList();

                _ThongKeSanPhamDataTable.Clear();
                foreach (var row in danhSachSanPham)
                {
                    _ThongKeSanPhamDataTable.AddDTS_thongKeSanPhamRow(
                         row.SanPhamID,
                         row.HangSanXuatID,
                         row.TenHangSanXuat,
                         row.TenSanPham,
                         row.GiaBan,
                         row.SoLuongTon,
                         row.NamSX,
                         row.MoTa,
                         row.TrangThai.ToString()??"",
                         row.HinhAnh);
                }

                ReportDataSource reportDataSource = new ReportDataSource
                {
                    Name = "DTS_thongKeSanPham",
                    Value = _ThongKeSanPhamDataTable
                };

                reportViewer.LocalReport.DataSources.Add(reportDataSource);
                reportViewer.LocalReport.SetParameters(new ReportParameter("MoTaKetQuaHienThi", description));

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

        private void btn_showSelected_Click(object sender, EventArgs e)
        {
            string tenhsx = cbb_hangSanXuat.SelectedIndex == 0 ? "-/-" : cbb_hangSanXuat.Text;
            string tensp = cbb_tenSanPham.SelectedIndex == 0 ? "-/-" : cbb_tenSanPham.Text;
            string text = "Tên Hảng sản xuất: " +tenhsx + "\n" +"Tên sản phẩm: " +tensp;
            LoadReportData(spID, hsxID, text);
        }

        private void btn_showAll_Click(object sender, EventArgs e)
        {
            Form_Report_thongKeSanPham_Load(sender, e);
        }

        private void pic_logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbb_tenSanPham_SelectionChangeCommitted(object sender, EventArgs e)
        {
            spID = Convert.ToInt32(cbb_tenSanPham.SelectedValue);
        }

        private void cbb_hangSanXuat_SelectionChangeCommitted(object sender, EventArgs e)
        {
            hsxID = Convert.ToInt32(cbb_hangSanXuat.SelectedValue);
        }
    }
}
