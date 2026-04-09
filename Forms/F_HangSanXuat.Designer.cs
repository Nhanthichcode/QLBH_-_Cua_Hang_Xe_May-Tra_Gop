namespace DoAnBanHang_cuahangxemay.Forms
{
    partial class F_HangSanXuat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_HangSanXuat));
            panel1 = new Panel();
            dtg_HangSanXuat = new DataGridView();
            groupBox2 = new GroupBox();
            cbb_trangThai = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            txt_tenhangsanxuat = new TextBox();
            label1 = new Label();
            pictureBox_troVe = new PictureBox();
            panel5 = new Panel();
            menuStrip1 = new MenuStrip();
            btn_Luulai = new ToolStripMenuItem();
            btn_Them = new ToolStripMenuItem();
            btn_Sua = new ToolStripMenuItem();
            btn_Xoa = new ToolStripMenuItem();
            btn_Huy = new ToolStripMenuItem();
            btn_XuatFile = new ToolStripMenuItem();
            btn_NhapFile = new ToolStripMenuItem();
            label17 = new Label();
            pictureBox2 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtg_HangSanXuat).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_troVe).BeginInit();
            panel5.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dtg_HangSanXuat);
            panel1.Location = new Point(148, 99);
            panel1.Name = "panel1";
            panel1.Size = new Size(463, 420);
            panel1.TabIndex = 0;
            // 
            // dtg_HangSanXuat
            // 
            dtg_HangSanXuat.AllowUserToAddRows = false;
            dtg_HangSanXuat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_HangSanXuat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_HangSanXuat.Dock = DockStyle.Fill;
            dtg_HangSanXuat.Location = new Point(0, 0);
            dtg_HangSanXuat.MultiSelect = false;
            dtg_HangSanXuat.Name = "dtg_HangSanXuat";
            dtg_HangSanXuat.ReadOnly = true;
            dtg_HangSanXuat.RowHeadersWidth = 51;
            dtg_HangSanXuat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_HangSanXuat.Size = new Size(463, 420);
            dtg_HangSanXuat.TabIndex = 0;
            dtg_HangSanXuat.CellClick += dtg_HangSanXuat_CellClick_1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cbb_trangThai);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txt_tenhangsanxuat);
            groupBox2.Location = new Point(647, 396);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(372, 123);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin";
            // 
            // cbb_trangThai
            // 
            cbb_trangThai.FormattingEnabled = true;
            cbb_trangThai.Location = new Point(145, 75);
            cbb_trangThai.Name = "cbb_trangThai";
            cbb_trangThai.Size = new Size(200, 28);
            cbb_trangThai.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 78);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 4;
            label2.Text = "Trạng thái";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 42);
            label3.Name = "label3";
            label3.Size = new Size(127, 20);
            label3.TabIndex = 5;
            label3.Text = "Tên hảng sản xuất";
            // 
            // txt_tenhangsanxuat
            // 
            txt_tenhangsanxuat.Location = new Point(145, 35);
            txt_tenhangsanxuat.Name = "txt_tenhangsanxuat";
            txt_tenhangsanxuat.Size = new Size(200, 27);
            txt_tenhangsanxuat.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DeepSkyBlue;
            label1.Location = new Point(592, 26);
            label1.Name = "label1";
            label1.Size = new Size(303, 43);
            label1.TabIndex = 3;
            label1.Text = "HẢNG SẢN XUẤT";
            // 
            // pictureBox_troVe
            // 
            pictureBox_troVe.BorderStyle = BorderStyle.Fixed3D;
            pictureBox_troVe.Image = (Image)resources.GetObject("pictureBox_troVe.Image");
            pictureBox_troVe.Location = new Point(1337, 1);
            pictureBox_troVe.Name = "pictureBox_troVe";
            pictureBox_troVe.Size = new Size(81, 68);
            pictureBox_troVe.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_troVe.TabIndex = 12;
            pictureBox_troVe.TabStop = false;
            pictureBox_troVe.Click += pictureBox_troVe_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(menuStrip1);
            panel5.Location = new Point(148, 569);
            panel5.Name = "panel5";
            panel5.Size = new Size(1073, 55);
            panel5.TabIndex = 64;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.MediumTurquoise;
            menuStrip1.Dock = DockStyle.Fill;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { btn_Luulai, btn_Them, btn_Sua, btn_Xoa, btn_Huy, btn_XuatFile, btn_NhapFile });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1073, 55);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
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
            btn_Luulai.Click += btn_luulai_Click;
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
            btn_Them.Click += btn_Them_Click;
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
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 13F, FontStyle.Bold | FontStyle.Underline);
            label17.Location = new Point(94, 28);
            label17.Name = "label17";
            label17.Size = new Size(102, 30);
            label17.TabIndex = 66;
            label17.Text = "Trợ Giúp";
            label17.Click += pictureBox2_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(13, 11);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(77, 70);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 65;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // F_HangSanXuat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(1420, 744);
            ControlBox = false;
            Controls.Add(label17);
            Controls.Add(pictureBox2);
            Controls.Add(panel5);
            Controls.Add(pictureBox_troVe);
            Controls.Add(label1);
            Controls.Add(groupBox2);
            Controls.Add(panel1);
            Name = "F_HangSanXuat";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hảng Sản Xuất";
            TransparencyKey = SystemColors.Window;
            Load += F_HangSanXuat_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtg_HangSanXuat).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_troVe).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DataGridView dtg_HangSanXuat;
        private GroupBox groupBox2;
        private TextBox txt_tenhangsanxuat;
        private Label label2;
        private Label label3;
        private Label label1;
        private PictureBox pictureBox_troVe;
        private ComboBox cbb_trangThai;
        private Panel panel5;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem btn_Luulai;
        private ToolStripMenuItem btn_Them;
        private ToolStripMenuItem btn_Sua;
        private ToolStripMenuItem btn_Xoa;
        private ToolStripMenuItem btn_Huy;
        private ToolStripMenuItem btn_XuatFile;
        private ToolStripMenuItem btn_NhapFile;
        private Label label17;
        private PictureBox pictureBox2;
    }
}