namespace DoAnBanHang_cuahangxemay.Reports
{
    partial class Form_Report_thongKeSanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Report_thongKeSanPham));
            panel_heaDer = new Panel();
            label2 = new Label();
            label1 = new Label();
            pic_logout = new PictureBox();
            btn_showAll = new Button();
            btn_showSelected = new Button();
            cbb_tenSanPham = new ComboBox();
            cbb_hangSanXuat = new ComboBox();
            panel_boDy = new Panel();
            panel_heaDer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_logout).BeginInit();
            SuspendLayout();
            // 
            // panel_heaDer
            // 
            panel_heaDer.Controls.Add(label2);
            panel_heaDer.Controls.Add(label1);
            panel_heaDer.Controls.Add(pic_logout);
            panel_heaDer.Controls.Add(btn_showAll);
            panel_heaDer.Controls.Add(btn_showSelected);
            panel_heaDer.Controls.Add(cbb_tenSanPham);
            panel_heaDer.Controls.Add(cbb_hangSanXuat);
            panel_heaDer.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            panel_heaDer.Location = new Point(1, 1);
            panel_heaDer.Name = "panel_heaDer";
            panel_heaDer.Size = new Size(1458, 64);
            panel_heaDer.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            label2.Location = new Point(444, 22);
            label2.Name = "label2";
            label2.Size = new Size(129, 23);
            label2.TabIndex = 6;
            label2.Text = "Hãng Sản Xuất";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            label1.Location = new Point(21, 22);
            label1.Name = "label1";
            label1.Size = new Size(124, 23);
            label1.TabIndex = 5;
            label1.Text = "Tên Sản Phẩm";
            // 
            // pic_logout
            // 
            pic_logout.Image = (Image)resources.GetObject("pic_logout.Image");
            pic_logout.Location = new Point(1394, 0);
            pic_logout.Name = "pic_logout";
            pic_logout.Size = new Size(61, 64);
            pic_logout.SizeMode = PictureBoxSizeMode.Zoom;
            pic_logout.TabIndex = 4;
            pic_logout.TabStop = false;
            pic_logout.Click += pic_logout_Click;
            // 
            // btn_showAll
            // 
            btn_showAll.BackColor = Color.Turquoise;
            btn_showAll.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btn_showAll.Location = new Point(1062, 8);
            btn_showAll.Name = "btn_showAll";
            btn_showAll.Size = new Size(128, 51);
            btn_showAll.TabIndex = 2;
            btn_showAll.Text = "Hiện tất cả";
            btn_showAll.UseVisualStyleBackColor = false;
            btn_showAll.Click += btn_showAll_Click;
            // 
            // btn_showSelected
            // 
            btn_showSelected.BackColor = Color.PaleTurquoise;
            btn_showSelected.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btn_showSelected.Location = new Point(854, 8);
            btn_showSelected.Name = "btn_showSelected";
            btn_showSelected.Size = new Size(115, 51);
            btn_showSelected.TabIndex = 3;
            btn_showSelected.Text = "Xem";
            btn_showSelected.UseVisualStyleBackColor = false;
            btn_showSelected.Click += btn_showSelected_Click;
            // 
            // cbb_tenSanPham
            // 
            cbb_tenSanPham.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            cbb_tenSanPham.FormattingEnabled = true;
            cbb_tenSanPham.Location = new Point(151, 19);
            cbb_tenSanPham.Name = "cbb_tenSanPham";
            cbb_tenSanPham.Size = new Size(254, 31);
            cbb_tenSanPham.TabIndex = 1;
            cbb_tenSanPham.SelectionChangeCommitted += cbb_tenSanPham_SelectionChangeCommitted;
            // 
            // cbb_hangSanXuat
            // 
            cbb_hangSanXuat.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic);
            cbb_hangSanXuat.FormattingEnabled = true;
            cbb_hangSanXuat.Location = new Point(579, 19);
            cbb_hangSanXuat.Name = "cbb_hangSanXuat";
            cbb_hangSanXuat.Size = new Size(253, 31);
            cbb_hangSanXuat.TabIndex = 0;
            cbb_hangSanXuat.SelectionChangeCommitted += cbb_hangSanXuat_SelectionChangeCommitted;
            // 
            // panel_boDy
            // 
            panel_boDy.Location = new Point(2, 71);
            panel_boDy.Name = "panel_boDy";
            panel_boDy.Size = new Size(1458, 619);
            panel_boDy.TabIndex = 1;
            // 
            // Form_Report_thongKeSanPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(1460, 691);
            ControlBox = false;
            Controls.Add(panel_boDy);
            Controls.Add(panel_heaDer);
            Name = "Form_Report_thongKeSanPham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "THỐNG KÊ SẢN PHẨM";
            Load += Form_Report_thongKeSanPham_Load;
            panel_heaDer.ResumeLayout(false);
            panel_heaDer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_logout).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_heaDer;
        private ComboBox cbb_tenSanPham;
        private ComboBox cbb_hangSanXuat;
        private Panel panel_boDy;
        private Button btn_showAll;
        private Button btn_showSelected;
        private PictureBox pic_logout;
        private Label label2;
        private Label label1;
    }
}