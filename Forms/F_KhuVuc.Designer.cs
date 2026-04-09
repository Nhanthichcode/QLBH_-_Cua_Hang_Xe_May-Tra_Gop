namespace DoAnBanHang_cuahangxemay.Forms
{
    partial class F_KhuVuc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_KhuVuc));
            dtg_khuVuc = new DataGridView();
            panel1 = new Panel();
            txt_tenKhuVuc = new TextBox();
            label17 = new Label();
            pictureBox2 = new PictureBox();
            panel5 = new Panel();
            menuStrip1 = new MenuStrip();
            btn_Luulai = new ToolStripMenuItem();
            btn_Them = new ToolStripMenuItem();
            btn_Sua = new ToolStripMenuItem();
            btn_Xoa = new ToolStripMenuItem();
            btn_Huy = new ToolStripMenuItem();
            btn_XuatFile = new ToolStripMenuItem();
            btn_NhapFile = new ToolStripMenuItem();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dtg_khuVuc).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel5.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dtg_khuVuc
            // 
            dtg_khuVuc.AllowUserToAddRows = false;
            dtg_khuVuc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_khuVuc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_khuVuc.Dock = DockStyle.Fill;
            dtg_khuVuc.Location = new Point(0, 0);
            dtg_khuVuc.MultiSelect = false;
            dtg_khuVuc.Name = "dtg_khuVuc";
            dtg_khuVuc.ReadOnly = true;
            dtg_khuVuc.RowHeadersWidth = 51;
            dtg_khuVuc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_khuVuc.Size = new Size(453, 468);
            dtg_khuVuc.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(dtg_khuVuc);
            panel1.Location = new Point(256, 216);
            panel1.Name = "panel1";
            panel1.Size = new Size(453, 468);
            panel1.TabIndex = 6;
            // 
            // txt_tenKhuVuc
            // 
            txt_tenKhuVuc.Location = new Point(256, 179);
            txt_tenKhuVuc.Name = "txt_tenKhuVuc";
            txt_tenKhuVuc.Size = new Size(453, 27);
            txt_tenKhuVuc.TabIndex = 7;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 13F, FontStyle.Bold | FontStyle.Underline);
            label17.Location = new Point(93, 29);
            label17.Name = "label17";
            label17.Size = new Size(102, 30);
            label17.TabIndex = 70;
            label17.Text = "Trợ Giúp";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(12, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(77, 70);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 69;
            pictureBox2.TabStop = false;
            // 
            // panel5
            // 
            panel5.Controls.Add(menuStrip1);
            panel5.Location = new Point(798, 156);
            panel5.Name = "panel5";
            panel5.Size = new Size(205, 573);
            panel5.TabIndex = 68;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.MediumTurquoise;
            menuStrip1.Dock = DockStyle.Right;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { btn_Luulai, btn_Them, btn_Sua, btn_Xoa, btn_Huy, btn_XuatFile, btn_NhapFile });
            menuStrip1.Location = new Point(1, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(204, 573);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // btn_Luulai
            // 
            btn_Luulai.BackColor = Color.Azure;
            btn_Luulai.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            btn_Luulai.Image = (Image)resources.GetObject("btn_Luulai.Image");
            btn_Luulai.ImageScaling = ToolStripItemImageScaling.None;
            btn_Luulai.Margin = new Padding(15);
            btn_Luulai.Name = "btn_Luulai";
            btn_Luulai.Padding = new Padding(5, 5, 40, 10);
            btn_Luulai.Size = new Size(161, 51);
            btn_Luulai.Text = "Lưu Lại";
            btn_Luulai.TextAlign = ContentAlignment.MiddleRight;
            btn_Luulai.Click += btn_Luulai_Click_1;
            // 
            // btn_Them
            // 
            btn_Them.BackColor = Color.PaleTurquoise;
            btn_Them.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            btn_Them.Image = (Image)resources.GetObject("btn_Them.Image");
            btn_Them.ImageScaling = ToolStripItemImageScaling.None;
            btn_Them.Margin = new Padding(15);
            btn_Them.Name = "btn_Them";
            btn_Them.Padding = new Padding(5, 5, 40, 10);
            btn_Them.Size = new Size(161, 51);
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
            btn_Sua.Margin = new Padding(15);
            btn_Sua.Name = "btn_Sua";
            btn_Sua.Padding = new Padding(5, 5, 40, 10);
            btn_Sua.Size = new Size(161, 51);
            btn_Sua.Text = "Sửa";
            btn_Sua.TextAlign = ContentAlignment.MiddleRight;
            btn_Sua.Click += btn_Sua_Click;
            // 
            // btn_Xoa
            // 
            btn_Xoa.BackColor = Color.PaleTurquoise;
            btn_Xoa.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            btn_Xoa.Image = (Image)resources.GetObject("btn_Xoa.Image");
            btn_Xoa.ImageScaling = ToolStripItemImageScaling.None;
            btn_Xoa.Margin = new Padding(15);
            btn_Xoa.Name = "btn_Xoa";
            btn_Xoa.Padding = new Padding(5, 5, 40, 10);
            btn_Xoa.Size = new Size(161, 51);
            btn_Xoa.Text = "Xóa";
            btn_Xoa.TextAlign = ContentAlignment.MiddleRight;
            btn_Xoa.Click += btn_Xoa_Click;
            // 
            // btn_Huy
            // 
            btn_Huy.BackColor = Color.Azure;
            btn_Huy.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            btn_Huy.Image = (Image)resources.GetObject("btn_Huy.Image");
            btn_Huy.ImageScaling = ToolStripItemImageScaling.None;
            btn_Huy.Margin = new Padding(15);
            btn_Huy.Name = "btn_Huy";
            btn_Huy.Padding = new Padding(5, 5, 40, 10);
            btn_Huy.Size = new Size(161, 51);
            btn_Huy.Text = "Hủy bỏ";
            btn_Huy.TextAlign = ContentAlignment.MiddleRight;
            btn_Huy.Click += btn_Huy_Click;
            // 
            // btn_XuatFile
            // 
            btn_XuatFile.BackColor = Color.PaleTurquoise;
            btn_XuatFile.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            btn_XuatFile.Image = (Image)resources.GetObject("btn_XuatFile.Image");
            btn_XuatFile.ImageScaling = ToolStripItemImageScaling.None;
            btn_XuatFile.Margin = new Padding(15);
            btn_XuatFile.Name = "btn_XuatFile";
            btn_XuatFile.Padding = new Padding(5, 5, 40, 10);
            btn_XuatFile.Size = new Size(161, 51);
            btn_XuatFile.Text = "Xuất File";
            btn_XuatFile.TextAlign = ContentAlignment.MiddleRight;
            btn_XuatFile.Click += btn_XuatFile_Click;
            // 
            // btn_NhapFile
            // 
            btn_NhapFile.BackColor = Color.Azure;
            btn_NhapFile.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            btn_NhapFile.Image = (Image)resources.GetObject("btn_NhapFile.Image");
            btn_NhapFile.ImageScaling = ToolStripItemImageScaling.None;
            btn_NhapFile.Margin = new Padding(15);
            btn_NhapFile.Name = "btn_NhapFile";
            btn_NhapFile.Padding = new Padding(5, 5, 40, 10);
            btn_NhapFile.Size = new Size(161, 51);
            btn_NhapFile.Text = "Nhập File";
            btn_NhapFile.TextAlign = ContentAlignment.MiddleRight;
            btn_NhapFile.Click += btn_NhapFile_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DeepSkyBlue;
            label1.Location = new Point(517, 29);
            label1.Name = "label1";
            label1.Size = new Size(337, 43);
            label1.TabIndex = 67;
            label1.Text = "QUẢN LÝ KHU VỰC";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(256, 156);
            label2.Name = "label2";
            label2.Size = new Size(126, 20);
            label2.TabIndex = 71;
            label2.Text = "Thông tin khu vực";
            // 
            // F_KhuVuc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(1280, 741);
            Controls.Add(label2);
            Controls.Add(label17);
            Controls.Add(pictureBox2);
            Controls.Add(panel5);
            Controls.Add(label1);
            Controls.Add(txt_tenKhuVuc);
            Controls.Add(panel1);
            Name = "F_KhuVuc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Khu Vực Quản Lý";
            Load += F_KhuVuc_Load;
            ((System.ComponentModel.ISupportInitialize)dtg_khuVuc).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtg_khuVuc;
        private Panel panel1;
        private TextBox txt_tenKhuVuc;
        private Label label17;
        private PictureBox pictureBox2;
        private Panel panel5;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem btn_Luulai;
        private ToolStripMenuItem btn_Them;
        private ToolStripMenuItem btn_Sua;
        private ToolStripMenuItem btn_Xoa;
        private ToolStripMenuItem btn_Huy;
        private ToolStripMenuItem btn_XuatFile;
        private ToolStripMenuItem btn_NhapFile;
        private Label label1;
        private Label label2;
    }
}