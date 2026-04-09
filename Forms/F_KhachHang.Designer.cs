namespace DoAnBanHang_cuahangxemay.Forms
{
    partial class F_KhachHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_KhachHang));
            txt_dienThoai = new TextBox();
            txt_diaChiThuongTru = new TextBox();
            txt_hoTen = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            dtg_khachHang = new DataGridView();
            groupBox2 = new GroupBox();
            label21 = new Label();
            cbb_khuVuc = new ComboBox();
            groupBox1 = new GroupBox();
            rdb_nam = new RadioButton();
            rdb_nu = new RadioButton();
            label7 = new Label();
            panel4 = new Panel();
            menuStrip2 = new MenuStrip();
            btn_ChonAnh = new ToolStripMenuItem();
            btn_DoiAnh = new ToolStripMenuItem();
            label18 = new Label();
            label17 = new Label();
            dtp_ngayCapCCCD = new DateTimePicker();
            panel2 = new Panel();
            pic_anhChanDung = new PictureBox();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label6 = new Label();
            label5 = new Label();
            cbb_noiCapCCCD = new ComboBox();
            num_diemTinhDung = new NumericUpDown();
            num_hanMucTinDung = new NumericUpDown();
            txt_noiLamViec = new TextBox();
            cbb_tenNganHang = new ComboBox();
            txt_soTaiKhoan = new TextBox();
            dtp_ngaySinh = new DateTimePicker();
            num_thuNhap = new NumericUpDown();
            txt_ngheNghiep = new TextBox();
            txt_diaChiLienHe = new TextBox();
            txt_eMail = new TextBox();
            txt_soCCCD = new TextBox();
            label4 = new Label();
            pictureBox_troVe = new PictureBox();
            panel5 = new Panel();
            menuStrip_chucNang = new MenuStrip();
            btn_Luulai = new ToolStripMenuItem();
            btn_Them = new ToolStripMenuItem();
            btn_Sua = new ToolStripMenuItem();
            btn_Xoa = new ToolStripMenuItem();
            btn_Huy = new ToolStripMenuItem();
            btn_XuatFile = new ToolStripMenuItem();
            btn_NhapFile = new ToolStripMenuItem();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            textBox_SearchByName = new TextBox();
            label19 = new Label();
            panel3 = new Panel();
            label20 = new Label();
            pictureBox2 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtg_khachHang).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel4.SuspendLayout();
            menuStrip2.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_anhChanDung).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_diemTinhDung).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_hanMucTinDung).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_thuNhap).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_troVe).BeginInit();
            panel5.SuspendLayout();
            menuStrip_chucNang.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // txt_dienThoai
            // 
            txt_dienThoai.Location = new Point(152, 69);
            txt_dienThoai.Name = "txt_dienThoai";
            txt_dienThoai.Size = new Size(211, 30);
            txt_dienThoai.TabIndex = 0;
            // 
            // txt_diaChiThuongTru
            // 
            txt_diaChiThuongTru.BackColor = SystemColors.HighlightText;
            txt_diaChiThuongTru.Location = new Point(152, 101);
            txt_diaChiThuongTru.Multiline = true;
            txt_diaChiThuongTru.Name = "txt_diaChiThuongTru";
            txt_diaChiThuongTru.Size = new Size(211, 65);
            txt_diaChiThuongTru.TabIndex = 1;
            // 
            // txt_hoTen
            // 
            txt_hoTen.BackColor = SystemColors.HighlightText;
            txt_hoTen.Location = new Point(152, 35);
            txt_hoTen.Name = "txt_hoTen";
            txt_hoTen.Size = new Size(211, 30);
            txt_hoTen.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 37);
            label1.Name = "label1";
            label1.Size = new Size(62, 23);
            label1.TabIndex = 4;
            label1.Text = "Họ tên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 72);
            label2.Name = "label2";
            label2.Size = new Size(111, 23);
            label2.TabIndex = 5;
            label2.Text = "Số điện thoại";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 104);
            label3.Name = "label3";
            label3.Size = new Size(123, 46);
            label3.TabIndex = 6;
            label3.Text = "Địa chỉ thường\r\ntrú";
            // 
            // panel1
            // 
            panel1.Controls.Add(dtg_khachHang);
            panel1.Location = new Point(75, 501);
            panel1.Name = "panel1";
            panel1.Size = new Size(1263, 227);
            panel1.TabIndex = 8;
            // 
            // dtg_khachHang
            // 
            dtg_khachHang.AllowUserToAddRows = false;
            dtg_khachHang.AllowUserToDeleteRows = false;
            dtg_khachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtg_khachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_khachHang.Dock = DockStyle.Fill;
            dtg_khachHang.Location = new Point(0, 0);
            dtg_khachHang.Name = "dtg_khachHang";
            dtg_khachHang.ReadOnly = true;
            dtg_khachHang.RowHeadersWidth = 51;
            dtg_khachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_khachHang.Size = new Size(1263, 227);
            dtg_khachHang.TabIndex = 0;
            dtg_khachHang.EnabledChanged += dtg_khachHang_EnabledChanged;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.AliceBlue;
            groupBox2.Controls.Add(label21);
            groupBox2.Controls.Add(cbb_khuVuc);
            groupBox2.Controls.Add(groupBox1);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(panel4);
            groupBox2.Controls.Add(label18);
            groupBox2.Controls.Add(label17);
            groupBox2.Controls.Add(dtp_ngayCapCCCD);
            groupBox2.Controls.Add(panel2);
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(label15);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(cbb_noiCapCCCD);
            groupBox2.Controls.Add(num_diemTinhDung);
            groupBox2.Controls.Add(num_hanMucTinDung);
            groupBox2.Controls.Add(txt_noiLamViec);
            groupBox2.Controls.Add(cbb_tenNganHang);
            groupBox2.Controls.Add(txt_soTaiKhoan);
            groupBox2.Controls.Add(dtp_ngaySinh);
            groupBox2.Controls.Add(num_thuNhap);
            groupBox2.Controls.Add(txt_ngheNghiep);
            groupBox2.Controls.Add(txt_diaChiLienHe);
            groupBox2.Controls.Add(txt_eMail);
            groupBox2.Controls.Add(txt_soCCCD);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(txt_hoTen);
            groupBox2.Controls.Add(txt_diaChiThuongTru);
            groupBox2.Controls.Add(txt_dienThoai);
            groupBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            groupBox2.Location = new Point(45, 77);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1327, 361);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin Khách Hàng";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(886, 27);
            label21.Name = "label21";
            label21.Size = new Size(75, 23);
            label21.TabIndex = 70;
            label21.Text = "Khu vực:";
            // 
            // cbb_khuVuc
            // 
            cbb_khuVuc.FormattingEnabled = true;
            cbb_khuVuc.Location = new Point(886, 57);
            cbb_khuVuc.Name = "cbb_khuVuc";
            cbb_khuVuc.Size = new Size(259, 31);
            cbb_khuVuc.TabIndex = 69;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.GradientInactiveCaption;
            groupBox1.Controls.Add(rdb_nam);
            groupBox1.Controls.Add(rdb_nu);
            groupBox1.Location = new Point(152, 275);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(211, 43);
            groupBox1.TabIndex = 45;
            groupBox1.TabStop = false;
            // 
            // rdb_nam
            // 
            rdb_nam.AutoSize = true;
            rdb_nam.Font = new Font("Rockwell", 9F, FontStyle.Bold);
            rdb_nam.ForeColor = Color.Green;
            rdb_nam.Location = new Point(134, 15);
            rdb_nam.Name = "rdb_nam";
            rdb_nam.Size = new Size(65, 22);
            rdb_nam.TabIndex = 43;
            rdb_nam.TabStop = true;
            rdb_nam.Tag = "Nam";
            rdb_nam.Text = "Nam";
            rdb_nam.UseVisualStyleBackColor = true;
            rdb_nam.CheckedChanged += rdb_nam_CheckedChanged_1;
            // 
            // rdb_nu
            // 
            rdb_nu.AutoSize = true;
            rdb_nu.Font = new Font("Rockwell", 9F, FontStyle.Bold);
            rdb_nu.ForeColor = Color.Green;
            rdb_nu.Location = new Point(16, 15);
            rdb_nu.Name = "rdb_nu";
            rdb_nu.Size = new Size(50, 22);
            rdb_nu.TabIndex = 42;
            rdb_nu.TabStop = true;
            rdb_nu.Tag = "Nữ";
            rdb_nu.Text = "Nữ";
            rdb_nu.UseVisualStyleBackColor = true;
            rdb_nu.CheckedChanged += rdb_nu_CheckedChanged_1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 287);
            label7.Name = "label7";
            label7.Size = new Size(75, 23);
            label7.TabIndex = 44;
            label7.Text = "Giới tính";
            // 
            // panel4
            // 
            panel4.Controls.Add(menuStrip2);
            panel4.Location = new Point(1151, 107);
            panel4.Name = "panel4";
            panel4.Size = new Size(170, 247);
            panel4.TabIndex = 62;
            // 
            // menuStrip2
            // 
            menuStrip2.Dock = DockStyle.Left;
            menuStrip2.ImageScalingSize = new Size(20, 20);
            menuStrip2.Items.AddRange(new ToolStripItem[] { btn_ChonAnh, btn_DoiAnh });
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Padding = new Padding(6, 3, 0, 3);
            menuStrip2.Size = new Size(170, 247);
            menuStrip2.TabIndex = 0;
            menuStrip2.Text = "menuStrip2";
            // 
            // btn_ChonAnh
            // 
            btn_ChonAnh.BackColor = Color.PaleTurquoise;
            btn_ChonAnh.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Underline);
            btn_ChonAnh.Image = (Image)resources.GetObject("btn_ChonAnh.Image");
            btn_ChonAnh.ImageScaling = ToolStripItemImageScaling.None;
            btn_ChonAnh.Margin = new Padding(0, 0, 0, 100);
            btn_ChonAnh.Name = "btn_ChonAnh";
            btn_ChonAnh.Padding = new Padding(0);
            btn_ChonAnh.Size = new Size(157, 68);
            btn_ChonAnh.Text = "Chọn Ảnh";
            btn_ChonAnh.Click += btn_chonAnh_Click;
            // 
            // btn_DoiAnh
            // 
            btn_DoiAnh.BackColor = Color.PaleTurquoise;
            btn_DoiAnh.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Underline);
            btn_DoiAnh.Image = (Image)resources.GetObject("btn_DoiAnh.Image");
            btn_DoiAnh.ImageScaling = ToolStripItemImageScaling.None;
            btn_DoiAnh.Name = "btn_DoiAnh";
            btn_DoiAnh.Size = new Size(157, 68);
            btn_DoiAnh.Text = "Đổi Ảnh";
            btn_DoiAnh.Click += btn_doiAnh_Click;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(18, 248);
            label18.Name = "label18";
            label18.Size = new Size(86, 23);
            label18.TabIndex = 41;
            label18.Text = "Ngày sinh";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(384, 101);
            label17.Name = "label17";
            label17.Size = new Size(132, 23);
            label17.TabIndex = 40;
            label17.Text = "Ngày cấp CCCD";
            // 
            // dtp_ngayCapCCCD
            // 
            dtp_ngayCapCCCD.Format = DateTimePickerFormat.Short;
            dtp_ngayCapCCCD.Location = new Point(529, 97);
            dtp_ngayCapCCCD.Name = "dtp_ngayCapCCCD";
            dtp_ngayCapCCCD.Size = new Size(314, 30);
            dtp_ngayCapCCCD.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.Controls.Add(pic_anhChanDung);
            panel2.Location = new Point(886, 107);
            panel2.Name = "panel2";
            panel2.Size = new Size(259, 243);
            panel2.TabIndex = 11;
            // 
            // pic_anhChanDung
            // 
            pic_anhChanDung.BorderStyle = BorderStyle.FixedSingle;
            pic_anhChanDung.Dock = DockStyle.Fill;
            pic_anhChanDung.Location = new Point(0, 0);
            pic_anhChanDung.Name = "pic_anhChanDung";
            pic_anhChanDung.Size = new Size(259, 243);
            pic_anhChanDung.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_anhChanDung.TabIndex = 24;
            pic_anhChanDung.TabStop = false;
            pic_anhChanDung.DragDrop += pic_hinhAnhChanDung_DragDrop;
            pic_anhChanDung.DragEnter += pic_hinhAnhChanDung_DragEnter;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(384, 61);
            label16.Name = "label16";
            label16.Size = new Size(119, 23);
            label16.TabIndex = 39;
            label16.Text = "Nơi cấp CCCD";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(384, 29);
            label15.Name = "label15";
            label15.Size = new Size(79, 23);
            label15.TabIndex = 38;
            label15.Text = "Số CCCD";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(384, 321);
            label14.Name = "label14";
            label14.Size = new Size(159, 23);
            label14.TabIndex = 37;
            label14.Text = "Hạn mức tính dụng";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(384, 287);
            label13.Name = "label13";
            label13.Size = new Size(83, 23);
            label13.TabIndex = 36;
            label13.Text = "Thu nhập";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(739, 287);
            label12.Name = "label12";
            label12.Size = new Size(120, 23);
            label12.TabIndex = 35;
            label12.Text = "Điểm tín dụng";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(384, 175);
            label11.Name = "label11";
            label11.Size = new Size(110, 23);
            label11.TabIndex = 34;
            label11.Text = "Nghề nghiệp";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(384, 212);
            label10.Name = "label10";
            label10.Size = new Size(104, 23);
            label10.TabIndex = 33;
            label10.Text = "Nơi làm việc";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(384, 251);
            label9.Name = "label9";
            label9.Size = new Size(105, 23);
            label9.TabIndex = 32;
            label9.Text = "Số tài khoản";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(384, 140);
            label8.Name = "label8";
            label8.Size = new Size(124, 23);
            label8.TabIndex = 31;
            label8.Text = "Tên ngân hàng";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 325);
            label6.Name = "label6";
            label6.Size = new Size(51, 23);
            label6.TabIndex = 29;
            label6.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 175);
            label5.Name = "label5";
            label5.Size = new Size(118, 23);
            label5.TabIndex = 28;
            label5.Text = "Địa chỉ liên hệ";
            // 
            // cbb_noiCapCCCD
            // 
            cbb_noiCapCCCD.FormattingEnabled = true;
            cbb_noiCapCCCD.Location = new Point(529, 59);
            cbb_noiCapCCCD.Name = "cbb_noiCapCCCD";
            cbb_noiCapCCCD.Size = new Size(314, 31);
            cbb_noiCapCCCD.TabIndex = 27;
            // 
            // num_diemTinhDung
            // 
            num_diemTinhDung.Location = new Point(739, 319);
            num_diemTinhDung.Maximum = new decimal(new int[] { 1410065407, 2, 0, 0 });
            num_diemTinhDung.Name = "num_diemTinhDung";
            num_diemTinhDung.Size = new Size(104, 30);
            num_diemTinhDung.TabIndex = 26;
            num_diemTinhDung.TextAlign = HorizontalAlignment.Right;
            // 
            // num_hanMucTinDung
            // 
            num_hanMucTinDung.DecimalPlaces = 2;
            num_hanMucTinDung.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            num_hanMucTinDung.Location = new Point(554, 319);
            num_hanMucTinDung.Maximum = new decimal(new int[] { 1316134911, 2328, 0, 0 });
            num_hanMucTinDung.Name = "num_hanMucTinDung";
            num_hanMucTinDung.Size = new Size(179, 30);
            num_hanMucTinDung.TabIndex = 25;
            num_hanMucTinDung.TextAlign = HorizontalAlignment.Right;
            // 
            // txt_noiLamViec
            // 
            txt_noiLamViec.Location = new Point(529, 205);
            txt_noiLamViec.Name = "txt_noiLamViec";
            txt_noiLamViec.Size = new Size(314, 30);
            txt_noiLamViec.TabIndex = 23;
            // 
            // cbb_tenNganHang
            // 
            cbb_tenNganHang.FormattingEnabled = true;
            cbb_tenNganHang.Location = new Point(529, 137);
            cbb_tenNganHang.Name = "cbb_tenNganHang";
            cbb_tenNganHang.Size = new Size(314, 31);
            cbb_tenNganHang.TabIndex = 22;
            // 
            // txt_soTaiKhoan
            // 
            txt_soTaiKhoan.BackColor = SystemColors.HighlightText;
            txt_soTaiKhoan.Location = new Point(529, 243);
            txt_soTaiKhoan.Name = "txt_soTaiKhoan";
            txt_soTaiKhoan.Size = new Size(314, 30);
            txt_soTaiKhoan.TabIndex = 21;
            // 
            // dtp_ngaySinh
            // 
            dtp_ngaySinh.CalendarMonthBackground = Color.White;
            dtp_ngaySinh.CalendarTitleBackColor = Color.LightCoral;
            dtp_ngaySinh.CalendarTitleForeColor = Color.Lime;
            dtp_ngaySinh.Format = DateTimePickerFormat.Short;
            dtp_ngaySinh.Location = new Point(152, 243);
            dtp_ngaySinh.Name = "dtp_ngaySinh";
            dtp_ngaySinh.Size = new Size(211, 30);
            dtp_ngaySinh.TabIndex = 13;
            // 
            // num_thuNhap
            // 
            num_thuNhap.Location = new Point(529, 283);
            num_thuNhap.Maximum = new decimal(new int[] { 1316134911, 2328, 0, 0 });
            num_thuNhap.Name = "num_thuNhap";
            num_thuNhap.Size = new Size(203, 30);
            num_thuNhap.TabIndex = 20;
            num_thuNhap.TextAlign = HorizontalAlignment.Right;
            // 
            // txt_ngheNghiep
            // 
            txt_ngheNghiep.BackColor = SystemColors.HighlightText;
            txt_ngheNghiep.Location = new Point(529, 171);
            txt_ngheNghiep.Name = "txt_ngheNghiep";
            txt_ngheNghiep.Size = new Size(314, 30);
            txt_ngheNghiep.TabIndex = 19;
            // 
            // txt_diaChiLienHe
            // 
            txt_diaChiLienHe.Location = new Point(152, 172);
            txt_diaChiLienHe.Multiline = true;
            txt_diaChiLienHe.Name = "txt_diaChiLienHe";
            txt_diaChiLienHe.Size = new Size(211, 64);
            txt_diaChiLienHe.TabIndex = 18;
            // 
            // txt_eMail
            // 
            txt_eMail.BackColor = SystemColors.HighlightText;
            txt_eMail.Location = new Point(152, 323);
            txt_eMail.Name = "txt_eMail";
            txt_eMail.Size = new Size(211, 30);
            txt_eMail.TabIndex = 17;
            // 
            // txt_soCCCD
            // 
            txt_soCCCD.BackColor = SystemColors.HighlightText;
            txt_soCCCD.Location = new Point(529, 20);
            txt_soCCCD.Name = "txt_soCCCD";
            txt_soCCCD.Size = new Size(314, 30);
            txt_soCCCD.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.LightSkyBlue;
            label4.Location = new Point(646, 4);
            label4.Name = "label4";
            label4.Size = new Size(421, 43);
            label4.TabIndex = 10;
            label4.Text = "QUẢN LÝ- KHÁCH HÀNG";
            // 
            // pictureBox_troVe
            // 
            pictureBox_troVe.BorderStyle = BorderStyle.Fixed3D;
            pictureBox_troVe.Image = (Image)resources.GetObject("pictureBox_troVe.Image");
            pictureBox_troVe.Location = new Point(1291, 4);
            pictureBox_troVe.Name = "pictureBox_troVe";
            pictureBox_troVe.Size = new Size(81, 68);
            pictureBox_troVe.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_troVe.TabIndex = 14;
            pictureBox_troVe.TabStop = false;
            pictureBox_troVe.Click += pictureBox_troVe_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(menuStrip_chucNang);
            panel5.Location = new Point(178, 441);
            panel5.Name = "panel5";
            panel5.Size = new Size(1073, 55);
            panel5.TabIndex = 62;
            // 
            // menuStrip_chucNang
            // 
            menuStrip_chucNang.BackColor = Color.MediumTurquoise;
            menuStrip_chucNang.Dock = DockStyle.Fill;
            menuStrip_chucNang.ImageScalingSize = new Size(20, 20);
            menuStrip_chucNang.Items.AddRange(new ToolStripItem[] { btn_Luulai, btn_Them, btn_Sua, btn_Xoa, btn_Huy, btn_XuatFile, btn_NhapFile });
            menuStrip_chucNang.Location = new Point(0, 0);
            menuStrip_chucNang.Name = "menuStrip_chucNang";
            menuStrip_chucNang.Padding = new Padding(6, 3, 0, 3);
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
            btn_Luulai.Size = new Size(150, 49);
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
            btn_Them.Size = new Size(135, 49);
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
            btn_Sua.Size = new Size(121, 49);
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
            btn_Xoa.Size = new Size(122, 49);
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
            btn_Huy.Size = new Size(148, 49);
            btn_Huy.Text = "Hủy bỏ";
            btn_Huy.TextAlign = ContentAlignment.MiddleRight;
            btn_Huy.Click += btn_huyBo_Click;
            // 
            // btn_XuatFile
            // 
            btn_XuatFile.BackColor = Color.PaleTurquoise;
            btn_XuatFile.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            btn_XuatFile.Image = (Image)resources.GetObject("btn_XuatFile.Image");
            btn_XuatFile.ImageScaling = ToolStripItemImageScaling.None;
            btn_XuatFile.Name = "btn_XuatFile";
            btn_XuatFile.Padding = new Padding(5, 5, 40, 5);
            btn_XuatFile.Size = new Size(161, 49);
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
            btn_NhapFile.Size = new Size(168, 49);
            btn_NhapFile.Text = "Nhập File";
            btn_NhapFile.TextAlign = ContentAlignment.MiddleRight;
            btn_NhapFile.Click += btn_nhapFile_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // textBox_SearchByName
            // 
            textBox_SearchByName.Location = new Point(8, 35);
            textBox_SearchByName.Name = "textBox_SearchByName";
            textBox_SearchByName.Size = new Size(257, 27);
            textBox_SearchByName.TabIndex = 64;
            textBox_SearchByName.TextChanged += combox_SearchByName_TextChanged;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(2, 7);
            label19.Name = "label19";
            label19.Size = new Size(263, 20);
            label19.TabIndex = 65;
            label19.Text = "Nhập tên muốn tìm ( tối thiểu 1 ký tự )";
            // 
            // panel3
            // 
            panel3.BackColor = Color.PaleTurquoise;
            panel3.Controls.Add(textBox_SearchByName);
            panel3.Controls.Add(label19);
            panel3.Location = new Point(245, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(275, 68);
            panel3.TabIndex = 66;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 13F, FontStyle.Bold | FontStyle.Underline);
            label20.Location = new Point(101, 19);
            label20.Name = "label20";
            label20.Size = new Size(102, 30);
            label20.TabIndex = 68;
            label20.Text = "Trợ Giúp";
            label20.Click += label20_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(19, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(77, 69);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 67;
            pictureBox2.TabStop = false;
            pictureBox2.Click += label20_Click;
            // 
            // F_KhachHang
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(1394, 744);
            ControlBox = false;
            Controls.Add(label20);
            Controls.Add(pictureBox2);
            Controls.Add(panel3);
            Controls.Add(panel5);
            Controls.Add(pictureBox_troVe);
            Controls.Add(label4);
            Controls.Add(groupBox2);
            Controls.Add(panel1);
            Name = "F_KhachHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Khách Hàng";
            Load += F_KhachHang_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtg_khachHang).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pic_anhChanDung).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_diemTinhDung).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_hanMucTinDung).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_thuNhap).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_troVe).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            menuStrip_chucNang.ResumeLayout(false);
            menuStrip_chucNang.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_dienThoai;
        private TextBox txt_diaChiThuongTru;
        private TextBox txt_hoTen;
        private Label label1;
        private Label label2;
        private Label label3;
        private Panel panel1;
        private DataGridView dtg_khachHang;
        private GroupBox groupBox2;
        private Label label4;
        private TextBox txt_soTaiKhoan;
        private NumericUpDown num_thuNhap;
        private TextBox txt_ngheNghiep;
        private TextBox txt_diaChiLienHe;
        private TextBox txt_eMail;
        private TextBox txt_soCCCD;
        private DateTimePicker dtp_ngaySinh;
        private DateTimePicker dtp_ngayCapCCCD;
        private TextBox txt_noiLamViec;
        private ComboBox cbb_tenNganHang;
        private PictureBox pic_anhChanDung;
        private Panel panel2;
        private NumericUpDown num_hanMucTinDung;
        private NumericUpDown num_diemTinhDung;
        private ComboBox cbb_noiCapCCCD;
        private Label label18;
        private Label label17;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label6;
        private Label label5;
        private PictureBox pictureBox_troVe;
        private Panel panel5;
        private MenuStrip menuStrip_chucNang;
        private ToolStripMenuItem btn_Luulai;
        private ToolStripMenuItem btn_Them;
        private ToolStripMenuItem btn_Sua;
        private ToolStripMenuItem btn_Xoa;
        private ToolStripMenuItem btn_Huy;
        private ToolStripMenuItem btn_XuatFile;
        private ToolStripMenuItem btn_NhapFile;
        private Label label7;
        private RadioButton rdb_nam;
        private RadioButton rdb_nu;
        private GroupBox groupBox1;
        private Panel panel4;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem btn_ChonAnh;
        private ToolStripMenuItem btn_DoiAnh;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private TextBox textBox_SearchByName;
        private Label label19;
        private Panel panel3;
        private Label label20;
        private PictureBox pictureBox2;
        private ComboBox cbb_khuVuc;
        private Label label21;
    }
}