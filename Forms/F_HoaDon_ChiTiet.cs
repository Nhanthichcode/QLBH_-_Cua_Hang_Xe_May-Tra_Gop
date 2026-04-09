using DoAnBanHang_cuahangxemay.Data_Table;
using DoAnBanHang_cuahangxemay.help;
using System.ComponentModel;
using System.Data;
using System.Text;
using static DoAnBanHang_cuahangxemay.Data_Table.enum_ThongTin;


namespace DoAnBanHang_cuahangxemay.Forms
{
    public partial class F_HoaDon_ChiTiet : Form
    {
        public static event EventHandler themhoadon_troVe;
        bool isKhachHangMoi = false, isXacNhanLuu = false;
        AppDbContext context = new AppDbContext();
        int id_hoaDonCu = 0;
        BindingList<DanhSachHoaDon_ChiTiet> hd_ChiTiet = new BindingList<DanhSachHoaDon_ChiTiet>();
        decimal laiSuat;
        int kyHan;
        int id_nguoiDung;

        #region methods

        private List<string> imagePaths = new List<string>();
        private int currentImageIndex = 0;


        private void ShowNextImage()
        {
            currentImageIndex = (currentImageIndex + 1) % imagePaths.Count;
        }
        private void SetControlsFor_KhachHangCu()// tắt các chức năng dành của khách hàng cũ
        {
            // Tắt các control không cho phép tương tác đối với khách hàng cũ
            cbb_khachHang.Enabled = false;
            cbb_nhanVien.Enabled = false;
            //cbb_phuongThucThanhToan.Enabled = false;
            groupBox_traGop.Enabled = false;

            // Cho phép tương tác với sản phẩm và số lượng
            cbb_sanPham.Enabled = true;
            num_soLuong.Enabled = true;
        }
        void BatTat()
        {
            if (id_hoaDonCu == 0 && dtg_chiTietHoaDon.Rows.Count == 0)
            {
                cbb_nhanVien.SelectedIndex = -1;
                cbb_khachHang.SelectedIndex = -1;
                cbb_sanPham.SelectedIndex = -1;
                num_donGia.Value = 0;
                num_soLuong.Value = 1;
            }
            btn_xoaSanPham.Enabled = dtg_chiTietHoaDon.Rows.Count > 0;
            isXacNhanLuu = false;
        }
        void load_cbb_tenKhachHang()
        {
            cbb_khachHang.DataBindings.Clear();
            cbb_khachHang.DataSource = context.KhachHang.Distinct().ToList();
            cbb_khachHang.DisplayMember = "HoVaTen";
            cbb_khachHang.ValueMember = "KhachHangID";
        }
        void load_cbb_tenSanPham()
        {
            cbb_sanPham.DataBindings.Clear();
            cbb_sanPham.DataSource = context.SanPham.Distinct().ToList();
            cbb_sanPham.DisplayMember = "TenSanPham";
            cbb_sanPham.ValueMember = "SanPhamID";
        }
        void load_cbb_tenNhanVien()
        {
            cbb_nhanVien.DataBindings.Clear();
            cbb_nhanVien.DataSource = context.NhanVien.Distinct().ToList();
            cbb_nhanVien.DisplayMember = "HoVaTen";
            cbb_nhanVien.ValueMember = "NhanVienID";
        }

        bool _isKiemTraThongTin()
        {
            if (isKhachHangMoi == true) // khách hàng mới là False,
                                        // ==> khách hàng cũ chỉ kiểm tra chọn sản phẩm
            {
                if (cbb_khachHang.SelectedItem == null)
                {
                    MessageBox.Show("Hãy chọn khách hàng cho hóa đơn", "Thiếu khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (cbb_nhanVien.SelectedItem == null)
                {
                    MessageBox.Show("Hãy chọn nhân viên lập hóa đơn", "Thiếu nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //if (cbb_sanPham.SelectedItem == null)
                //{
                //    MessageBox.Show("Hãy chọn 1 sản phẩm", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return false;
                //}
                else if (cbb_phuongThucThanhToan.SelectedValue == null || string.IsNullOrEmpty(cbb_phuongThucThanhToan.SelectedValue.ToString()))
                {
                    MessageBox.Show("Hãy chọn phương thức thanh toán", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (num_donGia.Value == 0)
                {
                    MessageBox.Show("Hãy chọn 1 sản phẩm cho hóa đơn", "Thiếu đơn giá", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (cbb_phuongThucThanhToan.Text != "Trả góp")
                {
                    if (cbb_trangThaiThanhToan.SelectedIndex == -1)
                    {
                        MessageBox.Show("Hãy chọn trạng thái thanh toán cho hóa đơn của bạn", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else if (isKhachHangMoi == false)// khách hàng đã có hóa đơn trước
                {


                    if (cbb_phuongThucThanhToan.SelectedValue == null || string.IsNullOrEmpty(cbb_phuongThucThanhToan.SelectedValue.ToString()))
                    {
                        MessageBox.Show("Hãy chọn phương thức thanh toán", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (cbb_sanPham.SelectedItem == null)
                    {
                        MessageBox.Show("Hãy chọn 1 sản phẩm", "Thiếu sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else if (num_donGia.Value == 0)
                    {
                        MessageBox.Show("Hãy chọn 1 sản phẩm cho hóa đơn", "Thiếu đơn giá", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }
        void _isKhachHangCu()
        {

            HoaDon hd = context.HoaDon.Find(id_hoaDonCu);
            decimal tongTien = 0;
            tongTien = hd_ChiTiet.Sum(x => x.DonGia * x.SoLuongBan);
            bool isTraGop = false;
            if (!cbb_phuongThucThanhToan.Text.ToLower().Trim().Equals("trả góp"))
            {   // chỉ cập nhật thêm sản phẩm và thông tin như người dùng, nhân viên               
                var confirmMessage = new StringBuilder();
                confirmMessage.AppendLine("XÁC NHẬN CẬP NHẬT THÔNG TIN HÓA ĐƠN");
                confirmMessage.AppendLine("────────────────────────────────────");
                confirmMessage.AppendLine($"Khách hàng: {cbb_khachHang.Text}");
                confirmMessage.AppendLine($"Nhân viên: {cbb_nhanVien.Text}");
                confirmMessage.AppendLine($"Ngày lập: {DateTime.Now:dd/MM/yyyy HH:mm}");
                confirmMessage.AppendLine($"Phương thức TT: {cbb_phuongThucThanhToan.Text}");
                confirmMessage.AppendLine($"Trạng thái TT: Chưa thanh toán");
                confirmMessage.AppendLine("────────────────────────────────────");

                // Thêm chi tiết sản phẩm
                confirmMessage.AppendLine("CHI TIẾT SẢN PHẨM MỚI:");
                foreach (var item in hd_ChiTiet)
                {
                    confirmMessage.AppendLine($"- {item.TenSanPham} x {item.SoLuongBan} = {item.DonGia * item.SoLuongBan:N0} VNĐ");
                }

                confirmMessage.AppendLine("────────────────────────────────────");
                confirmMessage.AppendLine($"TỔNG CỘNG: {tongTien:N0} VNĐ");
                confirmMessage.AppendLine("────────────────────────────────────");

                // Hiển thị dialog xác nhận
                var result = MessageBox.Show(
                        confirmMessage.ToString(),
                        "XÁC NHẬN CẬP NHẬT HÓA ĐƠN",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);

                if (result != DialogResult.Yes)
                {
                    isXacNhanLuu = false;
                    return; // Hủy thao tác nếu người dùng không xác nhận
                }
            }
            else
            {
                isTraGop = true;
                kyHan = int.Parse(num_soKyHan.Value.ToString());
                laiSuat = num_soTienLai.Value;
                var confirmMessage = new StringBuilder();
                confirmMessage.AppendLine("XÁC NHẬN CẬP NHẬT THÔNG TIN HÓA ĐƠN TRẢ GÓP");
                confirmMessage.AppendLine("────────────────────────────────────");
                confirmMessage.AppendLine($"Khách hàng: {cbb_khachHang.Text}");
                confirmMessage.AppendLine($"Nhân viên: {cbb_nhanVien.Text}");
                confirmMessage.AppendLine($"Ngày lập: {DateTime.Now:dd/MM/yyyy HH:mm}");
                confirmMessage.AppendLine($"Phương thức TT: Trả Góp");
                confirmMessage.AppendLine($"Số kỳ hạn: {kyHan} tháng");
                confirmMessage.AppendLine($"Lãi suất: {laiSuat} %");
                confirmMessage.AppendLine($"Trạng thái TT: Đang thanh toán");
                confirmMessage.AppendLine("────────────────────────────────────");

                // Thêm chi tiết sản phẩm
                confirmMessage.AppendLine("CHI TIẾT SẢN PHẨM MỚI:");
                foreach (var item in hd_ChiTiet)
                {
                    confirmMessage.AppendLine($"- {item.TenSanPham} x {item.SoLuongBan} = {item.DonGia * item.SoLuongBan:N0} VNĐ");
                }

                confirmMessage.AppendLine("────────────────────────────────────");
                confirmMessage.AppendLine($"TỔNG CỘNG: {tongTien:N0} VNĐ");
                confirmMessage.AppendLine("────────────────────────────────────");

                // Hiển thị dialog xác nhận
                var result = MessageBox.Show(
                        confirmMessage.ToString(),
                        "XÁC NHẬN TẠO HÓA ĐƠN TRẢ GÓP",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);

                if (result != DialogResult.Yes)
                {
                    isXacNhanLuu = false;
                    return; // Hủy thao tác nếu người dùng không xác nhận
                }
            }

            if (hd != null)// đã tồn tại 1 id nên sẽ bổ sung các sản phẩm và thành tiền
            {
                hd.PhuongThucThanhToan = ((enum_ThongTin.enum_PhuongThucThanhToan)cbb_phuongThucThanhToan.SelectedValue).ToString();
                hd.IsDeleted = 0;
                hd.GhiChuHoaDon = "Đã sửa: " + DateTime.Now;
                context.HoaDon.Update(hd);
                // xóa chi tiết cũ
                var currentChiTietIds = hd_ChiTiet.Select(item => item.SanPhamID).ToList();
                var old_chitiet_to_remove = context.HoaDon_ChiTiet
                    .Where(x => x.HoaDonID == id_hoaDonCu && !currentChiTietIds.Contains(x.SanPhamID))
                    .ToList();

                context.HoaDon_ChiTiet.RemoveRange(old_chitiet_to_remove);

                // thêm lại chi tiết mới
                foreach (var item in hd_ChiTiet.ToList())
                {
                    var existingChiTiet = context.HoaDon_ChiTiet
                .FirstOrDefault(x => x.HoaDonID == id_hoaDonCu && x.SanPhamID == item.SanPhamID);

                    if (existingChiTiet == null)
                    {
                        HoaDon_ChiTiet hd_ct = new HoaDon_ChiTiet
                        {
                            SanPhamID = item.SanPhamID,
                            HoaDonID = item.HoaDonID,
                            DonGia = item.DonGia,
                            SoLuongBan = item.SoLuongBan
                        };
                        context.HoaDon_ChiTiet.Add(hd_ct);
                        context.SaveChanges();
                    }
                    else
                    {
                        // Cập nhật nếu đã tồn tại (ví dụ: số lượng, đơn giá)
                        existingChiTiet.DonGia = item.DonGia;
                        existingChiTiet.SoLuongBan = item.SoLuongBan;
                        context.HoaDon_ChiTiet.Update(existingChiTiet);
                        context.SaveChanges();
                    }
                }
                // khách hàng cũ nên chỉ cập nhật lại hóa đơn thanh toán
                tongTien = hd_ChiTiet.Sum(x => x.DonGia * x.SoLuongBan);

                var existingThanhToan = context.ThanhToan.FirstOrDefault(tt => tt.HoaDonID == id_hoaDonCu);
                if (existingThanhToan == null)
                {
                    // Xử lý trường hợp không tìm thấy thanh toán
                    MessageBox.Show("Không tìm thấy thông tin thanh toán cho hóa đơn này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // xử lý nếu tạo trả góp
                if (isTraGop == true)
                {
                    hd.TrangThai = enum_ThongTin.enum_TrangThaiThanhToan.DangThanhToan.ToString();
                    context.HoaDon.Update(hd);
                    context.SaveChanges();

                    TaoKeHoachTraGop(hd.HoaDonID, tongTien, kyHan, laiSuat);
                    existingThanhToan.SoTienThanhToan = tongTien; // Cập nhật tổng tiền mới
                    existingThanhToan.NgayLap = DateTime.Now;
                    existingThanhToan.GhiChuHoaDon = "Thay đổi hóa đơn thành trả góp: " + DateTime.Now;
                    existingThanhToan.TrangThaiHoaDon = enum_ThongTin.enum_TrangThaiThanhToan.DangThanhToan.ToString();
                    existingThanhToan.TrangThaiThanhToan = enum_ThongTin.enum_TrangThaiThanhToan.MoiTao.ToString();
                    existingThanhToan.PhuongThucThanhToan = enum_ThongTin.enum_PhuongThucThanhToan.TraGop.ToString();

                    context.ThanhToan.Update(existingThanhToan);
                }
                else
                {
                    // tìm hóa đơn không phải trả góp
                    if (existingThanhToan != null)
                    {
                        existingThanhToan.SoTienThanhToan = tongTien; // Cập nhật tổng tiền mới                       
                        existingThanhToan.GhiChuHoaDon = txt_ghiChuHoaDon.Text.Trim();
                        context.ThanhToan.Update(existingThanhToan);
                    }
                }

                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex) { Console.WriteLine(ex.StackTrace); }
                SetControlsFor_KhachHangCu();
                isXacNhanLuu = true;
            }
        }

        void _isKhachHangMoi()
        {
            // Tạo thông báo chi tiết
            var confirmMessage = new StringBuilder();
            confirmMessage.AppendLine("XÁC NHẬN THÔNG TIN HÓA ĐƠN");
            confirmMessage.AppendLine("────────────────────────────────────");
            confirmMessage.AppendLine($"Khách hàng: {cbb_khachHang.Text}");
            confirmMessage.AppendLine($"Nhân viên: {cbb_nhanVien.Text}");
            confirmMessage.AppendLine($"Ngày lập: {DateTime.Now:dd/MM/yyyy HH:mm}");
            confirmMessage.AppendLine($"Phương thức TT: {cbb_phuongThucThanhToan.Text}");
            if (cbb_phuongThucThanhToan.Text.ToLower().Trim().Equals("trả góp"))
            {
                laiSuat = num_soTienLai.Value;
                kyHan = int.Parse(num_soKyHan.Value.ToString());
                confirmMessage.AppendLine($"Số kỳ hạn: {kyHan} tháng");
                confirmMessage.AppendLine($"Lãi suất: {laiSuat} %");
                confirmMessage.AppendLine($"Trạng thái: Chưa thanh toán");
            }
            else
            {
                confirmMessage.AppendLine($"Trạng thái TT: Chưa thanh toán");
            }
            confirmMessage.AppendLine("────────────────────────────────────");

            // Thêm chi tiết sản phẩm
            confirmMessage.AppendLine("CHI TIẾT SẢN PHẨM:");
            foreach (var item in hd_ChiTiet)
            {
                confirmMessage.AppendLine($"- {item.TenSanPham} x {item.SoLuongBan} = {item.DonGia * item.SoLuongBan:N0} VNĐ");
            }

            decimal tongTien = 0;
            tongTien = hd_ChiTiet.Sum(x => x.DonGia * x.SoLuongBan);

            confirmMessage.AppendLine("────────────────────────────────────");
            confirmMessage.AppendLine($"TỔNG CỘNG: {tongTien:N0} VNĐ");
            confirmMessage.AppendLine("────────────────────────────────────");

            // Hiển thị dialog xác nhận
            var result = MessageBox.Show(
                confirmMessage.ToString(),
                "XÁC NHẬN TẠO HÓA ĐƠN",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes)
            {
                isXacNhanLuu = false;
                return; // Hủy thao tác nếu người dùng không xác nhận
            }
            var hd = new HoaDon
            {
                NhanVienID = Convert.ToInt32(cbb_nhanVien.SelectedValue.ToString()),
                KhachHangID = Convert.ToInt32(cbb_khachHang.SelectedValue.ToString()),
                NgayLap = DateTime.Now,
                IsDeleted = 0,
                TrangThai = ((enum_ThongTin.enum_HoaDon.DangThanhToan)).ToString(),
                PhuongThucThanhToan = ((enum_ThongTin.enum_PhuongThucThanhToan)cbb_phuongThucThanhToan.SelectedValue).ToString(),
                GhiChuHoaDon = txt_ghiChuHoaDon.Text.Trim(),
            };
            if (cbb_trangThaiThanhToan.Text.Trim().ToLower().Equals("dahuy"))
            { hd.IsDeleted = 1; }
            context.HoaDon.Add(hd);
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Thêm chi tiết hóa đơn
            foreach (var item in hd_ChiTiet)
            {
                context.HoaDon_ChiTiet.Add(new HoaDon_ChiTiet
                {
                    SanPhamID = item.SanPhamID,
                    HoaDonID = hd.HoaDonID,
                    DonGia = item.DonGia,
                    SoLuongBan = item.SoLuongBan,
                });
            }

            //Xử lý trả góp nếu có, tự tạo hóa đơn riêng
            if (((enum_ThongTin.enum_PhuongThucThanhToan)cbb_phuongThucThanhToan.SelectedValue).ToString().ToLower().Equals("tragop"))
            {
                if (laiSuat == 0 || kyHan == 0)
                {
                    MessageBox.Show("Chọn kì hạn và lãi xuất cho hóa đơn", "Thiếu thông tin trả góp");
                    return;
                }
                hd.TrangThai = enum_ThongTin.enum_HoaDon.DangThanhToan.ToString();
                context.HoaDon.Update(hd);
                context.SaveChanges();

                TaoKeHoachTraGop(hd.HoaDonID, tongTien, kyHan, laiSuat);
                // Lưu kế hoạch trả góp

                // Tạo thanh toán đầu tiên của trả góp
                context.ThanhToan.Add(
                    new ThanhToan
                    {
                        HoaDonID = hd.HoaDonID,
                        SoTienThanhToan = tongTien,
                        NgayLap = DateTime.Now,
                        GhiChuHoaDon = "Khách hàng chọn trả góp, chưa thanh toán",
                        TrangThaiHoaDon = enum_ThongTin.enum_TrangThaiThanhToan.ChuaThanhToan.ToString(),
                        TrangThaiThanhToan = enum_ThongTin.enum_TrangThaiThanhToan.MoiTao.ToString(),
                        PhuongThucThanhToan = enum_ThongTin.enum_PhuongThucThanhToan.TraGop.ToString(),
                    });
            }
            else // Thanh toán thường
            {
                context.ThanhToan.Add(new ThanhToan
                {
                    HoaDonID = hd.HoaDonID,
                    NgayLap = DateTime.Now,
                    TrangThaiThanhToan = ((enum_ThongTin.enum_TrangThaiThanhToan.MoiTao.ToString())),
                    TrangThaiHoaDon = enum_ThongTin.enum_TrangThaiThanhToan.ChuaThanhToan.ToString(),
                    SoTienThanhToan = tongTien,
                    PhuongThucThanhToan = ((enum_ThongTin.enum_PhuongThucThanhToan)cbb_phuongThucThanhToan.SelectedValue).ToString(),
                    GhiChuHoaDon = txt_ghiChuHoaDon.Text.Trim(),
                });

                hd.TrangThai = enum_ThongTin.enum_TrangThaiThanhToan.ChuaThanhToan.ToString();
                context.HoaDon.Update(hd);
            }
            try
            {
                context.SaveChanges();
                isKhachHangMoi = false;// đã có hóa đơn thì không bổ sung thêm hồ sơ nữa mà chỉ cập nhật các thông tin tổng tiền
                id_hoaDonCu = hd.HoaDonID;
                SetControlsFor_KhachHangCu();
                isXacNhanLuu = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Load_Form()
        {
            groupBox_traGop.Enabled = cbb_trangThaiThanhToan.Enabled = false;

            dtg_chiTietHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            load_cbb_tenSanPham();
            load_cbb_tenNhanVien();
            load_cbb_tenKhachHang();
            BindEnumToComboBox(typeof(enum_ThongTin.enum_PhuongThucThanhToan), cbb_phuongThucThanhToan);
            BindEnumToComboBox(typeof(enum_ThongTin.enum_HoaDon), cbb_trangThaiThanhToan);
            if (isKhachHangMoi == false)// là khách hàng cũ do khách đã có hóa đơn
            {
                // tải lên hóa đơn của khách hàng đang chọn ở Hóa Đơn
                SetControlsFor_KhachHangCu();
                var hd = context.HoaDon.Where(r => r.HoaDonID == id_hoaDonCu).FirstOrDefault();
                if (hd != null)
                {
                    try
                    {
                        cbb_khachHang.SelectedValue = hd.KhachHangID;
                        cbb_nhanVien.SelectedValue = hd.NhanVienID;
                        // Chuyển đổi từ chuỗi sang enum trước khi gán
                        var ct = context.HoaDon_ChiTiet
                            .Where(r => r.HoaDonID == id_hoaDonCu)
                            .Select(r => new DanhSachHoaDon_ChiTiet
                            {
                                HoaDonChiTietID = r.HoaDonChiTietID,
                                HoaDonID = r.HoaDonID,
                                SanPhamID = r.SanPhamID,
                                TenSanPham = r.SanPham.TenSanPham ?? "Không xác định",
                                SoLuongBan = r.SoLuongBan,
                                DonGia = r.DonGia,
                                ThanhTien = Convert.ToDecimal(r.DonGia * r.SoLuongBan)
                            }).ToList();

                        hd_ChiTiet = new BindingList<DanhSachHoaDon_ChiTiet>(ct);

                        if (hd.PhuongThucThanhToan?.Trim() == enum_ThongTin.enum_PhuongThucThanhToan.TraGop.ToString()
                             || hd.TrangThai?.ToString() == enum_ThongTin.enum_HoaDon.DaThanhToan.ToString()
                             || hd.TrangThai?.ToString() == enum_ThongTin.enum_HoaDon.DangThanhToan.ToString())
                        {
                            panel_thongTinThanhToan.Enabled = menuStrip_chucNang.Enabled = false;
                            MessageBox.Show($"Bạn chỉ được xem chi tiết hóa đơn\ncủa {hd.KhachHang.HoVaTen ?? ""} !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi" + ex.Message, "Error");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy hóa đơn với ID {id_hoaDonCu}. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    themhoadon_troVe?.Invoke(this, EventArgs.Empty);
                }
                dtg_chiTietHoaDon.DataSource = hd_ChiTiet;
                changeHeaderName();
            }
            BatTat();
            lable_tongTienHoaDon.Text = string.Format("{0:N2}", hd_ChiTiet.Sum(x => x.ThanhTien)) + " VNĐ";
            btn_luuLai.Enabled = hd_ChiTiet.Count > 0;
            //InitializeSlideshow();//ảnh lặp lại
        }

        void changeHeaderName()
        {
            dtg_chiTietHoaDon.Columns["HoaDonChiTietID"].Visible = false;
            dtg_chiTietHoaDon.Columns["HoaDonID"].Visible = false;
            dtg_chiTietHoaDon.Columns["SanPhamID"].Visible = false;
            dtg_chiTietHoaDon.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            dtg_chiTietHoaDon.Columns["SoLuongBan"].HeaderText = "Số lượng";
            dtg_chiTietHoaDon.Columns["DonGia"].HeaderText = "Giá bán";
            dtg_chiTietHoaDon.Columns["DonGia"].DefaultCellStyle.Format = "#,##0 'VNĐ'";
            dtg_chiTietHoaDon.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dtg_chiTietHoaDon.Columns["ThanhTien"].DefaultCellStyle.Format = "#,##0 'VNĐ'";
        }
        #endregion

        #region event
        private void btn_themKhachHang_Click(object sender, EventArgs e)
        {
            F_KhachHang khachHang = new F_KhachHang(id_nguoiDung, 0);

            khachHang.ShowDialog();
        }

        public F_HoaDon_ChiTiet(int id_hoadon, int nhanvienID)
        {
            // nếu là nghiệp vụ thêm hóa đơn mới thì 'id_hoadon' mặc định = 0 
            InitializeComponent();
            //id_hoaDonCu để tải lên trang chi tiết hóa đơn 1 lần
            id_hoaDonCu = id_hoadon;
            isKhachHangMoi = (id_hoadon == 0);
            id_nguoiDung = nhanvienID;
            F_KhachHang.themKhachHang_troVe += F_KhachHang_themKhachHang_troVe;

            if (id_hoadon != 0)
            {
                btn_luuLai.Text = "Cập nhật hóa đơn";
            }
            else
            {
                btn_luuLai.Text = "Lưu hóa đơn";
            }
        }

        private void F_HoaDon_ChiTiet_Load(object sender, EventArgs e)
        {
            Load_Form();
        }

        private void F_KhachHang_themKhachHang_troVe(object? sender, EventArgs e)
        {

        }

        private void btn_xacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbb_sanPham.SelectedItem == null)
                {
                    MessageBox.Show("Hãy chọn 1 sản phẩm", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //if (!_isKiemTraThongTin())
                //    return;
                int maSanPham = Convert.ToInt32(cbb_sanPham.SelectedValue?.ToString());
                var chiTiet = hd_ChiTiet.FirstOrDefault(x => x.SanPhamID == maSanPham);

                var sp = context.SanPham.Where(r => r.SanPhamID == maSanPham).FirstOrDefault();
                if (sp != null)
                {
                    if (sp.SoLuongTon < int.Parse(num_soLuong.Value.ToString()))
                    {
                        if (sp.SoLuongTon == 0)
                        {
                            sp.TrangThai = enum_ThongTin.enum_SanPham_TrangThai.HetHang.ToString();
                            context.SanPham.Update(sp);
                            context.SaveChanges();
                            MessageBox.Show($"Sản phẩm này đã hết hàng tồn kho\nxin hãy liên hệ quản trị viên để được bổ sung", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (chiTiet == null)//thêm mới hóa đơn
                {
                    DanhSachHoaDon_ChiTiet ds_ChiTiet = new DanhSachHoaDon_ChiTiet
                    {
                        HoaDonChiTietID = 0,
                        HoaDonID = id_hoaDonCu,
                        TenSanPham = cbb_sanPham.Text,
                        SanPhamID = maSanPham,
                        DonGia = decimal.Parse(num_donGia.Value.ToString()),
                        SoLuongBan = int.Parse(num_soLuong.Value.ToString()),
                        ThanhTien = Convert.ToDecimal(num_donGia.Value * num_soLuong.Value),
                    };
                    hd_ChiTiet.Add(ds_ChiTiet);
                    context.SaveChanges();
                }
                else//cậo nhật số lượng
                {
                    chiTiet.SoLuongBan += int.Parse(num_soLuong.Value.ToString());
                    chiTiet.ThanhTien = chiTiet.SoLuongBan * chiTiet.DonGia;
                }
                if (sp.SoLuongTon < num_soLuong.Value) { return; }
                else
                {
                    sp.SoLuongTon -= int.Parse(num_soLuong.Value.ToString());
                    if (sp.SoLuongTon == 0)
                    {
                        sp.TrangThai = enum_ThongTin.enum_SanPham_TrangThai.HetHang.ToString();
                    }
                    context.SanPham.Update(sp);
                    context.SaveChanges();
                }
                dtg_chiTietHoaDon.DataSource = null;
                dtg_chiTietHoaDon.DataSource = hd_ChiTiet;
                changeHeaderName();
                cbb_sanPham.SelectedIndex = 1;
                num_soLuong.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message, "Error");
                return;
            }
            BatTat();
            btn_luuLai.Enabled = hd_ChiTiet.Count > 0;
            lable_tongTienHoaDon.Text = string.Format("{0:N2}", hd_ChiTiet.Sum(x => x.ThanhTien)) + " VNĐ";
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dtg_chiTietHoaDon.CurrentRow == null || dtg_chiTietHoaDon.RowCount == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng để xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int maSanPham = Convert.ToInt32(dtg_chiTietHoaDon.CurrentRow.Cells["SanPhamID"].Value);
            var chiTiet = hd_ChiTiet.FirstOrDefault(x => x.SanPhamID == maSanPham);

            if (chiTiet == null) return;

            if (MessageBox.Show($"Bạn có chắc muốn xóa sản phẩm '{chiTiet.TenSanPham}'?",
                               "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                // Xóa từ BindingList
                hd_ChiTiet.Remove(chiTiet);

                // Xóa từ database
                var chiTietDb = context.HoaDon_ChiTiet
                    .FirstOrDefault(x => x.HoaDonID == id_hoaDonCu && x.SanPhamID == maSanPham);

                if (chiTietDb != null)
                {
                    context.HoaDon_ChiTiet.Remove(chiTietDb);
                    context.SaveChanges();
                    MessageBox.Show("Đã xóa thành công", "Thông báo");
                }

                // Cập nhật lại DataGridView
                btn_luuLai.Enabled = hd_ChiTiet.Count > 0;
                dtg_chiTietHoaDon.DataSource = null;
                dtg_chiTietHoaDon.DataSource = hd_ChiTiet;
                changeHeaderName();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Khôi phục BindingList nếu cần
                if (!hd_ChiTiet.Contains(chiTiet))
                {
                    hd_ChiTiet.Add(chiTiet);
                }
            }
        }
        bool kiemTraHoaDon()
        {
            if (dtg_chiTietHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Hãy thêm sản phẩm cho hóa đơn trước khi lưu lại", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            kyHan = num_soKyHan.Value == 0 ? 0 : Convert.ToInt32(num_soKyHan.Value);
            laiSuat = num_soTienLai.Value == 0 ? 0 : Convert.ToDecimal(num_soTienLai.Value);
            //if(id_hoaDonCu)
            if (cbb_khachHang.SelectedText == "") return false;
            if (cbb_nhanVien.SelectedText == "") return false;
            if (cbb_phuongThucThanhToan.SelectedIndex == -1)
            {
                MessageBox.Show("Hãy chọn phương thức thanh toán cho hóa đơn này", "Thiếu phương thức thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbb_phuongThucThanhToan.Text.Equals("Trả góp") && (kyHan == 0 || laiSuat == 0))
            {
                MessageBox.Show("Hãy chọn kì hạn và lãi suất cho hóa đơn trả góp", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (hd_ChiTiet.Count == 0)
            {
                MessageBox.Show("Hãy thêm sản phẩm cho hóa đơn trước khi lưu lại", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else { return true; }
        }
        private void btn_luuLai_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_isKiemTraThongTin())
                {
                    return;
                }

                if (isKhachHangMoi != true) // nếu là khách hàng cũ thì bổ sung sản phẩm và thông tin thanh toán
                {
                    _isKhachHangCu();
                }
                else // Tạo hóa đơn mới
                {
                    _isKhachHangMoi();
                }
                if (isXacNhanLuu)
                {
                    MessageBox.Show("Đã lưu những thay đổi thành công\nBạn sẽ được đưa về Hóa đơn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // slideshowTimer.Stop();
                    themhoadon_troVe?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Lỗi lưu lại");
            }
        }
        private void TaoKeHoachTraGop(int hoaDonId, decimal tongTien, int soKyHan, decimal laiSuat)
        {
            // tạo 1 hóa đơn với phương thức trả góp
            decimal tienGocMoiKy = tongTien / soKyHan;
            decimal laiSuatKy = laiSuat / 100 / soKyHan; // Chuyển từ % sang decimal
            for (int i = 1; i <= soKyHan; i++)
            {
                decimal tienLaiKy = (tongTien - tienGocMoiKy * (i - 1)) * laiSuatKy;
                context.TraGop.Add(new TraGop
                {
                    HoaDonID = hoaDonId,
                    SoKyHan = soKyHan,
                    KyTra = i,
                    SoTienGoc = tienGocMoiKy,
                    SoTienLai = tienLaiKy,
                    SoTienConLai = tienGocMoiKy + tienLaiKy,
                    NgayDenHan = DateTime.Now.AddMonths(i + 1),
                    TrangThai = enum_ThongTin.enum_HoaDon.ChuaThanhToan.ToString(),
                    laiSuat = laiSuat
                });
            }
            decimal tongLai = tongTien * laiSuatKy * soKyHan;
            decimal tongPhaiTra = tongTien + tongLai;
            isKhachHangMoi = false;
            context.SaveChanges();
        }

        private void cbb_sanPham_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int maSanPham = Convert.ToInt32(cbb_sanPham.SelectedValue?.ToString());
            var sanPham = context.SanPham.Find(maSanPham);
            num_donGia.Value = decimal.Parse(sanPham.GiaBan.ToString().Replace(",", ""));
        }

        private void cbb_phuongThucThanhToan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selectedMethod = (enum_ThongTin.enum_PhuongThucThanhToan)cbb_phuongThucThanhToan.SelectedValue;
            if (selectedMethod == enum_ThongTin.enum_PhuongThucThanhToan.TraGop)
            {
                groupBox_trangThaiThanhToan.Enabled = false;
                groupBox_traGop.Enabled = true;
            }
            else
            {
                groupBox_trangThaiThanhToan.Enabled = true;
                groupBox_traGop.Enabled = false;
                laiSuat = 0;
                kyHan = 0;
            }
        }
        private void toolStripButton_huyBo_Click(object sender, EventArgs e)
        {
            laiSuat = 0;
            kyHan = 0;
        }
        private void pictureBox_troVeHoaDon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hãy đảm bảo đã lưu lại các thay đổi trước khi rời đi", "Lưu ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) == DialogResult.OK)
            {
                //slideshowTimer.Stop();
                themhoadon_troVe?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            else { return; }
        }

        private void label17_Click(object sender, EventArgs e)
        {
            F_Help helpForm = new F_Help("chitiet_hoadon"); // "login" là tên tương ứng file login.txt
            helpForm.ShowDialog();
        }

        #endregion

        private void pictureBox_troVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

