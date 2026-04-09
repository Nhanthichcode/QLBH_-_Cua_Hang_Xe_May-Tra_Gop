using DoAnBanHang_cuahangxemay.Data_Table;
using DoAnBanHang_cuahangxemay.help;
using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DoAnBanHang_cuahangxemay.Data_Table.enum_ThongTin;

namespace DoAnBanHang_cuahangxemay.Forms
{
    public partial class F_TraGop : Form
    {
        AppDbContext context = new AppDbContext();
        BindingSource binding = new BindingSource();
        List<DanhSachTraGop> danhSachTraGops = new List<DanhSachTraGop>();
        private decimal tmp_tongTienCuaHoaDon;
        decimal tmp_tongTienCacLanThanhToan;
        int id_hoaDonseLectecd;
        bool isDaThanhToan = false;

        #region Methods
        void reSetValue()
        {
            txt_tienLai.DataBindings.Clear();
            txt_laiSuat.DataBindings.Clear();
            txt_soKyHan.DataBindings.Clear();
            txt_kyTra.DataBindings.Clear();
            txt_hoVaTen.DataBindings.Clear();
            txt_soTienGoc.DataBindings.Clear();
            txt_soTienConLai.ResetText();
            txt_soTienDaThanhToan.ResetText();
            txt_soTienHoaDon.DataBindings.Clear();
            txt_trangThai.DataBindings.Clear();
            dtg_traGop.DataBindings.Clear();
            dtp_ngayTra.DataBindings.Clear();
            dtp_ngayDenHan.DataBindings.Clear();

            tmp_tongTienCacLanThanhToan = 0;
            tmp_tongTienCuaHoaDon = 0;
            binding.DataSource = null;
        }

        void kiemTraHoaDon(int hoadonID)
        {
            var traGop = context.TraGop
            .FirstOrDefault(r => r.HoaDonID == hoadonID);
            if (traGop == null)
            {
                btn_suaTrangThai.Enabled = btn_thanhToan.Enabled = false;
                return;
            }
            var trangThaiTT = traGop.TrangThai?.Trim().ToLower();

            // Kiểm tra nếu tất cả các kỳ đã thanh toán

            var danhSachTraGop = context.TraGop
            .Where(r => r.HoaDonID == hoadonID)
            .ToList();
            bool isAllPaid = danhSachTraGop.All(r => r.NgayThanhToan != null);
            if (isAllPaid)
            {
                btn_thanhToan.Enabled = false;
                btn_suaTrangThai.Enabled = danhSachTraGop.Any(r => r.NgayThanhToan == null);
            }
            else
            {
                btn_thanhToan.Enabled = true;
                btn_suaTrangThai.Enabled = danhSachTraGop.Any(r => r.NgayThanhToan != null);
            }
        }
        public List<DanhSachTraGop> Load_traGopTheoID_HoaDon(int id)
        {
            if (id == 0) return new List<DanhSachTraGop>();
            isDaThanhToan = false;
            btn_thanhToan.Enabled = !rdb_daHoanThanh.Checked;
            try
            {
                var query = context.TraGop
                .Include(t => t.HoaDon)
                .ThenInclude(h => h.KhachHang)
                .Where(t => t.HoaDonID == id && t.HoaDon.IsDeleted == 0);

                var danhSachTraGop = query
                    .OrderBy(t => t.KyTra)
                    .Select(k => new DanhSachTraGop
                    {
                        TraGopID = k.TraGopID,
                        HoaDonID = k.HoaDonID,
                        KhachHangID = k.HoaDon.KhachHangID,
                        HoVaTen = k.HoaDon.KhachHang.HoVaTen,
                        SoTienGoc = Math.Round(k.SoTienGoc, 2),
                        laiSuat = k.laiSuat,
                        SoTienLai = Math.Round(k.SoTienLai, 2),
                        SoKyHan = k.SoKyHan,
                        KyTra = k.KyTra,
                        soTienCanDong = Math.Round((k.SoTienGoc / (decimal)k.SoKyHan) + k.SoTienLai, 2),
                        SoTienConLai = Math.Round(k.SoTienConLai, 2),
                        NgayDenHan = k.NgayDenHan,
                        NgayThanhToan = k.NgayThanhToan,
                        TrangThai = k.HoaDon.TrangThai ?? "",
                        TrangThaiTraGop = k.TrangThai,
                        GhiChuHoaDon = k.HoaDon.GhiChuHoaDon ?? ""
                    })
                    .AsNoTracking()
                    .ToList();

                tmp_tongTienCacLanThanhToan = danhSachTraGop
                    .Where(t => t.NgayThanhToan != null) // Chỉ tính các khoản đã thanh toán
                    .Sum(t => t.soTienCanDong);

                txt_soTienDaThanhToan.Text = string.Format("{0:N2}", tmp_tongTienCacLanThanhToan) + " VNĐ";

                decimal tienGoc = danhSachTraGop.Select(t => t.SoTienGoc).First();
                decimal tienLai = danhSachTraGop.Sum(t => t.SoTienLai);

                tmp_tongTienCuaHoaDon = tienGoc + tienLai;
                txt_soTienHoaDon.Text = string.Format("{0:N2}", tmp_tongTienCuaHoaDon) + " VNĐ";
                txt_soTienGoc.Text = string.Format("{0:N2}", tienGoc) + " VNĐ";
                txt_soTienConLai.Text = string.Format("{0:N2}", tmp_tongTienCuaHoaDon - tmp_tongTienCacLanThanhToan) + " VNĐ";
                var countKyHan = danhSachTraGop.Count(r => r.NgayThanhToan == null).ToString();
                if (int.Parse(countKyHan) == 0)// count = 0 có nghĩa đã hoàn thành all các kì
                {
                    isDaThanhToan = true;
                }
                return danhSachTraGop;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu !!", "Lỗi");
                return new List<DanhSachTraGop>();
            }
        }

        void Load_danhSachKhachHangTraGop()
        {
            var danhSachKhachHangTraGop = context.HoaDon
             .Where(hd => (hd.IsDeleted == 0) &&
                (hd.PhuongThucThanhToan.Trim().Equals(enum_ThongTin.enum_PhuongThucThanhToan.TraGop.ToString()) &&
                hd.TrangThai == (enum_ThongTin.enum_HoaDon.DangThanhToan.ToString())) ||
                (hd.PhuongThucThanhToan.Trim().Equals(enum_ThongTin.enum_PhuongThucThanhToan.TraGop.ToString()) && 
                hd.TrangThai == (enum_ThongTin.enum_HoaDon.ChuaThanhToan.ToString())) )
             .Select(hd => new DanhSachTraGop
             {
                 HoaDonID = hd.HoaDonID,
                 TraGopID = hd.TraGop.FirstOrDefault() != null ? hd.TraGop.FirstOrDefault().TraGopID : 0,
                 HoVaTen = hd.KhachHang.HoVaTen,
                 TrangThai = hd.TrangThai,
                 SoKyHan = hd.TraGop != null ? hd.TraGop.Count : 0,
                 DisplayText = $"HĐ_{hd.HoaDonID}<>{hd.KhachHang.HoVaTen}"
             })
             .ToList();
            if (danhSachKhachHangTraGop.Count == 0)
            {
                cbb_tenKhachHang.Text = "Không có hóa đơn nào trả góp";
            }
            cbb_tenKhachHang.DisplayMember = "DisplayText";
            cbb_tenKhachHang.ValueMember = "HoaDonID";
            cbb_tenKhachHang.DataSource = danhSachKhachHangTraGop;
        }
        #endregion

        #region Event
        private void label17_Click_1(object sender, EventArgs e)
        {
            F_Help helpForm = new F_Help("tragop"); // "login" là tên tương ứng file login.txt
            helpForm.ShowDialog();
        }

        public F_TraGop(int key)
        {
            InitializeComponent();
        }

        private void F_TraGop_Load(object sender, EventArgs e)
        {
            Load_danhSachKhachHangTraGop();
            btn_suaTrangThai.Enabled = btn_thanhToan.Enabled = false;
        }

        private void btn_xemChiTiet_Click(object sender, EventArgs e)
        {
            btn_suaTrangThai.Enabled = btn_thanhToan.Enabled = false;
            enum_ThongTin.enum_HoaDon trangThaihoaDon = enum_ThongTin.enum_HoaDon.ChuaThanhToan; // gán giá trị để không lỗi
            try
            {
                if (da_rdb_chuaHoanThanh.Checked)
                {
                    trangThaihoaDon = enum_ThongTin.enum_HoaDon.DangThanhToan;
                }
                if (rdb_daHoanThanh.Checked)
                {
                    trangThaihoaDon = enum_ThongTin.enum_HoaDon.DaThanhToan;
                }

                var query = context.HoaDon
                    .Where(r => r.PhuongThucThanhToan != null
                    && r.PhuongThucThanhToan.Equals(enum_ThongTin.enum_PhuongThucThanhToan.TraGop.ToString())
                    && r.TrangThai != null
                    && r.TrangThai.Equals(trangThaihoaDon.ToString()))
                    .Select(r => new DanhSachHoaDon
                    {
                        HoaDonID = r.HoaDonID,
                        KhachHangID = r.KhachHangID,
                        TenKhachHang = r.KhachHang != null ? r.KhachHang.HoVaTen : "Không xác định",
                        NhanVienID = r.NhanVienID,
                        TenNhanVien = r.NhanVien != null ? r.NhanVien.HoVaTen : "Không xác định",
                        PhuongThucThanhToan = r.PhuongThucThanhToan,
                        TrangThai = r.TrangThai,
                        TongTien = r.HoaDon_ChiTiet != null
                                    ? r.HoaDon_ChiTiet.Sum(ct => ct.SoLuongBan * ct.DonGia)
                                    : 0,
                        NgayLap = r.NgayLap,
                        GhiChuHoaDon = r.GhiChuHoaDon
                    });

                // Thực thi truy vấn và binding dữ liệu
                dtg_traGop.DataSource = query.ToList();
                _doiTenBangHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm:\n" + ex.Message, "Lỗi");
            }
        }

        void _doiTenBangHoaDon()
        {
            dtg_traGop.Columns["KhachHangID"].Visible = false;
            dtg_traGop.Columns["NhanVienID"].Visible = false;
            dtg_traGop.Columns["TenNhanVien"].Visible = false;
            dtg_traGop.Columns["IsDeleted"].Visible = false;
            dtg_traGop.Columns["HoaDonID"].HeaderText = "Mã HĐ";
            dtg_traGop.Columns["TenKhachHang"].HeaderText = "Tên khách hàng";
            dtg_traGop.Columns["TongTien"].HeaderText = "Tổng tiền";
            dtg_traGop.Columns["TongTien"].DefaultCellStyle.Format = "#,##0 'VNĐ'";
            dtg_traGop.Columns["NgayLap"].HeaderText = "Ngày lập";
            dtg_traGop.Columns["PhuongThucThanhToan"].Visible = false;
            dtg_traGop.Columns["PhuongThucThanhToanValue"].Visible = false;
            dtg_traGop.Columns["PhuongThucThanhToanVietnamese"].HeaderText = "Phương thức thanh toán";
            dtg_traGop.Columns["TrangThai"].Visible = false;
            dtg_traGop.Columns["TrangThaiValue"].Visible = false;
            dtg_traGop.Columns["TrangThaiVietnamese"].HeaderText = "Trạng thái";
            dtg_traGop.Columns["GhiChuHoaDon"].HeaderText = "Ghi chú";

        }
        void _doiTenBangDSTraGop()
        {
            try
            {
                txt_hoVaTen.DataBindings.Clear();
                txt_hoVaTen.DataBindings.Add("Text", binding, "HoVaTen", false, DataSourceUpdateMode.Never);
                txt_laiSuat.DataBindings.Clear();
                txt_laiSuat.DataBindings.Add("Text", binding, "laiSuat", false, DataSourceUpdateMode.Never);
                txt_soKyHan.DataBindings.Clear();
                txt_soKyHan.DataBindings.Add("Text", binding, "SoKyHan", false, DataSourceUpdateMode.Never);
                txt_kyTra.DataBindings.Clear();
                txt_kyTra.DataBindings.Add("Text", binding, "KyTra", false, DataSourceUpdateMode.Never);


                txt_tienLai.DataBindings.Clear();
                txt_tienLai.DataBindings.Add("Text", binding, "SoTienLai", false, DataSourceUpdateMode.Never);
                txt_trangThai.DataBindings.Clear();
                txt_trangThai.DataBindings.Add("Text", binding, "TrangThai", false, DataSourceUpdateMode.Never);
                dtp_ngayDenHan.DataBindings.Clear();
                dtp_ngayDenHan.DataBindings.Add("Value", binding, "NgayDenHan", false, DataSourceUpdateMode.Never);
                dtp_ngayTra.DataBindings.Clear();
                dtp_ngayTra.DataBindings.Add("Value", binding, "NgayThanhToan", true, DataSourceUpdateMode.Never, null);
                txt_ghiChuTraGop.DataBindings.Clear();
                txt_ghiChuTraGop.DataBindings.Add("Text", binding, "GhiChuHoaDon", false, DataSourceUpdateMode.Never);

                dtg_traGop.Columns["TraGopID"].Visible = false;
                dtg_traGop.Columns["HoaDonID"].Visible = false;
                dtg_traGop.Columns["KhachHangID"].Visible = false;
                dtg_traGop.Columns["DisplayText"].Visible = false;
                dtg_traGop.Columns["SoKyHan"].Visible = false;
                dtg_traGop.Columns["KyTra"].Visible = false;
                dtg_traGop.Columns["laiSuat"].Visible = false;
                dtg_traGop.Columns["HoVaTen"].Visible = false;
                dtg_traGop.Columns["SoTienLai"].Visible = false;
                dtg_traGop.Columns["GhiChuHoaDon"].Visible = false;
                dtg_traGop.Columns["TrangThaiValue"].Visible = false;
                dtg_traGop.Columns["TrangThaiTraGop"].Visible = false;
                dtg_traGop.Columns["TrangThaiTraGopValue"].Visible = false;
                dtg_traGop.Columns["SoTienGoc"].Visible = false;
                dtg_traGop.Columns["TrangThai"].Visible = false;
                dtg_traGop.Columns["TrangThaiTraGopVietNamenamese"].Visible = false;

                dtg_traGop.Columns["TrangThaiVietnamese"].HeaderText = "Trạng thái trả góp";
                dtg_traGop.Columns["HoVaTen"].HeaderText = "Họ và tên";
                dtg_traGop.Columns["SoKyHan"].HeaderText = "Số kì hạn";
                dtg_traGop.Columns["KyTra"].HeaderText = "Kì trả";
                dtg_traGop.Columns["laiSuat"].HeaderText = "Lãi suất";
                dtg_traGop.Columns["soTienCanDong"].DefaultCellStyle.Format = "#,##0 'VNĐ'";
                dtg_traGop.Columns["soTienCanDong"].HeaderText = "Tiền cần đóng";
                dtg_traGop.Columns["SoTienGoc"].DefaultCellStyle.Format = "#,##0 'VNĐ'";
                dtg_traGop.Columns["SoTienLai"].HeaderText = "Số tiền lãi";
                dtg_traGop.Columns["SoTienConLai"].HeaderText = "Số tiền còn lại";
                dtg_traGop.Columns["SoTienConLai"].DefaultCellStyle.Format = "#,##0 'VNĐ'";
                dtg_traGop.Columns["NgayDenHan"].HeaderText = "Ngày đến kì trả";
                dtg_traGop.Columns["NgayThanhToan"].HeaderText = "Ngày thanh toán";

                foreach (DataGridViewRow row in dtg_traGop.Rows)
                {
                    // Giả sử cột "TrangThai" có giá trị "Thanh toán" muốn được highlight
                    if (row.Cells["TrangThaiTraGop"].Value != null && row.Cells["TrangThaiTraGop"].Value.ToString() == enum_ThongTin.enum_TrangThaiThanhToan.DaThanhToan.ToString())
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi binding: " + ex.StackTrace, "Lỗi"); }
        }
        //    dtg_traGop.Columns["TrangThaiTraGop"].Visible = false;
        //    dtg_traGop.Columns["TrangThaiTraGopValue"].Visible = false;
        //    dtg_traGop.Columns["TrangThaiTraGopnamese"].Visible = false;
        //    dtg_traGop.Columns["KhachHangID"].Visible = false;
        //    dtg_traGop.Columns["TraGopID"].Visible = false;
        //    dtg_traGop.Columns["HoaDonID"].Visible = false;
        //    dtg_traGop.Columns["HoVaTen"].HeaderText = "Họ Tên KH";
        //    dtg_traGop.Columns["SoTienGoc"].HeaderText = "Tổng tiền";
        //    dtg_traGop.Columns["SoTienGoc"].DefaultCellStyle.Format = "#,##0 '₫'";
        //    dtg_traGop.Columns["TrangThai"].Visible = false;
        //    dtg_traGop.Columns["TrangThaiValue"].Visible = false;
        //    dtg_traGop.Columns["TrangThaiVietnamese"].HeaderText = "Trạng thái trả góp";
        //    dtg_traGop.Columns["SoKyHan"].Visible = false;
        //    dtg_traGop.Columns["KyTra"].Visible = false;
        //    dtg_traGop.Columns["laiSuat"].Visible = false;
        //    dtg_traGop.Columns["SoTienLai"].Visible = false;
        //    dtg_traGop.Columns["soTienCanDong"].Visible = false;
        //    dtg_traGop.Columns["SoTienConLai"].Visible = false;
        //    dtg_traGop.Columns["GhiChuHoaDon"].Visible = false;
        //    dtg_traGop.Columns["NgayThanhToan"].HeaderText = "Ngày thanh toán";
        //    dtg_traGop.Columns["DisplayText"].Visible = false;
        //    dtg_traGop.Columns["NgayDenHan"].HeaderText = "Ngày đến hạn";
        //}
        void thucHienThanhToan()
        {
            if (dtg_traGop.Rows.Count == 0 || cbb_tenKhachHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int hoaDonID = (int)cbb_tenKhachHang.SelectedValue;
            var traGop = context.TraGop
                .FirstOrDefault(r => r.HoaDonID == hoaDonID && r.NgayThanhToan == null);

            if (traGop == null)
            {
                MessageBox.Show("Không còn kỳ nào để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            HoaDon hd = context.HoaDon.Find(hoaDonID);
            if (hd == null)
            {
                MessageBox.Show("Không tìm thấy hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ThanhToan tt = context.ThanhToan.Where(r => r.HoaDonID == hoaDonID).First();
            if (tt == null)
            {
                MessageBox.Show("Không tìm thấy hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Cập nhật thanh toán kỳ hiện tại
            traGop.NgayThanhToan = DateTime.Now;
            traGop.TrangThai = enum_ThongTin.enum_TrangThaiThanhToan.DaThanhToan.ToString();
            context.TraGop.Update(traGop);

            hd.GhiChuHoaDon = $"Đã trả {traGop.KyTra}/{traGop.SoKyHan} lần";
            context.HoaDon.Update(hd);

            tt.GhiChuHoaDon = $"Đã trả {traGop.KyTra}/{traGop.SoKyHan} lần";
            context.ThanhToan.Update(tt);

            context.SaveChanges();

            // Kiểm tra xem đã thanh toán hết chưa
            var danhSachTraGop = context.TraGop
                .Where(r => r.HoaDonID == hoaDonID)
                .ToList();

            bool isAllPaid = danhSachTraGop.All(r => r.NgayThanhToan != null);

            if (isAllPaid)
            {

                hd.TrangThai = (enum_ThongTin.enum_HoaDon.DaThanhToan).ToString();
                hd.GhiChuHoaDon = (enum_ThongTin.GetDescription(enum_ThongTin.enum_HoaDon.DaThanhToan)).ToString() + " Ngày: " + DateTime.Now;
                tt.TrangThaiThanhToan = (enum_ThongTin.enum_HoaDon.DaThanhToan).ToString();
                tt.GhiChuHoaDon = hd.GhiChuHoaDon = (enum_ThongTin.GetDescription(enum_ThongTin.enum_HoaDon.DaThanhToan)).ToString() + " Ngày: " + DateTime.Now;
                tt.NgayThanhToan = DateTime.Now;

                context.SaveChanges();

                MessageBox.Show("Đã hoàn thành tất cả các kỳ thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Tải lại dữ liệu và cập nhật giao diện
            binding.DataSource = Load_traGopTheoID_HoaDon(hoaDonID);
            dtg_traGop.DataSource = binding;
            _doiTenBangDSTraGop();
            kiemTraHoaDon(hoaDonID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btn_thanhToan.Enabled = false;
            try
            {
                thucHienThanhToan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật hóa đơn", "Thông báo");
            }
        }

        private void pictureBox_troVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void SuaHoaDon()
        {
            if (cbb_tenKhachHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int hoaDonID = (int)cbb_tenKhachHang.SelectedValue;

            // Tìm kỳ thanh toán cuối cùng đã được thanh toán
            var lastPaidTraGop = context.TraGop
                .Where(r => r.HoaDonID == hoaDonID && r.NgayThanhToan != null)
                .OrderByDescending(r => r.KyTra)
                .FirstOrDefault();

            if (lastPaidTraGop == null)
            {
                MessageBox.Show("Không có kỳ nào đã thanh toán để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Bạn có muốn hủy thanh toán kỳ {lastPaidTraGop.KyTra} không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                lastPaidTraGop.NgayThanhToan = null;
                lastPaidTraGop.TrangThai = enum_ThongTin.enum_HoaDon.ChuaThanhToan.ToString();

                context.TraGop.Update(lastPaidTraGop);
                context.SaveChanges();

                // Cập nhật trạng thái hóa đơn
                HoaDon hd = context.HoaDon.Find(hoaDonID);
                if (hd == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                hd.GhiChuHoaDon = $"Đã trả {lastPaidTraGop.KyTra - 1}/{lastPaidTraGop.SoKyHan} lần";
                //hd.GhiChuHoaDon = enum_ThongTin.GetDescription(enum_ThongTin.enum_HoaDon.DangThanhToan);
                context.HoaDon.Update(hd);

                ThanhToan tt = context.ThanhToan.Where(r => r.HoaDonID == hoaDonID).First();
                if (tt == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                tt.GhiChuHoaDon = $"Đã trả {lastPaidTraGop.KyTra - 1}/{lastPaidTraGop.SoKyHan}  lần";
                //tt.GhiChuHoaDon = enum_ThongTin.GetDescription(enum_ThongTin.enum_HoaDon.DangThanhToan);
                context.ThanhToan.Update(tt);

                context.SaveChanges();

                var chuaThanhToan = context.TraGop.All(r => r.HoaDonID == hoaDonID && r.NgayThanhToan == null);
                if (chuaThanhToan)
                {
                    hd.TrangThai = (enum_ThongTin.enum_HoaDon.ChuaThanhToan).ToString();
                    hd.GhiChuHoaDon = "";
                    context.HoaDon.Update(hd);
                    tt.TrangThaiThanhToan = (enum_ThongTin.enum_HoaDon.ChuaThanhToan).ToString();
                    context.ThanhToan.Update(tt);
                    lastPaidTraGop.TrangThai = (enum_ThongTin.enum_HoaDon.ChuaThanhToan).ToString();
                    context.TraGop.Update(lastPaidTraGop);
                    context.SaveChanges();
                }

                // Tải lại dữ liệu và cập nhật giao diện
                binding.DataSource = Load_traGopTheoID_HoaDon(hoaDonID);
                dtg_traGop.DataSource = binding;
                _doiTenBangDSTraGop();
                kiemTraHoaDon(hoaDonID);
            }
        }

        private void btn_suaTrangThai_Click(object sender, EventArgs e)
        {
            try
            {
                SuaHoaDon();
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật hóa đơn", "Thông báo");
            }
        }

        private void cbb_tenKhachHang_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btn_suaTrangThai.Enabled = btn_thanhToan.Enabled = false;
            if (cbb_tenKhachHang.SelectedIndex == -1) return;
            id_hoaDonseLectecd = int.TryParse(cbb_tenKhachHang.SelectedValue?.ToString(), out id_hoaDonseLectecd) ? id_hoaDonseLectecd : 0;
            var ketQua = Load_traGopTheoID_HoaDon(id_hoaDonseLectecd);
            if (ketQua.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hóa đơn của Khách hàng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cbb_tenKhachHang.Focus();
                return;
            }
            binding.DataSource = ketQua;
            dtg_traGop.DataSource = binding;
            _doiTenBangDSTraGop();
            kiemTraHoaDon(id_hoaDonseLectecd);
        }
        #endregion

    }
}
