
namespace DoAnBanHang_cuahangxemay.Forms
{
    partial class F_HoaDon
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_HoaDon));
            dtg_hoaDon = new DataGridView();
            panel1 = new Panel();
            pictureBox_thoat = new PictureBox();
            label1 = new Label();
            toolTip_thoat = new ToolTip(components);
            panel_menu = new Panel();
            menuStrip2 = new MenuStrip();
            btn_khoiPhucHoaDon = new ToolStripMenuItem();
            btn_thungRac = new ToolStripMenuItem();
            btn_huyHoaDon = new ToolStripMenuItem();
            btn_Deleted_All = new ToolStripMenuItem();
            btn_Them = new ToolStripMenuItem();
            btn_Sua = new ToolStripMenuItem();
            btn_Xoa = new ToolStripMenuItem();
            btn_Huy = new ToolStripMenuItem();
            btn_XuatFile = new ToolStripMenuItem();
            btn_NhapFile = new ToolStripMenuItem();
            panel5 = new Panel();
            menuStrip1 = new MenuStrip();
            btn_inHoaDon = new ToolStripMenuItem();
            panel3 = new Panel();
            textBox_SearchByName = new TextBox();
            label19 = new Label();
            label17 = new Label();
            pictureBox2 = new PictureBox();
            groupBox_trangThaiHoaDon = new GroupBox();
            rdb_dangThanhToan = new RadioButton();
            rdb_chuaThanhToan = new RadioButton();
            rdb_daThanhToan = new RadioButton();
            groupBox1 = new GroupBox();
            rdb_chuynKhoan = new RadioButton();
            rdb_theNganHang = new RadioButton();
            rdb_traGop = new RadioButton();
            rdb_tienMat = new RadioButton();
            pictureBox_reSet_Rdb = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dtg_hoaDon).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_thoat).BeginInit();
            panel_menu.SuspendLayout();
            menuStrip2.SuspendLayout();
            panel5.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox_trangThaiHoaDon.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_reSet_Rdb).BeginInit();
            SuspendLayout();
            // 
            // dtg_hoaDon
            // 
            dtg_hoaDon.AllowUserToAddRows = false;
            dtg_hoaDon.BackgroundColor = SystemColors.ControlLight;
            dtg_hoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            dataGridViewCellStyle1.ForeColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Info;
            dataGridViewCellStyle1.SelectionForeColor = Color.Red;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dtg_hoaDon.DefaultCellStyle = dataGridViewCellStyle1;
            dtg_hoaDon.Dock = DockStyle.Fill;
            dtg_hoaDon.Location = new Point(0, 0);
            dtg_hoaDon.MultiSelect = false;
            dtg_hoaDon.Name = "dtg_hoaDon";
            dtg_hoaDon.RowHeadersWidth = 51;
            dtg_hoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_hoaDon.Size = new Size(995, 328);
            dtg_hoaDon.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Controls.Add(dtg_hoaDon);
            panel1.Location = new Point(272, 214);
            panel1.Name = "panel1";
            panel1.Size = new Size(995, 328);
            panel1.TabIndex = 5;
            // 
            // pictureBox_thoat
            // 
            pictureBox_thoat.BorderStyle = BorderStyle.Fixed3D;
            pictureBox_thoat.Image = (Image)resources.GetObject("pictureBox_thoat.Image");
            pictureBox_thoat.Location = new Point(1390, 1);
            pictureBox_thoat.Name = "pictureBox_thoat";
            pictureBox_thoat.Size = new Size(70, 72);
            pictureBox_thoat.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_thoat.TabIndex = 22;
            pictureBox_thoat.TabStop = false;
            toolTip_thoat.SetToolTip(pictureBox_thoat, "Đóng cửa sổ");
            pictureBox_thoat.Click += pictureBox_thoat_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DeepSkyBlue;
            label1.Location = new Point(432, 63);
            label1.Name = "label1";
            label1.Size = new Size(380, 43);
            label1.TabIndex = 21;
            label1.Text = "THÔNG TIN HÓA ĐƠN";
            // 
            // panel_menu
            // 
            panel_menu.BackColor = Color.LightCyan;
            panel_menu.Controls.Add(menuStrip2);
            panel_menu.Location = new Point(583, 555);
            panel_menu.Name = "panel_menu";
            panel_menu.Size = new Size(644, 61);
            panel_menu.TabIndex = 30;
            // 
            // menuStrip2
            // 
            menuStrip2.Dock = DockStyle.Fill;
            menuStrip2.ImageScalingSize = new Size(20, 20);
            menuStrip2.Items.AddRange(new ToolStripItem[] { btn_khoiPhucHoaDon, btn_thungRac, btn_huyHoaDon, btn_Deleted_All });
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(644, 61);
            menuStrip2.TabIndex = 0;
            menuStrip2.Text = "menuStrip2";
            // 
            // btn_khoiPhucHoaDon
            // 
            btn_khoiPhucHoaDon.BackColor = Color.PaleTurquoise;
            btn_khoiPhucHoaDon.Image = (Image)resources.GetObject("btn_khoiPhucHoaDon.Image");
            btn_khoiPhucHoaDon.ImageScaling = ToolStripItemImageScaling.None;
            btn_khoiPhucHoaDon.Name = "btn_khoiPhucHoaDon";
            btn_khoiPhucHoaDon.Size = new Size(184, 57);
            btn_khoiPhucHoaDon.Text = "Khôi Phục Hóa Đơn";
            btn_khoiPhucHoaDon.Click += unDoRepair;
            // 
            // btn_thungRac
            // 
            btn_thungRac.BackColor = Color.Turquoise;
            btn_thungRac.Image = (Image)resources.GetObject("btn_thungRac.Image");
            btn_thungRac.ImageScaling = ToolStripItemImageScaling.None;
            btn_thungRac.Margin = new Padding(10, 0, 10, 0);
            btn_thungRac.Name = "btn_thungRac";
            btn_thungRac.Size = new Size(120, 57);
            btn_thungRac.Text = "Thùng rác";
            btn_thungRac.Click += btn_showRepairIsDeleted_Click;
            // 
            // btn_huyHoaDon
            // 
            btn_huyHoaDon.BackColor = Color.PaleTurquoise;
            btn_huyHoaDon.Image = (Image)resources.GetObject("btn_huyHoaDon.Image");
            btn_huyHoaDon.ImageScaling = ToolStripItemImageScaling.None;
            btn_huyHoaDon.Name = "btn_huyHoaDon";
            btn_huyHoaDon.Size = new Size(143, 57);
            btn_huyHoaDon.Text = "Hủy Thao Tác";
            btn_huyHoaDon.Click += F_HoaDon_Load;
            // 
            // btn_Deleted_All
            // 
            btn_Deleted_All.BackColor = Color.Chocolate;
            btn_Deleted_All.ForeColor = SystemColors.ControlLightLight;
            btn_Deleted_All.Image = (Image)resources.GetObject("btn_Deleted_All.Image");
            btn_Deleted_All.ImageScaling = ToolStripItemImageScaling.None;
            btn_Deleted_All.Margin = new Padding(40, 0, 0, 0);
            btn_Deleted_All.Name = "btn_Deleted_All";
            btn_Deleted_All.Size = new Size(127, 57);
            btn_Deleted_All.Text = "Xóa Tất Cả";
            btn_Deleted_All.Click += btn_Deleted_All_Click;
            // 
            // btn_Them
            // 
            btn_Them.BackColor = Color.PaleTurquoise;
            btn_Them.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            btn_Them.Image = (Image)resources.GetObject("btn_Them.Image");
            btn_Them.ImageScaling = ToolStripItemImageScaling.None;
            btn_Them.Margin = new Padding(40, 0, 0, 0);
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
            btn_XuatFile.Size = new Size(161, 51);
            btn_XuatFile.Text = "Xuất File";
            btn_XuatFile.TextAlign = ContentAlignment.MiddleRight;
            btn_XuatFile.Click += btn_XuatFile_Click_1;
            // 
            // btn_NhapFile
            // 
            btn_NhapFile.BackColor = Color.Azure;
            btn_NhapFile.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            btn_NhapFile.Image = (Image)resources.GetObject("btn_NhapFile.Image");
            btn_NhapFile.ImageScaling = ToolStripItemImageScaling.None;
            btn_NhapFile.Name = "btn_NhapFile";
            btn_NhapFile.Padding = new Padding(5, 5, 40, 5);
            btn_NhapFile.Size = new Size(168, 51);
            btn_NhapFile.Text = "Nhập File";
            btn_NhapFile.TextAlign = ContentAlignment.MiddleRight;
            btn_NhapFile.Click += btn_nhapFile_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(menuStrip1);
            panel5.Location = new Point(95, 141);
            panel5.Name = "panel5";
            panel5.Size = new Size(1122, 55);
            panel5.TabIndex = 63;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.MediumTurquoise;
            menuStrip1.Dock = DockStyle.Fill;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { btn_Them, btn_Sua, btn_Xoa, btn_Huy, btn_XuatFile, btn_NhapFile, btn_inHoaDon });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1122, 55);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // btn_inHoaDon
            // 
            btn_inHoaDon.BackColor = Color.PaleTurquoise;
            btn_inHoaDon.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
            btn_inHoaDon.Image = (Image)resources.GetObject("btn_inHoaDon.Image");
            btn_inHoaDon.ImageScaling = ToolStripItemImageScaling.None;
            btn_inHoaDon.Margin = new Padding(40, 0, 0, 0);
            btn_inHoaDon.Name = "btn_inHoaDon";
            btn_inHoaDon.Size = new Size(135, 51);
            btn_inHoaDon.Text = "In Hóa Đơn";
            btn_inHoaDon.Click += btn_inHoaDon_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.PaleTurquoise;
            panel3.Controls.Add(textBox_SearchByName);
            panel3.Controls.Add(label19);
            panel3.Location = new Point(272, 548);
            panel3.Name = "panel3";
            panel3.Size = new Size(305, 68);
            panel3.TabIndex = 67;
            // 
            // textBox_SearchByName
            // 
            textBox_SearchByName.Location = new Point(9, 34);
            textBox_SearchByName.Name = "textBox_SearchByName";
            textBox_SearchByName.Size = new Size(227, 28);
            textBox_SearchByName.TabIndex = 64;
            textBox_SearchByName.TextChanged += textBox_SearchByName_TextChanged;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(2, 7);
            label19.Name = "label19";
            label19.Size = new Size(292, 20);
            label19.TabIndex = 65;
            label19.Text = "Nhập tên muốn tìm ( tối thiểu 1 ký tự )";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 13F, FontStyle.Bold | FontStyle.Underline);
            label17.Location = new Point(95, 28);
            label17.Name = "label17";
            label17.Size = new Size(102, 30);
            label17.TabIndex = 69;
            label17.Text = "Trợ Giúp";
            label17.Click += pictureBox2_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(14, 11);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(77, 70);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 68;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // groupBox_trangThaiHoaDon
            // 
            groupBox_trangThaiHoaDon.Controls.Add(rdb_dangThanhToan);
            groupBox_trangThaiHoaDon.Controls.Add(rdb_chuaThanhToan);
            groupBox_trangThaiHoaDon.Controls.Add(rdb_daThanhToan);
            groupBox_trangThaiHoaDon.Location = new Point(12, 214);
            groupBox_trangThaiHoaDon.Name = "groupBox_trangThaiHoaDon";
            groupBox_trangThaiHoaDon.Size = new Size(227, 143);
            groupBox_trangThaiHoaDon.TabIndex = 70;
            groupBox_trangThaiHoaDon.TabStop = false;
            groupBox_trangThaiHoaDon.Text = "Sắp xếp theo trạng thái";
            // 
            // rdb_dangThanhToan
            // 
            rdb_dangThanhToan.AutoSize = true;
            rdb_dangThanhToan.Location = new Point(24, 103);
            rdb_dangThanhToan.Name = "rdb_dangThanhToan";
            rdb_dangThanhToan.Size = new Size(149, 24);
            rdb_dangThanhToan.TabIndex = 2;
            rdb_dangThanhToan.TabStop = true;
            rdb_dangThanhToan.Text = "Đang thanh toán";
            rdb_dangThanhToan.UseVisualStyleBackColor = true;
            rdb_dangThanhToan.Click += trangThaiThanhToan;
            rdb_dangThanhToan.MouseEnter += rdb_MouseEnter;
            rdb_dangThanhToan.MouseLeave += rdb_MouseLeave;
            // 
            // rdb_chuaThanhToan
            // 
            rdb_chuaThanhToan.AutoSize = true;
            rdb_chuaThanhToan.Location = new Point(24, 67);
            rdb_chuaThanhToan.Name = "rdb_chuaThanhToan";
            rdb_chuaThanhToan.Size = new Size(150, 24);
            rdb_chuaThanhToan.TabIndex = 1;
            rdb_chuaThanhToan.TabStop = true;
            rdb_chuaThanhToan.Text = "Chưa thanh toán";
            rdb_chuaThanhToan.UseVisualStyleBackColor = true;
            rdb_chuaThanhToan.Click += trangThaiThanhToan;
            rdb_chuaThanhToan.MouseEnter += rdb_MouseEnter;
            rdb_chuaThanhToan.MouseLeave += rdb_MouseLeave;
            // 
            // rdb_daThanhToan
            // 
            rdb_daThanhToan.AutoSize = true;
            rdb_daThanhToan.Location = new Point(24, 32);
            rdb_daThanhToan.Name = "rdb_daThanhToan";
            rdb_daThanhToan.Size = new Size(132, 24);
            rdb_daThanhToan.TabIndex = 0;
            rdb_daThanhToan.TabStop = true;
            rdb_daThanhToan.Text = "Đã thanh toán";
            rdb_daThanhToan.UseVisualStyleBackColor = true;
            rdb_daThanhToan.Click += trangThaiThanhToan;
            rdb_daThanhToan.MouseEnter += rdb_MouseEnter;
            rdb_daThanhToan.MouseLeave += rdb_MouseLeave;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdb_chuynKhoan);
            groupBox1.Controls.Add(rdb_theNganHang);
            groupBox1.Controls.Add(rdb_traGop);
            groupBox1.Controls.Add(rdb_tienMat);
            groupBox1.Location = new Point(14, 366);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(225, 176);
            groupBox1.TabIndex = 71;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sắp xếp theo loại giao dịch";
            // 
            // rdb_chuynKhoan
            // 
            rdb_chuynKhoan.AutoSize = true;
            rdb_chuynKhoan.Location = new Point(22, 103);
            rdb_chuynKhoan.Name = "rdb_chuynKhoan";
            rdb_chuynKhoan.Size = new Size(135, 24);
            rdb_chuynKhoan.TabIndex = 3;
            rdb_chuynKhoan.TabStop = true;
            rdb_chuynKhoan.Text = "Chuyển khoản";
            rdb_chuynKhoan.UseVisualStyleBackColor = true;
            rdb_chuynKhoan.Click += loaiGiaoDich;
            rdb_chuynKhoan.MouseEnter += rdb_MouseEnter;
            rdb_chuynKhoan.MouseLeave += rdb_MouseLeave;
            // 
            // rdb_theNganHang
            // 
            rdb_theNganHang.AutoSize = true;
            rdb_theNganHang.Location = new Point(22, 70);
            rdb_theNganHang.Name = "rdb_theNganHang";
            rdb_theNganHang.Size = new Size(137, 24);
            rdb_theNganHang.TabIndex = 2;
            rdb_theNganHang.TabStop = true;
            rdb_theNganHang.Text = "Thẻ ngân hàng";
            rdb_theNganHang.UseVisualStyleBackColor = true;
            rdb_theNganHang.Click += loaiGiaoDich;
            rdb_theNganHang.MouseEnter += rdb_MouseEnter;
            rdb_theNganHang.MouseLeave += rdb_MouseLeave;
            // 
            // rdb_traGop
            // 
            rdb_traGop.AutoSize = true;
            rdb_traGop.Location = new Point(22, 136);
            rdb_traGop.Name = "rdb_traGop";
            rdb_traGop.Size = new Size(86, 24);
            rdb_traGop.TabIndex = 1;
            rdb_traGop.TabStop = true;
            rdb_traGop.Text = "Trả góp";
            rdb_traGop.UseVisualStyleBackColor = true;
            rdb_traGop.Click += loaiGiaoDich;
            rdb_traGop.MouseEnter += rdb_MouseEnter;
            rdb_traGop.MouseLeave += rdb_MouseLeave;
            // 
            // rdb_tienMat
            // 
            rdb_tienMat.AutoSize = true;
            rdb_tienMat.Location = new Point(22, 40);
            rdb_tienMat.Name = "rdb_tienMat";
            rdb_tienMat.Size = new Size(94, 24);
            rdb_tienMat.TabIndex = 0;
            rdb_tienMat.TabStop = true;
            rdb_tienMat.Text = "Tiền mặt";
            rdb_tienMat.UseVisualStyleBackColor = true;
            rdb_tienMat.Click += loaiGiaoDich;
            rdb_tienMat.MouseEnter += rdb_MouseEnter;
            rdb_tienMat.MouseLeave += rdb_MouseLeave;
            // 
            // pictureBox_reSet_Rdb
            // 
            pictureBox_reSet_Rdb.Image = (Image)resources.GetObject("pictureBox_reSet_Rdb.Image");
            pictureBox_reSet_Rdb.Location = new Point(14, 548);
            pictureBox_reSet_Rdb.Name = "pictureBox_reSet_Rdb";
            pictureBox_reSet_Rdb.Size = new Size(87, 84);
            pictureBox_reSet_Rdb.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_reSet_Rdb.TabIndex = 3;
            pictureBox_reSet_Rdb.TabStop = false;
            pictureBox_reSet_Rdb.Click += F_HoaDon_Load;
            // 
            // F_HoaDon
            // 
            BackColor = Color.Azure;
            ClientSize = new Size(1279, 767);
            ControlBox = false;
            Controls.Add(pictureBox_reSet_Rdb);
            Controls.Add(groupBox1);
            Controls.Add(groupBox_trangThaiHoaDon);
            Controls.Add(label17);
            Controls.Add(pictureBox2);
            Controls.Add(panel3);
            Controls.Add(panel5);
            Controls.Add(panel_menu);
            Controls.Add(pictureBox_thoat);
            Controls.Add(label1);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            ForeColor = SystemColors.ActiveCaptionText;
            MainMenuStrip = menuStrip2;
            Name = "F_HoaDon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hóa Đơn";
            Load += F_HoaDon_Load;
            ((System.ComponentModel.ISupportInitialize)dtg_hoaDon).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_thoat).EndInit();
            panel_menu.ResumeLayout(false);
            panel_menu.PerformLayout();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox_trangThaiHoaDon.ResumeLayout(false);
            groupBox_trangThaiHoaDon.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_reSet_Rdb).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void btn_xuatFile_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private DataGridView dtg_hoaDon;
        private Panel panel1;
        private GroupBox groupBox3;
        private Label label1;
        private PictureBox pictureBox_thoat;
        private ToolTip toolTip_thoat;
        private Panel panel_menu;
        private ToolStripMenuItem btn_Them;
        private ToolStripMenuItem btn_Sua;
        private ToolStripMenuItem btn_Xoa;
        private ToolStripMenuItem btn_Huy;
        private ToolStripMenuItem btn_XuatFile;
        private ToolStripMenuItem btn_NhapFile;
        private Panel panel5;
        private MenuStrip menuStrip1;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem btn_khoiPhucHoaDon;
        private ToolStripMenuItem btn_thungRac;
        private ToolStripMenuItem btn_huyHoaDon;
        private ToolStripMenuItem btn_inHoaDon;
        private ToolStripMenuItem btn_Deleted_All;
        private Panel panel3;
        private TextBox textBox_SearchByName;
        private Label label19;
        private Label label17;
        private PictureBox pictureBox2;
        private GroupBox groupBox_trangThaiHoaDon;
        private RadioButton rdb_dangThanhToan;
        private RadioButton rdb_chuaThanhToan;
        private RadioButton rdb_daThanhToan;
        private GroupBox groupBox1;
        private RadioButton rdb_chuynKhoan;
        private RadioButton rdb_theNganHang;
        private RadioButton rdb_traGop;
        private RadioButton rdb_tienMat;
        private PictureBox pictureBox_reSet_Rdb;
    }
}