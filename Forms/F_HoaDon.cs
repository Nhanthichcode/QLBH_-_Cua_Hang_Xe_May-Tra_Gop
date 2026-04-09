using ClosedXML.Excel;
using DoAnBanHang_cuahangxemay.Data_Table;
using DoAnBanHang_cuahangxemay.help;
using DoAnBanHang_cuahangxemay.Reports;
using DocumentFormat.OpenXml.VariantTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace DoAnBanHang_cuahangxemay.Forms
{
    public partial class F_HoaDon : Form
    {
        AppDbContext context = new AppDbContext();
        int id_hoadon;
        int id_nguoiDung;
        int _isDaXoa = 0; // 0: chưa xóa, 1: đã xóa
        BindingSource bindingSource = new BindingSource();
        public static event EventHandler moForms_ChiTiet;
        void batTatCHucNang()
        {
            btn_thungRac.Enabled = btn_khoiPhucHoaDon.Enabled = btn_huyHoaDon.Enabled = true;
            var nv = context.NhanVien.Find(id_nguoiDung);
            if (nv != null)
            {
                if (nv.QuyenHan)
                {
                    btn_thungRac.Enabled = true;
                }
                else
                {
                    btn_thungRac.Enabled = btn_khoiPhucHoaDon.Enabled = btn_huyHoaDon.Enabled = btn_inHoaDon.Enabled = btn_Deleted_All.Enabled = btn_NhapFile.Enabled = btn_XuatFile.Enabled = btn_Sua.Enabled = btn_Xoa.Enabled = false;
                }
            }
        }
        public F_HoaDon(int nhanvienID)
        {
            InitializeComponent();
            id_nguoiDung = nhanvienID;
            F_HoaDon_ChiTiet.themhoadon_troVe += F_HoaDon_ChiTiet_themhoadon_troVe;
        }

        private void F_HoaDon_ChiTiet_themhoadon_troVe(object? sender, EventArgs e)
        {
            F_HoaDon_Load(sender, e);
            this.Show();
        }
        private void F_HoaDon_Load(object sender, EventArgs e)
        {
            load_formHoaDon(0);
        }

        void load_formHoaDon(int isDaXoa)
        {
            huyRdb();
            _isDaXoa = isDaXoa;
            batTatCHucNang();
            dtg_hoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            List<DanhSachHoaDon> ds = new List<DanhSachHoaDon>();
            if (isDaXoa == 0)
            {
                btn_khoiPhucHoaDon.Enabled = btn_huyHoaDon.Enabled = btn_Deleted_All.Enabled = false;
                ds = context.HoaDon
                 .Where(h => h.IsDeleted == isDaXoa)
                 .Select(r => new DanhSachHoaDon
                 {

                     HoaDonID = r.HoaDonID,
                     IsDeleted = r.IsDeleted,
                     KhachHangID = r.KhachHangID,
                     TenKhachHang = r.KhachHang.HoVaTen,
                     NhanVienID = r.NhanVienID,
                     TenNhanVien = r.NhanVien.HoVaTen,
                     PhuongThucThanhToan = r.PhuongThucThanhToan,
                     TrangThai = r.TrangThai,
                     TongTien = r.HoaDon_ChiTiet.Sum(r => r.SoLuongBan * r.DonGia),
                     NgayLap = r.NgayLap,
                     GhiChuHoaDon = r.GhiChuHoaDon,
                 }).ToList();
            }
            else
            {
                ds = context.HoaDon
                 .Where(h => h.IsDeleted == isDaXoa)
                 .Select(r => new DanhSachHoaDon
                 {

                     HoaDonID = r.HoaDonID,
                     IsDeleted = r.IsDeleted,
                     KhachHangID = r.KhachHangID,
                     TenKhachHang = r.KhachHang.HoVaTen,
                     NhanVienID = r.NhanVienID,
                     TenNhanVien = r.NhanVien.HoVaTen,
                     PhuongThucThanhToan = r.PhuongThucThanhToan,
                     TrangThai = r.TrangThai,
                     TongTien = r.HoaDon_ChiTiet.Sum(r => r.SoLuongBan * r.DonGia),
                     NgayLap = r.NgayLap,
                     GhiChuHoaDon = r.GhiChuHoaDon,
                 }).ToList();
            }
            dtg_hoaDon.DataSource = ds;
            dtg_hoaDon.Refresh();
            ChangeHeaderName();
        }
        async void ChangeHeaderName()
        {
            if (_isDaXoa == 1)
            {
                btn_khoiPhucHoaDon.Enabled = btn_Deleted_All.Enabled = (dtg_hoaDon.Rows.Count != 0);
            }
            dtg_hoaDon.Columns["KhachHangID"].Visible = false;
            dtg_hoaDon.Columns["NhanVienID"].Visible = false;
            dtg_hoaDon.Columns["IsDeleted"].Visible = false;
            dtg_hoaDon.Columns["HoaDonID"].Visible = false;

            dtg_hoaDon.Columns["IsDeleted"].HeaderText = "Đã xóa";

            dtg_hoaDon.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";
            dtg_hoaDon.Columns["TenKhachHang"].HeaderText = "Tên khách hàng";
            dtg_hoaDon.Columns["TongTien"].HeaderText = "Tổng tiền";
            dtg_hoaDon.Columns["TongTien"].DefaultCellStyle.Format = "#,##0 'VNĐ'";
            dtg_hoaDon.Columns["NgayLap"].HeaderText = "Ngày lập";
            dtg_hoaDon.Columns["PhuongThucThanhToan"].Visible = false;
            dtg_hoaDon.Columns["PhuongThucThanhToanValue"].Visible = false;
            dtg_hoaDon.Columns["PhuongThucThanhToanVietnamese"].HeaderText = "Phương thức thanh toán";
            dtg_hoaDon.Columns["TrangThai"].Visible = false;
            dtg_hoaDon.Columns["TrangThaiValue"].Visible = false;
            dtg_hoaDon.Columns["TrangThaiVietnamese"].HeaderText = "Trạng thái";
            dtg_hoaDon.Columns["GhiChuHoaDon"].HeaderText = "Ghi chú";

            await Task.Delay(500);
            foreach (DataGridViewRow row in dtg_hoaDon.Rows)
            {
                if (row.Cells["TrangThai"].Value != null)
                {
                    string trangThai = row.Cells["TrangThai"].Value.ToString();
                    //MessageBox.Show(trangThai);
                    if (trangThai == enum_ThongTin.enum_TrangThaiThanhToan.DaThanhToan.ToString())
                    {
                        row.DefaultCellStyle.BackColor = Color.Lime;
                    }
                    else if (trangThai == enum_ThongTin.enum_TrangThaiThanhToan.DangThanhToan.ToString())
                    {
                        row.DefaultCellStyle.BackColor = Color.Orange;
                    }
                    else if (trangThai == enum_ThongTin.enum_TrangThaiThanhToan.ChuaThanhToan.ToString())
                    {
                        row.DefaultCellStyle.BackColor = Color.BurlyWood;
                    }
                    else if (trangThai == enum_ThongTin.enum_HoaDon.DaHuy.ToString())
                    {
                        row.DefaultCellStyle.BackColor = Color.Tomato;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (trangThai == enum_ThongTin.enum_TrangThaiThanhToan.MoiTao.ToString())
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                    else if (trangThai == enum_ThongTin.enum_HoaDon.DaKhoiPhuc.ToString())
                    {
                        row.DefaultCellStyle.BackColor = Color.DodgerBlue;
                    }
                }
            }


        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            using (F_HoaDon_ChiTiet hoaDon_ChiTiet = new F_HoaDon_ChiTiet(0, id_nguoiDung))
            {
                this.Hide();
                hoaDon_ChiTiet.ShowDialog();
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dtg_hoaDon.CurrentRow != null && dtg_hoaDon.Rows.Count > 0)
            {
                id_hoadon = Convert.ToInt32(dtg_hoaDon.CurrentRow.Cells["HoaDonID"].Value.ToString());
                if (id_hoadon == 0) return;
                HoaDon hd = context.HoaDon.Find(id_hoadon);

                if (hd != null)
                {
                    var nameKhachHang = context.KhachHang
                        .Where(kh => kh.KhachHangID == hd.KhachHangID)
                        .Select(kh => kh.HoVaTen)
                        .FirstOrDefault() ?? "Không xác định";

                    if (MessageBox.Show(
                        $"Bạn sắp xóa hóa đơn của: {nameKhachHang}\n\n" +
                        "Bạn có chắc chắn?",
                        "Xác nhận Xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        try
                        {
                            hd.IsDeleted = 1;//đã hủy
                            hd.TrangThai = enum_ThongTin.enum_HoaDon.DaHuy.ToString();
                            hd.GhiChuHoaDon = $"Đã hủy bởi hệ thống ngày {DateTime.Now:dd/MM/yyyy}";

                            context.HoaDon.Update(hd);
                            context.SaveChanges();
                            // 4. Load lại dữ liệu và thông báo
                            F_HoaDon_Load(sender, e);
                            MessageBox.Show("Thao tác xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xóa.", "Chưa chọn hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {

            if (dtg_hoaDon.CurrentRow == null || dtg_hoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            id_hoadon = Convert.ToInt32(dtg_hoaDon.CurrentRow.Cells["HoaDonID"]?.Value?.ToString());
            HoaDon h = context.HoaDon.Find(id_hoadon);
            if (h != null)
            {

                using (F_HoaDon_ChiTiet hoaDon_ChiTiet = new F_HoaDon_ChiTiet(id_hoadon, id_nguoiDung))
                {
                    this.Hide();
                    hoaDon_ChiTiet.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn cho khách hàng này", "Lỗi tim kiếm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_huyBo_Click(object sender, EventArgs e)
        {
            F_HoaDon_Load(sender, e);
        }

        void huyRdb()
        {
            rdb_daThanhToan.Checked = false;
            rdb_dangThanhToan.Checked = false;
            rdb_chuaThanhToan.Checked = false;
            rdb_tienMat.Checked = false;
            rdb_theNganHang.Checked = false;
            rdb_chuynKhoan.Checked = false;
            rdb_traGop.Checked = false;
        }
        //private void btn_nhapFile_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        OpenFileDialog op = new OpenFileDialog();
        //        op.Title = "Nhập dữ liệu từ tập tin Excel";
        //        op.Filter = "Tập tin Excel |*.xls ;*.xlsx";
        //        op.Multiselect = false;
        //        if (op.ShowDialog() == DialogResult.OK)
        //        {
        //            using (XLWorkbook workbook = new XLWorkbook(op.FileName))
        //            {
        //                // Worksheet chứa thông tin hóa đơn (header)
        //                var wsHoaDon = workbook.Worksheet("Danh sách hóa đơn");
        //                DataTable dtHoaDon = new DataTable();
        //                bool isFirstRow = true;
        //                // Xác định phạm vi cột dựa trên dòng đầu tiên
        //                string readRange = "1:1";
        //                foreach (IXLRow row in wsHoaDon.RowsUsed())
        //                {
        //                    if (isFirstRow)
        //                    {
        //                        readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
        //                        foreach (IXLCell cell in row.Cells(readRange))
        //                        {
        //                            dtHoaDon.Columns.Add(cell.Value.ToString());
        //                        }
        //                        isFirstRow = false;
        //                    }
        //                    else
        //                    {
        //                        DataRow dataRow = dtHoaDon.NewRow();
        //                        int cellIndex = 0;
        //                        foreach (IXLCell cell in row.Cells(readRange))
        //                        {
        //                            dataRow[cellIndex] = cell.Value.ToString();
        //                            cellIndex++;
        //                        }
        //                        dtHoaDon.Rows.Add(dataRow);
        //                    }
        //                }

        //                // Worksheet chứa thông tin chi tiết hóa đơn (detail)
        //                var wsChiTiet = workbook.Worksheet("Chi tiết hóa đơn");
        //                DataTable dtChiTiet = new DataTable();
        //                isFirstRow = true;
        //                readRange = "1:1";
        //                foreach (IXLRow row in wsChiTiet.RowsUsed())
        //                {
        //                    if (isFirstRow)
        //                    {
        //                        readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
        //                        foreach (IXLCell cell in row.Cells(readRange))
        //                        {
        //                            dtChiTiet.Columns.Add(cell.Value.ToString());
        //                        }
        //                        isFirstRow = false;
        //                    }
        //                    else
        //                    {
        //                        DataRow dataRow = dtChiTiet.NewRow();
        //                        int cellIndex = 0;
        //                        foreach (IXLCell cell in row.Cells(readRange))
        //                        {
        //                            dataRow[cellIndex] = cell.Value.ToString();
        //                            cellIndex++;
        //                        }
        //                        dtChiTiet.Rows.Add(dataRow);
        //                    }
        //                }
        //                // Tiến hành chuyển đổi DataTable sang đối tượng và lưu vào cơ sở dữ liệu
        //                ImportData(dtHoaDon, dtChiTiet);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi nhập hóa đơn" + ex.Message);

        //    }
        //}

        //private void btn_xuatFile_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog
        //    {
        //        Title = "Xuất dữ liệu ra tập tin Excel",
        //        Filter = "Excel Files|*.xlsx;*.xls",
        //        FileName = $"HoaDon_ChiTiet_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
        //        OverwritePrompt = true
        //    };

        //    if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

        //    try
        //    {
        //        // Lấy dữ liệu từ database với các điều kiện lọc nếu cần
        //        var hoaDonData = context.HoaDon
        //            .Include(h => h.NhanVien)
        //            .Include(h => h.KhachHang)
        //            .Include(h => h.HoaDon_ChiTiet)
        //            .ThenInclude(ct => ct.SanPham)          
        //            .Select(h => new
        //            {
        //                HoaDonInfo = new
        //                {
        //                    MaHoaDon = h.HoaDonID,
        //                    NhanVien = h.NhanVien.HoVaTen,
        //                    KhachHang = h.KhachHang.HoVaTen,
        //                    NgayLap = h.NgayLap,
        //                    PhuongThucThanhToan = h.PhuongThucThanhToan,
        //                    TrangThai = h.TrangThai,
        //                    TongTien = h.HoaDon_ChiTiet.Sum(ct => ct.SoLuongBan * ct.DonGia)
        //                },
        //                ChiTiet = h.HoaDon_ChiTiet.Select(ct => new
        //                {
        //                    MaHoaDon = ct.HoaDonID,
        //                    MaSanPham = ct.SanPhamID,
        //                    TenSanPham = ct.SanPham.TenSanPham ?? "Không xác định",
        //                    SoLuong = ct.SoLuongBan,
        //                    DonGia = ct.DonGia,
        //                    ThanhTien = ct.SoLuongBan * ct.DonGia
        //                }).ToList()
        //            })
        //            .ToList();

        //        using (var workbook = new XLWorkbook())
        //        {
        //            // Tạo worksheet cho hóa đơn
        //            var wsHoaDon = workbook.Worksheets.Add("Danh sách hóa đơn");

        //            // Thêm tiêu đề
        //            wsHoaDon.Cell(1, 1).Value = "DANH SÁCH HÓA ĐƠN";
        //            wsHoaDon.Range(1, 1, 1, 7).Merge().Style
        //                .Font.SetBold()
        //                .Font.SetFontSize(14)
        //                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        //            // Tạo bảng dữ liệu
        //            var tableHoaDon = wsHoaDon.Cell(3, 1).InsertTable(
        //                hoaDonData.Select(x => x.HoaDonInfo),
        //                "TableHoaDon",
        //                true
        //            );

        //            // Định dạng bảng
        //            tableHoaDon.Theme = XLTableTheme.TableStyleMedium13;
        //            tableHoaDon.ShowAutoFilter = false;

        //            // Định dạng cột
        //            wsHoaDon.Column(4).Style.DateFormat.Format = "dd/MM/yyyy HH:mm";
        //            wsHoaDon.Column(7).Style.NumberFormat.Format = "#,##0";
        //            wsHoaDon.Columns().AdjustToContents();

        //            // Tạo worksheet cho chi tiết hóa đơn
        //            var wsChiTiet = workbook.Worksheets.Add("Chi tiết hóa đơn");

        //            // Thêm tiêu đề
        //            wsChiTiet.Cell(1, 1).Value = "CHI TIẾT HÓA ĐƠN";
        //            wsChiTiet.Range(1, 1, 1, 6).Merge().Style
        //                .Font.SetBold()
        //                .Font.SetFontSize(14)
        //                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        //            // Tạo bảng dữ liệu chi tiết
        //            var tableChiTiet = wsChiTiet.Cell(3, 1).InsertTable(
        //                hoaDonData.SelectMany(x => x.ChiTiet),
        //                "TableChiTiet",
        //                true
        //            );

        //            // Định dạng bảng
        //            tableChiTiet.Theme = XLTableTheme.TableStyleMedium12;
        //            tableChiTiet.ShowAutoFilter = true; // Cho phép lọc dữ liệu

        //            // Định dạng cột số
        //            wsChiTiet.Columns(4, 6).Style.NumberFormat.Format = "#,##0";
        //            wsChiTiet.Columns().AdjustToContents();

        //            // Thêm tổng kết
        //            int lastRow = wsChiTiet.LastRowUsed().RowNumber() + 2;
        //            wsChiTiet.Cell(lastRow, 5).Value = "TỔNG CỘNG:";
        //            wsChiTiet.Cell(lastRow, 5).Style.Font.SetBold();
        //            wsChiTiet.Cell(lastRow, 6).FormulaA1 = $"SUM(F4:F{lastRow - 2})";
        //            wsChiTiet.Cell(lastRow, 6).Style.Font.SetBold();
        //            wsChiTiet.Cell(lastRow, 6).Style.NumberFormat.Format = "#,##0";

        //            // Thêm ngày xuất báo cáo
        //            wsHoaDon.Cell(wsHoaDon.LastRowUsed().RowNumber() + 2, 1).Value =
        //                $"Xuất ngày: {DateTime.Now:dd/MM/yyyy HH:mm}";
        //            wsChiTiet.Cell(wsChiTiet.LastRowUsed().RowNumber() + 2, 1).Value =
        //                $"Xuất ngày: {DateTime.Now:dd/MM/yyyy HH:mm}";

        //            // Lưu file
        //            workbook.SaveAs(saveFileDialog.FileName);

        //            MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo",
        //                          MessageBoxButtons.OK, MessageBoxIcon.Information);

        //            // Mở file sau khi xuất
        //            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
        //            {
        //                FileName = saveFileDialog.FileName,
        //                UseShellExecute = true
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Lỗi khi xuất dữ liệu:\n{ex.Message}", "Lỗi",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //private void ImportData(DataTable dtHoaDon, DataTable dtChiTiet)
        //{
        //    // Danh sách tạm chứa các hóa đơn đã nhập
        //    List<HoaDon> listHoaDon = new List<HoaDon>();
        //    int successHoaDon = 0, successChiTiet = 0;

        //    // Nhập thông tin hóa đơn (header)
        //    foreach (DataRow row in dtHoaDon.Rows)
        //    {
        //        try
        //        {
        //            HoaDon h = new HoaDon();

        //            // Xử lý từng trường với kiểm tra null
        //            h.NhanVienID = int.Parse(row["NhanVienID"]?.ToString() ?? "0");
        //            h.KhachHangID = int.Parse(row["KhachHangID"]?.ToString() ?? "0");

        //            // Xử lý ngày lập
        //            if (DateTime.TryParse(row["NgayLap"]?.ToString(), out DateTime ngayLap))
        //                h.NgayLap = ngayLap;
        //            else
        //                h.NgayLap = DateTime.Now;

        //            h.PhuongThucThanhToan = row["PhuongThucThanhToan"]?.ToString() ?? "Tiền mặt";
        //            h.TrangThai = row["TrangThai"]?.ToString() ?? "Đã thanh toán";

        //            context.HoaDon.Add(h);
        //            listHoaDon.Add(h);
        //            successHoaDon++;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Lỗi nhập hóa đơn dòng {dtHoaDon.Rows.IndexOf(row) + 1}: {ex.Message}");
        //        }
        //    }

        //    // Lưu để có ID cho hóa đơn
        //    context.SaveChanges();

        //    // Nhập chi tiết hóa đơn
        //    foreach (DataRow row in dtChiTiet.Rows)
        //    {
        //        try
        //        {
        //            if (!int.TryParse(row["HoaDonID"]?.ToString(), out int hoaDonID))
        //            {
        //                MessageBox.Show($"Thiếu HoaDonID ở dòng {dtChiTiet.Rows.IndexOf(row) + 1}");
        //                continue;
        //            }

        //            HoaDon h = listHoaDon.FirstOrDefault(x => x.HoaDonID == hoaDonID);
        //            if (h == null)
        //            {
        //                MessageBox.Show($"Không tìm thấy HoaDonID {hoaDonID} ở dòng {dtChiTiet.Rows.IndexOf(row) + 1}");
        //                continue;
        //            }

        //            HoaDon_ChiTiet ct = new HoaDon_ChiTiet
        //            {
        //                HoaDonID = hoaDonID,
        //                SanPhamID = int.Parse(row["SanPhamID"]?.ToString() ?? "0"),
        //                SoLuongBan = int.Parse(row["SoLuongBan"]?.ToString() ?? "0"),
        //                DonGia = decimal.Parse(row["DonGia"]?.ToString() ?? "0")
        //            };

        //            context.HoaDon_ChiTiet.Add(ct);
        //            successChiTiet++;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Lỗi nhập chi tiết dòng {dtChiTiet.Rows.IndexOf(row) + 1}: {ex.Message}");
        //        }
        //    }

        //    context.SaveChanges();
        //    MessageBox.Show($"Đã nhập thành công {successHoaDon}/{dtHoaDon.Rows.Count} hóa đơn và {successChiTiet}/{dtChiTiet.Rows.Count} chi tiết",
        //                   "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    F_HoaDon_Load(null, null);
        //}

        #region Nhập & Xuất


        // Hàm xuất file Excel với thông tin trả góp
        private void btn_XuatFile_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu ra tập tin Excel";
            saveFileDialog.Filter = "Tập tin Excel | *.xls;*.xlsx";
            saveFileDialog.FileName = "HoaDon_ChiTiet_" + DateTime.Now.Ticks + "_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Tạo DataTable cho HoaDon
                    System.Data.DataTable hoaDonTable = new System.Data.DataTable();
                    hoaDonTable.Columns.Add("HoaDonID", typeof(int));
                    hoaDonTable.Columns.Add("KhachHangID", typeof(int));
                    hoaDonTable.Columns.Add("TenKhachHang", typeof(string));
                    hoaDonTable.Columns.Add("NhanVienID", typeof(int));
                    hoaDonTable.Columns.Add("TenNhanVien", typeof(string));
                    hoaDonTable.Columns.Add("NgayLap", typeof(DateTime));
                    hoaDonTable.Columns.Add("PhuongThucThanhToan", typeof(string));
                    hoaDonTable.Columns.Add("TrangThai", typeof(string));
                    hoaDonTable.Columns.Add("GhiChuHoaDon", typeof(string));
                    hoaDonTable.Columns.Add("TongTien", typeof(decimal));

                    // Thêm cột cho thông tin trả góp
                    hoaDonTable.Columns.Add("KyHan", typeof(int));
                    hoaDonTable.Columns.Add("LaiSuat", typeof(decimal));

                    // Tạo DataTable cho Chi Tiết Hóa Đơn
                    System.Data.DataTable chiTietTable = new System.Data.DataTable();
                    chiTietTable.Columns.Add("HoaDonChiTietID", typeof(int));
                    chiTietTable.Columns.Add("HoaDonID", typeof(int));
                    chiTietTable.Columns.Add("SanPhamID", typeof(int));
                    chiTietTable.Columns.Add("TenSanPham", typeof(string));
                    chiTietTable.Columns.Add("SoLuongBan", typeof(int));
                    chiTietTable.Columns.Add("DonGia", typeof(decimal));
                    chiTietTable.Columns.Add("ThanhTien", typeof(decimal));

                    // Lấy danh sách hóa đơn
                    var danhSachHoaDon = context.HoaDon
                        .Where(hd => hd.IsDeleted == 0)
                        .Select(hd => new DanhSachHoaDon
                        {
                            HoaDonID = hd.HoaDonID,
                            IsDeleted = hd.IsDeleted,
                            KhachHangID = hd.KhachHangID,
                            TenKhachHang = hd.KhachHang.HoVaTen,
                            NhanVienID = hd.NhanVienID,
                            TenNhanVien = hd.NhanVien.HoVaTen,
                            NgayLap = hd.NgayLap,
                            PhuongThucThanhToan = hd.PhuongThucThanhToan,
                            TrangThai = hd.TrangThai,
                            GhiChuHoaDon = hd.GhiChuHoaDon,
                            TongTien = hd.HoaDon_ChiTiet.Sum(ct => ct.SoLuongBan * ct.DonGia)
                        })
                        .ToList();

                    // Điền dữ liệu vào DataTable HoaDon
                    foreach (var hd in danhSachHoaDon)
                    {
                        // Lấy thông tin trả góp nếu có
                        int kyHan = 0;
                        decimal laiSuat = 0;

                        if (hd.PhuongThucThanhToan == enum_ThongTin.enum_PhuongThucThanhToan.TraGop.ToString())
                        {
                            // Lấy thông tin trả góp từ database
                            var traGopInfo = context.TraGop
                                .Where(tg => tg.HoaDonID == hd.HoaDonID)
                                .FirstOrDefault();

                            if (traGopInfo != null)
                            {
                                kyHan = traGopInfo.SoKyHan;
                                laiSuat = traGopInfo.laiSuat;
                            }
                        }

                        hoaDonTable.Rows.Add(
                            hd.HoaDonID,
                            hd.KhachHangID,
                            hd.TenKhachHang,
                            hd.NhanVienID,
                            hd.TenNhanVien,
                            hd.NgayLap,
                            hd.PhuongThucThanhToanVietnamese,
                            hd.TrangThaiVietnamese,
                            hd.GhiChuHoaDon,
                            hd.TongTien,
                            kyHan,
                            laiSuat
                        );

                        // Lấy chi tiết cho từng hóa đơn
                        var chiTietList = context.HoaDon_ChiTiet
                            .Where(ct => ct.HoaDonID == hd.HoaDonID)
                            .Select(ct => new DanhSachHoaDon_ChiTiet
                            {
                                HoaDonChiTietID = ct.HoaDonChiTietID,
                                HoaDonID = ct.HoaDonID,
                                SanPhamID = ct.SanPhamID,
                                TenSanPham = ct.SanPham.TenSanPham,
                                SoLuongBan = ct.SoLuongBan,
                                DonGia = ct.DonGia,
                                ThanhTien = ct.SoLuongBan * ct.DonGia
                            })
                            .ToList();

                        // Điền dữ liệu vào DataTable Chi Tiết Hóa Đơn
                        foreach (var ct in chiTietList)
                        {
                            chiTietTable.Rows.Add(
                                ct.HoaDonChiTietID,
                                ct.HoaDonID,
                                ct.SanPhamID,
                                ct.TenSanPham,
                                ct.SoLuongBan,
                                ct.DonGia,
                                ct.ThanhTien
                            );
                        }
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        // Thêm sheet cho HoaDon
                        var sheetHoaDon = wb.Worksheets.Add(hoaDonTable, "HoaDon");
                        sheetHoaDon.Columns().AdjustToContents();

                        // Thêm sheet cho Chi Tiết Hóa Đơn
                        var sheetChiTiet = wb.Worksheets.Add(chiTietTable, "ChiTietHoaDon");
                        sheetChiTiet.Columns().AdjustToContents();

                        wb.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Đã xuất dữ liệu Hóa Đơn và Chi Tiết ra tập tin Excel thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi Xuất File");
                }
            }
        }

        // Hàm nhập file Excel với xử lý thông tin trả góp
        private void btn_nhapFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Nhập dữ liệu từ tập tin Excel";
            op.Filter = "Tập tin Excel |*.xls;*.xlsx";
            op.Multiselect = false;
            if (op.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.Data.DataTable hoaDonTable = new System.Data.DataTable();
                    System.Data.DataTable chiTietTable = new System.Data.DataTable();

                    using (XLWorkbook xlw = new XLWorkbook(op.FileName))
                    {
                        // Đọc sheet HoaDon
                        if (xlw.Worksheets.Count >= 1)
                        {
                            IXLWorksheet worksheetHoaDon = xlw.Worksheet("HoaDon");
                            hoaDonTable = ReadWorksheetToDataTable(worksheetHoaDon);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sheet HoaDon trong file Excel", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Đọc sheet ChiTietHoaDon
                        if (xlw.Worksheets.Count >= 2)
                        {
                            IXLWorksheet worksheetChiTiet = xlw.Worksheet("ChiTietHoaDon");
                            chiTietTable = ReadWorksheetToDataTable(worksheetChiTiet);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sheet ChiTietHoaDon trong file Excel", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Kiểm tra nếu không có dữ liệu
                        if (hoaDonTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có dữ liệu hóa đơn trong file", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Bắt đầu xử lý nhập dữ liệu trong transaction
                        using (var transaction = context.Database.BeginTransaction())
                        {
                            try
                            {
                                List<HoaDon> hoaDonMoi = new List<HoaDon>();
                                List<HoaDon_ChiTiet> chiTietMoi = new List<HoaDon_ChiTiet>();
                                Dictionary<int, int> mapHoaDonID = new Dictionary<int, int>(); // Map ID cũ -> ID mới

                                int countHoaDon = 0;
                                int countChiTiet = 0;

                                // Lấy danh sách khách hàng và nhân viên để kiểm tra
                                var dsKhachHang = context.KhachHang.ToDictionary(k => k.KhachHangID);
                                var dsNhanVien = context.NhanVien.ToDictionary(n => n.NhanVienID);
                                var dsSanPham = context.SanPham.ToDictionary(s => s.SanPhamID);

                                // Bổ sung dictionary lưu thông tin trả góp
                                Dictionary<int, (int KyHan, decimal LaiSuat)> traGopInfo = new Dictionary<int, (int, decimal)>();

                                // Xử lý từng hóa đơn
                                foreach (DataRow row in hoaDonTable.Rows)
                                {
                                    try
                                    {
                                        int khachHangID = Convert.ToInt32(row["KhachHangID"]);
                                        int nhanVienID = Convert.ToInt32(row["NhanVienID"]);
                                        int hoaDonIDCu = Convert.ToInt32(row["HoaDonID"]);

                                        // Kiểm tra xem Khách hàng và Nhân viên có tồn tại không
                                        if (!dsKhachHang.ContainsKey(khachHangID))
                                        {
                                            MessageBox.Show($"Không tìm thấy khách hàng có ID: {khachHangID}. Bỏ qua hóa đơn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            continue;
                                        }

                                        if (!dsNhanVien.ContainsKey(nhanVienID))
                                        {
                                            MessageBox.Show($"Không tìm thấy nhân viên có ID: {nhanVienID}. Bỏ qua hóa đơn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            continue;
                                        }

                                        // Tạo hóa đơn mới
                                        HoaDon hoaDon = new HoaDon
                                        {
                                            KhachHangID = khachHangID,
                                            NhanVienID = nhanVienID,
                                            NgayLap = Convert.ToDateTime(row["NgayLap"]),
                                            PhuongThucThanhToan = ConvertToEnumValue(row["PhuongThucThanhToan"].ToString(), "PhuongThucThanhToan"),
                                            TrangThai = ConvertToEnumValue(row["TrangThai"].ToString(), "TrangThai"),
                                            GhiChuHoaDon = row["GhiChuHoaDon"].ToString(),
                                            IsDeleted = 0
                                        };

                                        hoaDonMoi.Add(hoaDon);
                                        countHoaDon++;

                                        // Đọc thêm thông tin trả góp nếu có
                                        if (hoaDon.PhuongThucThanhToan == enum_ThongTin.enum_PhuongThucThanhToan.TraGop.ToString())
                                        {
                                            int kyHan = 12; // Giá trị mặc định
                                            decimal laiSuat = 10.0m; // Giá trị mặc định

                                            // Kiểm tra cột KyHan tồn tại và có giá trị
                                            if (hoaDonTable.Columns.Contains("KyHan") && row["KyHan"] != DBNull.Value)
                                            {
                                                kyHan = Convert.ToInt32(row["KyHan"]);
                                                if (kyHan <= 0) kyHan = 12; // Đảm bảo giá trị hợp lệ
                                            }

                                            // Kiểm tra cột LaiSuat tồn tại và có giá trị
                                            if (hoaDonTable.Columns.Contains("LaiSuat") && row["LaiSuat"] != DBNull.Value)
                                            {
                                                laiSuat = Convert.ToDecimal(row["LaiSuat"]);
                                                if (laiSuat <= 0) laiSuat = 10.0m; // Đảm bảo giá trị hợp lệ
                                            }

                                            traGopInfo.Add(hoaDonIDCu, (kyHan, laiSuat)); // Lưu thông tin theo ID cũ
                                        }

                                        // Lưu tạm để tạo mapping sau khi thêm vào database
                                        context.HoaDon.Add(hoaDon);
                                        context.SaveChanges(); // Lưu để có HoaDonID mới
                                        mapHoaDonID[hoaDonIDCu] = hoaDon.HoaDonID;
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"Lỗi khi xử lý hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        continue; // Bỏ qua hóa đơn lỗi và tiếp tục
                                    }
                                }

                                // Xử lý chi tiết hóa đơn và tính tổng tiền
                                Dictionary<int, decimal> tongTienByHoaDon = new Dictionary<int, decimal>();

                                if (chiTietTable.Rows.Count > 0)
                                {
                                    foreach (DataRow row in chiTietTable.Rows)
                                    {
                                        try
                                        {
                                            int hoaDonIDCu = Convert.ToInt32(row["HoaDonID"]);
                                            int sanPhamID = Convert.ToInt32(row["SanPhamID"]);

                                            // Kiểm tra hóa đơn mới và sản phẩm có tồn tại không
                                            if (!mapHoaDonID.ContainsKey(hoaDonIDCu))
                                            {
                                                continue; // Bỏ qua nếu không có hóa đơn tương ứng
                                            }

                                            if (!dsSanPham.ContainsKey(sanPhamID))
                                            {
                                                MessageBox.Show($"Không tìm thấy sản phẩm ID: {sanPhamID}. Bỏ qua chi tiết này.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                continue;
                                            }

                                            int hoaDonIDMoi = mapHoaDonID[hoaDonIDCu];
                                            int soLuongBan = Convert.ToInt32(row["SoLuongBan"]);
                                            decimal donGia = Convert.ToDecimal(row["DonGia"]);

                                            // Tạo chi tiết hóa đơn mới
                                            HoaDon_ChiTiet chiTiet = new HoaDon_ChiTiet
                                            {
                                                HoaDonID = hoaDonIDMoi,
                                                SanPhamID = sanPhamID,
                                                SoLuongBan = soLuongBan,
                                                DonGia = donGia
                                            };

                                            chiTietMoi.Add(chiTiet);
                                            context.HoaDon_ChiTiet.Add(chiTiet);
                                            countChiTiet++;

                                            // Tính tổng tiền cho từng hóa đơn
                                            decimal thanhTien = donGia * soLuongBan;
                                            if (tongTienByHoaDon.ContainsKey(hoaDonIDMoi))
                                                tongTienByHoaDon[hoaDonIDMoi] += thanhTien;
                                            else
                                                tongTienByHoaDon.Add(hoaDonIDMoi, thanhTien);
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show($"Lỗi khi xử lý chi tiết hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            continue; // Bỏ qua chi tiết lỗi và tiếp tục
                                        }
                                    }
                                }

                                context.SaveChanges();

                                // Tạo thanh toán và trả góp tự động
                                foreach (var hoaDon in hoaDonMoi)
                                {
                                    try
                                    {
                                        if (!tongTienByHoaDon.ContainsKey(hoaDon.HoaDonID))
                                        {
                                            tongTienByHoaDon[hoaDon.HoaDonID] = 0; // Nếu không có chi tiết nào
                                        }

                                        // Tạo thanh toán
                                        var thanhToan = new ThanhToan()
                                        {
                                            HoaDonID = hoaDon.HoaDonID,
                                            SoTienThanhToan = tongTienByHoaDon[hoaDon.HoaDonID],
                                            NgayLap = DateTime.Now,
                                            TrangThaiThanhToan = enum_ThongTin.enum_TrangThaiThanhToan.MoiTao.ToString(),
                                            PhuongThucThanhToan = hoaDon.PhuongThucThanhToan,
                                            GhiChuHoaDon = "Nhập tự động từ file Excel"
                                        };
                                        context.ThanhToan.Add(thanhToan);

                                        // Xử lý trả góp
                                        if (hoaDon.PhuongThucThanhToan == enum_ThongTin.enum_PhuongThucThanhToan.TraGop.ToString())
                                        {
                                            // Tìm ID cũ dựa trên ID mới
                                            int hoaDonIDCu = mapHoaDonID.FirstOrDefault(x => x.Value == hoaDon.HoaDonID).Key;

                                            if (traGopInfo.TryGetValue(hoaDonIDCu, out var info))
                                            {
                                                TaoKeHoachTraGop(hoaDon.HoaDonID,
                                                            tongTienByHoaDon[hoaDon.HoaDonID],
                                                            info.KyHan,
                                                            info.LaiSuat);
                                            }
                                            else
                                            {
                                                // Sử dụng giá trị mặc định nếu không tìm thấy thông tin
                                                TaoKeHoachTraGop(hoaDon.HoaDonID,
                                                            tongTienByHoaDon[hoaDon.HoaDonID],
                                                            12, // Kỳ hạn mặc định
                                                            10.0m); // Lãi suất mặc định
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"Lỗi khi xử lý thanh toán/trả góp cho hóa đơn ID {hoaDon.HoaDonID}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                context.SaveChanges();
                                transaction.Commit();

                                if (countHoaDon > 0 || countChiTiet > 0)
                                {
                                    MessageBox.Show($"Đã nhập thành công {countHoaDon} hóa đơn và {countChiTiet} chi tiết hóa đơn",
                                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    // Refresh lại form nếu cần
                                    F_HoaDon_Load(sender, e);
                                }
                                else
                                {
                                    MessageBox.Show("Không có dữ liệu mới để nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show($"Lỗi trong quá trình nhập dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi đọc file: {ex.Message}", "Lỗi Nhập File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Hàm tạo kế hoạch trả góp
        private void TaoKeHoachTraGop(int hoaDonId, decimal tongTien, int soKyHan, decimal laiSuat)
        {
            // Kiểm tra tính hợp lệ của dữ liệu đầu vào
            if (soKyHan <= 0)
            {
                soKyHan = 12; // Giá trị mặc định
            }

            if (laiSuat <= 0)
            {
                laiSuat = 10.0m; // Giá trị mặc định
            }

            decimal tienGocMoiKy = Math.Round(tongTien / soKyHan, 2);
            decimal laiSuatKy = laiSuat / 100 / 12; // Chuyển từ % năm sang decimal tháng

            decimal tongLai = 0;
            decimal tongPhaiTra = 0;

            for (int i = 1; i <= soKyHan; i++)
            {
                decimal tienGocConLai = tongTien - tienGocMoiKy * (i - 1);
                decimal tienLaiKy = Math.Round(tienGocConLai * laiSuatKy, 2);
                tongLai += tienLaiKy;

                var traGop = new TraGop
                {
                    HoaDonID = hoaDonId,
                    SoKyHan = soKyHan,
                    KyTra = i,
                    SoTienGoc = tienGocMoiKy,
                    SoTienLai = tienLaiKy,
                    SoTienConLai = Math.Max(0, tienGocConLai - tienGocMoiKy), // Đảm bảo không âm
                    NgayDenHan = DateTime.Now.AddMonths(i),
                    TrangThai = enum_ThongTin.enum_HoaDon.ChuaThanhToan.ToString(),
                    laiSuat = laiSuat
                };

                context.TraGop.Add(traGop);
            }

            tongPhaiTra = tongTien + tongLai;

            // Cập nhật thông tin trả góp vào hóa đơn
            var hoaDon = context.HoaDon.Find(hoaDonId);
            if (hoaDon != null)
            {
                string ghiChuTraGop = $" | Trả góp: {soKyHan} kỳ, LS: {laiSuat}%, Tổng lãi: {tongLai:N0}đ, Tổng phải trả: {tongPhaiTra:N0}đ";

                // Thêm ghi chú nếu chưa có thông tin trả góp
                if (!hoaDon.GhiChuHoaDon.Contains("Trả góp:"))
                {
                    hoaDon.GhiChuHoaDon += ghiChuTraGop;
                }
            }
        }


        //private void btn_XuatFile_Click_1(object sender, EventArgs e)
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.Title = "Xuất dữ liệu ra tập tin Excel";
        //    saveFileDialog.Filter = "Tập tin Excel | *.xls;*.xlsx";
        //    saveFileDialog.FileName = "HoaDon_ChiTiet_" + DateTime.Now.Ticks + "_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
        //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        try
        //        {
        //            // Tạo DataTable cho HoaDon
        //            System.Data.DataTable hoaDonTable = new System.Data.DataTable();
        //            hoaDonTable.Columns.Add("HoaDonID", typeof(int));
        //            hoaDonTable.Columns.Add("KhachHangID", typeof(int));
        //            hoaDonTable.Columns.Add("TenKhachHang", typeof(string));
        //            hoaDonTable.Columns.Add("NhanVienID", typeof(int));
        //            hoaDonTable.Columns.Add("TenNhanVien", typeof(string));
        //            hoaDonTable.Columns.Add("NgayLap", typeof(DateTime));
        //            hoaDonTable.Columns.Add("PhuongThucThanhToan", typeof(string));
        //            hoaDonTable.Columns.Add("TrangThai", typeof(string));
        //            hoaDonTable.Columns.Add("GhiChuHoaDon", typeof(string));
        //            hoaDonTable.Columns.Add("TongTien", typeof(decimal));
        //            hoaDonTable.Columns.Add("KyHan", typeof(int));
        //            hoaDonTable.Columns.Add("LaiSuat", typeof(decimal));
        //            // Tạo DataTable cho Chi Tiết Hóa Đơn
        //            System.Data.DataTable chiTietTable = new System.Data.DataTable();
        //            chiTietTable.Columns.Add("HoaDonChiTietID", typeof(int));
        //            chiTietTable.Columns.Add("HoaDonID", typeof(int));
        //            chiTietTable.Columns.Add("SanPhamID", typeof(int));
        //            chiTietTable.Columns.Add("TenSanPham", typeof(string));
        //            chiTietTable.Columns.Add("SoLuongBan", typeof(int));
        //            chiTietTable.Columns.Add("DonGia", typeof(decimal));
        //            chiTietTable.Columns.Add("ThanhTien", typeof(decimal));

        //            // Lấy danh sách hóa đơn
        //            var danhSachHoaDon = context.HoaDon
        //                .Where(hd => hd.IsDeleted == 0)
        //                .Select(hd => new DanhSachHoaDon
        //                {
        //                    HoaDonID = hd.HoaDonID,
        //                    IsDeleted = hd.IsDeleted,
        //                    KhachHangID = hd.KhachHangID,
        //                    TenKhachHang = hd.KhachHang.HoVaTen,
        //                    NhanVienID = hd.NhanVienID,
        //                    TenNhanVien = hd.NhanVien.HoVaTen,
        //                    NgayLap = hd.NgayLap,
        //                    PhuongThucThanhToan = hd.PhuongThucThanhToan,
        //                    TrangThai = hd.TrangThai,
        //                    GhiChuHoaDon = hd.GhiChuHoaDon,
        //                    TongTien = hd.HoaDon_ChiTiet.Sum(ct => ct.SoLuongBan * ct.DonGia)
        //                })
        //                .ToList();

        //            // Điền dữ liệu vào DataTable HoaDon
        //            foreach (var hd in danhSachHoaDon)
        //            {

        //                // Lấy thông tin trả góp nếu có
        //                int kyHan = 0;
        //                decimal laiSuat = 0;

        //                if (hd.PhuongThucThanhToan == enum_ThongTin.enum_PhuongThucThanhToan.TraGop.ToString())
        //                {
        //                    // Lấy thông tin trả góp từ database
        //                    var traGopInfo = context.TraGop
        //                        .Where(tg => tg.HoaDonID == hd.HoaDonID)
        //                        .FirstOrDefault();

        //                    if (traGopInfo != null)
        //                    {
        //                        kyHan = traGopInfo.SoKyHan;
        //                        laiSuat = traGopInfo.laiSuat;
        //                    }
        //                }


        //                hoaDonTable.Rows.Add(
        //                    hd.HoaDonID,
        //                    hd.KhachHangID,
        //                    hd.TenKhachHang,
        //                    hd.NhanVienID,
        //                    hd.TenNhanVien,
        //                    hd.NgayLap,
        //                    hd.PhuongThucThanhToanVietnamese,
        //                    hd.TrangThaiVietnamese,
        //                    hd.GhiChuHoaDon,
        //                    hd.TongTien
        //                );

        //                // Lấy chi tiết cho từng hóa đơn
        //                var chiTietList = context.HoaDon_ChiTiet
        //                    .Where(ct => ct.HoaDonID == hd.HoaDonID)
        //                    .Select(ct => new DanhSachHoaDon_ChiTiet
        //                    {
        //                        HoaDonChiTietID = ct.HoaDonChiTietID,
        //                        HoaDonID = ct.HoaDonID,
        //                        SanPhamID = ct.SanPhamID,
        //                        TenSanPham = ct.SanPham.TenSanPham,
        //                        SoLuongBan = ct.SoLuongBan,
        //                        DonGia = ct.DonGia,
        //                        ThanhTien = ct.SoLuongBan * ct.DonGia
        //                    })
        //                    .ToList();

        //                // Điền dữ liệu vào DataTable Chi Tiết Hóa Đơn
        //                foreach (var ct in chiTietList)
        //                {
        //                    chiTietTable.Rows.Add(
        //                        ct.HoaDonChiTietID,
        //                        ct.HoaDonID,
        //                        ct.SanPhamID,
        //                        ct.TenSanPham,
        //                        ct.SoLuongBan,
        //                        ct.DonGia,
        //                        ct.ThanhTien
        //                    );
        //                }
        //            }

        //            using (XLWorkbook wb = new XLWorkbook())
        //            {
        //                // Thêm sheet cho HoaDon
        //                var sheetHoaDon = wb.Worksheets.Add(hoaDonTable, "HoaDon");
        //                sheetHoaDon.Columns().AdjustToContents();

        //                // Thêm sheet cho Chi Tiết Hóa Đơn
        //                var sheetChiTiet = wb.Worksheets.Add(chiTietTable, "ChiTietHoaDon");
        //                sheetChiTiet.Columns().AdjustToContents();

        //                wb.SaveAs(saveFileDialog.FileName);
        //                MessageBox.Show("Đã xuất dữ liệu Hóa Đơn và Chi Tiết ra tập tin Excel thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message, "Lỗi Xuất File");
        //        }
        //    }
        //}

        //private void btn_nhapFile_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog op = new OpenFileDialog();
        //    op.Title = "Nhập dữ liệu từ tập tin Excel";
        //    op.Filter = "Tập tin Excel |*.xls;*.xlsx";
        //    op.Multiselect = false;
        //    if (op.ShowDialog() == DialogResult.OK)
        //    {
        //        try
        //        {
        //            System.Data.DataTable hoaDonTable = new System.Data.DataTable();
        //            System.Data.DataTable chiTietTable = new System.Data.DataTable();

        //            using (XLWorkbook xlw = new XLWorkbook(op.FileName))
        //            {
        //                // Đọc sheet HoaDon
        //                if (xlw.Worksheets.Count >= 1)
        //                {
        //                    IXLWorksheet worksheetHoaDon = xlw.Worksheet("HoaDon");
        //                    hoaDonTable = ReadWorksheetToDataTable(worksheetHoaDon);
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Không tìm thấy sheet HoaDon trong file Excel", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    return;
        //                }

        //                // Đọc sheet ChiTietHoaDon
        //                if (xlw.Worksheets.Count >= 2)
        //                {
        //                    IXLWorksheet worksheetChiTiet = xlw.Worksheet("ChiTietHoaDon");
        //                    chiTietTable = ReadWorksheetToDataTable(worksheetChiTiet);
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Không tìm thấy sheet ChiTietHoaDon trong file Excel", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    return;
        //                }

        //                // Bắt đầu xử lý nhập dữ liệu
        //                if (hoaDonTable.Rows.Count > 0)
        //                {
        //                    List<HoaDon> hoaDonMoi = new List<HoaDon>();
        //                    List<HoaDon_ChiTiet> chiTietMoi = new List<HoaDon_ChiTiet>();
        //                    Dictionary<int, int> mapHoaDonID = new Dictionary<int, int>(); // Map ID cũ -> ID mới

        //                    int countHoaDon = 0;
        //                    int countChiTiet = 0;

        //                    // Lấy danh sách khách hàng và nhân viên để kiểm tra
        //                    var dsKhachHang = context.KhachHang.ToDictionary(k => k.KhachHangID);
        //                    var dsNhanVien = context.NhanVien.ToDictionary(n => n.NhanVienID);
        //                    var dsSanPham = context.SanPham.ToDictionary(s => s.SanPhamID);

        //                    // Bổ sung dictionary lưu thông tin trả góp
        //                    Dictionary<int, (int KyHan, decimal LaiSuat)> traGopInfo = new Dictionary<int, (int, decimal)>();

        //                    // Xử lý từng hóa đơn
        //                    foreach (DataRow row in hoaDonTable.Rows)
        //                    {
        //                        int khachHangID = Convert.ToInt32(row["KhachHangID"]);
        //                        int nhanVienID = Convert.ToInt32(row["NhanVienID"]);
        //                        int hoaDonIDCu = Convert.ToInt32(row["HoaDonID"]);

        //                        // Kiểm tra xem Khách hàng và Nhân viên có tồn tại không
        //                        if (!dsKhachHang.ContainsKey(khachHangID) || !dsNhanVien.ContainsKey(nhanVienID))
        //                        {
        //                            continue; // Bỏ qua nếu không tìm thấy khách hàng hoặc nhân viên
        //                        }

        //                        // Tạo hóa đơn mới
        //                        HoaDon hoaDon = new HoaDon
        //                        {
        //                            KhachHangID = khachHangID,
        //                            NhanVienID = nhanVienID,
        //                            NgayLap = Convert.ToDateTime(row["NgayLap"]),
        //                            PhuongThucThanhToan = ConvertToEnumValue(row["PhuongThucThanhToan"].ToString(), "PhuongThucThanhToan"),
        //                            TrangThai = ConvertToEnumValue(row["TrangThai"].ToString(), "TrangThai"),
        //                            GhiChuHoaDon = row["GhiChuHoaDon"].ToString(),
        //                            IsDeleted = 0
        //                        };

        //                        hoaDonMoi.Add(hoaDon);
        //                        countHoaDon++;

        //                        // Đọc thêm thông tin trả góp nếu có
        //                        if (hoaDon.PhuongThucThanhToan == enum_ThongTin.enum_PhuongThucThanhToan.TraGop.ToString())
        //                        {
        //                            int kyHan = Convert.ToInt32(row["KyHan"]);
        //                            decimal laiSuat = Convert.ToDecimal(row["LaiSuat"]);
        //                            traGopInfo.Add(hoaDon.HoaDonID, (kyHan, laiSuat));
        //                        }

        //                        // Lưu tạm để tạo mapping sau khi thêm vào database
        //                        context.HoaDon.Add(hoaDon);
        //                        context.SaveChanges(); // Lưu để có HoaDonID mới
        //                        mapHoaDonID[hoaDonIDCu] = hoaDon.HoaDonID;
        //                    }

        //                    // Xử lý chi tiết hóa đơn
        //                    if (chiTietTable.Rows.Count > 0)
        //                    {
        //                        foreach (DataRow row in chiTietTable.Rows)
        //                        {
        //                            int hoaDonIDCu = Convert.ToInt32(row["HoaDonID"]);
        //                            int sanPhamID = Convert.ToInt32(row["SanPhamID"]);

        //                            // Kiểm tra hóa đơn mới và sản phẩm có tồn tại không
        //                            if (!mapHoaDonID.ContainsKey(hoaDonIDCu) || !dsSanPham.ContainsKey(sanPhamID))
        //                            {
        //                                continue;
        //                            }

        //                            int hoaDonIDMoi = mapHoaDonID[hoaDonIDCu];

        //                            // Tạo chi tiết hóa đơn mới
        //                            HoaDon_ChiTiet chiTiet = new HoaDon_ChiTiet
        //                            {
        //                                HoaDonID = hoaDonIDMoi,
        //                                SanPhamID = sanPhamID,
        //                                SoLuongBan = Convert.ToInt32(row["SoLuongBan"]),
        //                                DonGia = Convert.ToDecimal(row["DonGia"])
        //                            };

        //                            chiTietMoi.Add(chiTiet);
        //                            countChiTiet++;

        //                            // Bổ sung tính tổng tiền cho từng hóa đơn
        //                            Dictionary<int, decimal> tongTienByHoaDon = new Dictionary<int, decimal>();
        //                            foreach (var ct in chiTietMoi)
        //                            {
        //                                decimal thanhTien = ct.DonGia * ct.SoLuongBan;
        //                                if (tongTienByHoaDon.ContainsKey(ct.HoaDonID))
        //                                    tongTienByHoaDon[ct.HoaDonID] += thanhTien;
        //                                else
        //                                    tongTienByHoaDon.Add(ct.HoaDonID, thanhTien);
        //                            }
        //                            // Tạo thanh toán và trả góp tự động
        //                            foreach (var hoaDon in hoaDonMoi)
        //                            {
        //                                // Tạo thanh toán
        //                                var thanhToan = new ThanhToan()
        //                                {
        //                                    HoaDonID = hoaDon.HoaDonID,
        //                                    SoTienThanhToan = tongTienByHoaDon[hoaDon.HoaDonID],
        //                                    NgayLap = DateTime.Now,
        //                                    TrangThaiThanhToan = enum_ThongTin.enum_TrangThaiThanhToan.MoiTao.ToString(),
        //                                    PhuongThucThanhToan = hoaDon.PhuongThucThanhToan,
        //                                    GhiChuHoaDon = "Nhập tự động từ file Excel"
        //                                };
        //                                context.ThanhToan.Add(thanhToan);

        //                                // Xử lý trả góp
        //                                if (hoaDon.PhuongThucThanhToan == enum_ThongTin.enum_PhuongThucThanhToan.TraGop.ToString())
        //                                {
        //                                    int hoaDonIDCu1 = mapHoaDonID.FirstOrDefault(x => x.Value == hoaDon.HoaDonID).Key;
        //                                    if (traGopInfo.TryGetValue(hoaDonIDCu, out var info1))
        //                                    {
        //                                        TaoKeHoachTraGop(hoaDon.HoaDonID,
        //                                                      tongTienByHoaDon[hoaDon.HoaDonID],
        //                                                      info1.KyHan,
        //                                                      info1.LaiSuat);
        //                                    }
        //                                    else
        //                                    {
        //                                        // Sử dụng giá trị mặc định nếu không tìm thấy thông tin
        //                                        TaoKeHoachTraGop(hoaDon.HoaDonID,
        //                                                      tongTienByHoaDon[hoaDon.HoaDonID],
        //                                                      12, // Kỳ hạn mặc định
        //                                                      10.0m); // Lãi suất mặc định
        //                                    }
        //                                }
        //                            }
        //                            context.SaveChanges();
        //                        }
        //                    }
        //                    if (countHoaDon > 0 || countChiTiet > 0)
        //                    {
        //                        MessageBox.Show($"Đã nhập thành công {countHoaDon} hóa đơn và {countChiTiet} chi tiết hóa đơn",
        //                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        // Refresh lại form nếu cần
        //                        F_HoaDon_Load(sender, e);
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Không có dữ liệu mới để nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    }

        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message, "Lỗi Nhập File");
        //        }
        //    }
        //}
        //private void TaoKeHoachTraGop(int hoaDonId, decimal tongTien, int soKyHan, decimal laiSuat)
        //{
        //    // tạo 1 hóa đơn với phương thức trả góp
        //    decimal tienGocMoiKy = tongTien / soKyHan;
        //    decimal laiSuatKy = laiSuat / 100 / soKyHan; // Chuyển từ % sang decimal
        //    for (int i = 1; i <= soKyHan; i++)
        //    {
        //        decimal tienLaiKy = (tongTien - tienGocMoiKy * (i - 1)) * laiSuatKy;
        //        context.TraGop.Add(new TraGop
        //        {
        //            HoaDonID = hoaDonId,
        //            SoKyHan = soKyHan,
        //            KyTra = i,
        //            SoTienGoc = tienGocMoiKy,
        //            SoTienLai = tienLaiKy,
        //            SoTienConLai = tienGocMoiKy + tienLaiKy,
        //            NgayDenHan = DateTime.Now.AddMonths(i + 1),
        //            TrangThai = enum_ThongTin.enum_HoaDon.ChuaThanhToan.ToString(),
        //            laiSuat = laiSuat
        //        });
        //    }
        //    decimal tongLai = tongTien * laiSuatKy * soKyHan;
        //    decimal tongPhaiTra = tongTien + tongLai;
        //}

        // Hàm hỗ trợ đọc Worksheet sang DataTable
        private System.Data.DataTable ReadWorksheetToDataTable(IXLWorksheet worksheet)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            bool firstRow = true;
            string readRange = "1:1";

            foreach (IXLRow row in worksheet.RowsUsed())
            {
                if (firstRow)
                {
                    readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                    foreach (IXLCell cell in row.Cells(readRange))
                    {
                        dataTable.Columns.Add(cell.Value.ToString());
                    }
                    firstRow = false;
                }
                else
                {
                    dataTable.Rows.Add();
                    int cellIndex = 0;
                    foreach (IXLCell cell in row.Cells(readRange))
                    {
                        dataTable.Rows[dataTable.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                        cellIndex++;
                    }
                }
            }
            return dataTable;
        }

        // Hàm chuyển đổi giá trị hiển thị sang giá trị Enum
        private string ConvertToEnumValue(string displayValue, string enumType)
        {
            if (enumType == "PhuongThucThanhToan")
            {
                // Duyệt qua tất cả các giá trị enum để tìm cái nào có mô tả trùng với displayValue
                foreach (enum_ThongTin.enum_PhuongThucThanhToan enumValue in Enum.GetValues(typeof(enum_ThongTin.enum_PhuongThucThanhToan)))
                {
                    if (enumValue.GetDescription() == displayValue)
                    {
                        return enumValue.ToString();
                    }
                }
            }
            else if (enumType == "TrangThai")
            {
                foreach (enum_ThongTin.enum_HoaDon enumValue in Enum.GetValues(typeof(enum_ThongTin.enum_HoaDon)))
                {
                    if (enumValue.GetDescription() == displayValue)
                    {
                        return enumValue.ToString();
                    }
                }
            }

            // Nếu không tìm thấy, trả về giá trị mặc định
            return displayValue;
        }
        #endregion
        private void btn_inHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtg_hoaDon.Rows.Count == 0 || dtg_hoaDon.CurrentRow == null)
                {
                    MessageBox.Show("Hãy chọn 1 hóa đơn để in", "Thông báo");
                    return;
                }
                int id;
                if (!int.TryParse(dtg_hoaDon.CurrentRow.Cells["HoaDonID"].Value.ToString(), out id))
                {
                    MessageBox.Show("Không tìm thấy hóa đơn để in", "Lỗi In Hóa Đơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (Form_inHoaDon inHoaDon = new Form_inHoaDon(id))
                {
                    inHoaDon.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }
        }

        private void pictureBox_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_showRepairIsDeleted_Click(object sender, EventArgs e)
        {
            load_formHoaDon(1);
        }

        private void unDoRepair(object sender, EventArgs e)
        {
            if (dtg_hoaDon.CurrentRow == null || dtg_hoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để khôi phục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            id_hoadon = Convert.ToInt32(dtg_hoaDon.CurrentRow.Cells["HoaDonID"].Value);
            string ten = dtg_hoaDon.CurrentRow.Cells["TenKhachHang"].Value.ToString() ?? "Tên không xác định";
            HoaDon hd = context.HoaDon?.Find(id_hoadon);

            if (MessageBox.Show($"Bạn có chắc muốn khôi phục lại hóa đơn\ncủa:  {ten} không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id_hoadon = Convert.ToInt32(dtg_hoaDon.CurrentRow.Cells["HoaDonID"].Value.ToString());
                if (id_hoadon == 0) return;

                if (hd != null)
                {
                    hd.IsDeleted = 0;//đã khôi phục
                    hd.TrangThai = enum_ThongTin.enum_HoaDon.DaKhoiPhuc.ToString();
                    hd.GhiChuHoaDon = $"Đã được khôi phục bởi hệ thống ngày {DateTime.Now:dd/MM/yyyy}";

                    context.HoaDon.Update(hd);
                    context.SaveChanges();
                    // 4. Load lại dữ liệu và thông báo
                    F_HoaDon_Load(sender, e);
                    MessageBox.Show("Thao tác xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                btn_thungRac.Enabled = btn_khoiPhucHoaDon.Enabled = btn_Huy.Enabled = false;
            }
            else { return; }
        }

        private void btn_Deleted_All_Click(object sender, EventArgs e)
        {
            if (context.HoaDon.Any(h => h.IsDeleted == 1) == false)
            {
                MessageBox.Show("Không có hóa đơn để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa tất cả hóa đơn trong thùng rác không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var deletedInvoices = context.HoaDon.Where(h => h.IsDeleted == 1).ToList();
                if (deletedInvoices.Count > 0)
                {
                    context.HoaDon.RemoveRange(deletedInvoices);
                    context.SaveChanges();
                    MessageBox.Show("Đã xóa tất cả hóa đơn đã xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_formHoaDon(1);
                }
                else
                {
                    MessageBox.Show("Không có hóa đơn nào đã xóa để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void textBox_SearchByName_TextChanged(object sender, EventArgs e)
        {
            if (textBox_SearchByName.Text != "")
            {
                var searchText = textBox_SearchByName.Text.ToLower();
                var filteredData = context.HoaDon
                    .Include(h => h.KhachHang)
                    .Where(h => h.KhachHang.HoVaTen.ToLower().Contains(searchText))
                    .Select(r => new DanhSachHoaDon
                    {
                        HoaDonID = r.HoaDonID,
                        IsDeleted = r.IsDeleted,
                        KhachHangID = r.KhachHangID,
                        TenKhachHang = r.KhachHang.HoVaTen,
                        NhanVienID = r.NhanVienID,
                        TenNhanVien = r.NhanVien.HoVaTen,
                        PhuongThucThanhToan = r.PhuongThucThanhToan,
                        TrangThai = r.TrangThai,
                        TongTien = r.HoaDon_ChiTiet.Sum(r => r.SoLuongBan * r.DonGia),
                        NgayLap = r.NgayLap,
                        GhiChuHoaDon = r.GhiChuHoaDon,
                    }).ToList();

                dtg_hoaDon.DataSource = filteredData;
            }
            else
            {
                load_formHoaDon(0);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            F_Help helpForm = new F_Help("hoadon"); // "login" là tên tương ứng file login.txt
            helpForm.ShowDialog();
        }

        private void groupBox_trangThaiHoaDon_MouseHover(object sender, EventArgs e)
        {

        }


        private void trangThaiThanhToan(object sender, EventArgs e)
        {
            thucHienSapXep();
        }
        private void loaiGiaoDich(object sender, EventArgs e)
        {
            thucHienSapXep();
        }

        int trangThai = 0; // 1-đã thanh toán, 2- chưa thanh toán, 3- đang thanh toán
        int loaiGD = 0; //1-tiền mặt, 2- thẻ nh, 3- chuyển khoản, 4- trả góp

        void thucHienSapXep()
        {
            loaiGD = trangThai = 0;

            if (rdb_daThanhToan.Checked) { trangThai = 1; }
            else if (rdb_dangThanhToan.Checked) { trangThai = 2; }
            else if (rdb_chuaThanhToan.Checked) { trangThai = 3; }

            if (rdb_tienMat.Checked) { loaiGD = 1; }
            else if (rdb_theNganHang.Checked) { loaiGD = 2; }
            else if (rdb_chuynKhoan.Checked) { loaiGD = 3; }
            else if (rdb_traGop.Checked) { loaiGD = 4; }

            var hd = lisstHoaDon(trangThai, loaiGD);
            if (hd != null)
            {
                dtg_hoaDon.DataSource = hd;
            }
            else
            {
                MessageBox.Show("Không có hóa đơn nào trong trạng thái này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private List<DanhSachHoaDon> lisstHoaDon(int trangThai, int loaiGiaoDich)
        {

            var query = context.HoaDon
                .Include(h => h.KhachHang)
                .Include(h => h.NhanVien)
                .Where(h => h.IsDeleted == 0);

            if (trangThai == 1)
            {
                query = query.Where(h => h.TrangThai == (enum_ThongTin.enum_HoaDon.DaThanhToan).ToString());
            }
            else if (trangThai == 2)
            {
                query = query.Where(h => h.TrangThai == (enum_ThongTin.enum_HoaDon.DangThanhToan).ToString());
            }
            else if (trangThai == 3)
            {
                query = query.Where(h => h.TrangThai == (enum_ThongTin.enum_HoaDon.ChuaThanhToan).ToString());
            }

            if (loaiGiaoDich == 1)
            {
                query = query.Where(h => h.PhuongThucThanhToan == (enum_ThongTin.enum_PhuongThucThanhToan.TienMat).ToString());
            }
            else if (loaiGiaoDich == 2)
            {
                query = query.Where(h => h.PhuongThucThanhToan == (enum_ThongTin.enum_PhuongThucThanhToan.TheNganHang).ToString());
            }
            else if (loaiGiaoDich == 3)
            {
                query = query.Where(h => h.PhuongThucThanhToan == (enum_ThongTin.enum_PhuongThucThanhToan.ChuyenKhoan).ToString());
            }
            else if (loaiGiaoDich == 4)
            {
                query = query.Where(h => h.PhuongThucThanhToan == (enum_ThongTin.enum_PhuongThucThanhToan.TraGop).ToString());
            }

            if (query.Any())
            {
                var danhSachHoaDon = query
                    .Select(r => new DanhSachHoaDon
                    {
                        HoaDonID = r.HoaDonID,
                        IsDeleted = r.IsDeleted,
                        KhachHangID = r.KhachHangID,
                        TenKhachHang = r.KhachHang.HoVaTen ?? "",
                        NhanVienID = r.NhanVienID,
                        TenNhanVien = r.NhanVien.HoVaTen ?? "",
                        PhuongThucThanhToan = r.PhuongThucThanhToan ?? "",
                        TrangThai = r.TrangThai,
                        TongTien = r.HoaDon_ChiTiet.Sum(r => r.SoLuongBan * r.DonGia),
                        NgayLap = r.NgayLap,
                        GhiChuHoaDon = r.GhiChuHoaDon,
                    }).ToList();
                return danhSachHoaDon;
            }
            else
            {
                return new List<DanhSachHoaDon>();
            }
        }

        private void rdb_MouseEnter(object sender, EventArgs e)
        {
            RadioButton rd = sender as RadioButton;
            if (rd != null && rd.Checked == false)
            {
                rd.Font = new Font(rd.Font, FontStyle.Bold);
                rd.ForeColor = Color.Crimson;
            }

        }

        private void rdb_MouseLeave(object sender, EventArgs e)
        {
            RadioButton rd = sender as RadioButton;
            if (rd != null)
            {
                rd.Font = new Font(rd.Font, FontStyle.Regular);
                rd.ForeColor = Color.Black;
            }
        }

    }
}