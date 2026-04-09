using ClosedXML.Excel;
using DoAnBanHang_cuahangxemay.Data_Table;
using DoAnBanHang_cuahangxemay.help;
using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnBanHang_cuahangxemay.Forms
{
    public partial class F_KhachHang : Form
    {
        AppDbContext context = new AppDbContext();
        bool xulythem = false;
        //string isGioiTinh;
        int id_khachhang;
        int id_khachHangKhongDangNhap;
        int id_nguoiDung;
        string image_filePath = "";
        string imageFolder = Application.StartupPath.Replace("bin\\Debug\\net5.0-windows", "avatar");
        public static event EventHandler themKhachHang_troVe;
        BindingSource bindingSource = new BindingSource();
        List<KhachHang> list_khachHangs = new List<KhachHang>();

        #region Methods
        void phanQuyenNguoiDung(bool tmp)
        {
            var nv = context.NhanVien.Find(id_nguoiDung);
            if (nv != null)
            {
                if (nv.QuyenHan)
                {
                    btn_Sua.Enabled = btn_Xoa.Enabled = btn_NhapFile.Enabled = btn_XuatFile.Enabled = btn_DoiAnh.Enabled = false;
                    btn_Them.Enabled = btn_Sua.Enabled = btn_Xoa.Enabled = btn_NhapFile.Enabled = btn_XuatFile.Enabled = btn_DoiAnh.Enabled = tmp;
                    btn_Huy.Enabled = btn_ChonAnh.Enabled = btn_Luulai.Enabled = !tmp;
                }
                else
                {
                    btn_Sua.Enabled = btn_Xoa.Enabled = btn_NhapFile.Enabled = btn_XuatFile.Enabled = btn_DoiAnh.Enabled = btn_ChonAnh.Enabled = false;
                    btn_Them.Enabled = tmp;
                    btn_ChonAnh.Enabled = btn_Huy.Enabled = btn_Luulai.Enabled = !tmp;
                }
            }
        }
        bool _kiemTra()
        {
            // 1. Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(txt_hoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_hoTen.Focus();
                return false;
            }

            // 2. Kiểm tra số điện thoại
            if (string.IsNullOrWhiteSpace(txt_dienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_dienThoai.Focus();
                return false;
            }

            if (!IsValidPhoneNumber(txt_dienThoai.Text.Trim()))
            {
                MessageBox.Show("Số điện thoại không hợp lệ\nĐịnh dạng: 10-11 số, bắt đầu bằng 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_dienThoai.Focus();
                return false;
            }

            // 3. Kiểm tra địa chỉ thường trú
            if (string.IsNullOrWhiteSpace(txt_diaChiThuongTru.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ thường trú", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_diaChiThuongTru.Focus();
                return false;
            }

            // 4. Kiểm tra CCCD (nếu có)
            if (!string.IsNullOrWhiteSpace(txt_soCCCD.Text) && !IsValidCCCD(txt_soCCCD.Text))
            {
                MessageBox.Show("Số CCCD không hợp lệ\nPhải có 12 chữ số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_soCCCD.Focus();
                return false;
            }

            // 5. Kiểm tra email (nếu có)
            if (!string.IsNullOrWhiteSpace(txt_eMail.Text) && !IsValidEmail(txt_eMail.Text))
            {
                MessageBox.Show("Email không hợp lệ\nVí dụ: example@domain.com", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_eMail.Focus();
                return false;
            }

            // 6. Kiểm tra ngày sinh hợp lệ
            if (dtp_ngaySinh.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không thể lớn hơn ngày hiện tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtp_ngaySinh.Focus();
                return false;
            }

            // 7. Kiểm tra thu nhập không âm
            if (num_thuNhap.Value < 0)
            {
                MessageBox.Show("Thu nhập không thể là số âm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                num_thuNhap.Focus();
                return false;
            }
            return true;
        }

        bool IsValidPhoneNumber(string phoneNumber)
        {
            // Pattern cho số điện thoại Việt Nam (10-11 số, bắt đầu bằng 0)
            string pattern = @"^(0[0-9]{9,10})$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        private bool IsValidCCCD(string cccd)
        {
            string pattern = @"^\d{12}$";
            return Regex.IsMatch(cccd, pattern);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        private List<string> DanhSachNoiCapCCCDMau = new List<string>
        {
                "CA TP Hà Nội",
                "CA TP Hồ Chí Minh",
                "CA TP Hải Phòng",
                "CA TP Đà Nẵng",
                "CA TP Cần Thơ",
                "CA tỉnh Hà Giang",
                "CA tỉnh Cao Bằng",
                "CA tỉnh Bắc Kạn",
                "CA tỉnh Tuyên Quang",
                "CA tỉnh Lào Cai",
                "CA tỉnh Điện Biên",
                "CA tỉnh Lai Châu",
                "CA tỉnh Sơn La",
                "CA tỉnh Yên Bái",
                "CA tỉnh Hoà Bình",
                "CA tỉnh Thái Nguyên",
                "CA tỉnh Lạng Sơn",
                "CA tỉnh Quảng Ninh",
                "CA tỉnh Bắc Giang",
                "CA tỉnh Phú Thọ",
                "CA tỉnh Vĩnh Phúc",
                "CA tỉnh Bắc Ninh",
                "CA tỉnh Hải Dương",
                "CA tỉnh Hưng Yên",
                "CA tỉnh Thái Bình",
                "CA tỉnh Hà Nam",
                "CA tỉnh Nam Định",
                "CA tỉnh Ninh Bình",
                "CA tỉnh Thanh Hóa",
                "CA tỉnh Nghệ An",
                "CA tỉnh Hà Tĩnh",
                "CA tỉnh Quảng Bình",
                "CA tỉnh Quảng Trị",
                "CA tỉnh Thừa Thiên Huế",
                "CA tỉnh Quảng Nam",
                "CA tỉnh Quảng Ngãi",
                "CA tỉnh Bình Định",
                "CA tỉnh Phú Yên",
                "CA tỉnh Khánh Hòa",
                "CA tỉnh Ninh Thuận",
                "CA tỉnh Bình Thuận",
                "CA tỉnh Kon Tum",
                "CA tỉnh Gia Lai",
                "CA tỉnh Đắk Lắk",
                "CA tỉnh Đắk Nông",
                "CA tỉnh Lâm Đồng",
                "CA tỉnh Bình Phước",
                "CA tỉnh Tây Ninh",
                "CA tỉnh Bình Dương",
                "CA tỉnh Đồng Nai",
                "CA tỉnh Bà Rịa - Vũng Tàu",
                "CA tỉnh Long An",
                "CA tỉnh Tiền Giang",
                "CA tỉnh Bến Tre",
                "CA tỉnh Trà Vinh",
                "CA tỉnh Vĩnh Long",
                "CA tỉnh Đồng Tháp",
                "CA tỉnh An Giang",
                "CA tỉnh Kiên Giang",
                "CA tỉnh Cần Thơ",
                "CA tỉnh Hậu Giang",
                "CA tỉnh Sóc Trăng",
                "CA tỉnh Bạc Liêu",
                "CA tỉnh Cà Mau"
        };

        private List<string> DanhSachNganHangMau = new List<string>
        {
            "Ngân hàng Ngoại thương Việt Nam (Vietcombank)",
            "Ngân hàng Công thương Việt Nam (VietinBank)",
            "Ngân hàng Đầu tư và Phát triển Việt Nam (BIDV)",
            "Ngân hàng Nông nghiệp và Phát triển Nông thôn Việt Nam (Agribank)",
            "Ngân hàng TMCP Sài Gòn Thương Tín (Sacombank)",
            "Ngân hàng TMCP Á Châu (ACB)",
            "Ngân hàng TMCP Quân đội (MB Bank)",
            "Ngân hàng TMCP Tiên Phong (TPBank)",
            "Ngân hàng TMCP Hàng Hải Việt Nam (MSB)",
            "Ngân hàng TMCP Phát triển TP.HCM (HDBank)",
            "Ngân hàng TMCP Phương Đông (OCB)",
            "Ngân hàng TMCP Quốc Dân (NCB)",
            "Ngân hàng TMCP Việt Á (VietABank)",
            "Ngân hàng TMCP Bản Việt (VietCapital Bank)",
            "Ngân hàng TMCP Đông Nam Á (SeABank)",
            "Ngân hàng TMCP Kiên Long (KienLongBank)",
            "Ngân hàng TMCP Nam Á (NamABank)",
            "Ngân hàng TMCP Bắc Á (BacABank)",
            "Ngân hàng TMCP An Bình (ABBank)",
            "Ngân hàng TMCP Việt Nam Thịnh Vượng (VPBank)",
            "Ngân hàng TMCP Xuất Nhập khẩu Việt Nam (Eximbank)",
            "Ngân hàng TMCP Sài Gòn (SCB)",
            "Ngân hàng TMCP Đông Á (DongABank)",
            "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)",
            "Ngân hàng TMCP Việt Nam Thương Tín (VietBank)",
            "Ngân hàng TMCP Quốc tế Việt Nam (VIB)",
            "Ngân hàng TMCP Xăng dầu Petrolimex (PGBank)",
            "Ngân hàng TMCP Đại Chúng Việt Nam (PVcomBank)",
            "Ngân hàng TMCP Sài Gòn Công Thương (SaigonBank)",
            "Ngân hàng TMCP Đại Dương (OceanBank)",
            "Ngân hàng TMCP Dầu khí Toàn Cầu (GPBank)",
            "Ngân hàng TMCP Bưu điện Liên Việt (LienVietPostBank)",
            "Ngân hàng TMCP Shinhan Việt Nam (Shinhan Bank)",
            "Ngân hàng TMCP HSBC Việt Nam (HSBC Vietnam)",
            "Ngân hàng TMCP Standard Chartered Việt Nam (Standard Chartered Vietnam)",
            "Ngân hàng TMCP Citi Việt Nam (Citibank Vietnam)",
            "Ngân hàng TMCP Đầu tư và Phát triển Campuchia (BIDC)",
            "Ngân hàng TNHH MTV Woori Việt Nam (Woori Bank)",
            "Ngân hàng TNHH MTV Public Việt Nam (PVB)",
            "Ngân hàng TNHH MTV Hong Leong Việt Nam (Hong Leong Bank)",
            "Ngân hàng TNHH MTV United Overseas Bank Việt Nam (UOB Vietnam)",
            "Ngân hàng TNHH MTV Industrial Bank of Korea Việt Nam (IBK Vietnam)",
            "Ngân hàng TNHH MTV KEB Hana Việt Nam (KEB Hana Bank)",
            "Ngân hàng Liên doanh Việt Nga (VRB)",
            "Ngân hàng Liên doanh Indovina (Indovina Bank)",
            "Ngân hàng Liên doanh Việt Thái (VTB)",
            "Ngân hàng Liên doanh Vid Public (Vid Public Bank)"
        };

        void caiDatLai()
        {
            // Ẩn cột ID
            dtg_khachHang.Columns["KhachHangID"].Visible = false;

            // Thiết lập header text và các thuộc tính hiển thị
            dtg_khachHang.Columns["HoVaTen"].HeaderText = "Họ tên";

            dtg_khachHang.Columns["GioiTinh"].Visible = false;
            //dtg_khachHang.Columns["gioiTinhTex"].HeaderText = "Giới tính";

            dtg_khachHang.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dtg_khachHang.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dtg_khachHang.Columns["CCCD"].HeaderText = "Số CCCD";
            dtg_khachHang.Columns["NgayCapCCCD"].HeaderText = "Ngày cấp CCCD";
            dtg_khachHang.Columns["NgayCapCCCD"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtg_khachHang.Columns["NoiCapCCCD"].HeaderText = "Nơi cấp CCCD";

            dtg_khachHang.Columns["DienThoai"].HeaderText = "Điện thoại";
            dtg_khachHang.Columns["Email"].HeaderText = "Email";

            dtg_khachHang.Columns["DiaChiThuongTru"].HeaderText = "Địa chỉ thường trú";
            dtg_khachHang.Columns["DiaChiLienHe"].HeaderText = "Địa chỉ liên hệ";
            dtg_khachHang.Columns["DiaChiThuongTru"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dtg_khachHang.Columns["DiaChiLienHe"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dtg_khachHang.Columns["NgheNghiep"].HeaderText = "Nghề nghiệp";
            dtg_khachHang.Columns["NoiLamViec"].HeaderText = "Nơi làm việc";
            dtg_khachHang.Columns["NoiLamViec"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dtg_khachHang.Columns["ThuNhap"].HeaderText = "Thu nhập";
            dtg_khachHang.Columns["ThuNhap"].DefaultCellStyle.Format = "N0"; // Định dạng số
            dtg_khachHang.Columns["ThuNhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtg_khachHang.Columns["STK_NganHang"].HeaderText = "Số tài khoản";
            dtg_khachHang.Columns["TenNganHang"].HeaderText = "Ngân hàng";
            dtg_khachHang.Columns["TenNganHang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dtg_khachHang.Columns["CreditScore"].HeaderText = "Điểm tín dụng";
            dtg_khachHang.Columns["HanMucTinDung"].HeaderText = "Hạn mức tín dụng";
            dtg_khachHang.Columns["HanMucTinDung"].DefaultCellStyle.Format = "N0";
            dtg_khachHang.Columns["HanMucTinDung"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Ẩn các cột không cần thiết
            dtg_khachHang.Columns["AnhChanDung"].Visible = false;
            dtg_khachHang.Columns["KhuVucID"].Visible = false;
            dtg_khachHang.Columns["KhuVuc"].Visible = false;

            // Thiết lập độ rộng các cột quan trọng
            dtg_khachHang.Columns["HoVaTen"].Width = 150;
            dtg_khachHang.Columns["DienThoai"].Width = 100;
            dtg_khachHang.Columns["NgaySinh"].Width = 90;
            dtg_khachHang.Columns["GioiTinh"].Width = 70;
            dtg_khachHang.Columns["CCCD"].Width = 120;
        }
        void load_khachhang()
        {
            if (id_nguoiDung != 0)
            {
                phanQuyenNguoiDung(true);
                dtg_khachHang.MultiSelect = false;

                list_khachHangs = context.KhachHang.ToList();
            }
            else
            {
                list_khachHangs = context.KhachHang.Where(k => k.KhachHangID == id_khachHangKhongDangNhap).ToList();
                menuStrip_chucNang.Enabled = btn_ChonAnh.Enabled = btn_DoiAnh.Enabled = false;
            }
            bindingSource.DataSource = list_khachHangs;

            txt_hoTen.DataBindings.Clear();
            txt_hoTen.DataBindings.Add("Text", bindingSource, "HoVaTen", false, DataSourceUpdateMode.Never);

            dtp_ngaySinh.DataBindings.Clear();
            dtp_ngaySinh.DataBindings.Add("Value", bindingSource, "NgaySinh", true, DataSourceUpdateMode.Never, DateTime.Now);

            txt_soCCCD.DataBindings.Clear();
            txt_soCCCD.DataBindings.Add("Text", bindingSource, "CCCD", false, DataSourceUpdateMode.Never);

            dtp_ngayCapCCCD.DataBindings.Clear();
            dtp_ngayCapCCCD.DataBindings.Add("Value", bindingSource, "NgayCapCCCD", true, DataSourceUpdateMode.Never, DateTime.Now);

            txt_dienThoai.DataBindings.Clear();
            txt_dienThoai.DataBindings.Add("Text", bindingSource, "DienThoai", false, DataSourceUpdateMode.Never);

            txt_eMail.DataBindings.Clear();
            txt_eMail.DataBindings.Add("Text", bindingSource, "Email", false, DataSourceUpdateMode.Never);

            txt_diaChiThuongTru.DataBindings.Clear();
            txt_diaChiThuongTru.DataBindings.Add("Text", bindingSource, "DiaChiThuongTru", false, DataSourceUpdateMode.Never);

            txt_diaChiLienHe.DataBindings.Clear();
            txt_diaChiLienHe.DataBindings.Add("Text", bindingSource, "DiaChiLienHe", false, DataSourceUpdateMode.Never);

            txt_ngheNghiep.DataBindings.Clear();
            txt_ngheNghiep.DataBindings.Add("Text", bindingSource, "NgheNghiep", false, DataSourceUpdateMode.Never);

            txt_noiLamViec.DataBindings.Clear();
            txt_noiLamViec.DataBindings.Add("Text", bindingSource, "NoiLamViec", false, DataSourceUpdateMode.Never);

            num_thuNhap.DataBindings.Clear();
            num_thuNhap.DataBindings.Add("Value", bindingSource, "ThuNhap", true, DataSourceUpdateMode.Never, 0);

            txt_soTaiKhoan.DataBindings.Clear();
            txt_soTaiKhoan.DataBindings.Add("Text", bindingSource, "STK_NganHang", false, DataSourceUpdateMode.Never);

            num_diemTinhDung.DataBindings.Clear();
            num_diemTinhDung.DataBindings.Add("Value", bindingSource, "CreditScore", true, DataSourceUpdateMode.Never, 0);

            num_hanMucTinDung.DataBindings.Clear();
            num_hanMucTinDung.DataBindings.Add("Value", bindingSource, "HanMucTinDung", true, DataSourceUpdateMode.Never, 0);


            rdb_nam.DataBindings.Clear();
            rdb_nu.DataBindings.Clear();

            // Tạo binding mới với Format/Parse để chuyển đổi giữa int và bool
            Binding namBinding = new Binding("Checked", bindingSource, "GioiTinh", true, DataSourceUpdateMode.OnPropertyChanged);
            namBinding.Format += (s, e) => e.Value = (int)e.Value == 0; // Chuyển int sang bool (0 -> true, 1 -> false)
            namBinding.Parse += (s, e) => e.Value = (bool)e.Value ? 0 : 1; // Chuyển bool sang int (true -> 0, false -> 1)
            rdb_nam.DataBindings.Add(namBinding);

            Binding nuBinding = new Binding("Checked", bindingSource, "GioiTinh", true, DataSourceUpdateMode.OnPropertyChanged);
            nuBinding.Format += (s, e) => e.Value = (int)e.Value == 1; // Chuyển int sang bool (1 -> true, 0 -> false)
            nuBinding.Parse += (s, e) => e.Value = (bool)e.Value ? 1 : 0; // Chuyển bool sang int (true -> 1, false -> 0)
            rdb_nu.DataBindings.Add(nuBinding);

            // Binding ảnh chân dung (nếu có)
            try
            {
                Binding imageBinding = new Binding("ImageLocation", bindingSource, "AnhChanDung", true);
                imageBinding.Format += (sender, e) =>
                {
                    if (string.IsNullOrEmpty(e.Value?.ToString()))
                    {
                        e.Value = null; // Hoặc đường dẫn ảnh mặc định
                    }
                    else
                    {
                        string fullPath = Path.Combine(imageFolder, e.Value.ToString());
                        e.Value = File.Exists(fullPath) ? fullPath : null;
                    }
                };

                imageBinding.Parse += (sender, e) =>
                {
                    // Xử lý khi cần update ngược từ control vào datasource
                    if (e.Value != null)
                    {
                        e.Value = Path.GetFileName(e.Value.ToString());
                    }
                };
                pic_anhChanDung.DataBindings.Add(imageBinding);
            }
            catch
            {
                pic_anhChanDung.Image = null;
            }
            dtg_khachHang.DataSource = bindingSource;
            caiDatLai();
        }
        void loadComboboxDayDu()
        {
            cbb_khuVuc.DataSource = context.KhuVuc.ToList();
            cbb_khuVuc.DisplayMember = "TenKhuVuc";
            cbb_khuVuc.ValueMember = "KhuVucID";

            var nganHangTuDb = list_khachHangs
       .Where(kh => !string.IsNullOrEmpty(kh.TenNganHang))
       .Select(kh => kh.TenNganHang)
       .Distinct()
       .ToList();

            var allNganHang = DanhSachNganHangMau
                .Union(nganHangTuDb)
                .OrderBy(x => x)
                .ToList();

            cbb_tenNganHang.DataSource = allNganHang;
            cbb_tenNganHang.SelectedItem = null;


            var noiCapTuDb = list_khachHangs
        .Where(kh => !string.IsNullOrEmpty(kh.NoiCapCCCD))
        .Select(kh => kh.NoiCapCCCD)
        .Distinct()
        .ToList();

            var allNoiCap = DanhSachNoiCapCCCDMau
                .Union(noiCapTuDb)
                .OrderBy(x => x)
                .ToList();

            cbb_noiCapCCCD.DataSource = allNoiCap;
            cbb_noiCapCCCD.SelectedItem = null;

            // 3. Thiết lập binding sau khi đã có DataSource
            cbb_tenNganHang.DataBindings.Clear();
            cbb_tenNganHang.DataBindings.Add("SelectedItem", bindingSource, "TenNganHang", true, DataSourceUpdateMode.OnPropertyChanged);

            cbb_noiCapCCCD.DataBindings.Clear();
            cbb_noiCapCCCD.DataBindings.Add("SelectedItem", bindingSource, "NoiCapCCCD", true, DataSourceUpdateMode.OnPropertyChanged);

            cbb_khuVuc.DataBindings.Clear();
            cbb_khuVuc.DataBindings.Add("SelectedValue", bindingSource, "KhuVucID", true, DataSourceUpdateMode.Never);
        }

        #endregion

        #region Event

        public F_KhachHang(int nhanvienID, int khachhangID)
        {
            InitializeComponent();
            if (khachhangID == 0)
            {
                id_nguoiDung = nhanvienID;
                id_khachHangKhongDangNhap = khachhangID;
            }
            else
            {
                id_khachHangKhongDangNhap = khachhangID;
                id_nguoiDung = nhanvienID;
            }
            pic_anhChanDung.AllowDrop = true;
        }

        private void F_KhachHang_Load(object sender, EventArgs e)
        {
            load_khachhang();
            loadComboboxDayDu();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            xulythem = true;
            txt_diaChiThuongTru.Clear(); txt_diaChiLienHe.Clear(); txt_hoTen.Clear(); txt_dienThoai.Clear();
            txt_eMail.Clear(); txt_ngheNghiep.Clear(); txt_noiLamViec.Clear(); txt_soCCCD.Clear(); txt_soTaiKhoan.Clear();
            num_diemTinhDung.Value = 0; num_hanMucTinDung.Value = 0; num_thuNhap.Value = 0;
            cbb_noiCapCCCD.SelectedIndex = -1; cbb_tenNganHang.SelectedIndex = -1;
            dtp_ngaySinh.Value = DateTime.Now;
            dtp_ngayCapCCCD.Value = DateTime.Now;
            pic_anhChanDung.Image = null;
            phanQuyenNguoiDung(false);
            btn_Xoa.Enabled = false;
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (dtg_khachHang.CurrentRow == null) { MessageBox.Show("Chọn 1 hàng muốn sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
            xulythem = false;
            pic_anhChanDung.Image = null;
            phanQuyenNguoiDung(false);
            id_khachhang = Convert.ToInt32(dtg_khachHang.CurrentRow.Cells["KhachHangID"].Value.ToString());
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dtg_khachHang.CurrentRow == null) { MessageBox.Show("Chọn 1 hàng muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }

            id_khachhang = Convert.ToInt32(dtg_khachHang.CurrentRow.Cells["KhachHangID"].Value.ToString());
            if (context.HoaDon.Any(k => k.KhachHangID == id_khachhang))
            {
                MessageBox.Show("Không thể xóa khách hàng này vì đã có hóa đơn liên quan", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var kh_khuvuc = context.KhachHang.Find(id_khachhang);
            var ql_khuvuc = context.NhanVien.Find(id_nguoiDung);
            if (ql_khuvuc == null || ql_khuvuc == null)
            {
                MessageBox.Show("Không tìm thấy khu vực quản lý", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (ql_khuvuc.KhuVucID != kh_khuvuc?.KhuVucID)
            {
                MessageBox.Show("Bạn không có quyền xóa khách hàng nằm ngoài khu vực quản lý của mình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"bạn có muốn xóa khách hàng {kh_khuvuc.HoVaTen ?? "Không xác định"} không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                context.KhachHang.Remove(kh_khuvuc);
                context.SaveChanges();
                load_khachhang();
            }
        }

        private void btn_huyBo_Click(object sender, EventArgs e)
        {
            F_KhachHang_Load(sender, e);
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (!_kiemTra())
            {
                return;
            }
            else
            {
                if (xulythem)
                {
                    KhachHang khachHang = new KhachHang();
                    khachHang.HoVaTen = txt_hoTen.Text.Trim();
                    khachHang.DienThoai = txt_dienThoai.Text.Trim();
                    khachHang.DiaChiThuongTru = txt_diaChiThuongTru.Text.Trim();
                    khachHang.DiaChiLienHe = txt_diaChiLienHe.Text.Trim();
                    khachHang.NoiLamViec = txt_noiLamViec.Text.Trim();
                    khachHang.GioiTinh = rdb_nam.Checked ? 0 : 1;
                    khachHang.CCCD = txt_soCCCD.Text.Trim();
                    khachHang.CreditScore = Convert.ToInt32(num_diemTinhDung.Value);
                    khachHang.Email = txt_eMail.Text.Trim();
                    khachHang.HanMucTinDung = Convert.ToInt32(num_hanMucTinDung.Value);
                    khachHang.NgayCapCCCD = dtp_ngayCapCCCD.Value;
                    khachHang.NgaySinh = dtp_ngaySinh.Value;
                    khachHang.STK_NganHang = txt_soTaiKhoan.Text.Trim();
                    khachHang.NoiCapCCCD = cbb_noiCapCCCD.Text;
                    khachHang.NgheNghiep = txt_ngheNghiep.Text.Trim();
                    khachHang.ThuNhap = Convert.ToInt32(num_thuNhap.Value);
                    khachHang.AnhChanDung = image_filePath;
                    khachHang.KhuVucID = int.Parse(cbb_khuVuc.SelectedValue?.ToString());
                    context.KhachHang.Add(khachHang);
                }
                else
                {
                    KhachHang khachHang = context.KhachHang.Find(id_khachhang);
                    if (khachHang != null)
                    {
                        khachHang.HoVaTen = txt_hoTen.Text.Trim();
                        khachHang.DienThoai = txt_dienThoai.Text.Trim();
                        khachHang.DiaChiThuongTru = txt_diaChiThuongTru.Text.Trim();
                        khachHang.DiaChiLienHe = txt_diaChiLienHe.Text.Trim();
                        khachHang.NoiLamViec = txt_noiLamViec.Text.Trim();
                        khachHang.GioiTinh = rdb_nam.Checked ? 0 : 1;
                        khachHang.CCCD = txt_soCCCD.Text.Trim();
                        khachHang.CreditScore = Convert.ToInt32(num_diemTinhDung.Value);
                        khachHang.Email = txt_eMail.Text.Trim();
                        khachHang.HanMucTinDung = Convert.ToInt32(num_hanMucTinDung.Value);
                        khachHang.NgayCapCCCD = dtp_ngayCapCCCD.Value;
                        khachHang.NgaySinh = dtp_ngaySinh.Value;
                        khachHang.STK_NganHang = txt_soTaiKhoan.Text.Trim();
                        khachHang.NoiCapCCCD = cbb_noiCapCCCD.Text;
                        khachHang.NgheNghiep = txt_ngheNghiep.Text.Trim();
                        khachHang.ThuNhap = Convert.ToInt32(num_thuNhap.Value);
                        khachHang.AnhChanDung = image_filePath;
                        khachHang.KhuVucID = int.Parse(cbb_khuVuc.SelectedValue?.ToString());
                        context.KhachHang.Update(khachHang);
                    }
                }
                context.SaveChanges();
                F_KhachHang_Load(sender, e);
            }

        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_xuatFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu ra tập tin Excel";
            saveFileDialog.Filter = "Tập tin Excel | *.xls;*.xlsx";
            saveFileDialog.FileName = "KhachHang_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    dataTable.Columns.Add("KhachHangID", typeof(int));
                    dataTable.Columns.Add("HoVaTen", typeof(string));
                    dataTable.Columns.Add("DienThoai", typeof(string));
                    dataTable.Columns.Add("KhuVucID", typeof(int));
                    dataTable.Columns.Add("GioiTinh", typeof(int));
                    dataTable.Columns.Add("NgaySinh", typeof(DateTime));
                    dataTable.Columns.Add("CCCD", typeof(string));
                    dataTable.Columns.Add("NgayCapCCCD", typeof(DateTime));
                    dataTable.Columns.Add("NoiCapCCCD", typeof(string));
                    dataTable.Columns.Add("Email", typeof(string));
                    dataTable.Columns.Add("DiaChiThuongTru", typeof(string));
                    dataTable.Columns.Add("DiaChiLienHe", typeof(string));
                    dataTable.Columns.Add("NgheNghiep", typeof(string));
                    dataTable.Columns.Add("NoiLamViec", typeof(string));
                    dataTable.Columns.Add("ThuNhap", typeof(decimal));
                    dataTable.Columns.Add("STK_NganHang", typeof(string));
                    dataTable.Columns.Add("TenNganHang", typeof(string));
                    dataTable.Columns.Add("CreditScore", typeof(int));
                    dataTable.Columns.Add("AnhChanDung", typeof(string));
                    dataTable.Columns.Add("HanMucTinDung", typeof(decimal));

                    var khachHang = context.KhachHang.ToList();
                    if (khachHang != null)
                    {
                        foreach (var p in khachHang)
                        {
                            dataTable.Rows.Add(
                                               p.KhachHangID, p.HoVaTen, p.DienThoai, p.KhuVucID, p.GioiTinh,
                                               p.NgaySinh, p.CCCD, p.NgayCapCCCD, p.NoiCapCCCD, p.Email,
                                               p.DiaChiThuongTru, p.DiaChiLienHe, p.NgheNghiep, p.NoiLamViec,
                                               p.ThuNhap, p.STK_NganHang, p.TenNganHang, p.CreditScore,
                                               p.AnhChanDung, p.HanMucTinDung
                                               );
                        }
                    }
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(dataTable, "KhachHang");
                        sheet.Columns().AdjustToContents();
                        wb.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Đã xuất dữ liệu ra tập tin Excel thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }

        private void btn_nhapFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Nhập dữ liệu từ tập tin Excel";
            op.Filter = "Tập tin Excel |*.xls ;*.xlsx";
            op.Multiselect = false;
            if (op.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    using (XLWorkbook xlw = new XLWorkbook(op.FileName))
                    {
                        IXLWorksheet xLWorksheet = xlw.Worksheet("KhachHang");
                        bool firstRow = true;
                        string ReadRange = "1:1";
                        foreach (IXLRow row in xLWorksheet.RowsUsed())
                        {
                            if (firstRow)
                            {
                                ReadRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                                foreach (IXLCell cell in row.Cells(ReadRange))
                                {
                                    dataTable.Columns.Add(cell.Value.ToString());
                                    firstRow = false;
                                }
                            }
                            else
                            {
                                dataTable.Rows.Add();
                                int cellIndex = 0;
                                foreach (IXLCell cell in row.Cells(ReadRange))
                                {
                                    dataTable.Rows[dataTable.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                    cellIndex++;
                                }
                            }
                        }
                        if (dataTable.Rows.Count > 0)
                        {
                            int cout = 0;
                            List<KhachHang> khachHangMoi = new List<KhachHang>();
                            var KhachHangDangTonTai = context.KhachHang.Select(s => s.CCCD).ToList();
                            foreach (DataRow row in dataTable.Rows)
                            {
                                string soCCCD = row["CCCD"]?.ToString() ?? "";
                                if (string.IsNullOrEmpty(soCCCD)) continue; // Bỏ qua nếu không có số CCCD
                                if (!KhachHangDangTonTai.Contains(soCCCD))
                                {
                                    int khuVucID;
                                    if (!int.TryParse(row["KhuVucID"]?.ToString(), out khuVucID))
                                    {
                                        khuVucID = 1; // Giá trị mặc định nếu không hợp lệ
                                    }                                   
                                    KhachHang h = new KhachHang
                                    {
                                        HoVaTen = row["HoVaTen"]?.ToString()??"",
                                        DienThoai = row["DienThoai"]?.ToString(),
                                        KhuVucID = int.Parse(row["KhuVucID"].ToString() ?? null),
                                        GioiTinh = int.Parse(row["GioiTinh"].ToString() ?? "1"),
                                        NgaySinh = DateTime.Parse(row["NgaySinh"].ToString() ?? DateTime.Now.ToString()),
                                        CCCD = row["CCCD"]?.ToString(),
                                        NgayCapCCCD = DateTime.Parse(row["NgayCapCCCD"].ToString() ?? DateTime.Now.ToString()),
                                        NoiCapCCCD = row["NoiCapCCCD"]?.ToString(),
                                        Email = row["Email"]?.ToString(),
                                        DiaChiThuongTru = row["DiaChiThuongTru"]?.ToString(),
                                        DiaChiLienHe = row["DiaChiLienHe"]?.ToString(),
                                        NgheNghiep = row["NgheNghiep"]?.ToString(),
                                        NoiLamViec = row["NoiLamViec"]?.ToString(),
                                        ThuNhap = decimal.Parse(row["ThuNhap"].ToString() ?? "9999"),
                                        STK_NganHang = row["STK_NganHang"]?.ToString(),
                                        TenNganHang = row["TenNganHang"]?.ToString(),
                                        CreditScore = int.Parse(row["CreditScore"].ToString() ?? "99877899"),
                                        AnhChanDung = row["AnhChanDung"]?.ToString(),
                                        HanMucTinDung = decimal.Parse(row["HanMucTinDung"].ToString() ?? "99")
                                    };

                                    khachHangMoi.Add(h);
                                    KhachHangDangTonTai.Add(soCCCD);
                                    cout++;
                                }
                            }
                            if (cout > 0)
                            {
                                if (MessageBox.Show("Tìm thấy ( " + cout + " ) Khách hàng !\nBạn có muốn thêm váo danh sách không?", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                {
                                    context.KhachHang.AddRange(khachHangMoi);
                                    context.SaveChanges();
                                    F_KhachHang_Load(sender, e);
                                    MessageBox.Show($"Đã nhập thành công {cout} Khách hàng", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    khachHangMoi.Clear();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không có gì mới cả !!!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                        }
                        if (firstRow)
                        {
                            MessageBox.Show("Tập tin Excel rỗng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }

        private void btn_chonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Cập nhật hình ảnh khách hàng";
            openFileDialog.Filter = "Tập tin hình ảnh|*.jpg;*.jpeg;*.png;*.gif;*.bmp"; openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy tên và phần mở rộng của tệp
                string fileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                string ext = Path.GetExtension(openFileDialog.FileName);
                // Xác định đường dẫn lưu hình ảnh
                string fileSavePath = Path.Combine(imageFolder, fileName + ext);
                try
                {
                    // Giải phóng tài nguyên hình ảnh trong PictureBox nếu có
                    if (pic_anhChanDung.Image != null)
                    {
                        pic_anhChanDung.Image.Dispose();
                        pic_anhChanDung.Image = null;
                    }
                    // Sao chép tệp hình ảnh vào thư mục đích
                    File.Copy(openFileDialog.FileName, fileSavePath, true);
                    // Thêm hình ảnh vào PictureBox (nếu cần)
                    image_filePath = fileName + ext;
                    pic_anhChanDung.Image = Image.FromFile(fileSavePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn_doiAnh_Click(object sender, EventArgs e)
        {
            if (dtg_khachHang.CurrentRow == null) { MessageBox.Show("Chọn 1 hàng muốn đổi ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Cập nhật hình ảnh khách hàng";
            openFileDialog.Filter = "Tập tin hình ảnh|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy tên và phần mở rộng của tệp
                string fileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                string ext = Path.GetExtension(openFileDialog.FileName);

                // Xác định đường dẫn lưu hình ảnh
                string fileSavePath = Path.Combine(imageFolder, fileName + ext);

                try
                {
                    // Giải phóng tài nguyên hình ảnh trong PictureBox nếu có
                    if (pic_anhChanDung.Image != null)
                    {
                        pic_anhChanDung.Image.Dispose();
                        pic_anhChanDung.Image = null;
                    }
                    // Sao chép tệp hình ảnh vào thư mục đích
                    File.Copy(openFileDialog.FileName, fileSavePath, true);

                    id_khachhang = Convert.ToInt32(dtg_khachHang.CurrentRow.Cells["KhachHangID"].Value.ToString());

                    KhachHang kh = context.KhachHang.Find(id_khachhang);
                    if (kh != null)
                    {
                        kh.AnhChanDung = fileName + ext;
                        context.KhachHang.Update(kh);
                        context.SaveChanges();
                    }
                    load_khachhang();
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Lỗi khi sao chép hình ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox_troVe_Click(object sender, EventArgs e)
        {
            themKhachHang_troVe?.Invoke(this, new EventArgs());
            this.Close();
        }


        private void dtg_khachHang_EnabledChanged(object sender, EventArgs e)
        {
            if (!dtg_khachHang.Enabled)
            {
                dtg_khachHang.DefaultCellStyle.BackColor = Color.LightSlateGray;
                dtg_khachHang.DefaultCellStyle.ForeColor = Color.DarkGray;
                dtg_khachHang.BackgroundColor = SystemColors.Control;
                dtg_khachHang.Cursor = Cursors.No; // Hiển thị cursor "không được phép"
            }
            else
            {
                dtg_khachHang.DefaultCellStyle.BackColor = Color.White;
                dtg_khachHang.DefaultCellStyle.ForeColor = Color.Black;
                dtg_khachHang.BackgroundColor = Color.White;
                dtg_khachHang.Cursor = Cursors.Default;
            }
        }

        private void rdb_nam_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdb_nam.Checked)
            {
                rdb_nu.Checked = false;
            }
        }

        private void rdb_nu_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdb_nu.Checked)
            {
                rdb_nam.Checked = false;
            }
        }

        private void combox_SearchByName_TextChanged(object sender, EventArgs e)
        {
            if (textBox_SearchByName.Text != "")
            {
                string searchText = textBox_SearchByName.Text.ToLower();
                var filteredList = list_khachHangs.Where(kh => kh.HoVaTen.ToLower().Contains(searchText)).ToList();
                bindingSource.DataSource = filteredList;
            }
            else
            {
                bindingSource.DataSource = list_khachHangs;
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {
            F_Help helpForm = new F_Help("khachhang"); // "login" là tên tương ứng file login.txt
            helpForm.ShowDialog();
        }


        private void pic_hinhAnhChanDung_DragDrop(object sender, DragEventArgs e)
        {
            id_khachhang = Convert.ToInt32(dtg_khachHang.CurrentRow.Cells["KhachHangID"].Value.ToString());
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string file = files[0];
                string ext = Path.GetExtension(file).ToLower();

                // Kiểm tra loại file ảnh hợp lệ
                if (!new[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif" }.Contains(ext))
                {
                    MessageBox.Show("Chỉ hỗ trợ file ảnh!");
                    return;
                }

                string fileName = Path.GetFileName(file);
                string destPath = Path.Combine(imageFolder, fileName);

                try
                {
                    // Kiểm tra thư mục đích có tồn tại không, nếu không thì tạo mới
                    if (!Directory.Exists(imageFolder))
                    {
                        Directory.CreateDirectory(imageFolder);
                    }

                    // Giải phóng tài nguyên hình ảnh trong PictureBox nếu có
                    var oldImage = pic_anhChanDung.Image;
                    pic_anhChanDung.Image = null;
                    oldImage?.Dispose();

                    // Nếu ảnh đã tồn tại, có thể tự tạo tên mới hoặc ghi đè
                    if (File.Exists(destPath))
                    {
                        // Tạo tên mới cho file nếu tồn tại
                        string uniqueFileName = Path.GetFileNameWithoutExtension(fileName) + "_" + Guid.NewGuid().ToString().Substring(0, 6) + ext;
                        destPath = Path.Combine(imageFolder, uniqueFileName);
                        fileName = uniqueFileName; // Cập nhật tên file cho DB
                    }

                    // Sao chép tệp hình ảnh vào thư mục đích
                    File.Copy(file, destPath, true); // Ghi đè nếu đã tồn tại

                    // Lấy ID sản phẩm và cập nhật hình ảnh trong cơ sở dữ liệu
                    var kh = context.KhachHang.Find(id_khachhang);
                    if (kh != null)
                    {
                        kh.AnhChanDung= fileName; // Lưu tên ảnh vào DB
                        context.KhachHang.Update(kh);
                        context.SaveChanges();

                        // Cập nhật lại UI hoặc reload form
                        F_KhachHang_Load(sender, e);
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Lỗi khi sao chép hình ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pic_hinhAnhChanDung_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                pic_anhChanDung.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }


        #endregion
    }
}
