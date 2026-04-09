using BCrypt.Net;
using DoAnBanHang_cuahangxemay.Data_Table;
using DoAnBanHang_cuahangxemay.help;
using DoAnBanHang_cuahangxemay.NhatKyDangNhap;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net.Http;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DoAnBanHang_cuahangxemay.Forms
{
    public partial class F_DangNhap : Form
    {
        AppDbContext context = new AppDbContext();
        public int setPhanQuyen { get; private set; } = 0;
        public string setTenUser { get; private set; } = "";

        LogDangNhapThanhCong log = new LogDangNhapThanhCong();


        private void panel_formCon_Paint(object sender, PaintEventArgs e) // màu nền cho panel
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(5, 153, 158),    // Màu bắt đầu (#05999E)
                Color.FromArgb(203, 231, 227),  // Màu kết thúc (#CBE7E3)
                LinearGradientMode.ForwardDiagonal)) // Chiều chéo ↘
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Không tìm thấy địa chỉ IPv4!");
        }


        // 0 QL, 1 NV, df KH
        public F_DangNhap()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                F_Help helpForm = new F_Help("dangnhap"); // "login" là tên tương ứng file login.txt
                helpForm.ShowDialog();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        void kiemTraTonTai()
        {
            if (!context.NhanVien.Any(r => r.NhanVienID != 0))
            {
                MessageBox.Show("Chào mừng\nĐây là lần đăng nhập đầu tiên vào hệ thống, bạn sẽ được cung cấp 1 tài khoản mặc định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var kv = new KhuVuc
                {
                    TenKhuVuc = "rỗng"
                };
                context.KhuVuc.Add(kv);
                context.SaveChanges();

                var admin = new NhanVien
                {
                    HoVaTen = "User_1",
                    DienThoai = "0866710544",
                    DiaChi = "123 Long Xuyên, An Giang",
                    KhuVucID = 1,
                    TenDangNhap = "admin",
                    MatKhau = BCrypt.Net.BCrypt.HashPassword("1"),
                    QuyenHan = true
                };
                context.NhanVien.Add(admin);
                context.SaveChanges();

                MessageBox.Show($"Đây là tài khoản Admin của bạn:\nTên đăng nhập:   admin\nPassWord:    1\nVới quyền quản trị viên", "Chào mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_useName.Text = "admin";
                txt_passWord.Text = "1";
            }
        }
        private void F_DangNhap_Load(object sender, EventArgs e)
        {
            try
            {
                kiemTraTonTai();

                // Các thiết lập khác
                this.AcceptButton = btn_accept;

                setUpForm();
                this.ActiveControl = null;

                // Placeholder cho textbox
                txt_useName.Text = "nhập tên đăng nhập";
                txt_useName.ForeColor = Color.Gray;
                txt_passWord.Text = "nhập mật khẩu";
                txt_passWord.ForeColor = Color.Gray;
                txt_passWord.PasswordChar = '*';
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo: {ex.Message}", "Lỗi đăng nhập line 128", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void setUpForm()
        {
            pictureBox_Unlock.Visible = false;
            pictureBox_lock.Visible = true;
            txt_passWord.PasswordChar = '*';
            pic_hidePass.Visible = false;
        }

        private void pic_showPass_Click(object sender, EventArgs e)
        {
            txt_passWord.PasswordChar = '\0';
            label4.Text = "Ẩn mật khẩu";
            pic_showPass.Visible = false;
            pic_hidePass.Visible = true;
        }

        private void pic_hidePass_Click(object sender, EventArgs e)
        {
            txt_passWord.PasswordChar = '*';
            label4.Text = "Hiện mật khẩu";
            pic_showPass.Visible = true;
            pic_hidePass.Visible = false;
        }

        private void pic_reSet_Click(object sender, EventArgs e)
        {
            txt_useName.Text = "nhập tên đăng nhập";
            txt_useName.ForeColor = Color.Gray;
            txt_passWord.Text = "nhập mật khẩu";
            txt_passWord.ForeColor = Color.Gray;
            txt_passWord.PasswordChar = '\0';
        }

        private void GhiLogDangNhapThatBai(string tenDangNhap, string lyDo)
        {
            string jsonFilePath = @"D:\Lập Trình Quản Lý\Đồ án 00\Đồ án 00-traGop\Đồ án 00\DoAnBanHang_cuahangxemay\NhatKyDangNhap\LogDangNhapThatBai.json";

            try
            {
                // Tạo thư mục nếu chưa tồn tại
                Directory.CreateDirectory(Path.GetDirectoryName(jsonFilePath));

                // Khởi tạo danh sách log
                List<LoginLog> logs = new List<LoginLog>();

                // Đọc file nếu đã tồn tại và KHÔNG rỗng
                if (File.Exists(jsonFilePath))
                {
                    string jsonContent = File.ReadAllText(jsonFilePath);
                    if (!string.IsNullOrWhiteSpace(jsonContent)) // Kiểm tra file không rỗng
                    {
                        logs = JsonSerializer.Deserialize<List<LoginLog>>(jsonContent) ?? new List<LoginLog>();
                    }
                }

                // Thêm log mới
                logs.Add(new LoginLog
                {
                    ThoiGian = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                    TenDangNhap = tenDangNhap,
                    IP = GetLocalIPAddress(),
                    LyDo = lyDo,
                });

                // Ghi đè file với cấu trúc mảng JSON
                File.WriteAllText(
                    jsonFilePath,
                    JsonSerializer.Serialize(logs, new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                    })
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi ghi log: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool kiemTraDangNhap()
        {
            if (string.IsNullOrEmpty(txt_useName.Text))
            {
                MessageBox.Show("Nhập tên đăng nhập", "Thiếu tên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_useName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_passWord.Text))
            {
                MessageBox.Show("Nhập mật khẩu", "Thiếu mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_passWord.Focus();
                return false;
            }
            var any = context.NhanVien.Any(u => u.TenDangNhap == txt_useName.Text);
            if (any == false)
            {
                MessageBox.Show("Tên đăng nhập không tồn tại", "Sai tên đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_useName.ResetText();
                return false;
            }
            var use = context.NhanVien.Where(r => r.TenDangNhap == txt_useName.Text).First();
            bool hassPass = BCrypt.Net.BCrypt.Verify(txt_passWord.Text, use?.MatKhau);
            if (!hassPass)
            {
                MessageBox.Show("Mật khẩu bạn vùa nhập không đúng", "Sai mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_passWord.ResetText();

                GhiLogDangNhapThatBai(use.TenDangNhap, "Sai mật khẩu");

                return false;
            }
            else
            {
                pictureBox_lock.Visible = false;
                pictureBox_Unlock.Visible = true;
                //int quyenHan = (use.QuyenHan) ? 0 : 1;
                setPhanQuyen = use.NhanVienID;
                setTenUser = use.HoVaTen;

                context.LogDangNhapThanhCongs.Add(
                    new LogDangNhapThanhCong
                    {
                        NhanVienID = use.NhanVienID,
                        TimeLogIn = DateTime.Now.AddMilliseconds(100),
                        IP = GetLocalIPAddress()
                    });
                context.SaveChanges();

            }
            return true;
        }

        private void pic_ok_Click(object sender, EventArgs e)
        {
            btn_accept_Click(sender, e);
        }

        void event_Cancel()
        {
            setPhanQuyen = 0;
            setTenUser = "";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void pic_canncel_Click(object sender, EventArgs e)
        {
            event_Cancel();
        }

        private void txt_useName_Enter(object sender, EventArgs e)
        {
            if (txt_useName.Text == "nhập tên đăng nhập")
            {
                txt_useName.Text = "";
                txt_useName.ForeColor = SystemColors.WindowText;
            }
        }

        private void txt_useName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_useName.Text))
            {
                txt_useName.Text = "nhập tên đăng nhập";
                txt_useName.ForeColor = Color.Gray;
            }
        }

        private void txt_passWord_Enter(object sender, EventArgs e)
        {
            if (txt_passWord.Text == "nhập mật khẩu")
            {
                txt_passWord.Text = "";
                txt_passWord.ForeColor = SystemColors.WindowText;
                txt_passWord.PasswordChar = '*'; // Bật chế độ ẩn mật khẩu
            }
        }

        private void txt_passWord_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_passWord.Text))
            {
                txt_passWord.Text = "nhập mật khẩu";
                txt_passWord.ForeColor = Color.Gray;
                txt_passWord.PasswordChar = '\0';
            }
        }

        private async void btn_accept_Click(object sender, EventArgs e)
        {

            if (!kiemTraDangNhap()) return;

            pictureBox_lock.Visible = false;
            pictureBox_Unlock.Visible = true;

            await Task.Delay(1000);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void F_DangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btn_accept_Click(sender, e);
            }
            if(e.KeyCode == Keys.Escape)
            {
                event_Cancel();
            }
            if(e.KeyCode == Keys.F1)
            {
                F_Help helpForm = new F_Help("dangnhap"); // "login" là tên tương ứng file login.txt
                helpForm.ShowDialog();
            }
        }
    }
}
