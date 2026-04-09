namespace DoAnBanHang_cuahangxemay.Forms
{
    partial class F_ThanhToan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_ThanhToan));
            panel1 = new Panel();
            dtg_thanhToan = new DataGridView();
            cbb_trangThaiTT = new ComboBox();
            cbb_timKiemTenKH = new ComboBox();
            dtp_ngayTT = new DateTimePicker();
            txt_phuongTTT = new TextBox();
            panel_thongTinKhachHang = new Panel();
            label12 = new Label();
            label11 = new Label();
            txt_ghiChu = new TextBox();
            txt_tenNhanVien = new TextBox();
            label10 = new Label();
            dtp_ngayLap = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            num_soTIenTT = new NumericUpDown();
            txt_tenKhachHang = new TextBox();
            groupBox2 = new GroupBox();
            label8 = new Label();
            cbb_searchBytrangThaiHoaDon = new ComboBox();
            label6 = new Label();
            btn_timKiem = new Button();
            label9 = new Label();
            dtg_khachHang = new DataGridView();
            panel2 = new Panel();
            label5 = new Label();
            btn_xacNhan = new Button();
            panel_trangThai = new Panel();
            pictureBox1 = new PictureBox();
            label7 = new Label();
            groupBox3 = new GroupBox();
            pictureBox_troVe = new PictureBox();
            groupBox1 = new GroupBox();
            label17 = new Label();
            pictureBox2 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtg_thanhToan).BeginInit();
            panel_thongTinKhachHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_soTIenTT).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtg_khachHang).BeginInit();
            panel2.SuspendLayout();
            panel_trangThai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_troVe).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dtg_thanhToan);
            panel1.Location = new Point(5, 498);
            panel1.Name = "panel1";
            panel1.Size = new Size(981, 260);
            panel1.TabIndex = 0;
            // 
            // dtg_thanhToan
            // 
            dtg_thanhToan.AllowUserToAddRows = false;
            dtg_thanhToan.BackgroundColor = SystemColors.Control;
            dtg_thanhToan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Info;
            dataGridViewCellStyle1.SelectionForeColor = Color.Red;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dtg_thanhToan.DefaultCellStyle = dataGridViewCellStyle1;
            dtg_thanhToan.Dock = DockStyle.Fill;
            dtg_thanhToan.Location = new Point(0, 0);
            dtg_thanhToan.MultiSelect = false;
            dtg_thanhToan.Name = "dtg_thanhToan";
            dtg_thanhToan.ReadOnly = true;
            dtg_thanhToan.RowHeadersWidth = 51;
            dtg_thanhToan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_thanhToan.Size = new Size(981, 260);
            dtg_thanhToan.TabIndex = 0;
            dtg_thanhToan.SelectionChanged += dtg_thanhToan_SelectionChanged;
            // 
            // cbb_trangThaiTT
            // 
            cbb_trangThaiTT.FormattingEnabled = true;
            cbb_trangThaiTT.Location = new Point(11, 43);
            cbb_trangThaiTT.Name = "cbb_trangThaiTT";
            cbb_trangThaiTT.Size = new Size(158, 28);
            cbb_trangThaiTT.TabIndex = 1;
            // 
            // cbb_timKiemTenKH
            // 
            cbb_timKiemTenKH.FormattingEnabled = true;
            cbb_timKiemTenKH.Location = new Point(110, 47);
            cbb_timKiemTenKH.Name = "cbb_timKiemTenKH";
            cbb_timKiemTenKH.Size = new Size(157, 28);
            cbb_timKiemTenKH.TabIndex = 2;
            cbb_timKiemTenKH.SelectionChangeCommitted += cbb_timKiemTenKH_SelectionChangeCommitted;
            // 
            // dtp_ngayTT
            // 
            dtp_ngayTT.CalendarForeColor = Color.SandyBrown;
            dtp_ngayTT.CalendarTitleBackColor = Color.DodgerBlue;
            dtp_ngayTT.CalendarTitleForeColor = Color.Red;
            dtp_ngayTT.CalendarTrailingForeColor = SystemColors.ControlLightLight;
            dtp_ngayTT.Format = DateTimePickerFormat.Short;
            dtp_ngayTT.Location = new Point(219, 304);
            dtp_ngayTT.Name = "dtp_ngayTT";
            dtp_ngayTT.Size = new Size(238, 27);
            dtp_ngayTT.TabIndex = 3;
            // 
            // txt_phuongTTT
            // 
            txt_phuongTTT.Location = new Point(219, 85);
            txt_phuongTTT.Name = "txt_phuongTTT";
            txt_phuongTTT.Size = new Size(238, 27);
            txt_phuongTTT.TabIndex = 5;
            // 
            // panel_thongTinKhachHang
            // 
            panel_thongTinKhachHang.BackColor = Color.Honeydew;
            panel_thongTinKhachHang.Controls.Add(label12);
            panel_thongTinKhachHang.Controls.Add(label11);
            panel_thongTinKhachHang.Controls.Add(txt_ghiChu);
            panel_thongTinKhachHang.Controls.Add(txt_tenNhanVien);
            panel_thongTinKhachHang.Controls.Add(label10);
            panel_thongTinKhachHang.Controls.Add(dtp_ngayLap);
            panel_thongTinKhachHang.Controls.Add(label1);
            panel_thongTinKhachHang.Controls.Add(label2);
            panel_thongTinKhachHang.Controls.Add(label3);
            panel_thongTinKhachHang.Controls.Add(label4);
            panel_thongTinKhachHang.Controls.Add(num_soTIenTT);
            panel_thongTinKhachHang.Controls.Add(txt_tenKhachHang);
            panel_thongTinKhachHang.Controls.Add(txt_phuongTTT);
            panel_thongTinKhachHang.Controls.Add(dtp_ngayTT);
            panel_thongTinKhachHang.Location = new Point(304, 29);
            panel_thongTinKhachHang.Name = "panel_thongTinKhachHang";
            panel_thongTinKhachHang.Size = new Size(470, 343);
            panel_thongTinKhachHang.TabIndex = 16;
            panel_thongTinKhachHang.Paint += panel_thongTinKhachHang_Paint;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(11, 216);
            label12.Name = "label12";
            label12.Size = new Size(133, 20);
            label12.TabIndex = 48;
            label12.Text = "Ghi chú thanh toán";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(11, 169);
            label11.Name = "label11";
            label11.Size = new Size(103, 20);
            label11.TabIndex = 47;
            label11.Text = "Nhân viên lập:";
            // 
            // txt_ghiChu
            // 
            txt_ghiChu.Location = new Point(219, 213);
            txt_ghiChu.Multiline = true;
            txt_ghiChu.Name = "txt_ghiChu";
            txt_ghiChu.Size = new Size(238, 85);
            txt_ghiChu.TabIndex = 46;
            // 
            // txt_tenNhanVien
            // 
            txt_tenNhanVien.Location = new Point(219, 166);
            txt_tenNhanVien.Name = "txt_tenNhanVien";
            txt_tenNhanVien.Size = new Size(125, 27);
            txt_tenNhanVien.TabIndex = 45;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(11, 129);
            label10.Name = "label10";
            label10.Size = new Size(72, 20);
            label10.TabIndex = 13;
            label10.Text = "Ngày lập:";
            // 
            // dtp_ngayLap
            // 
            dtp_ngayLap.Format = DateTimePickerFormat.Custom;
            dtp_ngayLap.Location = new Point(219, 124);
            dtp_ngayLap.Margin = new Padding(3, 4, 3, 4);
            dtp_ngayLap.Name = "dtp_ngayLap";
            dtp_ngayLap.Size = new Size(238, 27);
            dtp_ngayLap.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 15);
            label1.Name = "label1";
            label1.Size = new Size(111, 20);
            label1.TabIndex = 8;
            label1.Text = "Tên khách hàng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 51);
            label2.Name = "label2";
            label2.Size = new Size(130, 20);
            label2.TabIndex = 9;
            label2.Text = "Số tiền thanh toán";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 85);
            label3.Name = "label3";
            label3.Size = new Size(168, 20);
            label3.TabIndex = 10;
            label3.Text = "Phương thức thanh toán";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 309);
            label4.Name = "label4";
            label4.Size = new Size(119, 20);
            label4.TabIndex = 11;
            label4.Text = "Ngày thanh toán";
            // 
            // num_soTIenTT
            // 
            num_soTIenTT.Location = new Point(219, 49);
            num_soTIenTT.Maximum = new decimal(new int[] { 1661992959, 1808227885, 5, 0 });
            num_soTIenTT.Name = "num_soTIenTT";
            num_soTIenTT.Size = new Size(238, 27);
            num_soTIenTT.TabIndex = 7;
            num_soTIenTT.TextAlign = HorizontalAlignment.Right;
            // 
            // txt_tenKhachHang
            // 
            txt_tenKhachHang.Location = new Point(219, 12);
            txt_tenKhachHang.Name = "txt_tenKhachHang";
            txt_tenKhachHang.Size = new Size(238, 27);
            txt_tenKhachHang.TabIndex = 6;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Azure;
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(cbb_searchBytrangThaiHoaDon);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(btn_timKiem);
            groupBox2.Controls.Add(cbb_timKiemTenKH);
            groupBox2.Controls.Add(label9);
            groupBox2.Location = new Point(14, 28);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(284, 344);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tìm kiếm";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(11, 107);
            label8.Name = "label8";
            label8.Size = new Size(136, 20);
            label8.TabIndex = 21;
            label8.Text = "Tìm theo trạng thái";
            // 
            // cbb_searchBytrangThaiHoaDon
            // 
            cbb_searchBytrangThaiHoaDon.FormattingEnabled = true;
            cbb_searchBytrangThaiHoaDon.Location = new Point(150, 105);
            cbb_searchBytrangThaiHoaDon.Name = "cbb_searchBytrangThaiHoaDon";
            cbb_searchBytrangThaiHoaDon.Size = new Size(117, 28);
            cbb_searchBytrangThaiHoaDon.TabIndex = 14;
            cbb_searchBytrangThaiHoaDon.SelectionChangeCommitted += cbb_searchBytrangThaiHoaDon_SelectionChangeCommitted;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 51);
            label6.Name = "label6";
            label6.Size = new Size(93, 20);
            label6.TabIndex = 12;
            label6.Text = "Tìm theo tên";
            // 
            // btn_timKiem
            // 
            btn_timKiem.BackColor = SystemColors.ActiveCaptionText;
            btn_timKiem.Font = new Font("Showcard Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_timKiem.ForeColor = Color.Chartreuse;
            btn_timKiem.Location = new Point(131, 279);
            btn_timKiem.Name = "btn_timKiem";
            btn_timKiem.Size = new Size(136, 59);
            btn_timKiem.TabIndex = 13;
            btn_timKiem.Text = "Hiện Tất Cả";
            btn_timKiem.UseVisualStyleBackColor = false;
            btn_timKiem.Click += btn_timKiem_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Variable Display", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label9.ForeColor = Color.Aquamarine;
            label9.Location = new Point(-5, 61);
            label9.Name = "label9";
            label9.Size = new Size(292, 49);
            label9.TabIndex = 22;
            label9.Text = "------------------";
            // 
            // dtg_khachHang
            // 
            dtg_khachHang.AllowUserToAddRows = false;
            dtg_khachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtg_khachHang.BackgroundColor = Color.LightSkyBlue;
            dtg_khachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_khachHang.Dock = DockStyle.Fill;
            dtg_khachHang.Location = new Point(0, 0);
            dtg_khachHang.MultiSelect = false;
            dtg_khachHang.Name = "dtg_khachHang";
            dtg_khachHang.ReadOnly = true;
            dtg_khachHang.RowHeadersWidth = 51;
            dtg_khachHang.Size = new Size(386, 633);
            dtg_khachHang.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.Controls.Add(dtg_khachHang);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 19);
            panel2.Name = "panel2";
            panel2.Size = new Size(386, 633);
            panel2.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(11, 17);
            label5.Name = "label5";
            label5.Size = new Size(75, 20);
            label5.TabIndex = 9;
            label5.Text = "Trạng thái";
            // 
            // btn_xacNhan
            // 
            btn_xacNhan.BackColor = Color.MediumAquamarine;
            btn_xacNhan.ForeColor = SystemColors.ButtonHighlight;
            btn_xacNhan.Location = new Point(77, 103);
            btn_xacNhan.Name = "btn_xacNhan";
            btn_xacNhan.Size = new Size(107, 52);
            btn_xacNhan.TabIndex = 14;
            btn_xacNhan.Text = "Thay đổi";
            btn_xacNhan.UseVisualStyleBackColor = false;
            btn_xacNhan.Click += btn_xacNhan_Click;
            // 
            // panel_trangThai
            // 
            panel_trangThai.BackColor = Color.Honeydew;
            panel_trangThai.Controls.Add(pictureBox1);
            panel_trangThai.Controls.Add(btn_xacNhan);
            panel_trangThai.Controls.Add(label5);
            panel_trangThai.Controls.Add(cbb_trangThaiTT);
            panel_trangThai.Location = new Point(780, 29);
            panel_trangThai.Name = "panel_trangThai";
            panel_trangThai.Size = new Size(187, 177);
            panel_trangThai.TabIndex = 16;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(15, 103);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(55, 67);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.DeepSkyBlue;
            label7.Location = new Point(408, 38);
            label7.Name = "label7";
            label7.Size = new Size(440, 43);
            label7.TabIndex = 17;
            label7.Text = "THÔNG TIN THANH TOÁN";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(panel2);
            groupBox3.Font = new Font("Segoe UI", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, 163);
            groupBox3.Location = new Point(992, 103);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(392, 655);
            groupBox3.TabIndex = 18;
            groupBox3.TabStop = false;
            groupBox3.Text = "Thông tin Khách Hàng";
            // 
            // pictureBox_troVe
            // 
            pictureBox_troVe.BorderStyle = BorderStyle.Fixed3D;
            pictureBox_troVe.Image = (Image)resources.GetObject("pictureBox_troVe.Image");
            pictureBox_troVe.Location = new Point(1300, 13);
            pictureBox_troVe.Name = "pictureBox_troVe";
            pictureBox_troVe.Size = new Size(81, 68);
            pictureBox_troVe.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_troVe.TabIndex = 19;
            pictureBox_troVe.TabStop = false;
            pictureBox_troVe.Click += pictureBox_troVe_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.PaleTurquoise;
            groupBox1.Controls.Add(panel_thongTinKhachHang);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(panel_trangThai);
            groupBox1.Location = new Point(7, 114);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(979, 378);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin thanh toán";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 13F, FontStyle.Bold | FontStyle.Underline);
            label17.Location = new Point(95, 29);
            label17.Name = "label17";
            label17.Size = new Size(102, 30);
            label17.TabIndex = 44;
            label17.Text = "Trợ Giúp";
            label17.Click += pictureBox2_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(13, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(77, 69);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 43;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // F_ThanhToan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(1400, 767);
            ControlBox = false;
            Controls.Add(label17);
            Controls.Add(pictureBox2);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox_troVe);
            Controls.Add(groupBox3);
            Controls.Add(label7);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            Name = "F_ThanhToan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thanh Toán";
            Load += F_ThanhToan_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtg_thanhToan).EndInit();
            panel_thongTinKhachHang.ResumeLayout(false);
            panel_thongTinKhachHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num_soTIenTT).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtg_khachHang).EndInit();
            panel2.ResumeLayout(false);
            panel_trangThai.ResumeLayout(false);
            panel_trangThai.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_troVe).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DataGridView dtg_thanhToan;
        private ComboBox cbb_trangThaiTT;
        private ComboBox cbb_timKiemTenKH;
        private DateTimePicker dtp_ngayTT;
        private TextBox txt_phuongTTT;
        private TextBox txt_tenKhachHang;
        private NumericUpDown num_soTIenTT;
        private DataGridView dtg_khachHang;
        private Panel panel2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btn_timKiem;
        private Button btn_xacNhan;
        private GroupBox groupBox2;
        private Panel panel_trangThai;
        private Label label7;
        private GroupBox groupBox3;
        private PictureBox pictureBox_troVe;
        private Panel panel_thongTinKhachHang;
        private ComboBox cbb_searchBytrangThaiHoaDon;
        private GroupBox groupBox1;
        private Label label8;
        private Label label9;
        private PictureBox pictureBox1;
        private Label label17;
        private PictureBox pictureBox2;
        private Label label10;
        private DateTimePicker dtp_ngayLap;
        private TextBox txt_ghiChu;
        private TextBox txt_tenNhanVien;
        private Label label12;
        private Label label11;
    }
}