using DoAnBanHang_cuahangxemay.Data_Table;
using DoAnBanHang_cuahangxemay.help;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.VariantTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DoAnBanHang_cuahangxemay.Data_Table.enum_ThongTin;


namespace DoAnBanHang_cuahangxemay.Forms
{
    public partial class F_ThanhToan : Form
    {
        AppDbContext context = new AppDbContext();
        BindingSource bindingSource = new BindingSource();
        List<DanhSachThanhToan> danhSachThanhToans = new List<DanhSachThanhToan>();
        KhachHang khachHang = new KhachHang();
        int trangThaiHoaDon;
        int id_nguoidung;

        #region Methods
        void Load_tenKhachHang()
        {
            cbb_timKiemTenKH.DisplayMember = "HoVaTen";
            cbb_timKiemTenKH.ValueMember = "KhachHangID";
            cbb_timKiemTenKH.DataSource = context.KhachHang.Where(r => r.KhachHangID != 0).ToList();
            BindEnumToComboBox(typeof(enum_ThongTin.enum_TrangThaiThanhToan), cbb_trangThaiTT);
            BindEnumToComboBox(typeof(enum_ThongTin.enum_HoaDon), cbb_searchBytrangThaiHoaDon);

        }
        public List<DanhSachThanhToan> GetdanhSachThanhToan_trangthai(int tmp)
        {
            try
            {
                // Khởi tạo query với Include cần thiết
                var query = context.ThanhToan
                    .Include(t => t.HoaDon)
                    .ThenInclude(h => h.KhachHang)
                    .Include(t => t.HoaDon)
                    .ThenInclude(h => h.NhanVien)
                    .AsQueryable();

                // Áp dụng điều kiện lọc
                switch (tmp)
                {
                    case 0: // Đã thanh toán
                        query = query.Where(r => r.HoaDon.TrangThai == enum_ThongTin.enum_HoaDon.DaThanhToan.ToString());
                        break;
                    case 1: // Đang thanh toán
                        query = query.Where(r => r.HoaDon.TrangThai == enum_ThongTin.enum_HoaDon.DangThanhToan.ToString());
                        break;
                    case 2: // Chưa thanh toán
                        query = query.Where(r => r.HoaDon.TrangThai == enum_ThongTin.enum_HoaDon.ChuaThanhToan.ToString());
                        break;
                    case 3: // Đã hủy
                        query = query.Where(r => r.HoaDon.TrangThai == enum_ThongTin.enum_HoaDon.DaHuy.ToString());
                        break;
                    case 4: // Đã khôi phục
                        query = query.Where(r => r.HoaDon.TrangThai == enum_ThongTin.enum_HoaDon.DaKhoiPhuc.ToString());
                        break;
                    case 5: // Tất cả
                            // Không cần điều kiện Where
                        break;
                }

                // Thực hiện select và chuyển đổi
                var result = query.Select(k => new DanhSachThanhToan
                {
                    HoaDonID = k.HoaDonID,
                    ThanhToanID = k.ThanhToanID,
                    KhachHangID = k.HoaDon.KhachHangID,
                    NhanVienID = k.HoaDon.NhanVienID,
                    TenNhanVien = k.HoaDon.NhanVien.HoVaTen ?? "không xác định",
                    TenKhachHang = k.HoaDon.KhachHang != null ? k.HoaDon.KhachHang.HoVaTen : "Không xác định",
                    NgayLap = k.NgayLap,
                    TrangThaiHoaDon = k.HoaDon.TrangThai ?? "không xác định",
                    PhuongThucThanhToan = k.HoaDon.PhuongThucThanhToan ?? "",
                    SoTienThanhToan = k.SoTienThanhToan,
                    NgayThanhToan = k.NgayThanhToan,
                    TrangThaiThanhToan = k.TrangThaiThanhToan ?? "Không xác định",
                    GhiChuHoaDon = k.GhiChuHoaDon
                }).ToList();

                // Debug: Kiểm tra số lượng bản ghi
                Debug.WriteLine($"Số lượng bản ghi trả về: {result.Count}");

                if (result.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn nào với điều kiện hiện tại",
                                  "Thông báo",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu: {ex.Message}",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return new List<DanhSachThanhToan>();
            }
        }
        void doiTenBang()
        {
            try
            {
                txt_phuongTTT.DataBindings.Clear();
                txt_phuongTTT.DataBindings.Add("Text", bindingSource, "PhuongThucThanhToanVietnamese", false, DataSourceUpdateMode.Never);

                txt_tenKhachHang.DataBindings.Clear();
                txt_tenKhachHang.DataBindings.Add("Text", bindingSource, "TenKhachHang", false, DataSourceUpdateMode.Never);

                txt_ghiChu.DataBindings.Clear();
                txt_ghiChu.DataBindings.Add("Text", bindingSource, "GhiChuHoaDon", false, DataSourceUpdateMode.Never);

                txt_tenNhanVien.DataBindings.Clear();
                txt_tenNhanVien.DataBindings.Add("Text", bindingSource, "TenNhanVien", false, DataSourceUpdateMode.Never);

                num_soTIenTT.DataBindings.Clear();
                num_soTIenTT.DataBindings.Add("value", bindingSource, "SoTienThanhToan", false, DataSourceUpdateMode.Never);

                dtp_ngayLap.DataBindings.Clear();
                dtp_ngayLap.DataBindings.Add("Value", bindingSource, "NgayLap", false, DataSourceUpdateMode.Never);

                dtp_ngayTT.DataBindings.Clear();
                dtp_ngayTT.DataBindings.Add("Value", bindingSource, "NgayThanhToan", true, DataSourceUpdateMode.Never, DateTime.Now);

                cbb_trangThaiTT.DataBindings.Clear();
                cbb_trangThaiTT.DataBindings.Add("selectedvalue", bindingSource, "TrangThaiThanhToanValue", false, DataSourceUpdateMode.Never);

                dtg_thanhToan.Columns["HoaDonID"].Visible = false;
                dtg_thanhToan.Columns["ThanhToanID"].Visible = false;
                dtg_thanhToan.Columns["KhachHangID"].Visible = false;
                dtg_thanhToan.Columns["NhanVienID"].Visible = false;
                dtg_thanhToan.Columns["TenNhanVien"].HeaderText = "Nhân Viên Lập";
                dtg_thanhToan.Columns["TenKhachHang"].HeaderText = "Họ Tên Khách Hàng";

                dtg_thanhToan.Columns["PhuongThucThanhToan"].Visible = false;
                dtg_thanhToan.Columns["PhuongThucThanhToanValue"].Visible = false;
                dtg_thanhToan.Columns["PhuongThucThanhToanVietnamese"].HeaderText = "Phương thức thanh toán";

                dtg_thanhToan.Columns["NgayLap"].HeaderText = "Ngày lập";

                dtg_thanhToan.Columns["SoTienThanhToan"].DefaultCellStyle.Format = "#,##0 'VNĐ'";
                dtg_thanhToan.Columns["SoTienThanhToan"].HeaderText = "Số tiền Thanh Toán";

                dtg_thanhToan.Columns["TrangThaiHoaDon"].Visible = false;
                dtg_thanhToan.Columns["TrangThaiHoaDonValue"].Visible = false;
                dtg_thanhToan.Columns["TrangThaiHoaDonVietnamese"].HeaderText = "Trạng thái hóa đơn";

                dtg_thanhToan.Columns["TrangThaiThanhToan"].Visible = false;
                dtg_thanhToan.Columns["TrangThaiThanhToanValue"].Visible = false;
                dtg_thanhToan.Columns["TrangThaiThanhToanVietnamese"].HeaderText = "Trạng thái thanh toán";

                dtg_thanhToan.Columns["NgayThanhToan"].HeaderText = "Ngày thanh toán";

                dtg_thanhToan.Columns["GhiChuHoaDon"].HeaderText = "Ghi chú";

                foreach (DataGridViewRow row in dtg_thanhToan.Rows)
                {
                    if (row.Cells["TrangThaiHoaDon"].Value != null)
                    {
                        string trangThai = row.Cells["TrangThaiHoaDon"].Value.ToString();
                        //MessageBox.Show(trangThai);
                        if (trangThai == enum_ThongTin.enum_TrangThaiThanhToan.DaThanhToan.ToString())
                        {
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                        else if (trangThai == enum_ThongTin.enum_TrangThaiThanhToan.DangThanhToan.ToString())
                        {
                            row.DefaultCellStyle.BackColor = Color.Moccasin;
                        }
                        else if (trangThai == enum_ThongTin.enum_HoaDon.DaHuy.ToString())
                        {
                            row.DefaultCellStyle.BackColor = Color.Tomato;
                            row.DefaultCellStyle.ForeColor = Color.White;
                        }
                        else if (trangThai == enum_ThongTin.enum_HoaDon.DaKhoiPhuc.ToString())
                        {
                            row.DefaultCellStyle.BackColor = Color.CornflowerBlue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật tên bảng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void AddVerticalRow(string propertyName, string value)
        {
            int rowIndex = dtg_khachHang.Rows.Add();
            dtg_khachHang.Rows[rowIndex].Cells[0].Value = propertyName;
            dtg_khachHang.Rows[rowIndex].Cells[1].Value = value;

            // Tô màu dòng tiêu đề
            dtg_khachHang.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            dtg_khachHang.Rows[rowIndex].DefaultCellStyle.Font = new Font(dtg_khachHang.Font, FontStyle.Bold);
        }

        void phanQuyenNguoiDung()
        {
            var nv = context.NhanVien.Find(id_nguoidung);
            if (nv.QuyenHan)
            {
                panel_trangThai.Enabled = true;
            }
            else
            {
                panel_trangThai.Enabled = false;
            }
        }

        #endregion

        #region Event

        public F_ThanhToan(int id_nhanVien)
        {
            // 1-đã tt, 0-chưa tt , # deff
            id_nguoidung = id_nhanVien;
            InitializeComponent();
            khoiTaoBangKhachHang();
        }

        private void F_ThanhToan_Load(object sender, EventArgs e)
        {
            Load_tenKhachHang();
            load_thanhToan();
        }
        async void load_thanhToan()
        {
            try
            {
                var ketQua = GetdanhSachThanhToan_trangthai(5);
                if (ketQua != null)
                {
                    bindingSource.DataSource = ketQua;
                    dtg_thanhToan.DataSource = bindingSource;

                    await Task.Delay(500);
                    doiTenBang();

                }
                else
                {
                    MessageBox.Show("Tải dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tải dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.StackTrace); return;
            }
        }
        void khoiTaoBangKhachHang()
        {
            dtg_khachHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PropertyColumn",
                HeaderText = "Thuộc tính",
                Width = 150
            });

            // Thêm cột "Giá trị"
            dtg_khachHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ValueColumn",
                HeaderText = "Giá trị",
                Width = 250,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dtg_khachHang.Columns["ValueColumn"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtg_khachHang.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtg_khachHang.RowTemplate.Height = 40; // Độ cao mặc định

            dtg_khachHang.RowHeadersVisible = false;
            dtg_khachHang.ColumnHeadersVisible = false;
            dtg_khachHang.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtg_khachHang.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dtg_khachHang.BackgroundColor = SystemColors.Control;

        }

        private void dtg_thanhToan_SelectionChanged(object sender, EventArgs e)
        {
            if (dtg_thanhToan.CurrentRow == null) return;

            // Kiểm tra null an toàn hơn
            var khachHangID = dtg_thanhToan.CurrentRow.Cells["KhachHangID"].Value?.ToString();
            if (string.IsNullOrEmpty(khachHangID)) return;

            if (khachHangID != null)
            {
                int thanhToanID = Convert.ToInt32(dtg_thanhToan.CurrentRow.Cells["ThanhToanID"].Value);
                ThanhToan tt = context.ThanhToan.Where(r => r.ThanhToanID == thanhToanID).Include(t => t.HoaDon).First();
                panel_trangThai.Enabled = true;
                if (tt != null && tt.HoaDon.PhuongThucThanhToan.Equals(enum_ThongTin.enum_PhuongThucThanhToan.TraGop.ToString()) ||
                    tt.TrangThaiThanhToan.Equals(enum_ThongTin.enum_TrangThaiThanhToan.DaThanhToan.ToString()) ||
                    tt.HoaDon.TrangThai.Equals(enum_ThongTin.enum_HoaDon.DaHuy.ToString()))
                {
                    panel_trangThai.Enabled = false;
                }

            }

            if (int.TryParse(khachHangID, out int id))
            {
                if (id == 0) return;
                khachHang = context.KhachHang.Find(id);
                if (khachHang != null)
                {
                    dtg_khachHang.Rows.Clear();
                    AddVerticalRow("Họ và tên", khachHang.HoVaTen ?? "N/A");
                    AddVerticalRow("Giới tính", khachHang.GioiTinh == 0 ? "Nam" : "Nữ");
                    AddVerticalRow("Ngày sinh", khachHang.NgaySinh?.ToString("dd/MM/yyyy") ?? "N/A");
                    AddVerticalRow("Số điện thoại", khachHang.DienThoai ?? "N/A");
                    AddVerticalRow("Email", khachHang.Email ?? "N/A");

                    // Thông tin CCCD
                    AddVerticalRow("Số CCCD", khachHang.CCCD ?? "N/A");
                    AddVerticalRow("Ngày cấp CCCD", khachHang.NgayCapCCCD?.ToString("dd/MM/yyyy") ?? "N/A");
                    AddVerticalRow("Nơi cấp CCCD", khachHang.NoiCapCCCD ?? "N/A");

                    // Địa chỉ
                    AddVerticalRow("Địa chỉ thường trú", khachHang.DiaChiThuongTru ?? "N/A");
                    AddVerticalRow("Địa chỉ liên hệ", khachHang.DiaChiLienHe ?? "N/A");

                    // Thông tin nghề nghiệp
                    AddVerticalRow("Nghề nghiệp", khachHang.NgheNghiep ?? "N/A");
                    AddVerticalRow("Nơi làm việc", khachHang.NoiLamViec ?? "N/A");
                    AddVerticalRow("Thu nhập", khachHang.ThuNhap?.ToString("N0") + " VNĐ" ?? "N/A");

                    // Thông tin ngân hàng
                    AddVerticalRow("Số tài khoản", khachHang.STK_NganHang ?? "N/A");
                    AddVerticalRow("Tên ngân hàng", khachHang.TenNganHang ?? "N/A");

                    // Thông tin tín dụng
                    AddVerticalRow("Điểm tín dụng", khachHang.CreditScore?.ToString() ?? "N/A");
                    AddVerticalRow("Hạn mức tín dụng", khachHang.HanMucTinDung.ToString("N0") + " VNĐ");
                }
            }
        }
        public List<DanhSachThanhToan> GetDanhSachThanhToan_theoID(int name)
        {
            var query = context.ThanhToan
                .Include(t => t.HoaDon)
                .ThenInclude(h => h.KhachHang)
                .AsQueryable(); // Giữ ở dạng IQueryable để có thể thêm điều kiện

            // Thêm điều kiện lọc nếu có tên khách hàng
            if (name != 0)
            {
                query = query.Where(t => t.HoaDon.KhachHang.KhachHangID.Equals(name) && t.HoaDon.IsDeleted == 0);
            }

            var danhSachThanhToans = query
                .Select(k => new DanhSachThanhToan
                {
                    HoaDonID = k.HoaDonID,
                    ThanhToanID = k.ThanhToanID,
                    TenNhanVien = k.HoaDon.NhanVien.TenDangNhap,
                    KhachHangID = k.HoaDon.KhachHangID,
                    TenKhachHang = k.HoaDon.KhachHang.HoVaTen,
                    PhuongThucThanhToan = k.PhuongThucThanhToan,
                    SoTienThanhToan = k.SoTienThanhToan,
                    NgayLap = k.NgayLap,
                    NgayThanhToan = k.NgayThanhToan,
                    TrangThaiThanhToan = k.TrangThaiThanhToan,
                    TrangThaiHoaDon = k.HoaDon.TrangThai,
                    GhiChuHoaDon = k.HoaDon.GhiChuHoaDon
                })
                .ToList();
            return danhSachThanhToans;
        }

        private void btn_timKiem_Click(object sender, EventArgs e)
        {
            try
            {
                load_thanhToan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
                return;
            }
        }

        private void btn_xacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtg_thanhToan.CurrentRow == null)
                {
                    MessageBox.Show("Chọn 1 hàng muốn chỉnh sữa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (!int.TryParse(dtg_thanhToan.CurrentRow.Cells["HoaDonID"].Value?.ToString(), out int id))
                {
                    MessageBox.Show("Không thể xác định hóa đơn",
                                  "Lỗi",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                    return;
                }
                NhanVien nhanVienDangNhap = context.NhanVien.Find(id_nguoidung);
                int id_nhanVienLap = Convert.ToInt32(dtg_thanhToan.CurrentRow.Cells["NhanVienID"].Value.ToString());
                var nhanVien = context.NhanVien.Find(id_nhanVienLap);

                if (nhanVien != null)
                {
                    if (nhanVien.KhuVucID != nhanVienDangNhap?.KhuVucID)
                    {
                        MessageBox.Show($"Bạn không có quyền chỉnh sửa hóa đơn này\nHãy liên hệ với nhân viên {nhanVien.HoVaTen} để được hỗ trợ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else { MessageBox.Show("Không tìm thấy nhân viên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                HoaDon hd = context.HoaDon.Where(r => r.HoaDonID == id).First();
                if (hd != null)
                {
                  
                    if (hd.PhuongThucThanhToan == (enum_ThongTin.enum_PhuongThucThanhToan.TraGop).ToString())
                    {
                        MessageBox.Show($"Không thể thay đổi trạng thái của khách hàng: {hd.KhachHang.HoVaTen}\nDo đây là hóa đơn trả góp !!",
                                 "Chưa đến lúc thay đổi",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                        return;
                    }
                    if (hd.TrangThai == (enum_ThongTin.enum_HoaDon.DaHuy).ToString())
                    {
                        MessageBox.Show($"Không thể thay đổi trạng thái của khách hàng: {hd.KhachHang.HoVaTen}\n Do hóa đơn đã bị hủy !!",
                                 "Chưa đến lúc thay đổi",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                        return;
                    }
                    if (hd.TrangThai == (enum_ThongTin.enum_HoaDon.DaThanhToan).ToString())
                    {
                        MessageBox.Show($"Không thể thay đổi trạng thái của khách hàng: {hd.KhachHang.HoVaTen}\n Do hóa đơn đã được thanh toán !!",
                                 "Chưa đến lúc thay đổi",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                        return;
                    }

                    if (MessageBox.Show($"Bạn có chắc chắc muốn đổi trạng thái thanh toán\ncủa khách hàng: {hd.KhachHang.HoVaTen} không ?", "Lưu ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        ThanhToan tt = context.ThanhToan.Where(r => r.HoaDonID == id).First();
                        if (tt != null)
                        {
                            string trangThai = ((enum_ThongTin.enum_TrangThaiThanhToan)cbb_trangThaiTT.SelectedValue).ToString();
                           
                            if (trangThai.Equals("DaThanhToan"))
                            {
                                tt.TrangThaiThanhToan = ((enum_ThongTin.enum_TrangThaiThanhToan)cbb_trangThaiTT.SelectedValue).ToString();
                                string ghiChu = $"Đã thanh toán bởi {nhanVien?.HoVaTen} vào lúc {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";
                                if (!string.IsNullOrEmpty(txt_ghiChu.Text))
                                {
                                    ghiChu = txt_ghiChu.Text.Trim();
                                }
                                tt.GhiChuHoaDon = ghiChu;
                                tt.NgayThanhToan = DateTime.Now;
                                hd.TrangThai = (enum_ThongTin.enum_HoaDon.DaThanhToan).ToString();
                                hd.GhiChuHoaDon = "Đã thanh toán";
                                context.HoaDon.Update(hd);
                                context.ThanhToan.Update(tt);
                            }
                            else
                            {
                                tt.TrangThaiThanhToan = ((enum_ThongTin.enum_TrangThaiThanhToan)cbb_trangThaiTT.SelectedValue).ToString();
                                string ghiChu = $"Đã sửa bởi {nhanVien?.HoVaTen} vào lúc {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";
                                if (!string.IsNullOrEmpty(txt_ghiChu.Text))
                                {
                                    ghiChu = txt_ghiChu.Text.Trim();
                                }
                                tt.GhiChuHoaDon = ghiChu;
                                ghiChu = "đang cập nhật hồ sơ...";
                                hd.GhiChuHoaDon = ghiChu;
                                context.HoaDon.Update(hd);
                                context.ThanhToan.Update(tt);
                            }
                        }
                        context.SaveChanges();
                        load_thanhToan();
                        MessageBox.Show("Đã chỉnh sữa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("không tìm thấy hóa đơn");

                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source);
            }
        }

        private void pictureBox_troVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbb_searchBytrangThaiHoaDon_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btn_timKiem.ForeColor = Color.Red;
            if (cbb_searchBytrangThaiHoaDon.SelectedIndex == -1) return;
            panel_trangThai.Enabled = panel_thongTinKhachHang.Enabled = true;
            switch (cbb_searchBytrangThaiHoaDon.SelectedValue)
            {
                case 0:
                    dtg_thanhToan.DataSource = GetdanhSachThanhToan_trangthai(0);// đã thanh toán
                    doiTenBang();
                    break;
                case 1:
                    dtg_thanhToan.DataSource = GetdanhSachThanhToan_trangthai(1); // đang thanh toán
                    doiTenBang();
                    break;
                case 2:
                    panel_trangThai.Enabled = panel_thongTinKhachHang.Enabled = false;
                    dtg_thanhToan.DataSource = GetdanhSachThanhToan_trangthai(2); // chưa thanh toán
                    doiTenBang();
                    break;
                case 3:
                    dtg_thanhToan.DataSource = GetdanhSachThanhToan_trangthai(3);// đã hủy
                    doiTenBang();
                    break;
                case 4:
                    dtg_thanhToan.DataSource = GetdanhSachThanhToan_trangthai(4); // đã khôi phục
                    doiTenBang();
                    break;
            }

        }

        private void cbb_timKiemTenKH_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btn_timKiem.ForeColor = Color.Red;
            if (cbb_timKiemTenKH.SelectedIndex == -1) return;
            int id = Convert.ToInt32(cbb_timKiemTenKH.SelectedValue) == 0 ? 0 : Convert.ToInt32(cbb_timKiemTenKH.SelectedValue);
            KhachHang k = context.KhachHang.Find(id);
            if (k == null) { MessageBox.Show("Không có khách hàng này trong danh sách", "Lỗi tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            try
            {
                if (cbb_timKiemTenKH.Items.Count == 0)
                    return;

                var ketQua = GetDanhSachThanhToan_theoID(id);
                if (!ketQua.Any())
                {
                    btn_timKiem.ForeColor = Color.Chartreuse;
                    MessageBox.Show($"Không tìm thấy hóa đơn của Khách hàng {cbb_timKiemTenKH.Text.ToString()} \nMã số {id} !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    dtg_thanhToan.DataSource = ketQua;
                    dtg_thanhToan.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tìm kiếm", "Lỗi");
            }
        }
        #endregion

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            F_Help helpForm = new F_Help("thanhtoan"); // "login" là tên tương ứng file login.txt
            helpForm.ShowDialog();
        }

        private void panel_thongTinKhachHang_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
