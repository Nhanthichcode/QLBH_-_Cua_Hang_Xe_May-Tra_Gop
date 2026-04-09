namespace DoAnBanHang_cuahangxemay.Forms
{
    partial class F_SanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_SanPham));
            panel1 = new Panel();
            dtg_sanPham = new DataGridView();
            groupBox2 = new GroupBox();
            cbb_trangThaiSanPham = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            num_soLuongTon = new NumericUpDown();
            num_giaBan = new NumericUpDown();
            txt_mota = new TextBox();
            txt_tenSP = new TextBox();
            dtpic_namSX = new DateTimePicker();
            cbb_hangsx = new ComboBox();
            pic_hinhAnhSanPham = new PictureBox();
            panel2 = new Panel();
            label8 = new Label();
            panel3 = new Panel();
            menuStrip1 = new MenuStrip();
            btn_Luu = new ToolStripMenuItem();
            btn_Them = new ToolStripMenuItem();
            btn_Sua = new ToolStripMenuItem();
            btn_Xoa = new ToolStripMenuItem();
            btn_Huybo = new ToolStripMenuItem();
            btn_XuatFile = new ToolStripMenuItem();
            btn_NhapFile = new ToolStripMenuItem();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            btn_luulaii = new ToolStripMenuItem();
            panel4 = new Panel();
            menuStrip2 = new MenuStrip();
            btn_ChonAnh = new ToolStripMenuItem();
            btn_DoiAnh = new ToolStripMenuItem();
            label17 = new Label();
            pictureBox2 = new PictureBox();
            textBox_searchByName = new TextBox();
            textBox_searchByHSX = new TextBox();
            label9 = new Label();
            label10 = new Label();
            groupBox3 = new GroupBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtg_sanPham).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_soLuongTon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_giaBan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic_hinhAnhSanPham).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel4.SuspendLayout();
            menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dtg_sanPham);
            panel1.Location = new Point(119, 492);
            panel1.Name = "panel1";
            panel1.Size = new Size(1158, 219);
            panel1.TabIndex = 0;
            // 
            // dtg_sanPham
            // 
            dtg_sanPham.AllowUserToAddRows = false;
            dtg_sanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_sanPham.BackgroundColor = SystemColors.ControlLight;
            dtg_sanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_sanPham.Dock = DockStyle.Fill;
            dtg_sanPham.GridColor = SystemColors.ScrollBar;
            dtg_sanPham.Location = new Point(0, 0);
            dtg_sanPham.MultiSelect = false;
            dtg_sanPham.Name = "dtg_sanPham";
            dtg_sanPham.ReadOnly = true;
            dtg_sanPham.RowHeadersWidth = 51;
            dtg_sanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_sanPham.Size = new Size(1158, 219);
            dtg_sanPham.TabIndex = 0;
            dtg_sanPham.CellClick += dtg_sanPham_CellClick;
            dtg_sanPham.SelectionChanged += dtg_sanPham_SelectionChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cbb_trangThaiSanPham);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(num_soLuongTon);
            groupBox2.Controls.Add(num_giaBan);
            groupBox2.Controls.Add(txt_mota);
            groupBox2.Controls.Add(txt_tenSP);
            groupBox2.Controls.Add(dtpic_namSX);
            groupBox2.Controls.Add(cbb_hangsx);
            groupBox2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            groupBox2.Location = new Point(119, 127);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(657, 261);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin Sản Phẩm";
            // 
            // cbb_trangThaiSanPham
            // 
            cbb_trangThaiSanPham.FormattingEnabled = true;
            cbb_trangThaiSanPham.Location = new Point(112, 97);
            cbb_trangThaiSanPham.Name = "cbb_trangThaiSanPham";
            cbb_trangThaiSanPham.Size = new Size(223, 33);
            cbb_trangThaiSanPham.TabIndex = 70;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 145);
            label7.Name = "label7";
            label7.Size = new Size(85, 25);
            label7.TabIndex = 14;
            label7.Text = "Số lượng";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(261, 145);
            label6.Name = "label6";
            label6.Size = new Size(75, 25);
            label6.TabIndex = 13;
            label6.Text = "Đơn giá";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(369, 96);
            label5.Name = "label5";
            label5.Size = new Size(76, 25);
            label5.TabIndex = 12;
            label5.Text = "Năm SX";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 99);
            label4.Name = "label4";
            label4.Size = new Size(92, 25);
            label4.TabIndex = 11;
            label4.Text = "Tình trạng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 195);
            label3.Name = "label3";
            label3.Size = new Size(59, 25);
            label3.TabIndex = 10;
            label3.Text = "Mô tả";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(369, 45);
            label2.Name = "label2";
            label2.Size = new Size(81, 25);
            label2.TabIndex = 9;
            label2.Text = "Hãng SX";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 49);
            label1.Name = "label1";
            label1.Size = new Size(60, 25);
            label1.TabIndex = 8;
            label1.Text = "Tên xe";
            // 
            // num_soLuongTon
            // 
            num_soLuongTon.Location = new Point(112, 143);
            num_soLuongTon.Name = "num_soLuongTon";
            num_soLuongTon.Size = new Size(109, 31);
            num_soLuongTon.TabIndex = 7;
            num_soLuongTon.TextAlign = HorizontalAlignment.Right;
            // 
            // num_giaBan
            // 
            num_giaBan.DecimalPlaces = 3;
            num_giaBan.Increment = new decimal(new int[] { 100000, 0, 0, 0 });
            num_giaBan.Location = new Point(341, 143);
            num_giaBan.Maximum = new decimal(new int[] { 1661992959, 1808227885, 5, 0 });
            num_giaBan.Name = "num_giaBan";
            num_giaBan.Size = new Size(287, 31);
            num_giaBan.TabIndex = 5;
            num_giaBan.TextAlign = HorizontalAlignment.Right;
            // 
            // txt_mota
            // 
            txt_mota.Location = new Point(112, 192);
            txt_mota.Name = "txt_mota";
            txt_mota.Size = new Size(516, 31);
            txt_mota.TabIndex = 3;
            // 
            // txt_tenSP
            // 
            txt_tenSP.Location = new Point(112, 43);
            txt_tenSP.Name = "txt_tenSP";
            txt_tenSP.Size = new Size(223, 31);
            txt_tenSP.TabIndex = 2;
            // 
            // dtpic_namSX
            // 
            dtpic_namSX.Format = DateTimePickerFormat.Custom;
            dtpic_namSX.Location = new Point(456, 91);
            dtpic_namSX.Name = "dtpic_namSX";
            dtpic_namSX.Size = new Size(172, 31);
            dtpic_namSX.TabIndex = 1;
            // 
            // cbb_hangsx
            // 
            cbb_hangsx.FormattingEnabled = true;
            cbb_hangsx.Location = new Point(456, 43);
            cbb_hangsx.Name = "cbb_hangsx";
            cbb_hangsx.Size = new Size(172, 33);
            cbb_hangsx.TabIndex = 0;
            // 
            // pic_hinhAnhSanPham
            // 
            pic_hinhAnhSanPham.BorderStyle = BorderStyle.FixedSingle;
            pic_hinhAnhSanPham.Dock = DockStyle.Fill;
            pic_hinhAnhSanPham.Location = new Point(0, 0);
            pic_hinhAnhSanPham.Name = "pic_hinhAnhSanPham";
            pic_hinhAnhSanPham.Size = new Size(219, 243);
            pic_hinhAnhSanPham.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_hinhAnhSanPham.TabIndex = 7;
            pic_hinhAnhSanPham.TabStop = false;
            pic_hinhAnhSanPham.DragDrop += pic_hinhAnhSanPham_DragDrop;
            pic_hinhAnhSanPham.DragEnter += pic_hinhAnhSanPham_DragEnter;
            // 
            // panel2
            // 
            panel2.Controls.Add(pic_hinhAnhSanPham);
            panel2.Location = new Point(814, 141);
            panel2.Name = "panel2";
            panel2.Size = new Size(219, 243);
            panel2.TabIndex = 8;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Showcard Gothic", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.DeepSkyBlue;
            label8.Location = new Point(586, 43);
            label8.Name = "label8";
            label8.Size = new Size(212, 46);
            label8.TabIndex = 10;
            label8.Text = "SẢN PHẨM";
            // 
            // panel3
            // 
            panel3.Controls.Add(menuStrip1);
            panel3.Location = new Point(163, 421);
            panel3.Name = "panel3";
            panel3.Size = new Size(1073, 55);
            panel3.TabIndex = 60;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.MediumTurquoise;
            menuStrip1.Dock = DockStyle.Fill;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { btn_Luu, btn_Them, btn_Sua, btn_Xoa, btn_Huybo, btn_XuatFile, btn_NhapFile });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 3, 0, 3);
            menuStrip1.Size = new Size(1073, 55);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // btn_Luu
            // 
            btn_Luu.BackColor = Color.Azure;
            btn_Luu.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            btn_Luu.Image = (Image)resources.GetObject("btn_Luu.Image");
            btn_Luu.ImageScaling = ToolStripItemImageScaling.None;
            btn_Luu.Margin = new Padding(30, 0, 0, 0);
            btn_Luu.Name = "btn_Luu";
            btn_Luu.Padding = new Padding(5, 0, 40, 0);
            btn_Luu.Size = new Size(150, 49);
            btn_Luu.Text = "Lưu Lại";
            btn_Luu.TextAlign = ContentAlignment.MiddleRight;
            btn_Luu.Click += btn_luulai_Click;
            // 
            // btn_Them
            // 
            btn_Them.BackColor = Color.PaleTurquoise;
            btn_Them.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            btn_Them.Image = (Image)resources.GetObject("btn_Them.Image");
            btn_Them.ImageScaling = ToolStripItemImageScaling.None;
            btn_Them.Name = "btn_Them";
            btn_Them.Padding = new Padding(5, 0, 40, 0);
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
            btn_Sua.Padding = new Padding(5, 0, 40, 0);
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
            btn_Xoa.Padding = new Padding(5, 0, 40, 0);
            btn_Xoa.Size = new Size(122, 49);
            btn_Xoa.Text = "Xóa";
            btn_Xoa.TextAlign = ContentAlignment.MiddleRight;
            btn_Xoa.Click += btn_xoa_Click;
            // 
            // btn_Huybo
            // 
            btn_Huybo.BackColor = Color.Azure;
            btn_Huybo.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            btn_Huybo.Image = (Image)resources.GetObject("btn_Huybo.Image");
            btn_Huybo.ImageScaling = ToolStripItemImageScaling.None;
            btn_Huybo.Name = "btn_Huybo";
            btn_Huybo.Padding = new Padding(5, 0, 40, 0);
            btn_Huybo.Size = new Size(148, 49);
            btn_Huybo.Text = "Hủy bỏ";
            btn_Huybo.TextAlign = ContentAlignment.MiddleRight;
            btn_Huybo.Click += btn_huy_Click;
            // 
            // btn_XuatFile
            // 
            btn_XuatFile.BackColor = Color.PaleTurquoise;
            btn_XuatFile.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            btn_XuatFile.Image = (Image)resources.GetObject("btn_XuatFile.Image");
            btn_XuatFile.ImageScaling = ToolStripItemImageScaling.None;
            btn_XuatFile.Name = "btn_XuatFile";
            btn_XuatFile.Padding = new Padding(5, 0, 40, 0);
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
            btn_NhapFile.Padding = new Padding(5, 0, 40, 0);
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
            // btn_luulaii
            // 
            btn_luulaii.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic);
            btn_luulaii.Image = (Image)resources.GetObject("btn_luulaii.Image");
            btn_luulaii.ImageScaling = ToolStripItemImageScaling.None;
            btn_luulaii.Name = "btn_luulaii";
            btn_luulaii.Padding = new Padding(50, 0, 5, 0);
            btn_luulaii.Size = new Size(153, 51);
            btn_luulaii.Text = "Lưu Lại";
            // 
            // panel4
            // 
            panel4.Controls.Add(menuStrip2);
            panel4.Location = new Point(1040, 141);
            panel4.Name = "panel4";
            panel4.Size = new Size(176, 247);
            panel4.TabIndex = 61;
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
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 13F, FontStyle.Bold | FontStyle.Underline);
            label17.Location = new Point(91, 24);
            label17.Name = "label17";
            label17.Size = new Size(102, 30);
            label17.TabIndex = 63;
            label17.Text = "Trợ Giúp";
            label17.Click += pictureBox2_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(10, 7);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(77, 69);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 62;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // textBox_searchByName
            // 
            textBox_searchByName.Location = new Point(155, 27);
            textBox_searchByName.Name = "textBox_searchByName";
            textBox_searchByName.Size = new Size(125, 27);
            textBox_searchByName.TabIndex = 64;
            textBox_searchByName.TextChanged += textBox_searchByName_TextChanged;
            // 
            // textBox_searchByHSX
            // 
            textBox_searchByHSX.Location = new Point(155, 65);
            textBox_searchByHSX.Name = "textBox_searchByHSX";
            textBox_searchByHSX.Size = new Size(125, 27);
            textBox_searchByHSX.TabIndex = 65;
            textBox_searchByHSX.TextChanged += textBox_searchByHSX_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(19, 29);
            label9.Name = "label9";
            label9.Size = new Size(103, 20);
            label9.TabIndex = 66;
            label9.Text = "Tên sản phẩm:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(19, 68);
            label10.Name = "label10";
            label10.Size = new Size(130, 20);
            label10.TabIndex = 67;
            label10.Text = "Tên hảng sản xuất:";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.LightCyan;
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(textBox_searchByHSX);
            groupBox3.Controls.Add(textBox_searchByName);
            groupBox3.Location = new Point(978, 17);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(299, 109);
            groupBox3.TabIndex = 69;
            groupBox3.TabStop = false;
            groupBox3.Text = "Tìm kiếm";
            // 
            // F_SanPham
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(1326, 767);
            ControlBox = false;
            Controls.Add(groupBox3);
            Controls.Add(label17);
            Controls.Add(pictureBox2);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(label8);
            Controls.Add(panel2);
            Controls.Add(groupBox2);
            Controls.Add(panel1);
            MainMenuStrip = menuStrip2;
            Name = "F_SanPham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sản Phẩm";
            Load += F_SanPham_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtg_sanPham).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num_soLuongTon).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_giaBan).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_hinhAnhSanPham).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DataGridView dtg_sanPham;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private NumericUpDown num_giaBan;
        private TextBox txt_mota;
        private TextBox txt_tenSP;
        private DateTimePicker dtpic_namSX;
        private ComboBox cbb_hangsx;
        private PictureBox pic_hinhAnhSanPham;
        private Panel panel2;
        private Button btn_nhapFile;
        private Button btn_xuatFile;
        private Button btn_huy;
        private Button btn_luulai;
        private Button btn_xoa;
        private Button btn_sua;
        private Button btn_them;
        private NumericUpDown num_soLuongTon;
        private Button btn_doiAnh;
        private Button btn_chonAnh;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label8;
        private Label label7;
        private PictureBox pictureBox6;
        private Panel panel3;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem thêmToolStripMenuItem;
        private ToolStripMenuItem sửaToolStripMenuItem;
        private ToolStripMenuItem xóaToolStripMenuItem;
        private ToolStripMenuItem hủyBỏToolStripMenuItem;
        private ToolStripMenuItem xuấtFileToolStripMenuItem;
        private ToolStripMenuItem nhậpFileToolStripMenuItem;
        private ToolStripMenuItem btn_luulaii;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private ToolStripMenuItem btn_Luu;
        private ToolStripMenuItem btn_Them;
        private ToolStripMenuItem btn_Sua;
        private ToolStripMenuItem btn_Xoa;
        private ToolStripMenuItem btn_Huybo;
        private ToolStripMenuItem btn_XuatFile;
        private ToolStripMenuItem btn_NhapFile;
        private Panel panel4;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem btn_ChonAnh;
        private ToolStripMenuItem btn_DoiAnh;
        private Label label17;
        private PictureBox pictureBox2;
        private TextBox textBox_searchByName;
        private TextBox textBox_searchByHSX;
        private Label label9;
        private Label label10;
        private GroupBox groupBox3;
        private ComboBox cbb_trangThaiSanPham;
    }
}