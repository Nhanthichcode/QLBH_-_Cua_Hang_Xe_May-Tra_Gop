namespace DoAnBanHang_cuahangxemay.Forms
{
    partial class F_TraGop
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_TraGop));
            btn_xemChiTiet = new Button();
            panel1 = new Panel();
            dtg_traGop = new DataGridView();
            txt_soTienConLai = new TextBox();
            txt_soKyHan = new TextBox();
            txt_laiSuat = new TextBox();
            txt_soTienGoc = new TextBox();
            dtp_ngayDenHan = new DateTimePicker();
            dtp_ngayTra = new DateTimePicker();
            txt_trangThai = new TextBox();
            cbb_tenKhachHang = new ComboBox();
            btn_thanhToan = new Button();
            txt_kyTra = new TextBox();
            txt_soTienHoaDon = new TextBox();
            txt_soTienDaThanhToan = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            txt_hoVaTen = new TextBox();
            txt_tienLai = new TextBox();
            label12 = new Label();
            label13 = new Label();
            pictureBox_troVe = new PictureBox();
            panel2 = new Panel();
            label14 = new Label();
            panel3 = new Panel();
            txt_ghiChuTraGop = new TextBox();
            btn_suaTrangThai = new Button();
            label15 = new Label();
            groupBox_showByName = new GroupBox();
            label16 = new Label();
            groupBox_trangThaiHoaDon = new GroupBox();
            rdb_daHoanThanh = new RadioButton();
            da_rdb_chuaHoanThanh = new RadioButton();
            pictureBox1 = new PictureBox();
            label17 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtg_traGop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_troVe).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            groupBox_showByName.SuspendLayout();
            groupBox_trangThaiHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btn_xemChiTiet
            // 
            btn_xemChiTiet.BackColor = Color.Aqua;
            btn_xemChiTiet.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_xemChiTiet.ForeColor = SystemColors.ControlText;
            btn_xemChiTiet.Location = new Point(203, 67);
            btn_xemChiTiet.Name = "btn_xemChiTiet";
            btn_xemChiTiet.Size = new Size(71, 55);
            btn_xemChiTiet.TabIndex = 0;
            btn_xemChiTiet.Text = "Xem";
            btn_xemChiTiet.UseVisualStyleBackColor = false;
            btn_xemChiTiet.Click += btn_xemChiTiet_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dtg_traGop);
            panel1.Location = new Point(12, 434);
            panel1.Name = "panel1";
            panel1.Size = new Size(1255, 321);
            panel1.TabIndex = 1;
            // 
            // dtg_traGop
            // 
            dtg_traGop.AllowUserToAddRows = false;
            dtg_traGop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_traGop.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtg_traGop.BackgroundColor = SystemColors.ControlLightLight;
            dtg_traGop.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Info;
            dataGridViewCellStyle1.SelectionForeColor = Color.Red;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dtg_traGop.DefaultCellStyle = dataGridViewCellStyle1;
            dtg_traGop.Dock = DockStyle.Fill;
            dtg_traGop.Location = new Point(0, 0);
            dtg_traGop.MultiSelect = false;
            dtg_traGop.Name = "dtg_traGop";
            dtg_traGop.ReadOnly = true;
            dtg_traGop.RowHeadersWidth = 51;
            dtg_traGop.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_traGop.Size = new Size(1255, 321);
            dtg_traGop.TabIndex = 0;
            // 
            // txt_soTienConLai
            // 
            txt_soTienConLai.Location = new Point(177, 157);
            txt_soTienConLai.Name = "txt_soTienConLai";
            txt_soTienConLai.ReadOnly = true;
            txt_soTienConLai.Size = new Size(177, 27);
            txt_soTienConLai.TabIndex = 2;
            txt_soTienConLai.TextAlign = HorizontalAlignment.Right;
            // 
            // txt_soKyHan
            // 
            txt_soKyHan.Location = new Point(96, 33);
            txt_soKyHan.Name = "txt_soKyHan";
            txt_soKyHan.ReadOnly = true;
            txt_soKyHan.Size = new Size(69, 27);
            txt_soKyHan.TabIndex = 3;
            txt_soKyHan.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_laiSuat
            // 
            txt_laiSuat.Location = new Point(367, 37);
            txt_laiSuat.Name = "txt_laiSuat";
            txt_laiSuat.ReadOnly = true;
            txt_laiSuat.Size = new Size(45, 27);
            txt_laiSuat.TabIndex = 4;
            txt_laiSuat.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_soTienGoc
            // 
            txt_soTienGoc.Location = new Point(177, 37);
            txt_soTienGoc.Name = "txt_soTienGoc";
            txt_soTienGoc.ReadOnly = true;
            txt_soTienGoc.Size = new Size(177, 27);
            txt_soTienGoc.TabIndex = 5;
            txt_soTienGoc.TextAlign = HorizontalAlignment.Right;
            // 
            // dtp_ngayDenHan
            // 
            dtp_ngayDenHan.Font = new Font("STSong", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 134);
            dtp_ngayDenHan.Format = DateTimePickerFormat.Custom;
            dtp_ngayDenHan.Location = new Point(402, 109);
            dtp_ngayDenHan.Name = "dtp_ngayDenHan";
            dtp_ngayDenHan.Size = new Size(149, 30);
            dtp_ngayDenHan.TabIndex = 7;
            // 
            // dtp_ngayTra
            // 
            dtp_ngayTra.CalendarForeColor = Color.IndianRed;
            dtp_ngayTra.Font = new Font("STSong", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 134);
            dtp_ngayTra.Format = DateTimePickerFormat.Custom;
            dtp_ngayTra.Location = new Point(15, 167);
            dtp_ngayTra.Name = "dtp_ngayTra";
            dtp_ngayTra.Size = new Size(155, 30);
            dtp_ngayTra.TabIndex = 8;
            // 
            // txt_trangThai
            // 
            txt_trangThai.Location = new Point(15, 100);
            txt_trangThai.Name = "txt_trangThai";
            txt_trangThai.ReadOnly = true;
            txt_trangThai.Size = new Size(155, 27);
            txt_trangThai.TabIndex = 9;
            txt_trangThai.TextAlign = HorizontalAlignment.Center;
            // 
            // cbb_tenKhachHang
            // 
            cbb_tenKhachHang.FormattingEnabled = true;
            cbb_tenKhachHang.Location = new Point(13, 61);
            cbb_tenKhachHang.Name = "cbb_tenKhachHang";
            cbb_tenKhachHang.Size = new Size(242, 28);
            cbb_tenKhachHang.TabIndex = 11;
            cbb_tenKhachHang.SelectionChangeCommitted += cbb_tenKhachHang_SelectionChangeCommitted;
            // 
            // btn_thanhToan
            // 
            btn_thanhToan.BackColor = Color.LawnGreen;
            btn_thanhToan.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_thanhToan.ForeColor = SystemColors.ControlText;
            btn_thanhToan.Location = new Point(9, 11);
            btn_thanhToan.Name = "btn_thanhToan";
            btn_thanhToan.Size = new Size(127, 53);
            btn_thanhToan.TabIndex = 12;
            btn_thanhToan.Text = "Thanh toán";
            btn_thanhToan.UseVisualStyleBackColor = false;
            btn_thanhToan.Click += button1_Click;
            // 
            // txt_kyTra
            // 
            txt_kyTra.Location = new Point(15, 35);
            txt_kyTra.Name = "txt_kyTra";
            txt_kyTra.ReadOnly = true;
            txt_kyTra.Size = new Size(44, 27);
            txt_kyTra.TabIndex = 15;
            txt_kyTra.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_soTienHoaDon
            // 
            txt_soTienHoaDon.Location = new Point(177, 77);
            txt_soTienHoaDon.Name = "txt_soTienHoaDon";
            txt_soTienHoaDon.ReadOnly = true;
            txt_soTienHoaDon.Size = new Size(177, 27);
            txt_soTienHoaDon.TabIndex = 16;
            txt_soTienHoaDon.TextAlign = HorizontalAlignment.Right;
            // 
            // txt_soTienDaThanhToan
            // 
            txt_soTienDaThanhToan.Location = new Point(177, 117);
            txt_soTienDaThanhToan.Name = "txt_soTienDaThanhToan";
            txt_soTienDaThanhToan.ReadOnly = true;
            txt_soTienDaThanhToan.Size = new Size(177, 27);
            txt_soTienDaThanhToan.TabIndex = 17;
            txt_soTienDaThanhToan.TextAlign = HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 11);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 19;
            label1.Text = "Kì trả";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(96, 11);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 20;
            label2.Text = "Số kì hạn";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(367, 11);
            label3.Name = "label3";
            label3.Size = new Size(59, 20);
            label3.TabIndex = 21;
            label3.Text = "Lãi suất";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 141);
            label4.Name = "label4";
            label4.Size = new Size(119, 20);
            label4.TabIndex = 22;
            label4.Text = "Ngày thanh toán";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(401, 84);
            label5.Name = "label5";
            label5.Size = new Size(101, 20);
            label5.TabIndex = 23;
            label5.Text = "Ngày đến hạn";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(177, 11);
            label6.Name = "label6";
            label6.Size = new Size(113, 20);
            label6.TabIndex = 24;
            label6.Text = "Số tiền ban đầu";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(9, 80);
            label7.Name = "label7";
            label7.Size = new Size(127, 20);
            label7.TabIndex = 25;
            label7.Text = "Tổng tiền phải trả";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(9, 120);
            label8.Name = "label8";
            label8.Size = new Size(151, 20);
            label8.TabIndex = 26;
            label8.Text = "Số tiền đã thanh toán";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(9, 161);
            label9.Name = "label9";
            label9.Size = new Size(55, 20);
            label9.TabIndex = 27;
            label9.Text = "Còn lại";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label10.Location = new Point(409, 39);
            label10.Name = "label10";
            label10.Size = new Size(28, 25);
            label10.TabIndex = 28;
            label10.Text = "%";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label11.Location = new Point(64, 29);
            label11.Name = "label11";
            label11.Size = new Size(24, 31);
            label11.TabIndex = 29;
            label11.Text = "/";
            // 
            // txt_hoVaTen
            // 
            txt_hoVaTen.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            txt_hoVaTen.ForeColor = Color.Yellow;
            txt_hoVaTen.Location = new Point(178, 392);
            txt_hoVaTen.Name = "txt_hoVaTen";
            txt_hoVaTen.ReadOnly = true;
            txt_hoVaTen.Size = new Size(217, 30);
            txt_hoVaTen.TabIndex = 30;
            txt_hoVaTen.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_tienLai
            // 
            txt_tienLai.Location = new Point(445, 37);
            txt_tienLai.Name = "txt_tienLai";
            txt_tienLai.ReadOnly = true;
            txt_tienLai.Size = new Size(106, 27);
            txt_tienLai.TabIndex = 31;
            txt_tienLai.TextAlign = HorizontalAlignment.Center;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(445, 11);
            label12.Name = "label12";
            label12.Size = new Size(57, 20);
            label12.TabIndex = 32;
            label12.Text = "Tiền lãi";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(15, 77);
            label13.Name = "label13";
            label13.Size = new Size(75, 20);
            label13.TabIndex = 33;
            label13.Text = "Trạng thái";
            // 
            // pictureBox_troVe
            // 
            pictureBox_troVe.BorderStyle = BorderStyle.Fixed3D;
            pictureBox_troVe.Image = (Image)resources.GetObject("pictureBox_troVe.Image");
            pictureBox_troVe.Location = new Point(1186, 13);
            pictureBox_troVe.Name = "pictureBox_troVe";
            pictureBox_troVe.Size = new Size(81, 68);
            pictureBox_troVe.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_troVe.TabIndex = 34;
            pictureBox_troVe.TabStop = false;
            pictureBox_troVe.Click += pictureBox_troVe_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightYellow;
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txt_kyTra);
            panel2.Controls.Add(txt_trangThai);
            panel2.Controls.Add(dtp_ngayTra);
            panel2.Controls.Add(txt_soKyHan);
            panel2.Location = new Point(1078, 146);
            panel2.Name = "panel2";
            panel2.Size = new Size(184, 205);
            panel2.TabIndex = 35;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Aquamarine;
            label14.Font = new Font("Segoe UI Black", 11F);
            label14.ForeColor = SystemColors.InactiveCaptionText;
            label14.Location = new Point(12, 398);
            label14.Name = "label14";
            label14.Size = new Size(159, 25);
            label14.TabIndex = 36;
            label14.Text = "Tên khách hàng";
            // 
            // panel3
            // 
            panel3.BackColor = Color.SeaShell;
            panel3.Controls.Add(txt_ghiChuTraGop);
            panel3.Controls.Add(label12);
            panel3.Controls.Add(txt_tienLai);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(btn_suaTrangThai);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(btn_thanhToan);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(txt_soTienDaThanhToan);
            panel3.Controls.Add(txt_soTienHoaDon);
            panel3.Controls.Add(dtp_ngayDenHan);
            panel3.Controls.Add(txt_soTienGoc);
            panel3.Controls.Add(txt_laiSuat);
            panel3.Controls.Add(txt_soTienConLai);
            panel3.Location = new Point(504, 146);
            panel3.Name = "panel3";
            panel3.Size = new Size(568, 276);
            panel3.TabIndex = 37;
            // 
            // txt_ghiChuTraGop
            // 
            txt_ghiChuTraGop.Location = new Point(177, 195);
            txt_ghiChuTraGop.Multiline = true;
            txt_ghiChuTraGop.Name = "txt_ghiChuTraGop";
            txt_ghiChuTraGop.ReadOnly = true;
            txt_ghiChuTraGop.Size = new Size(181, 70);
            txt_ghiChuTraGop.TabIndex = 40;
            // 
            // btn_suaTrangThai
            // 
            btn_suaTrangThai.BackColor = Color.Red;
            btn_suaTrangThai.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_suaTrangThai.ForeColor = SystemColors.ButtonHighlight;
            btn_suaTrangThai.Location = new Point(398, 159);
            btn_suaTrangThai.Name = "btn_suaTrangThai";
            btn_suaTrangThai.Size = new Size(163, 52);
            btn_suaTrangThai.TabIndex = 39;
            btn_suaTrangThai.Text = "Sửa trạng thái";
            btn_suaTrangThai.UseVisualStyleBackColor = false;
            btn_suaTrangThai.Click += btn_suaTrangThai_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.ForeColor = Color.DeepSkyBlue;
            label15.Location = new Point(431, 57);
            label15.Name = "label15";
            label15.Size = new Size(371, 43);
            label15.TabIndex = 38;
            label15.Text = "THÔNG TIN TRẢ GÓP";
            // 
            // groupBox_showByName
            // 
            groupBox_showByName.Controls.Add(label16);
            groupBox_showByName.Controls.Add(cbb_tenKhachHang);
            groupBox_showByName.Location = new Point(139, 130);
            groupBox_showByName.Margin = new Padding(3, 4, 3, 4);
            groupBox_showByName.Name = "groupBox_showByName";
            groupBox_showByName.Padding = new Padding(3, 4, 3, 4);
            groupBox_showByName.Size = new Size(285, 108);
            groupBox_showByName.TabIndex = 40;
            groupBox_showByName.TabStop = false;
            groupBox_showByName.Text = "Xem hóa đơn theo tên";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(11, 37);
            label16.Name = "label16";
            label16.Size = new Size(243, 20);
            label16.TabIndex = 39;
            label16.Text = "Chọn mã hóa đơn / Tên khách hàng";
            // 
            // groupBox_trangThaiHoaDon
            // 
            groupBox_trangThaiHoaDon.Controls.Add(rdb_daHoanThanh);
            groupBox_trangThaiHoaDon.Controls.Add(btn_xemChiTiet);
            groupBox_trangThaiHoaDon.Controls.Add(da_rdb_chuaHoanThanh);
            groupBox_trangThaiHoaDon.Location = new Point(139, 246);
            groupBox_trangThaiHoaDon.Margin = new Padding(3, 4, 3, 4);
            groupBox_trangThaiHoaDon.Name = "groupBox_trangThaiHoaDon";
            groupBox_trangThaiHoaDon.Padding = new Padding(3, 4, 3, 4);
            groupBox_trangThaiHoaDon.Size = new Size(285, 128);
            groupBox_trangThaiHoaDon.TabIndex = 40;
            groupBox_trangThaiHoaDon.TabStop = false;
            groupBox_trangThaiHoaDon.Text = "Xem hóa đơn theo trạng thái";
            // 
            // rdb_daHoanThanh
            // 
            rdb_daHoanThanh.AutoSize = true;
            rdb_daHoanThanh.Checked = true;
            rdb_daHoanThanh.Location = new Point(7, 35);
            rdb_daHoanThanh.Margin = new Padding(3, 4, 3, 4);
            rdb_daHoanThanh.Name = "rdb_daHoanThanh";
            rdb_daHoanThanh.Size = new Size(127, 24);
            rdb_daHoanThanh.TabIndex = 37;
            rdb_daHoanThanh.TabStop = true;
            rdb_daHoanThanh.Text = "Đã hoàn thành";
            rdb_daHoanThanh.UseVisualStyleBackColor = true;
            // 
            // da_rdb_chuaHoanThanh
            // 
            da_rdb_chuaHoanThanh.AutoSize = true;
            da_rdb_chuaHoanThanh.Location = new Point(141, 35);
            da_rdb_chuaHoanThanh.Margin = new Padding(3, 4, 3, 4);
            da_rdb_chuaHoanThanh.Name = "da_rdb_chuaHoanThanh";
            da_rdb_chuaHoanThanh.Size = new Size(142, 24);
            da_rdb_chuaHoanThanh.TabIndex = 38;
            da_rdb_chuaHoanThanh.Text = "Chưa hoàn thành";
            da_rdb_chuaHoanThanh.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(77, 69);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 41;
            pictureBox1.TabStop = false;
            pictureBox1.Click += label17_Click_1;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 13F, FontStyle.Bold | FontStyle.Underline);
            label17.Location = new Point(94, 29);
            label17.Name = "label17";
            label17.Size = new Size(102, 30);
            label17.TabIndex = 42;
            label17.Text = "Trợ Giúp";
            label17.Click += label17_Click_1;
            // 
            // F_TraGop
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(1281, 767);
            ControlBox = false;
            Controls.Add(label17);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox_trangThaiHoaDon);
            Controls.Add(groupBox_showByName);
            Controls.Add(label14);
            Controls.Add(label15);
            Controls.Add(panel3);
            Controls.Add(txt_hoVaTen);
            Controls.Add(panel2);
            Controls.Add(pictureBox_troVe);
            Controls.Add(panel1);
            Name = "F_TraGop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trả Góp";
            Load += F_TraGop_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtg_traGop).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_troVe).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            groupBox_showByName.ResumeLayout(false);
            groupBox_showByName.PerformLayout();
            groupBox_trangThaiHoaDon.ResumeLayout(false);
            groupBox_trangThaiHoaDon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_xemChiTiet;
        private Panel panel1;
        private DataGridView dtg_traGop;
        private TextBox txt_soTienConLai;
        private TextBox txt_soKyHan;
        private TextBox txt_laiSuat;
        private TextBox txt_soTienGoc;
        private DateTimePicker dtp_ngayDenHan;
        private DateTimePicker dtp_ngayTra;
        private TextBox txt_trangThai;
        private ComboBox cbb_tenKhachHang;
        private Button btn_thanhToan;
        private TextBox txt_kyTra;
        private TextBox txt_soTienHoaDon;
        private TextBox txt_soTienDaThanhToan;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox txt_hoVaTen;
        private TextBox txt_tienLai;
        private Label label12;
        private Label label13;
        private PictureBox pictureBox_troVe;
        private Panel panel2;
        private Label label14;
        private Panel panel3;
        private Label label15;
        private Button btn_suaTrangThai;
        private GroupBox groupBox_showByName;
        private RadioButton da_rdb_chuaHoanThanh;
        private RadioButton rdb_daHoanThanh;
        private GroupBox groupBox_trangThaiHoaDon;
        private Label label16;
        private PictureBox pictureBox1;
        private Label label17;
        private TextBox txt_ghiChuTraGop;
    }
}