using BCrypt.Net;
using ClosedXML.Excel;
using DoAnBanHang_cuahangxemay.Data_Table;
using DoAnBanHang_cuahangxemay.help;
using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnBanHang_cuahangxemay.Forms
{
    public partial class F_NhanVien : Form
    {
        AppDbContext context = new AppDbContext();
        BindingSource bindingSource = new BindingSource();
        bool xulythem = false, quyenhan = false, Selectdata = false;
        int id_nhanvien;
        int id_nguoiDung;

        #region Methods
        void BatTatChucNang(bool tmp)
        {
            btn_Them.Enabled = btn_Sua.Enabled = btn_NhapFile.Enabled = btn_XuatFile.Enabled = dtg_NhanVien.Enabled = !tmp;
            btn_Luulai.Enabled = btn_Huy.Enabled = btn_Xoa.Enabled = tmp;
            //phanQuyenNguoiDung();
        }
        //txt_dienThoai.Enabled = txt_matKhau.Enabled = txt_tenDangNhap.Enabled = txt_hoTen.Enabled = txt_diaChi.Enabled = cbb_quyenhan.Enabled =
        void phanQuyenNguoiDung(bool tmp)
        {
            var nv = context.NhanVien.Find(id_nguoiDung);
            if (nv == null)
            {
                return;
            }
            if (nv.QuyenHan)
            {
                btn_Them.Enabled = btn_Sua.Enabled = btn_NhapFile.Enabled = btn_XuatFile.Enabled = dtg_NhanVien.Enabled = true;
                btn_Luulai.Enabled = btn_Huy.Enabled = btn_Xoa.Enabled = false;

                btn_Them.Enabled = btn_Sua.Enabled = btn_Xoa.Enabled = !tmp;
                btn_Luulai.Enabled = btn_Huy.Enabled = tmp;
                groupBox_doiMatKhau.Visible = false;
            }
            else
            {
                groupBox_doiMatKhau.Visible = btn_doiMatKhau.Enabled = btn_Sua.Enabled = btn_Xoa.Enabled = btn_XuatFile.Enabled = btn_NhapFile.Enabled = false;

                btn_Them.Enabled = true;
                btn_Them.Enabled = !tmp;
                btn_Luulai.Enabled = btn_Huy.Enabled = tmp;
            }
        }

        bool kiemTra()
        {
            if (string.IsNullOrEmpty(txt_hoTen.Text))
            {
                return false;
            }
            return true;
        }

        void Load_KhuVuc()
        {
            List<KhuVuc> list_khuvuc = new List<KhuVuc>();
            list_khuvuc = context.KhuVuc.ToList();
            cbb_khuVuc.DataSource = list_khuvuc;
            cbb_khuVuc.DisplayMember = "TenKhuVuc";
            cbb_khuVuc.ValueMember = "KhuVucID";
        }
        void load_NhanVien()
        {
            phanQuyenNguoiDung(false);
            object[] objects = { "Nhân Viên", "Quản Lí" };
            cbb_quyenhan.Items.Clear();
            cbb_quyenhan.Items.AddRange(objects);
            cbb_quyenhan.SelectedIndex = 0;

            List<NhanVien> list_nhanvien = new List<NhanVien>();
            list_nhanvien = context.NhanVien.ToList();
            bindingSource.DataSource = list_nhanvien;

            txt_hoTen.DataBindings.Clear();
            txt_hoTen.DataBindings.Add("Text", bindingSource, "HoVaTen", false, DataSourceUpdateMode.Never);
            txt_dienThoai.DataBindings.Clear();
            txt_dienThoai.DataBindings.Add("Text", bindingSource, "DienThoai", false, DataSourceUpdateMode.Never);
            txt_diaChi.DataBindings.Clear();
            txt_diaChi.DataBindings.Add("Text", bindingSource, "DiaChi", false, DataSourceUpdateMode.Never);
            txt_tenDangNhap.DataBindings.Clear();
            txt_tenDangNhap.DataBindings.Add("Text", bindingSource, "TenDangNhap", false, DataSourceUpdateMode.Never);
            txt_matKhau.DataBindings.Clear();
            txt_matKhau.DataBindings.Add("Text", bindingSource, "MatKhau", false, DataSourceUpdateMode.Never);
            cbb_quyenhan.DataBindings.Clear();
            cbb_quyenhan.DataBindings.Add("SelectedIndex", bindingSource, "QuyenHan", false, DataSourceUpdateMode.Never);
            cbb_khuVuc.DataBindings.Clear();
            cbb_khuVuc.DataBindings.Add("SelectedValue", bindingSource, "KhuVucID", false, DataSourceUpdateMode.Never);

            dtg_NhanVien.DataSource = bindingSource;
            dtg_NhanVien.Columns["NhanVienID"].Visible = false;
            dtg_NhanVien.Columns["HoVaTen"].HeaderText = "Họ tên";
            dtg_NhanVien.Columns["DienThoai"].HeaderText = "Số điện thoại";
            dtg_NhanVien.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dtg_NhanVien.Columns["tenDangNhap"].HeaderText = "Tên đăng nhập";
            dtg_NhanVien.Columns["MatKhau"].HeaderText = "Mật khẩu";
            dtg_NhanVien.Columns["MatKhau"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            txt_matKhau.Enabled = false;
            dtg_NhanVien.Columns["QuyenHan"].Visible = false;
            dtg_NhanVien.Columns["KhuVucID"].Visible = false;
            dtg_NhanVien.Columns["KhuVuc"].Visible = false;


        }
        #endregion

        #region Event
        private void panel_formCon_Paint(object sender, PaintEventArgs e) // màu nền cho panel
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                panel_form.ClientRectangle,
                Color.FromArgb(5, 153, 158),    // Màu bắt đầu (#05999E)
                Color.FromArgb(203, 231, 227),  // Màu kết thúc (#CBE7E3)
                LinearGradientMode.ForwardDiagonal)) // Chiều chéo ↘
            {
                e.Graphics.FillRectangle(brush, panel_form.ClientRectangle);
            }
        }
        public F_NhanVien(int nhanVienID)
        {
            InitializeComponent();
            id_nguoiDung = nhanVienID;
        }

        private void F_NhanVien_Load(object sender, EventArgs e)
        {
            groupBox_doiMatKhau.Visible = false;
            load_NhanVien();
            Load_KhuVuc();
            menuStrip_chucNang.Enabled = true;
            Selectdata = true;
            pictureBox1.Visible = false;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            xulythem = txt_matKhau.Enabled = true;
            phanQuyenNguoiDung(true);
            txt_hoTen.Text = txt_dienThoai.Text = txt_matKhau.Text = txt_tenDangNhap.Text = txt_diaChi.Text = "";
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            //BatTatChucNang(true);
            phanQuyenNguoiDung(true);
            id_nhanvien = Convert.ToInt32(dtg_NhanVien.CurrentRow.Cells["NhanVienID"].Value.ToString());
            dtg_NhanVien.Enabled = false;
            xulythem = false;
            NhanVien n = context.NhanVien.Find(id_nhanvien);
            if (n != null)
            {
                bool ketQua = n.MatKhau.Trim().Equals("");
                if (ketQua)
                {
                    txt_matKhau.Enabled = true;
                }
                else
                {
                    txt_matKhau.Enabled = false;
                }
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dtg_NhanVien.CurrentRow == null || dtg_NhanVien.CurrentRow.Cells["NhanVienID"].Value == null)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(dtg_NhanVien.CurrentRow.Cells["NhanVienID"].Value.ToString(), out int id))
            {
                MessageBox.Show("ID nhân viên không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NhanVien n = context.NhanVien.Find(id);
            if (n == null)
            {
                MessageBox.Show("Không tìm thấy nhân viên này", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (n.TenDangNhap.ToLower().Equals("admin"))
            {
                MessageBox.Show("Đây là tài khoản mặc định của hệ thống không thể xóa", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            var tonTai = context.NhanVien.Where(r => r.QuyenHan == true).Count();
            if (tonTai == 1 && n.QuyenHan == true)
            {
                MessageBox.Show($"Không thể xóa tài khoản của {n.HoVaTen} vì phải có 1 quản lý trong danh sách", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (context.HoaDon.Any(x => x.NhanVienID == id_nhanvien) == true)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã có hóa đơn liên quan", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var ql_khuvuc = context.NhanVien.Find(id_nguoiDung);
            if (ql_khuvuc == null)
            {
                MessageBox.Show("Không tim thấy khu vực", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (ql_khuvuc.KhuVucID != n.KhuVucID)
            {
                string tenKhuVuc = context.KhuVuc.Find(n.KhuVucID)?.TenKhuVuc ?? "Không xác định";
                MessageBox.Show("Bạn không có quyền xóa nhân viên khác khu vực đang quản lý.\nLiên hệ Quản lý khu vực " + tenKhuVuc + " để được hỗ trợ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show($"bạn có muốn xóa nhân viên: {n.HoVaTen ?? "Tên không xác định"} không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    context.NhanVien.Remove(n);
                    context.SaveChanges();
                    load_NhanVien();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_huybo_Click(object sender, EventArgs e)
        {
            F_NhanVien_Load(sender, e);
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            var isNhanVien = context.NhanVien.Find(id_nguoiDung);
            dtg_NhanVien.Enabled = true;
            try
            {
                if (isNhanVien?.QuyenHan != true && cbb_quyenhan.SelectedIndex == 1)
                {
                    MessageBox.Show("Chỉ có quản lý mới được phân quyền cho tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (context.NhanVien.Any(nv => nv.NhanVienID != id_nhanvien && nv.TenDangNhap.Trim().Equals(txt_tenDangNhap.Text)))
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại, vui lòng chọn tên khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txt_tenDangNhap.Focus();
                    return;
                }
                if (xulythem)
                {
                    NhanVien nhanVien = new NhanVien();
                    nhanVien.HoVaTen = txt_hoTen.Text;
                    nhanVien.DiaChi = txt_diaChi.Text;
                    nhanVien.DienThoai = txt_dienThoai.Text;
                    nhanVien.TenDangNhap = txt_tenDangNhap.Text;
                    nhanVien.MatKhau = BCrypt.Net.BCrypt.HashPassword(txt_matKhau.Text);
                    nhanVien.QuyenHan = cbb_quyenhan.SelectedIndex == 1 ? true : false;
                    nhanVien.KhuVucID = int.Parse(cbb_khuVuc.SelectedValue?.ToString() ?? "1");
                    context.NhanVien.Add(nhanVien);
                    context.SaveChanges();
                }
                else
                {
                    NhanVien n = context.NhanVien.Find(id_nhanvien);
                    if (n != null)
                    {
                        n.HoVaTen = txt_hoTen.Text;
                        n.DiaChi = txt_diaChi.Text;
                        n.DienThoai = txt_dienThoai.Text;
                        n.TenDangNhap = txt_tenDangNhap.Text;
                        n.KhuVucID = int.Parse(cbb_khuVuc.SelectedValue?.ToString() ?? "1");
                        n.QuyenHan = cbb_quyenhan.SelectedIndex == 1 ? true : false;

                        context.NhanVien.Update(n);
                        context.SaveChanges();
                    }
                }
                load_NhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
            saveFileDialog.FileName = "NhanVien_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    dataTable.Columns.Add("NhanVienID", typeof(int));
                    dataTable.Columns.Add("HoVaTen", typeof(string));
                    dataTable.Columns.Add("DienThoai", typeof(string));
                    dataTable.Columns.Add("DiaChi", typeof(string));
                    dataTable.Columns.Add("TenDangNhap", typeof(string));
                    dataTable.Columns.Add("MatKhau", typeof(string));
                    dataTable.Columns.Add("QuyenHan", typeof(bool));
                    dataTable.Columns.Add("KhuVucID", typeof(int));
                    var nhanVien = context.NhanVien.ToList();
                    if (nhanVien != null)
                    {
                        List<NhanVien> ds = new List<NhanVien>();
                        if (nhanVien != null)
                        {
                            foreach (var p in nhanVien)
                            {
                                dataTable.Rows.Add(p.NhanVienID, p.HoVaTen, p.DienThoai, p.DiaChi, p.TenDangNhap, "", p.QuyenHan, p.KhuVucID);
                            }
                        }
                    }
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(dataTable, "NhanVien");
                        sheet.Columns().AdjustToContents();
                        wb.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Đã xuất dữ liệu nhân viên ra tập tin Excel thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        IXLWorksheet xLWorksheet = xlw.Worksheet(1);
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
                            List<NhanVien> nhanVienMoi = new List<NhanVien>();
                            var nhanvienDaTonTai = context.NhanVien.Select(s => s.DienThoai).ToList();
                            foreach (DataRow row in dataTable.Rows)
                            {
                                string soDienThoai = row["DienThoai"].ToString() ?? "";
                                if (string.IsNullOrEmpty(soDienThoai) || string.IsNullOrWhiteSpace(soDienThoai)) continue;
                                if (!nhanvienDaTonTai.Contains(soDienThoai))
                                {
                                    NhanVien s = new NhanVien();
                                    s.HoVaTen = (row["HoVaTen"]?.ToString() ?? "");
                                    s.DiaChi = (row["DiaChi"].ToString() ?? "");
                                    s.DienThoai = (row["DienThoai"].ToString() ?? "");
                                    s.KhuVucID = int.Parse(row["KhuVucID"].ToString() ?? "1");
                                    s.MatKhau = BCrypt.Net.BCrypt.HashPassword("1");
                                    s.TenDangNhap = row["TenDangNhap"].ToString() ?? "";
                                    s.QuyenHan = bool.Parse(row["QuyenHan"].ToString() ?? "0");

                                    nhanVienMoi.Add(s);
                                    cout++;
                                    nhanvienDaTonTai.Add(soDienThoai);
                                }
                            }
                            if (cout > 0)
                            {
                                if (MessageBox.Show("Tìm thấy ( " + cout + " ) Nhân viên mới !\nBạn có muốn thêm váo danh sách không?", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                {
                                    context.NhanVien.AddRange(nhanVienMoi);
                                    context.SaveChanges();
                                    F_NhanVien_Load(sender, e);
                                    MessageBox.Show($"Đã nhập thành công {cout} Nhân viên\nMật khẩu mặc định là 1", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    nhanVienMoi.Clear();
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
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }

        }

        private void dtg_NhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (Selectdata == false)
            {
                return;
            }
            else
            {
                if (bindingSource.Current != null)
                {
                    DoAnBanHang_cuahangxemay.Data_Table.NhanVien nhanVien = (DoAnBanHang_cuahangxemay.Data_Table.NhanVien)bindingSource.Current;
                    if (nhanVien.QuyenHan != true)
                    {
                        cbb_quyenhan.SelectedItem = "Nhân Viên";
                    }
                    else
                    {
                        cbb_quyenhan.SelectedItem = "Quản Lí";
                    }
                }
            }

        }

        private void cbb_quyenhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_quyenhan.SelectedIndex == 0)
            {
                quyenhan = false;
            }
            else
            {
                quyenhan = true;
            }

        }

        private void btn_doiMatKhau_Click(object sender, EventArgs e)
        {
            NhanVien nv = context.NhanVien.Where(s => s.NhanVienID == id_nguoiDung).First();
            if (nv.TenDangNhap.Trim().ToLower().Equals("admin"))
            {
                txt_oldPassWord.Enabled = false;
            }
            pictureBox1.Visible = true;
            pictureBox_locked.Visible = menuStrip_chucNang.Enabled = false;
            id_nhanvien = Convert.ToInt32(dtg_NhanVien.CurrentRow.Cells["NhanVienID"].Value.ToString());
            dtg_NhanVien.Enabled = btn_doiMatKhau.Enabled = false;
            btn_doiMatKhau.BackColor = Color.Aquamarine;
            groupBox_thongTinNhanVien.Visible = false;
            groupBox_doiMatKhau.Visible = true;
            BatTatChucNang(false);
        }

        private void checkBox_hienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_hienMatKhau.Checked)
            {
                txt_newPassWord.PasswordChar = '\0';
                txt_verifyNewPassWord.PasswordChar = '\0';
            }
            else
            {
                txt_newPassWord.PasswordChar = 'o';
                txt_verifyNewPassWord.PasswordChar = '^';
            }
        }

        private void btn_doiMatKhau_xacNhan_Click(object sender, EventArgs e)
        {
            bool isAdmin = false;
            NhanVien n = context.NhanVien.Find(id_nhanvien);
            if (n != null)
            {
                NhanVien admin = context.NhanVien.Where(s => s.NhanVienID == id_nguoiDung).First();
                if (!admin.TenDangNhap.Trim().ToLower().Equals("admin"))
                {
                    if (string.IsNullOrEmpty(txt_oldPassWord.Text))
                    {
                        MessageBox.Show("Mật khẩu < cũ > không được để trống !", "Lỗi Đổi Mật Khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_oldPassWord.Focus();
                        return;
                    }
                }
                else
                {
                    isAdmin = true;
                }
                if (string.IsNullOrEmpty(txt_newPassWord.Text) || string.IsNullOrEmpty(txt_verifyNewPassWord.Text))
                {
                    MessageBox.Show("Mật khẩu < mới > không được để trống !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_newPassWord.Focus();
                    return;
                }
                else if (!txt_verifyNewPassWord.Text.Contains(txt_newPassWord.Text))
                {
                    MessageBox.Show("Mật khẩu nhập lại không trùng khớp !", "Lỗi không trùng khớp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_verifyNewPassWord.Focus();
                    return;
                }
                try
                {
                    if (!isAdmin)
                    {

                        bool kiemtra = BCrypt.Net.BCrypt.Verify(txt_oldPassWord.Text.Trim(), n.MatKhau);

                        if (kiemtra == false)
                        {
                            MessageBox.Show("Mật khẩu cũ không chính xác !!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txt_matKhau.Focus();
                            return;
                        }
                        else
                        {
                            n.MatKhau = BCrypt.Net.BCrypt.HashPassword(txt_verifyNewPassWord.Text);
                            context.NhanVien.Update(n);
                            context.SaveChanges();
                            F_NhanVien_Load(sender, e);
                            btn_doiMatKhau_huyBo_Click(sender, e);
                            pictureBox1.Visible = menuStrip_chucNang.Enabled = true;
                            pictureBox_locked.Visible = false;
                            MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("admin true");
                        n.MatKhau = BCrypt.Net.BCrypt.HashPassword(txt_verifyNewPassWord.Text);
                        context.NhanVien.Update(n);
                        context.SaveChanges();
                        F_NhanVien_Load(sender, e);
                        btn_doiMatKhau_huyBo_Click(sender, e);
                        pictureBox1.Visible = menuStrip_chucNang.Enabled = true;
                        pictureBox_locked.Visible = false;
                        MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (BCrypt.Net.SaltParseException)
                {
                    return;
                }
            }
            else { MessageBox.Show("Không tồn tại người dùng này", "Lỗi Đổi Mật Khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btn_doiMatKhau_huyBo_Click(object sender, EventArgs e)
        {
            groupBox_doiMatKhau.Visible = false;
            btn_doiMatKhau.BackColor = Color.White;
            groupBox_thongTinNhanVien.Visible = btn_doiMatKhau.Enabled = menuStrip_chucNang.Enabled = true;
            BatTatChucNang(false);
            dtg_NhanVien.Enabled = true;
            pictureBox_locked.Visible = true;
            pictureBox1.Visible = false;
        }

        private void pictureBox_troVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_searchByName_TextChanged(object sender, EventArgs e)
        {
            if (txt_searchByName.Text != "")
            {
                var search = context.NhanVien.Where(x => x.HoVaTen.ToLower().Contains(txt_searchByName.Text.ToLower())).ToList();
                bindingSource.DataSource = search;
            }
            else
            {
                load_NhanVien();
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {
            F_Help helpForm = new F_Help("nhanvien"); // "login" là tên tương ứng file login.txt
            helpForm.ShowDialog();
        }

        #endregion

    }
}
