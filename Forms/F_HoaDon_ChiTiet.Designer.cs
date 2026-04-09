namespace DoAnBanHang_cuahangxemay.Forms
{
    partial class F_HoaDon_ChiTiet
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_HoaDon_ChiTiet));
            panel1 = new Panel();
            dtg_chiTietHoaDon = new DataGridView();
            cbb_sanPham = new ComboBox();
            num_soLuong = new NumericUpDown();
            num_donGia = new NumericUpDown();
            cbb_khachHang = new ComboBox();
            cbb_nhanVien = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            cbb_phuongThucThanhToan = new ComboBox();
            label6 = new Label();
            groupBox_traGop = new GroupBox();
            label8 = new Label();
            label7 = new Label();
            num_soTienLai = new NumericUpDown();
            num_soKyHan = new NumericUpDown();
            groupBox_thongTinHoaDon = new GroupBox();
            panel2 = new Panel();
            menuStrip_chucNang = new MenuStrip();
            btn_luuLai = new ToolStripMenuItem();
            btn_themSanPham = new ToolStripMenuItem();
            btn_xoaSanPham = new ToolStripMenuItem();
            label10 = new Label();
            txt_ghiChuHoaDon = new TextBox();
            groupBox_trangThaiThanhToan = new GroupBox();
            cbb_trangThaiThanhToan = new ComboBox();
            panel_thongTin = new Panel();
            pictureBox_maqueeSanPham = new PictureBox();
            panel_thongTinThanhToan = new Panel();
            pictureBox1 = new PictureBox();
            btn_themKhachHang = new Button();
            lable_tongTienHoaDon = new Label();
            label11 = new Label();
            pictureBox_troVeHoaDon = new PictureBox();
            toolTip_troVeFormHoaDon = new ToolTip(components);
            toolTip_ptth = new ToolTip(components);
            toolTip_luuLai = new ToolTip(components);
            toolTip_xoa = new ToolTip(components);
            label9 = new Label();
            tHeader_xacNhan = new ToolTip(components);
            label17 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox_troVe = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtg_chiTietHoaDon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_soLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_donGia).BeginInit();
            groupBox_traGop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_soTienLai).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_soKyHan).BeginInit();
            groupBox_thongTinHoaDon.SuspendLayout();
            panel2.SuspendLayout();
            menuStrip_chucNang.SuspendLayout();
            groupBox_trangThaiThanhToan.SuspendLayout();
            panel_thongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_maqueeSanPham).BeginInit();
            panel_thongTinThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_troVeHoaDon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_troVe).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dtg_chiTietHoaDon);
            panel1.Location = new Point(12, 492);
            panel1.Name = "panel1";
            panel1.Size = new Size(1352, 243);
            panel1.TabIndex = 0;
            // 
            // dtg_chiTietHoaDon
            // 
            dtg_chiTietHoaDon.AllowUserToAddRows = false;
            dtg_chiTietHoaDon.AllowUserToDeleteRows = false;
            dtg_chiTietHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtg_chiTietHoaDon.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtg_chiTietHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_chiTietHoaDon.Dock = DockStyle.Fill;
            dtg_chiTietHoaDon.Location = new Point(0, 0);
            dtg_chiTietHoaDon.MultiSelect = false;
            dtg_chiTietHoaDon.Name = "dtg_chiTietHoaDon";
            dtg_chiTietHoaDon.ReadOnly = true;
            dtg_chiTietHoaDon.RowHeadersWidth = 51;
            dtg_chiTietHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_chiTietHoaDon.Size = new Size(1352, 243);
            dtg_chiTietHoaDon.TabIndex = 1;
            // 
            // cbb_sanPham
            // 
            cbb_sanPham.FormattingEnabled = true;
            cbb_sanPham.Location = new Point(190, 107);
            cbb_sanPham.Name = "cbb_sanPham";
            cbb_sanPham.Size = new Size(222, 28);
            cbb_sanPham.TabIndex = 11;
            cbb_sanPham.SelectionChangeCommitted += cbb_sanPham_SelectionChangeCommitted;
            // 
            // num_soLuong
            // 
            num_soLuong.Location = new Point(191, 192);
            num_soLuong.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            num_soLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_soLuong.Name = "num_soLuong";
            num_soLuong.Size = new Size(221, 27);
            num_soLuong.TabIndex = 12;
            num_soLuong.TextAlign = HorizontalAlignment.Right;
            num_soLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // num_donGia
            // 
            num_donGia.Location = new Point(190, 155);
            num_donGia.Maximum = new decimal(new int[] { -1981284353, -1966660860, 0, 0 });
            num_donGia.Name = "num_donGia";
            num_donGia.ReadOnly = true;
            num_donGia.Size = new Size(221, 27);
            num_donGia.TabIndex = 13;
            num_donGia.TextAlign = HorizontalAlignment.Right;
            // 
            // cbb_khachHang
            // 
            cbb_khachHang.FormattingEnabled = true;
            cbb_khachHang.Location = new Point(190, 11);
            cbb_khachHang.Name = "cbb_khachHang";
            cbb_khachHang.Size = new Size(222, 28);
            cbb_khachHang.TabIndex = 3;
            // 
            // cbb_nhanVien
            // 
            cbb_nhanVien.FormattingEnabled = true;
            cbb_nhanVien.Location = new Point(190, 59);
            cbb_nhanVien.Name = "cbb_nhanVien";
            cbb_nhanVien.Size = new Size(222, 28);
            cbb_nhanVien.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 199);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 14;
            label1.Text = "Số kượng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 156);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 15;
            label2.Text = "Đơn giá";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 19);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 16;
            label3.Text = "Tên khách hàng";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 67);
            label4.Name = "label4";
            label4.Size = new Size(99, 20);
            label4.TabIndex = 17;
            label4.Text = "Tên nhân viên";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 115);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 18;
            label5.Text = "Tên sản phẩm";
            // 
            // cbb_phuongThucThanhToan
            // 
            cbb_phuongThucThanhToan.FormattingEnabled = true;
            cbb_phuongThucThanhToan.Location = new Point(21, 33);
            cbb_phuongThucThanhToan.Name = "cbb_phuongThucThanhToan";
            cbb_phuongThucThanhToan.Size = new Size(201, 28);
            cbb_phuongThucThanhToan.TabIndex = 19;
            toolTip_ptth.SetToolTip(cbb_phuongThucThanhToan, "Chọn Phương thức thanh toán");
            cbb_phuongThucThanhToan.SelectionChangeCommitted += cbb_phuongThucThanhToan_SelectionChangeCommitted;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 11);
            label6.Name = "label6";
            label6.Size = new Size(168, 20);
            label6.TabIndex = 20;
            label6.Text = "Phương thức thanh toán";
            // 
            // groupBox_traGop
            // 
            groupBox_traGop.Controls.Add(label8);
            groupBox_traGop.Controls.Add(label7);
            groupBox_traGop.Controls.Add(num_soTienLai);
            groupBox_traGop.Controls.Add(num_soKyHan);
            groupBox_traGop.Location = new Point(21, 67);
            groupBox_traGop.Name = "groupBox_traGop";
            groupBox_traGop.Size = new Size(218, 136);
            groupBox_traGop.TabIndex = 21;
            groupBox_traGop.TabStop = false;
            groupBox_traGop.Text = "Bổ sung thông tin trả góp";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 40);
            label8.Name = "label8";
            label8.Size = new Size(72, 20);
            label8.TabIndex = 4;
            label8.Text = "Số kỳ hạn";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 81);
            label7.Name = "label7";
            label7.Size = new Size(59, 20);
            label7.TabIndex = 3;
            label7.Text = "Lãi suất";
            // 
            // num_soTienLai
            // 
            num_soTienLai.DecimalPlaces = 2;
            num_soTienLai.Font = new Font("Stencil", 10.2F);
            num_soTienLai.ForeColor = Color.Red;
            num_soTienLai.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
            num_soTienLai.Location = new Point(103, 76);
            num_soTienLai.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            num_soTienLai.Name = "num_soTienLai";
            num_soTienLai.Size = new Size(98, 28);
            num_soTienLai.TabIndex = 1;
            num_soTienLai.TextAlign = HorizontalAlignment.Center;
            num_soTienLai.ThousandsSeparator = true;
            num_soTienLai.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            // 
            // num_soKyHan
            // 
            num_soKyHan.DecimalPlaces = 2;
            num_soKyHan.Font = new Font("Stencil", 10.2F);
            num_soKyHan.ForeColor = SystemColors.HotTrack;
            num_soKyHan.Increment = new decimal(new int[] { 3, 0, 0, 0 });
            num_soKyHan.Location = new Point(103, 32);
            num_soKyHan.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            num_soKyHan.Name = "num_soKyHan";
            num_soKyHan.Size = new Size(98, 28);
            num_soKyHan.TabIndex = 0;
            num_soKyHan.TextAlign = HorizontalAlignment.Center;
            num_soKyHan.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // groupBox_thongTinHoaDon
            // 
            groupBox_thongTinHoaDon.Controls.Add(panel2);
            groupBox_thongTinHoaDon.Controls.Add(label10);
            groupBox_thongTinHoaDon.Controls.Add(txt_ghiChuHoaDon);
            groupBox_thongTinHoaDon.Controls.Add(groupBox_trangThaiThanhToan);
            groupBox_thongTinHoaDon.Controls.Add(panel_thongTin);
            groupBox_thongTinHoaDon.Controls.Add(pictureBox_maqueeSanPham);
            groupBox_thongTinHoaDon.Controls.Add(panel_thongTinThanhToan);
            groupBox_thongTinHoaDon.Location = new Point(12, 157);
            groupBox_thongTinHoaDon.Name = "groupBox_thongTinHoaDon";
            groupBox_thongTinHoaDon.Size = new Size(1358, 333);
            groupBox_thongTinHoaDon.TabIndex = 22;
            groupBox_thongTinHoaDon.TabStop = false;
            groupBox_thongTinHoaDon.Text = "Thông tin Hóa Đơn";
            // 
            // panel2
            // 
            panel2.Controls.Add(menuStrip_chucNang);
            panel2.Location = new Point(3, 264);
            panel2.Name = "panel2";
            panel2.Size = new Size(1434, 57);
            panel2.TabIndex = 29;
            // 
            // menuStrip_chucNang
            // 
            menuStrip_chucNang.BackColor = Color.Azure;
            menuStrip_chucNang.Dock = DockStyle.Fill;
            menuStrip_chucNang.ImageScalingSize = new Size(20, 20);
            menuStrip_chucNang.Items.AddRange(new ToolStripItem[] { btn_luuLai, btn_themSanPham, btn_xoaSanPham });
            menuStrip_chucNang.Location = new Point(0, 0);
            menuStrip_chucNang.Name = "menuStrip_chucNang";
            menuStrip_chucNang.Padding = new Padding(6, 3, 0, 3);
            menuStrip_chucNang.Size = new Size(1434, 57);
            menuStrip_chucNang.TabIndex = 6;
            menuStrip_chucNang.Text = "menuStrip1";
            // 
            // btn_luuLai
            // 
            btn_luuLai.BackColor = Color.Gold;
            btn_luuLai.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_luuLai.Image = (Image)resources.GetObject("btn_luuLai.Image");
            btn_luuLai.ImageScaling = ToolStripItemImageScaling.None;
            btn_luuLai.Margin = new Padding(20, 0, 0, 0);
            btn_luuLai.Name = "btn_luuLai";
            btn_luuLai.Size = new Size(114, 51);
            btn_luuLai.Text = "Lưu Lại";
            btn_luuLai.Click += btn_luuLai_Click;
            // 
            // btn_themSanPham
            // 
            btn_themSanPham.BackColor = Color.MediumSpringGreen;
            btn_themSanPham.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_themSanPham.Image = (Image)resources.GetObject("btn_themSanPham.Image");
            btn_themSanPham.ImageScaling = ToolStripItemImageScaling.None;
            btn_themSanPham.Margin = new Padding(500, 0, 60, 0);
            btn_themSanPham.Name = "btn_themSanPham";
            btn_themSanPham.Size = new Size(223, 51);
            btn_themSanPham.Text = "Thêm vào Danh Sách";
            btn_themSanPham.Click += btn_xacNhan_Click;
            // 
            // btn_xoaSanPham
            // 
            btn_xoaSanPham.BackColor = Color.MistyRose;
            btn_xoaSanPham.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_xoaSanPham.Image = (Image)resources.GetObject("btn_xoaSanPham.Image");
            btn_xoaSanPham.ImageScaling = ToolStripItemImageScaling.None;
            btn_xoaSanPham.Margin = new Padding(200, 0, 0, 0);
            btn_xoaSanPham.Name = "btn_xoaSanPham";
            btn_xoaSanPham.Size = new Size(134, 51);
            btn_xoaSanPham.Text = "Xóa Hàng";
            btn_xoaSanPham.Click += btn_xoa_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 163);
            label10.Location = new Point(443, 115);
            label10.Name = "label10";
            label10.Size = new Size(80, 23);
            label10.TabIndex = 28;
            label10.Text = "Ghi chú :";
            // 
            // txt_ghiChuHoaDon
            // 
            txt_ghiChuHoaDon.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 163);
            txt_ghiChuHoaDon.Location = new Point(443, 140);
            txt_ghiChuHoaDon.Multiline = true;
            txt_ghiChuHoaDon.Name = "txt_ghiChuHoaDon";
            txt_ghiChuHoaDon.Size = new Size(353, 107);
            txt_ghiChuHoaDon.TabIndex = 27;
            // 
            // groupBox_trangThaiThanhToan
            // 
            groupBox_trangThaiThanhToan.BackColor = Color.Aquamarine;
            groupBox_trangThaiThanhToan.Controls.Add(cbb_trangThaiThanhToan);
            groupBox_trangThaiThanhToan.Location = new Point(599, 36);
            groupBox_trangThaiThanhToan.Name = "groupBox_trangThaiThanhToan";
            groupBox_trangThaiThanhToan.Size = new Size(197, 80);
            groupBox_trangThaiThanhToan.TabIndex = 25;
            groupBox_trangThaiThanhToan.TabStop = false;
            groupBox_trangThaiThanhToan.Text = "Trạng thái thanh toán";
            // 
            // cbb_trangThaiThanhToan
            // 
            cbb_trangThaiThanhToan.FormattingEnabled = true;
            cbb_trangThaiThanhToan.Location = new Point(6, 39);
            cbb_trangThaiThanhToan.Name = "cbb_trangThaiThanhToan";
            cbb_trangThaiThanhToan.Size = new Size(185, 28);
            cbb_trangThaiThanhToan.TabIndex = 25;
            // 
            // panel_thongTin
            // 
            panel_thongTin.Controls.Add(label2);
            panel_thongTin.Controls.Add(label1);
            panel_thongTin.Controls.Add(label5);
            panel_thongTin.Controls.Add(cbb_khachHang);
            panel_thongTin.Controls.Add(label4);
            panel_thongTin.Controls.Add(cbb_nhanVien);
            panel_thongTin.Controls.Add(label3);
            panel_thongTin.Controls.Add(num_donGia);
            panel_thongTin.Controls.Add(num_soLuong);
            panel_thongTin.Controls.Add(cbb_sanPham);
            panel_thongTin.Location = new Point(5, 27);
            panel_thongTin.Name = "panel_thongTin";
            panel_thongTin.Size = new Size(427, 225);
            panel_thongTin.TabIndex = 22;
            // 
            // pictureBox_maqueeSanPham
            // 
            pictureBox_maqueeSanPham.BorderStyle = BorderStyle.Fixed3D;
            pictureBox_maqueeSanPham.Location = new Point(1117, 27);
            pictureBox_maqueeSanPham.Name = "pictureBox_maqueeSanPham";
            pictureBox_maqueeSanPham.Size = new Size(235, 231);
            pictureBox_maqueeSanPham.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_maqueeSanPham.TabIndex = 25;
            pictureBox_maqueeSanPham.TabStop = false;
            // 
            // panel_thongTinThanhToan
            // 
            panel_thongTinThanhToan.BackColor = Color.LightCyan;
            panel_thongTinThanhToan.Controls.Add(groupBox_traGop);
            panel_thongTinThanhToan.Controls.Add(cbb_phuongThucThanhToan);
            panel_thongTinThanhToan.Controls.Add(label6);
            panel_thongTinThanhToan.Location = new Point(802, 27);
            panel_thongTinThanhToan.Name = "panel_thongTinThanhToan";
            panel_thongTinThanhToan.Size = new Size(251, 225);
            panel_thongTinThanhToan.TabIndex = 26;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1038, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(65, 69);
            pictureBox1.TabIndex = 30;
            pictureBox1.TabStop = false;
            // 
            // btn_themKhachHang
            // 
            btn_themKhachHang.BackColor = SystemColors.HotTrack;
            btn_themKhachHang.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            btn_themKhachHang.ForeColor = SystemColors.ButtonHighlight;
            btn_themKhachHang.Location = new Point(1101, 2);
            btn_themKhachHang.Name = "btn_themKhachHang";
            btn_themKhachHang.Size = new Size(193, 69);
            btn_themKhachHang.TabIndex = 26;
            btn_themKhachHang.Text = "Thêm mới khách hàng";
            btn_themKhachHang.UseVisualStyleBackColor = false;
            btn_themKhachHang.Click += btn_themKhachHang_Click;
            // 
            // lable_tongTienHoaDon
            // 
            lable_tongTienHoaDon.AutoSize = true;
            lable_tongTienHoaDon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 163);
            lable_tongTienHoaDon.Location = new Point(114, 741);
            lable_tongTienHoaDon.Name = "lable_tongTienHoaDon";
            lable_tongTienHoaDon.Size = new Size(59, 21);
            lable_tongTienHoaDon.TabIndex = 27;
            lable_tongTienHoaDon.Text = "0 VNĐ";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.8F, FontStyle.Underline, GraphicsUnit.Point, 163);
            label11.Location = new Point(17, 738);
            label11.Name = "label11";
            label11.Size = new Size(91, 25);
            label11.TabIndex = 26;
            label11.Text = "Tổng tiền:";
            // 
            // pictureBox_troVeHoaDon
            // 
            pictureBox_troVeHoaDon.BorderStyle = BorderStyle.Fixed3D;
            pictureBox_troVeHoaDon.Image = (Image)resources.GetObject("pictureBox_troVeHoaDon.Image");
            pictureBox_troVeHoaDon.Location = new Point(1558, 3);
            pictureBox_troVeHoaDon.Name = "pictureBox_troVeHoaDon";
            pictureBox_troVeHoaDon.Size = new Size(79, 55);
            pictureBox_troVeHoaDon.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_troVeHoaDon.TabIndex = 23;
            pictureBox_troVeHoaDon.TabStop = false;
            toolTip_troVeFormHoaDon.SetToolTip(pictureBox_troVeHoaDon, "Quay lại trang xem Hóa Đơn");
            pictureBox_troVeHoaDon.Click += pictureBox_troVeHoaDon_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.DeepSkyBlue;
            label9.Location = new Point(567, 40);
            label9.Name = "label9";
            label9.Size = new Size(346, 43);
            label9.TabIndex = 24;
            label9.Text = "CHI TIẾT HÓA ĐƠN";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 13F, FontStyle.Bold | FontStyle.Underline);
            label17.Location = new Point(177, 57);
            label17.Name = "label17";
            label17.Size = new Size(102, 30);
            label17.TabIndex = 65;
            label17.Text = "Trợ Giúp";
            label17.Click += label17_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(96, 40);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(77, 69);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 64;
            pictureBox2.TabStop = false;
            pictureBox2.Click += label17_Click;
            // 
            // pictureBox_troVe
            // 
            pictureBox_troVe.BorderStyle = BorderStyle.Fixed3D;
            pictureBox_troVe.Image = (Image)resources.GetObject("pictureBox_troVe.Image");
            pictureBox_troVe.Location = new Point(1300, 2);
            pictureBox_troVe.Name = "pictureBox_troVe";
            pictureBox_troVe.Size = new Size(81, 68);
            pictureBox_troVe.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_troVe.TabIndex = 66;
            pictureBox_troVe.TabStop = false;
            pictureBox_troVe.Click += pictureBox_troVe_Click;
            // 
            // F_HoaDon_ChiTiet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(1382, 774);
            ControlBox = false;
            Controls.Add(pictureBox_troVe);
            Controls.Add(pictureBox1);
            Controls.Add(label17);
            Controls.Add(btn_themKhachHang);
            Controls.Add(pictureBox2);
            Controls.Add(lable_tongTienHoaDon);
            Controls.Add(label9);
            Controls.Add(label11);
            Controls.Add(pictureBox_troVeHoaDon);
            Controls.Add(groupBox_thongTinHoaDon);
            Controls.Add(panel1);
            MainMenuStrip = menuStrip_chucNang;
            Name = "F_HoaDon_ChiTiet";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chi Tiết Hóa Đơn";
            Load += F_HoaDon_ChiTiet_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtg_chiTietHoaDon).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_soLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_donGia).EndInit();
            groupBox_traGop.ResumeLayout(false);
            groupBox_traGop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num_soTienLai).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_soKyHan).EndInit();
            groupBox_thongTinHoaDon.ResumeLayout(false);
            groupBox_thongTinHoaDon.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            menuStrip_chucNang.ResumeLayout(false);
            menuStrip_chucNang.PerformLayout();
            groupBox_trangThaiThanhToan.ResumeLayout(false);
            panel_thongTin.ResumeLayout(false);
            panel_thongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_maqueeSanPham).EndInit();
            panel_thongTinThanhToan.ResumeLayout(false);
            panel_thongTinThanhToan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_troVeHoaDon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_troVe).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DataGridView dtg_chiTietHoaDon;
        private ComboBox cbb_sanPham;
        private NumericUpDown num_soLuong;
        private NumericUpDown num_donGia;
        private ComboBox cbb_khachHang;
        private ComboBox cbb_nhanVien;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox cbb_phuongThucThanhToan;
        private Label label6;
        private GroupBox groupBox_traGop;
        private Label label8;
        private Label label7;
        private NumericUpDown num_soTienLai;
        private NumericUpDown num_soKyHan;
        private GroupBox groupBox_thongTinHoaDon;
        private Panel panel_thongTin;
        private PictureBox pictureBox_troVeHoaDon;
        private ToolTip toolTip_troVeFormHoaDon;
        private ToolTip toolTip_ptth;
        private ToolTip toolTip_luuLai;
        private ToolTip toolTip_xoa;
        private Label label9;
        private GroupBox groupBox_trangThaiThanhToan;
        private PictureBox pictureBox_maqueeSanPham;
        private ToolTip tHeader_xacNhan;
        private Panel panel_thongTinThanhToan;
        private Button btn_themKhachHang;
        private Label label10;
        private TextBox txt_ghiChuHoaDon;
        private Panel panel2;
        private MenuStrip menuStrip_chucNang;
        private ToolStripMenuItem btn_luuLai;
        private ToolStripMenuItem btn_themSanPham;
        private ToolStripMenuItem xóaToolStripMenuItem;
        private PictureBox pictureBox1;
        private ToolStripMenuItem btn_xoaSanPham;
        private Label label11;
        private Label lable_tongTienHoaDon;
        private Label label17;
        private PictureBox pictureBox2;
        private ComboBox cbb_trangThaiThanhToan;
        private PictureBox pictureBox_troVe;
    }
}