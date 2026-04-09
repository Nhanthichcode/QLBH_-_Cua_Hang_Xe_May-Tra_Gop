namespace DoAnBanHang_cuahangxemay.Forms
{
    partial class F_NhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_NhanVien));
            txt_hoTen = new TextBox();
            txt_dienThoai = new TextBox();
            txt_diaChi = new TextBox();
            txt_tenDangNhap = new TextBox();
            txt_matKhau = new TextBox();
            dtg_NhanVien = new DataGridView();
            panel1 = new Panel();
            groupBox_thongTinNhanVien = new GroupBox();
            label11 = new Label();
            cbb_khuVuc = new ComboBox();
            panel2 = new Panel();
            textBox1 = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            cbb_quyenhan = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            groupBox_doiMatKhau = new GroupBox();
            label3 = new Label();
            txt_verifyNewPassWord = new TextBox();
            btn_doiMatKhau_huyBo = new Button();
            btn_doiMatKhau_xacNhan = new Button();
            checkBox_hienMatKhau = new CheckBox();
            label2 = new Label();
            txt_newPassWord = new TextBox();
            label1 = new Label();
            txt_oldPassWord = new TextBox();
            btn_doiMatKhau = new Button();
            label10 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox_troVe = new PictureBox();
            pictureBox_locked = new PictureBox();
            panel5 = new Panel();
            menuStrip_chucNang = new MenuStrip();
            btn_Luulai = new ToolStripMenuItem();
            btn_Them = new ToolStripMenuItem();
            btn_Sua = new ToolStripMenuItem();
            btn_Xoa = new ToolStripMenuItem();
            btn_Huy = new ToolStripMenuItem();
            btn_XuatFile = new ToolStripMenuItem();
            btn_NhapFile = new ToolStripMenuItem();
            txt_searchByName = new TextBox();
            panel3 = new Panel();
            label19 = new Label();
            label17 = new Label();
            pictureBox2 = new PictureBox();
            panel_form = new Panel();
            ((System.ComponentModel.ISupportInitialize)dtg_NhanVien).BeginInit();
            panel1.SuspendLayout();
            groupBox_thongTinNhanVien.SuspendLayout();
            panel2.SuspendLayout();
            groupBox_doiMatKhau.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_troVe).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_locked).BeginInit();
            panel5.SuspendLayout();
            menuStrip_chucNang.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel_form.SuspendLayout();
            SuspendLayout();
            // 
            // txt_hoTen
            // 
            txt_hoTen.Location = new Point(83, 37);
            txt_hoTen.Name = "txt_hoTen";
            txt_hoTen.Size = new Size(176, 27);
            txt_hoTen.TabIndex = 0;
            // 
            // txt_dienThoai
            // 
            txt_dienThoai.Location = new Point(371, 37);
            txt_dienThoai.Name = "txt_dienThoai";
            txt_dienThoai.Size = new Size(125, 27);
            txt_dienThoai.TabIndex = 1;
            // 
            // txt_diaChi
            // 
            txt_diaChi.Location = new Point(83, 113);
            txt_diaChi.Multiline = true;
            txt_diaChi.Name = "txt_diaChi";
            txt_diaChi.Size = new Size(176, 149);
            txt_diaChi.TabIndex = 2;
            // 
            // txt_tenDangNhap
            // 
            txt_tenDangNhap.Location = new Point(141, 10);
            txt_tenDangNhap.Name = "txt_tenDangNhap";
            txt_tenDangNhap.Size = new Size(213, 27);
            txt_tenDangNhap.TabIndex = 3;
            // 
            // txt_matKhau
            // 
            txt_matKhau.Location = new Point(141, 46);
            txt_matKhau.Name = "txt_matKhau";
            txt_matKhau.Size = new Size(213, 27);
            txt_matKhau.TabIndex = 4;
            // 
            // dtg_NhanVien
            // 
            dtg_NhanVien.AllowUserToAddRows = false;
            dtg_NhanVien.AllowUserToDeleteRows = false;
            dtg_NhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_NhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_NhanVien.Dock = DockStyle.Fill;
            dtg_NhanVien.Location = new Point(0, 0);
            dtg_NhanVien.MultiSelect = false;
            dtg_NhanVien.Name = "dtg_NhanVien";
            dtg_NhanVien.ReadOnly = true;
            dtg_NhanVien.RowHeadersWidth = 51;
            dtg_NhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_NhanVien.Size = new Size(1162, 235);
            dtg_NhanVien.TabIndex = 6;
            dtg_NhanVien.SelectionChanged += dtg_NhanVien_SelectionChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(dtg_NhanVien);
            panel1.Location = new Point(141, 479);
            panel1.Name = "panel1";
            panel1.Size = new Size(1162, 235);
            panel1.TabIndex = 7;
            // 
            // groupBox_thongTinNhanVien
            // 
            groupBox_thongTinNhanVien.BackColor = Color.Azure;
            groupBox_thongTinNhanVien.Controls.Add(label11);
            groupBox_thongTinNhanVien.Controls.Add(cbb_khuVuc);
            groupBox_thongTinNhanVien.Controls.Add(panel2);
            groupBox_thongTinNhanVien.Controls.Add(label6);
            groupBox_thongTinNhanVien.Controls.Add(label5);
            groupBox_thongTinNhanVien.Controls.Add(label4);
            groupBox_thongTinNhanVien.Controls.Add(txt_hoTen);
            groupBox_thongTinNhanVien.Controls.Add(txt_dienThoai);
            groupBox_thongTinNhanVien.Controls.Add(txt_diaChi);
            groupBox_thongTinNhanVien.Location = new Point(141, 112);
            groupBox_thongTinNhanVien.Name = "groupBox_thongTinNhanVien";
            groupBox_thongTinNhanVien.Size = new Size(681, 281);
            groupBox_thongTinNhanVien.TabIndex = 8;
            groupBox_thongTinNhanVien.TabStop = false;
            groupBox_thongTinNhanVien.Text = "Thông tin nhân viên";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(16, 80);
            label11.Name = "label11";
            label11.Size = new Size(63, 20);
            label11.TabIndex = 72;
            label11.Text = "Khu Vực";
            // 
            // cbb_khuVuc
            // 
            cbb_khuVuc.FormattingEnabled = true;
            cbb_khuVuc.Location = new Point(83, 77);
            cbb_khuVuc.Name = "cbb_khuVuc";
            cbb_khuVuc.Size = new Size(176, 28);
            cbb_khuVuc.TabIndex = 71;
            // 
            // panel2
            // 
            panel2.BackColor = Color.MistyRose;
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txt_matKhau);
            panel2.Controls.Add(cbb_quyenhan);
            panel2.Controls.Add(txt_tenDangNhap);
            panel2.Location = new Point(272, 123);
            panel2.Name = "panel2";
            panel2.Size = new Size(390, 139);
            panel2.TabIndex = 23;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Violet;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Enabled = false;
            textBox1.Location = new Point(1, 87);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(388, 5);
            textBox1.TabIndex = 22;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(9, 112);
            label9.Name = "label9";
            label9.Size = new Size(79, 20);
            label9.TabIndex = 22;
            label9.Text = "Quyền hạn";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(9, 53);
            label8.Name = "label8";
            label8.Size = new Size(70, 20);
            label8.TabIndex = 21;
            label8.Text = "Mật khẩu";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(9, 13);
            label7.Name = "label7";
            label7.Size = new Size(107, 20);
            label7.TabIndex = 20;
            label7.Text = "Tên đăng nhập";
            // 
            // cbb_quyenhan
            // 
            cbb_quyenhan.FormattingEnabled = true;
            cbb_quyenhan.Location = new Point(141, 101);
            cbb_quyenhan.Name = "cbb_quyenhan";
            cbb_quyenhan.Size = new Size(213, 28);
            cbb_quyenhan.TabIndex = 9;
            cbb_quyenhan.SelectedIndexChanged += cbb_quyenhan_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(268, 41);
            label6.Name = "label6";
            label6.Size = new Size(97, 20);
            label6.TabIndex = 19;
            label6.Text = "Số điện thoại";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 123);
            label5.Name = "label5";
            label5.Size = new Size(58, 20);
            label5.TabIndex = 11;
            label5.Text = "Địa chỉ:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 41);
            label4.Name = "label4";
            label4.Size = new Size(57, 20);
            label4.TabIndex = 10;
            label4.Text = "Họ tên:";
            // 
            // groupBox_doiMatKhau
            // 
            groupBox_doiMatKhau.BackColor = Color.Azure;
            groupBox_doiMatKhau.Controls.Add(label3);
            groupBox_doiMatKhau.Controls.Add(txt_verifyNewPassWord);
            groupBox_doiMatKhau.Controls.Add(btn_doiMatKhau_huyBo);
            groupBox_doiMatKhau.Controls.Add(btn_doiMatKhau_xacNhan);
            groupBox_doiMatKhau.Controls.Add(checkBox_hienMatKhau);
            groupBox_doiMatKhau.Controls.Add(label2);
            groupBox_doiMatKhau.Controls.Add(txt_newPassWord);
            groupBox_doiMatKhau.Controls.Add(label1);
            groupBox_doiMatKhau.Controls.Add(txt_oldPassWord);
            groupBox_doiMatKhau.Location = new Point(392, 74);
            groupBox_doiMatKhau.Name = "groupBox_doiMatKhau";
            groupBox_doiMatKhau.Size = new Size(241, 306);
            groupBox_doiMatKhau.TabIndex = 12;
            groupBox_doiMatKhau.TabStop = false;
            groupBox_doiMatKhau.Text = "Đổi mật khẩu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ActiveCaptionText;
            label3.ForeColor = Color.Gold;
            label3.Location = new Point(14, 163);
            label3.Name = "label3";
            label3.Size = new Size(134, 20);
            label3.TabIndex = 18;
            label3.Text = "Xác nhận Mật khẩu";
            // 
            // txt_verifyNewPassWord
            // 
            txt_verifyNewPassWord.Location = new Point(14, 187);
            txt_verifyNewPassWord.Name = "txt_verifyNewPassWord";
            txt_verifyNewPassWord.PasswordChar = '^';
            txt_verifyNewPassWord.Size = new Size(205, 27);
            txt_verifyNewPassWord.TabIndex = 17;
            // 
            // btn_doiMatKhau_huyBo
            // 
            btn_doiMatKhau_huyBo.Location = new Point(125, 265);
            btn_doiMatKhau_huyBo.Name = "btn_doiMatKhau_huyBo";
            btn_doiMatKhau_huyBo.Size = new Size(94, 29);
            btn_doiMatKhau_huyBo.TabIndex = 16;
            btn_doiMatKhau_huyBo.Text = "Hủy";
            btn_doiMatKhau_huyBo.UseVisualStyleBackColor = true;
            btn_doiMatKhau_huyBo.Click += btn_doiMatKhau_huyBo_Click;
            // 
            // btn_doiMatKhau_xacNhan
            // 
            btn_doiMatKhau_xacNhan.Location = new Point(21, 265);
            btn_doiMatKhau_xacNhan.Name = "btn_doiMatKhau_xacNhan";
            btn_doiMatKhau_xacNhan.Size = new Size(94, 29);
            btn_doiMatKhau_xacNhan.TabIndex = 15;
            btn_doiMatKhau_xacNhan.Text = "Xác nhận";
            btn_doiMatKhau_xacNhan.UseVisualStyleBackColor = true;
            btn_doiMatKhau_xacNhan.Click += btn_doiMatKhau_xacNhan_Click;
            // 
            // checkBox_hienMatKhau
            // 
            checkBox_hienMatKhau.AutoSize = true;
            checkBox_hienMatKhau.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 163);
            checkBox_hienMatKhau.ForeColor = Color.MediumSlateBlue;
            checkBox_hienMatKhau.Location = new Point(14, 220);
            checkBox_hienMatKhau.Name = "checkBox_hienMatKhau";
            checkBox_hienMatKhau.Size = new Size(134, 24);
            checkBox_hienMatKhau.TabIndex = 14;
            checkBox_hienMatKhau.Text = "hiện mật khẩu";
            checkBox_hienMatKhau.UseVisualStyleBackColor = true;
            checkBox_hienMatKhau.CheckedChanged += checkBox_hienMatKhau_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ActiveCaptionText;
            label2.ForeColor = Color.Gold;
            label2.Location = new Point(14, 95);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 13;
            label2.Text = "Mật khẩu mới";
            // 
            // txt_newPassWord
            // 
            txt_newPassWord.Location = new Point(14, 118);
            txt_newPassWord.Name = "txt_newPassWord";
            txt_newPassWord.PasswordChar = 'o';
            txt_newPassWord.Size = new Size(205, 27);
            txt_newPassWord.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaptionText;
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(14, 25);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 11;
            label1.Text = "Mật khẩu cũ";
            // 
            // txt_oldPassWord
            // 
            txt_oldPassWord.Location = new Point(14, 48);
            txt_oldPassWord.Name = "txt_oldPassWord";
            txt_oldPassWord.Size = new Size(205, 27);
            txt_oldPassWord.TabIndex = 10;
            // 
            // btn_doiMatKhau
            // 
            btn_doiMatKhau.BackColor = Color.Azure;
            btn_doiMatKhau.Location = new Point(1143, 354);
            btn_doiMatKhau.Name = "btn_doiMatKhau";
            btn_doiMatKhau.Size = new Size(106, 40);
            btn_doiMatKhau.TabIndex = 17;
            btn_doiMatKhau.Text = "Đổi mật khẩu";
            btn_doiMatKhau.UseVisualStyleBackColor = false;
            btn_doiMatKhau.Click += btn_doiMatKhau_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Azure;
            label10.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.DeepSkyBlue;
            label10.Location = new Point(566, 31);
            label10.Name = "label10";
            label10.Size = new Size(385, 43);
            label10.TabIndex = 19;
            label10.Text = "QUẢN LÝ - NHÂN VIÊN";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Azure;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1104, 354);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            // 
            // pictureBox_troVe
            // 
            pictureBox_troVe.BorderStyle = BorderStyle.Fixed3D;
            pictureBox_troVe.Image = (Image)resources.GetObject("pictureBox_troVe.Image");
            pictureBox_troVe.Location = new Point(1327, 12);
            pictureBox_troVe.Name = "pictureBox_troVe";
            pictureBox_troVe.Size = new Size(81, 68);
            pictureBox_troVe.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_troVe.TabIndex = 21;
            pictureBox_troVe.TabStop = false;
            pictureBox_troVe.Click += pictureBox_troVe_Click;
            // 
            // pictureBox_locked
            // 
            pictureBox_locked.BackColor = Color.Azure;
            pictureBox_locked.Image = (Image)resources.GetObject("pictureBox_locked.Image");
            pictureBox_locked.Location = new Point(1104, 353);
            pictureBox_locked.Name = "pictureBox_locked";
            pictureBox_locked.Size = new Size(37, 40);
            pictureBox_locked.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_locked.TabIndex = 22;
            pictureBox_locked.TabStop = false;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Azure;
            panel5.Controls.Add(menuStrip_chucNang);
            panel5.Location = new Point(176, 410);
            panel5.Name = "panel5";
            panel5.Size = new Size(1073, 55);
            panel5.TabIndex = 63;
            // 
            // menuStrip_chucNang
            // 
            menuStrip_chucNang.BackColor = Color.MediumTurquoise;
            menuStrip_chucNang.Dock = DockStyle.Fill;
            menuStrip_chucNang.ImageScalingSize = new Size(20, 20);
            menuStrip_chucNang.Items.AddRange(new ToolStripItem[] { btn_Luulai, btn_Them, btn_Sua, btn_Xoa, btn_Huy, btn_XuatFile, btn_NhapFile });
            menuStrip_chucNang.Location = new Point(0, 0);
            menuStrip_chucNang.Name = "menuStrip_chucNang";
            menuStrip_chucNang.Size = new Size(1073, 55);
            menuStrip_chucNang.TabIndex = 0;
            menuStrip_chucNang.Text = "menuStrip1";
            // 
            // btn_Luulai
            // 
            btn_Luulai.BackColor = Color.Azure;
            btn_Luulai.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            btn_Luulai.Image = (Image)resources.GetObject("btn_Luulai.Image");
            btn_Luulai.ImageScaling = ToolStripItemImageScaling.None;
            btn_Luulai.Margin = new Padding(30, 0, 0, 0);
            btn_Luulai.Name = "btn_Luulai";
            btn_Luulai.Padding = new Padding(5, 5, 40, 5);
            btn_Luulai.Size = new Size(150, 51);
            btn_Luulai.Text = "Lưu Lại";
            btn_Luulai.TextAlign = ContentAlignment.MiddleRight;
            btn_Luulai.Click += btn_luu_Click;
            // 
            // btn_Them
            // 
            btn_Them.BackColor = Color.PaleTurquoise;
            btn_Them.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            btn_Them.Image = (Image)resources.GetObject("btn_Them.Image");
            btn_Them.ImageScaling = ToolStripItemImageScaling.None;
            btn_Them.Name = "btn_Them";
            btn_Them.Padding = new Padding(5, 5, 40, 5);
            btn_Them.Size = new Size(135, 51);
            btn_Them.Text = "Thêm";
            btn_Them.TextAlign = ContentAlignment.MiddleRight;
            btn_Them.Click += btn_them_Click;
            // 
            // btn_Sua
            // 
            btn_Sua.BackColor = Color.Azure;
            btn_Sua.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            btn_Sua.Image = (Image)resources.GetObject("btn_Sua.Image");
            btn_Sua.ImageScaling = ToolStripItemImageScaling.None;
            btn_Sua.Name = "btn_Sua";
            btn_Sua.Padding = new Padding(5, 5, 40, 5);
            btn_Sua.Size = new Size(121, 51);
            btn_Sua.Text = "Sửa";
            btn_Sua.TextAlign = ContentAlignment.MiddleRight;
            btn_Sua.Click += btn_sua_Click;
            // 
            // btn_Xoa
            // 
            btn_Xoa.BackColor = Color.PaleTurquoise;
            btn_Xoa.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            btn_Xoa.Image = (Image)resources.GetObject("btn_Xoa.Image");
            btn_Xoa.ImageScaling = ToolStripItemImageScaling.None;
            btn_Xoa.Name = "btn_Xoa";
            btn_Xoa.Padding = new Padding(5, 5, 40, 5);
            btn_Xoa.Size = new Size(122, 51);
            btn_Xoa.Text = "Xóa";
            btn_Xoa.TextAlign = ContentAlignment.MiddleRight;
            btn_Xoa.Click += btn_xoa_Click;
            // 
            // btn_Huy
            // 
            btn_Huy.BackColor = Color.Azure;
            btn_Huy.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            btn_Huy.Image = (Image)resources.GetObject("btn_Huy.Image");
            btn_Huy.ImageScaling = ToolStripItemImageScaling.None;
            btn_Huy.Name = "btn_Huy";
            btn_Huy.Padding = new Padding(5, 5, 40, 5);
            btn_Huy.Size = new Size(148, 51);
            btn_Huy.Text = "Hủy bỏ";
            btn_Huy.TextAlign = ContentAlignment.MiddleRight;
            btn_Huy.Click += btn_huybo_Click;
            // 
            // btn_XuatFile
            // 
            btn_XuatFile.BackColor = Color.PaleTurquoise;
            btn_XuatFile.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            btn_XuatFile.Image = (Image)resources.GetObject("btn_XuatFile.Image");
            btn_XuatFile.ImageScaling = ToolStripItemImageScaling.None;
            btn_XuatFile.Name = "btn_XuatFile";
            btn_XuatFile.Padding = new Padding(5, 5, 40, 5);
            btn_XuatFile.Size = new Size(161, 51);
            btn_XuatFile.Text = "Xuất File";
            btn_XuatFile.TextAlign = ContentAlignment.MiddleRight;
            btn_XuatFile.Click += btn_xuatFile_Click;
            // 
            // btn_NhapFile
            // 
            btn_NhapFile.BackColor = Color.Azure;
            btn_NhapFile.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            btn_NhapFile.Image = (Image)resources.GetObject("btn_NhapFile.Image");
            btn_NhapFile.ImageScaling = ToolStripItemImageScaling.None;
            btn_NhapFile.Margin = new Padding(0, 0, 30, 0);
            btn_NhapFile.Name = "btn_NhapFile";
            btn_NhapFile.Padding = new Padding(5, 5, 40, 5);
            btn_NhapFile.Size = new Size(168, 51);
            btn_NhapFile.Text = "Nhập File";
            btn_NhapFile.TextAlign = ContentAlignment.MiddleRight;
            btn_NhapFile.Click += btn_nhapFile_Click;
            // 
            // txt_searchByName
            // 
            txt_searchByName.Location = new Point(7, 36);
            txt_searchByName.Name = "txt_searchByName";
            txt_searchByName.Size = new Size(260, 27);
            txt_searchByName.TabIndex = 65;
            txt_searchByName.TextChanged += txt_searchByName_TextChanged;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Azure;
            panel3.Controls.Add(label19);
            panel3.Controls.Add(txt_searchByName);
            panel3.Location = new Point(828, 235);
            panel3.Name = "panel3";
            panel3.Size = new Size(277, 68);
            panel3.TabIndex = 67;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(4, 7);
            label19.Name = "label19";
            label19.Size = new Size(263, 20);
            label19.TabIndex = 65;
            label19.Text = "Nhập tên muốn tìm ( tối thiểu 1 ký tự )";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.Azure;
            label17.Font = new Font("Segoe UI", 13F, FontStyle.Bold | FontStyle.Underline);
            label17.Location = new Point(89, 22);
            label17.Name = "label17";
            label17.Size = new Size(102, 30);
            label17.TabIndex = 69;
            label17.Text = "Trợ Giúp";
            label17.Click += label17_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Azure;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(8, 5);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(77, 70);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 68;
            pictureBox2.TabStop = false;
            pictureBox2.Click += label17_Click;
            // 
            // panel_form
            // 
            panel_form.Controls.Add(pictureBox_troVe);
            panel_form.Controls.Add(groupBox_doiMatKhau);
            panel_form.Controls.Add(label17);
            panel_form.Controls.Add(pictureBox2);
            panel_form.Controls.Add(panel3);
            panel_form.Controls.Add(panel5);
            panel_form.Controls.Add(pictureBox_locked);
            panel_form.Controls.Add(pictureBox1);
            panel_form.Controls.Add(label10);
            panel_form.Controls.Add(groupBox_thongTinNhanVien);
            panel_form.Controls.Add(btn_doiMatKhau);
            panel_form.Dock = DockStyle.Fill;
            panel_form.Location = new Point(0, 0);
            panel_form.Name = "panel_form";
            panel_form.Size = new Size(1420, 744);
            panel_form.TabIndex = 70;
            // 
            // F_NhanVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(1420, 744);
            ControlBox = false;
            Controls.Add(panel1);
            Controls.Add(panel_form);
            Name = "F_NhanVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nhân Viên";
            Load += F_NhanVien_Load;
            ((System.ComponentModel.ISupportInitialize)dtg_NhanVien).EndInit();
            panel1.ResumeLayout(false);
            groupBox_thongTinNhanVien.ResumeLayout(false);
            groupBox_thongTinNhanVien.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox_doiMatKhau.ResumeLayout(false);
            groupBox_doiMatKhau.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_troVe).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_locked).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            menuStrip_chucNang.ResumeLayout(false);
            menuStrip_chucNang.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel_form.ResumeLayout(false);
            panel_form.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txt_hoTen;
        private TextBox txt_dienThoai;
        private TextBox txt_diaChi;
        private TextBox txt_tenDangNhap;
        private TextBox txt_matKhau;
        private DataGridView dtg_NhanVien;
        private Panel panel1;
        private GroupBox groupBox_thongTinNhanVien;
        private Button btn_doiMatKhau;
        private GroupBox groupBox_doiMatKhau;
        private Label label1;
        private TextBox txt_oldPassWord;
        private TextBox txt_newPassWord;
        private CheckBox checkBox_hienMatKhau;
        private Label label2;
        private Button btn_doiMatKhau_huyBo;
        private Button btn_doiMatKhau_xacNhan;
        private Label label3;
        private TextBox txt_verifyNewPassWord;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Panel panel2;
        private Label label9;
        private ComboBox cbb_quyenhan;
        private Label label10;
        private PictureBox pictureBox1;
        private PictureBox pictureBox_troVe;
        private TextBox textBox1;
        private PictureBox pictureBox_locked;
        private Panel panel5;
        private MenuStrip menuStrip_chucNang;
        private ToolStripMenuItem btn_Luulai;
        private ToolStripMenuItem btn_Them;
        private ToolStripMenuItem btn_Sua;
        private ToolStripMenuItem btn_Xoa;
        private ToolStripMenuItem btn_Huy;
        private ToolStripMenuItem btn_XuatFile;
        private ToolStripMenuItem btn_NhapFile;
        private TextBox txt_searchByName;
        private Panel panel3;
        private Label label19;
        private Label label17;
        private PictureBox pictureBox2;
        private ComboBox cbb_khuVuc;
        private Label label11;
        private Panel panel_form;
    }
}