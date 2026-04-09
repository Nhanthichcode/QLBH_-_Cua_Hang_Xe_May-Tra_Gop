using DoAnBanHang_cuahangxemay.Data_Table;
using DoAnBanHang_cuahangxemay.help;
using DoAnBanHang_cuahangxemay.Reports;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.EntityFrameworkCore;
using DoAnBanHang_cuahangxemay.NhatKyDangNhap;
using DocumentFormat.OpenXml.InkML;
using System.Drawing.Drawing2D;
using QRCoder;

namespace DoAnBanHang_cuahangxemay.Forms
{
    public partial class F_MainTrangChu : Form
    {
        AppDbContext context = new AppDbContext();
        F_DangNhap f_DangNhap = null;
        F_KhuVuc f_KhuVuc = null;
        F_SanPham f_SanPham = null;
        F_HangSanXuat f_HangSanXuat = null;
        F_NhanVien f_NhanVien = null;
        F_KhachHang f_KhachHang = null;
        F_HoaDon f_HoaDon = null;
        F_HoaDon_ChiTiet f_HoaDon_ChiTiet = null; // chú ý
        F_ThanhToan f_ThanhToan = null;
        F_TraGop f_TraGop = null;
        F_MainTrangChu f_MainTrangChu = null;

        Form_Report_ThongKeDoanhThu form_Report_ThongKeDoanhThu = null;
        Form_Report_thongKeSanPham form_Report_ThongKeSan = null;
        private Form _currentChildForm;

        string hoVaTenNhanVien = "";
        int keyPhanQuyen;
        int quyenNguoiDung;

        // tạo mã QrCode
        public static Bitmap GenerateQRCode(string data)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            return qrCode.GetGraphic(10);
        }
        public static byte[] ConvertBitmapToBytes(Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        #region Methods
        public void SetPhanQuyen(int nhanvienID)
        {
            keyPhanQuyen = nhanvienID;
        }
        public void SetTenDangNhap(string name)
        {
            hoVaTenNhanVien = name;
        }
        void phanQuyenNguoiDung(int nhanvienID)
        {
            int tmp;
            var quyenHan = context.NhanVien.Find(nhanvienID);
            if (quyenHan != null)
            {
                tmp = quyenHan.QuyenHan == true ? 2 : 1; //(quản lý == true) 1 là quản lý, 0 là nhân viên
            }
            else
            {
                tmp = 0; // Khách hàng
            }
            switch (tmp)
            {
                case 2:
                    quyenNguoiDung = nhanvienID; // Đặt quyền người dùng là quản lý
                    quyenQuanLy();
                    break;
                case 1:
                    quyenNguoiDung = nhanvienID; // Đặt quyền người dùng là nhân viên
                    quyenNhanVien();
                    break;
                default:
                    quyenKhachHang();
                    quyenNguoiDung = 0; // Đặt lại quyền người dùng về mặc định (khách hàng)
                    break;
            }
        }
        public void quyenKhachHang()
        {
            //this.Icon = new Icon("1490201150-client_82317.ico");
            toolStripButton_Lout.Enabled = false;
            toolStripButtonLin.Enabled = true;
            toolStripButton_SP.Enabled = true;
            toolStripButton_KH.Enabled = true;

            toolStripMenuItem_KV.Enabled = false;
            toolStripButton_HSX.Enabled = false;
            toolStripButton_HĐ.Enabled = false;
            toolStripButton_NV.Enabled = false;
            toolStripButton_TG.Enabled = false;
            toolStripButton_TT.Enabled = false;

            đăngNhậpToolStripMenuItem.Enabled = false;
            toolStripMenuItem_lichSuDN.Enabled = false;


            toolStripDropDownButton_xemThem.Enabled = false;
            // Hiển thị thông tin trên thanh trạng thái
            tsLabel_trangThaidangNhap.Text = "Khách hàng không danh phận";
        }
        public void quyenQuanLy()
        {
            //this.Icon = new Icon("jenkins_logo_icon_170552.ico");

            toolStripButton_Lout.Enabled = true;
            toolStripButtonLin.Enabled = false;

            toolStripMenuItem_KV.Enabled = true;
            toolStripButton_HSX.Enabled = true;
            toolStripButton_HĐ.Enabled = true;
            toolStripButton_KH.Enabled = true;
            toolStripButton_NV.Enabled = true;
            toolStripButton_SP.Enabled = true;
            toolStripButton_TG.Enabled = true;
            toolStripButton_TT.Enabled = true;

            đăngNhậpToolStripMenuItem.Enabled = true;
            toolStripMenuItem_lichSuDN.Enabled = true;

            toolStripDropDownButton_xemThem.Enabled = true;
            var nv = context.NhanVien.Find(quyenNguoiDung);
            var kv = context.KhuVuc.Where(r => r.KhuVucID == nv.KhuVucID).FirstOrDefault();
            tsLabel_trangThaidangNhap.Text = "Quản lý:    " + hoVaTenNhanVien + "  /    Khu vực: " + kv.TenKhuVuc??"Không xác định";
        }
        public void quyenNhanVien()
        {
            //this.Icon = new Icon("bootloader_users_person_people_6080.ico");
            // Mờ đăng nhập
            toolStripButton_Lout.Enabled = true;
            toolStripButtonLin.Enabled = false;
            toolStripButton_TG.Enabled = false;
            toolStripButton_TT.Enabled = false;
            toolStripMenuItem_KV.Enabled = true;

            toolStripButton_HSX.Enabled = true;
            toolStripButton_HĐ.Enabled = true;
            toolStripButton_KH.Enabled = true;
            toolStripButton_NV.Enabled = true;
            toolStripButton_SP.Enabled = true;

            đăngNhậpToolStripMenuItem.Enabled = false;
            toolStripMenuItem_lichSuDN.Enabled = true;



            toolStripDropDownButton_xemThem.Enabled = false;
            tsLabel_trangThaidangNhap.Text = "Nhân viên: " + hoVaTenNhanVien;
        }

        #endregion

        // màu cho button 
        public class GlowToolStripRenderer : ToolStripProfessionalRenderer
        {
            public GlowToolStripRenderer() : base(new GlowColorTable()) { }

            // Vẽ nền của button khi hover (chọn)
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                base.OnRenderMenuItemBackground(e);

                if (e.Item.Selected && e.Item is ToolStripMenuItem)
                {
                    Rectangle rect = new Rectangle(Point.Empty, e.Item.Size);

                    // Gradient chéo: #05999E → #CBE7E3
                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        rect,
                        ColorTranslator.FromHtml("#1F2F98 "),
                        ColorTranslator.FromHtml("#4ADEDE"),
                        LinearGradientMode.ForwardDiagonal))
                    {
                        e.Graphics.FillRectangle(brush, rect);
                    }
                    // Viền viền viền glow
                    using (Pen borderPen = new Pen(Color.Teal, 2))
                    {
                        e.Graphics.DrawRectangle(borderPen, new Rectangle(0, 0, rect.Width - 1, rect.Height - 1));
                    }

                    // Đổi màu chữ để dễ nhìn
                    e.Item.ForeColor = Color.WhiteSmoke;
                }
                else
                {
                    e.Item.ForeColor = Color.Black; // reset nếu không hover
                }
            }

            protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
            {
                base.OnRenderButtonBackground(e);

                ToolStripButton button = e.Item as ToolStripButton;

                if (button != null && button.Selected) // Chỉ khi button được chọn (hover)
                {
                    Rectangle rect = new Rectangle(Point.Empty, e.Item.Size);

                    // Gradient chéo: #05999E → #CBE7E3
                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        rect,
                        ColorTranslator.FromHtml("#1F2F98 "),
                        ColorTranslator.FromHtml("#4ADEDE"),
                        LinearGradientMode.ForwardDiagonal))
                    {
                        e.Graphics.FillRectangle(brush, rect);
                    }
                    // Viền viền viền glow
                    using (Pen borderPen = new Pen(Color.Teal, 2))
                    {
                        e.Graphics.DrawRectangle(borderPen, new Rectangle(0, 0, rect.Width - 1, rect.Height - 1));
                    }
                    e.Item.ForeColor = Color.WhiteSmoke;// màu chữ
                }
                else
                {
                    e.Item.ForeColor = Color.Black;
                }
            }

            // Vẽ nền của drop-down button khi hover
            protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
            {
                base.OnRenderDropDownButtonBackground(e);

                if (e.Item.Selected) // Khi hover
                {
                    Rectangle rect = new Rectangle(Point.Empty, e.Item.Size);

                    // Gradient chéo: #1F2F98 → #4ADEDE
                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        rect,
                        ColorTranslator.FromHtml("#1F2F98 "),
                        ColorTranslator.FromHtml("#4ADEDE"),
                        LinearGradientMode.ForwardDiagonal))
                    {
                        e.Graphics.FillRectangle(brush, rect);
                    }
                    // Viền viền viền glow
                    using (Pen borderPen = new Pen(Color.Teal, 2))
                    {
                        e.Graphics.DrawRectangle(borderPen, new Rectangle(0, 0, rect.Width - 1, rect.Height - 1));
                    }
                    e.Item.ForeColor = Color.WhiteSmoke;// màu chữ
                }
                else
                {
                    e.Item.ForeColor = Color.Black;
                }
            }
        }

        public class GlowColorTable : ProfessionalColorTable
        {
            public override Color MenuItemSelected => Color.Transparent;
            public override Color MenuItemSelectedGradientBegin => Color.FromArgb(255, 255, 0);  // Neon Yellow
            public override Color MenuItemSelectedGradientEnd => Color.FromArgb(255, 0, 255);   // Magenta / Fuchsia
            public override Color MenuItemBorder => Color.DeepPink;  // Viền rực rỡ
        }

        private void panel_formCon_Paint(object sender, PaintEventArgs e) // màu nền cho panel
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                panel_formCon.ClientRectangle,
                Color.FromArgb(5, 153, 158),    // Màu bắt đầu (#05999E)
                Color.FromArgb(203, 231, 227),  // Màu kết thúc (#CBE7E3)
                LinearGradientMode.ForwardDiagonal)) // Chiều chéo ↘
            {
                e.Graphics.FillRectangle(brush, panel_formCon.ClientRectangle);
            }
        }

        #region Event
        private void F_MainTrangChu_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                F_Help helpForm = new F_Help("trangchu"); // "login" là tên tương ứng file login.txt
                helpForm.ShowDialog();
                return true;
            }
            if (keyData == Keys.Escape)
            {
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public F_MainTrangChu()
        {
            InitializeComponent();
            if (!this.IsMdiContainer)
            {
                this.IsMdiContainer = true;
            }
            //toolStrip_menuDropDown.Renderer = new CustomGlowRenderer();
            toolStrip_menuDropDown.Renderer = new GlowToolStripRenderer();
            this.Visible = false;
        }
        #region Xử Lý Đăng Nhập
        private void F_MainTrangChu_Load(object sender, EventArgs e)
        {
            kiemTraDanpNhap();
        }
        void kiemTraDanpNhap()
        {
            using (f_DangNhap = new F_DangNhap())
            {
                if (f_DangNhap.ShowDialog() == DialogResult.OK)
                {
                    SetPhanQuyen(f_DangNhap.setPhanQuyen);
                    SetTenDangNhap(f_DangNhap.setTenUser);
                    this.Show();
                }
            }
            phanQuyenNguoiDung(keyPhanQuyen);
        }
        #endregion

        #region QUẢN LÝ

        public void OpenChildForm(Form childForm)
        {
            try
            {
                CloseAllChildForms();
                CloseCurrentChildForm();

                childForm.TopLevel = false; // Quan trọng
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill; // Quan trọng
                // 3. Thêm Form vào Panel
                panel_formCon.Controls.Add(childForm);

                // 4. Căn giữa Form con trong Panel
                childForm.Location = new Point(
                    (panel_formCon.Width - childForm.Width) / 2,
                    (panel_formCon.Height - childForm.Height) / 2
                );

                // 5. Tự động căn giữa khi resize Panel
                panel_formCon.Resize += (sender, e) =>
                {
                    childForm.Location = new Point(
                        (panel_formCon.Width - childForm.Width) / 2,
                        (panel_formCon.Height - childForm.Height) / 2
                    );
                };

                childForm.Show();
                _currentChildForm = childForm;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở Form", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                childForm?.Dispose();
            }
        }
        private void CloseCurrentChildForm()
        {
            if (_currentChildForm != null && !_currentChildForm.IsDisposed)
            {
                // Hủy đăng ký sự kiện
                _currentChildForm.FormClosed -= ChildForm_FormClosed;

                // Đóng và giải phóng tài nguyên
                _currentChildForm.Close();
                _currentChildForm.Dispose();
                _currentChildForm = null;
            }

            // Xóa tất cả control còn sót lại (nếu cần)
            panel_formCon.Controls.Clear();
        }
        private void CloseAllChildForms()
        {
            // Tạo bản sao danh sách để tránh lỗi khi xóa phần tử
            var formsToClose = panel_formCon.Controls.OfType<Form>().ToList();

            foreach (var form in formsToClose)
            {
                form.FormClosed -= ChildForm_FormClosed; // Hủy đăng ký sự kiện nếu có
                form.Close();
                form.Dispose();
            }

            // Xóa tất cả control còn sót lại
            panel_formCon.Controls.Clear();

            // Reset biến theo dõi form hiện tại
            _currentChildForm = null;
        }
        private void ChildForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var form = (Form)sender;
            form.Dispose();
        }
        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_NhanVien != null && !f_NhanVien.IsDisposed)
            {
                f_NhanVien.Refresh();
                f_NhanVien.BringToFront();
            }
            else
            {
                f_NhanVien = new F_NhanVien(quyenNguoiDung);
                OpenChildForm(f_NhanVien);
            }
        }

        public static int ShowModernInputDialog(string title, string promptText, string defaultValue = "")
        {
            // Tạo form
            Form form = new Form()
            {
                Text = title,
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                ClientSize = new Size(400, 180),
                MinimumSize = new Size(400, 180),
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.FromArgb(250, 250, 250),
                Font = new Font("Segoe UI", 10)
            };

            // Label hướng dẫn
            Label label = new Label()
            {
                Text = promptText,
                Location = new Point(20, 20),
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 10.5f)
            };

            // TextBox nhập liệu
            TextBox textBox = new TextBox()
            {
                Location = new Point(20, 50),
                Size = new Size(360, 30),
                Text = defaultValue,
                Font = new Font("Segoe UI", 10),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                ForeColor = Color.Gray,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            // Panel phân cách
            Panel separator = new Panel()
            {
                BackColor = Color.FromArgb(230, 230, 230),
                Size = new Size(360, 1),
                Location = new Point(20, 85),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            // Button OK
            Button buttonOk = CreateModernButton("OK", DialogResult.OK, 200);
            buttonOk.Location = new Point(220, 110);

            // Button Cancel
            Button buttonCancel = CreateModernButton("Cancel", DialogResult.Cancel, 200);
            buttonCancel.Location = new Point(320, 110);

            // Thêm controls vào form
            form.Controls.Add(label);
            form.Controls.Add(textBox);
            form.Controls.Add(separator);
            form.Controls.Add(buttonOk);
            form.Controls.Add(buttonCancel);

            // Xử lý sự kiện
            buttonOk.Click += (sender, e) => { form.DialogResult = DialogResult.OK; };
            buttonCancel.Click += (sender, e) => { form.DialogResult = DialogResult.Cancel; };

            // Hiển thị dialog
            if (form.ShowDialog() == DialogResult.OK)
            {
                return int.Parse(textBox.Text);
            }
            return 0;
        }

        private static Button CreateModernButton(string text, DialogResult dialogResult, int width)
        {
            Button button = new Button()
            {
                Text = text,
                Size = new Size(80, 36),
                FlatStyle = FlatStyle.Flat,
                DialogResult = dialogResult,
                BackColor = Color.FromArgb(66, 133, 244), // Màu xanh Google
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(53, 122, 232);
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(42, 111, 221);

            return button;
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (quyenNguoiDung == 0)
            {
                int userInput = ShowModernInputDialog("Xác nhận thông tin",
                                                        "Vui lòng nhập mã khách hàng của bạn:",
                                                        "mã khách hàng");
                if (userInput != 0)
                {
                    var isTonTai = context.KhachHang.Any(r => r.KhachHangID == userInput);
                    if (!isTonTai)
                    {
                        MessageBox.Show("Mã khách hàng không tồn tại trong hệ thống\nVui lòng thử lại", "Không tìm thấy mã bạn vừa nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                        //userInput = ShowInputDialog("Nhập mã số", "Vui lòng nhập mã khách hàng của bạn:");
                    }
                    KhachHang k = context.KhachHang.Where(r => r.KhachHangID == userInput).First();
                    string tenKhachHang = k.HoVaTen ?? "";
                    tsLabel_trangThaidangNhap.Text = "Khách hàng: " + tenKhachHang;
                    this.Icon = new Icon("1490201150-client_82317.ico");
                    f_KhachHang = new F_KhachHang(0, userInput);
                    OpenChildForm(f_KhachHang);
                }
                return;
            }
            f_KhachHang = new F_KhachHang(quyenNguoiDung, 0);
            OpenChildForm(f_KhachHang);
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_SanPham = new F_SanPham(quyenNguoiDung);
            OpenChildForm(f_SanPham);
        }

        private void hãngSảnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_HangSanXuat = new F_HangSanXuat(quyenNguoiDung);
            OpenChildForm(f_HangSanXuat);
        }
        //public static event EventHandler moForms_ChiTiet;
        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_HoaDon = new F_HoaDon(quyenNguoiDung);
            OpenChildForm(f_HoaDon);
            F_HoaDon.moForms_ChiTiet += (s, e) =>
            {
                f_HoaDon_ChiTiet = new F_HoaDon_ChiTiet(0, quyenNguoiDung);
                OpenChildForm(f_HoaDon_ChiTiet);
            };
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_ThanhToan = new F_ThanhToan(quyenNguoiDung);
            OpenChildForm(f_ThanhToan);
        }

        private void trảGópToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_TraGop = new F_TraGop(quyenNguoiDung);
            OpenChildForm(f_TraGop);
        }
        #endregion

        private void đĂNGXUẤTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogDangNhapThanhCong log = context.LogDangNhapThanhCongs.Where(r => r.TimeLogOut == null).OrderByDescending(t => t.TimeLogIn).First();
            log.TimeLogOut = DateTime.Now.ToLocalTime();
            context.Update(log);
            context.SaveChanges();

            CloseAllChildForms();
            quyenNguoiDung = 0;
            quyenKhachHang();
            GC.Collect();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildForms();
            this.Visible = false;
            kiemTraDanpNhap();
        }

        private void thốngKêDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form_Report_ThongKeDoanhThu == null || form_Report_ThongKeDoanhThu.IsDisposed)
            {
                form_Report_ThongKeDoanhThu = new Form_Report_ThongKeDoanhThu();
                OpenChildForm(form_Report_ThongKeDoanhThu);
            }
            else
                form_Report_ThongKeDoanhThu.Activate();
        }

        private void thốngKêSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form_Report_ThongKeSan == null || form_Report_ThongKeSan.IsDisposed)
            {
                form_Report_ThongKeSan = new Form_Report_thongKeSanPham();
                OpenChildForm(form_Report_ThongKeSan);
            }
            else
                form_Report_ThongKeSan.Activate();
        }

        private void F_MainTrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn tắt ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void F_MainTrangChu_FormClosed(object sender, FormClosedEventArgs e)
        {
            var lastLogin = context.LogDangNhapThanhCongs
                                           .Where(r => r.TimeLogOut == null)
                                           .OrderByDescending(t => t.TimeLogIn)
                                           .FirstOrDefault();

            if (lastLogin != null)
            {
                // Cập nhật thời gian logout
                lastLogin.TimeLogOut = DateTime.Now;
                context.Update(lastLogin);

                // Lưu vào database
                context.SaveChanges();
            }
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }
        private void trợGiúpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            F_Help helpForm = new F_Help("trangchu"); // "login" là tên tương ứng file login.txt
            OpenChildForm(helpForm);
        }

        private void toolStripMenuItem_KV_Click(object sender, EventArgs e)
        {
            f_KhuVuc = new F_KhuVuc(quyenNguoiDung);
            OpenChildForm(f_KhuVuc);
        }

        private void đăngNhậpToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            F_Log f_Log = new F_Log(null);
            OpenChildForm(f_Log);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            F_Log f_Log = new F_Log("mở log");
            OpenChildForm(f_Log);
        }

        #endregion


    }
}
