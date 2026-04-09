namespace DoAnBanHang_cuahangxemay.Reports
{
    partial class Form_Report_ThongKeDoanhThu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Report_ThongKeDoanhThu));
            panel1 = new Panel();
            label4 = new Label();
            comboBox_trangThaiHoaDon = new ComboBox();
            panel2 = new Panel();
            label2 = new Label();
            label1 = new Label();
            dtp_denNgay = new DateTimePicker();
            dtp_tuNgay = new DateTimePicker();
            label3 = new Label();
            btn_showSelected = new Button();
            btn_showAll = new Button();
            panel_rePort = new Panel();
            pic_out = new PictureBox();
            chb_countUp = new CheckBox();
            chb_countDown = new CheckBox();
            groupBox1 = new GroupBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_out).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.PaleTurquoise;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(comboBox_trangThaiHoaDon);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btn_showSelected);
            panel1.Controls.Add(btn_showAll);
            panel1.Location = new Point(12, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1263, 54);
            panel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(999, 18);
            label4.Name = "label4";
            label4.Size = new Size(78, 20);
            label4.TabIndex = 10;
            label4.Text = "Trạng thái:";
            // 
            // comboBox_trangThaiHoaDon
            // 
            comboBox_trangThaiHoaDon.FormattingEnabled = true;
            comboBox_trangThaiHoaDon.Location = new Point(1083, 12);
            comboBox_trangThaiHoaDon.Name = "comboBox_trangThaiHoaDon";
            comboBox_trangThaiHoaDon.Size = new Size(172, 28);
            comboBox_trangThaiHoaDon.TabIndex = 9;
            comboBox_trangThaiHoaDon.SelectionChangeCommitted += comboBox_trangThaiHoaDon_SelectionChangeCommitted;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightBlue;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(dtp_denNgay);
            panel2.Controls.Add(dtp_tuNgay);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(33, 7);
            panel2.Name = "panel2";
            panel2.Size = new Size(559, 40);
            panel2.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.Location = new Point(316, 9);
            label2.Name = "label2";
            label2.Size = new Size(84, 23);
            label2.TabIndex = 7;
            label2.Text = "đến ngày";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label1.Location = new Point(10, 9);
            label1.Name = "label1";
            label1.Size = new Size(75, 23);
            label1.TabIndex = 6;
            label1.Text = "Từ ngày";
            // 
            // dtp_denNgay
            // 
            dtp_denNgay.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            dtp_denNgay.Format = DateTimePickerFormat.Short;
            dtp_denNgay.Location = new Point(407, 5);
            dtp_denNgay.Name = "dtp_denNgay";
            dtp_denNgay.Size = new Size(145, 30);
            dtp_denNgay.TabIndex = 5;
            // 
            // dtp_tuNgay
            // 
            dtp_tuNgay.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            dtp_tuNgay.Format = DateTimePickerFormat.Short;
            dtp_tuNgay.Location = new Point(93, 5);
            dtp_tuNgay.Name = "dtp_tuNgay";
            dtp_tuNgay.Size = new Size(145, 30);
            dtp_tuNgay.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label3.ForeColor = Color.Yellow;
            label3.Location = new Point(243, -2);
            label3.Name = "label3";
            label3.Size = new Size(74, 37);
            label3.TabIndex = 10;
            label3.Text = "==>";
            // 
            // btn_showSelected
            // 
            btn_showSelected.BackColor = Color.Honeydew;
            btn_showSelected.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btn_showSelected.Location = new Point(598, 7);
            btn_showSelected.Name = "btn_showSelected";
            btn_showSelected.Size = new Size(102, 38);
            btn_showSelected.TabIndex = 2;
            btn_showSelected.Text = "Xem";
            btn_showSelected.UseVisualStyleBackColor = false;
            btn_showSelected.Click += btn_showSelected_Click;
            // 
            // btn_showAll
            // 
            btn_showAll.BackColor = Color.SkyBlue;
            btn_showAll.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btn_showAll.Location = new Point(781, 9);
            btn_showAll.Name = "btn_showAll";
            btn_showAll.Size = new Size(113, 36);
            btn_showAll.TabIndex = 1;
            btn_showAll.Text = "Xem tất cả";
            btn_showAll.UseVisualStyleBackColor = false;
            btn_showAll.Click += btn_showAll_Click;
            // 
            // panel_rePort
            // 
            panel_rePort.Font = new Font("Segoe UI", 4.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            panel_rePort.Location = new Point(12, 122);
            panel_rePort.Name = "panel_rePort";
            panel_rePort.Size = new Size(1255, 633);
            panel_rePort.TabIndex = 1;
            // 
            // pic_out
            // 
            pic_out.Image = (Image)resources.GetObject("pic_out.Image");
            pic_out.Location = new Point(1390, 0);
            pic_out.Name = "pic_out";
            pic_out.Size = new Size(69, 60);
            pic_out.SizeMode = PictureBoxSizeMode.Zoom;
            pic_out.TabIndex = 9;
            pic_out.TabStop = false;
            pic_out.Click += pic_out_Click;
            // 
            // chb_countUp
            // 
            chb_countUp.AutoSize = true;
            chb_countUp.Location = new Point(6, 24);
            chb_countUp.Name = "chb_countUp";
            chb_countUp.Size = new Size(92, 24);
            chb_countUp.TabIndex = 10;
            chb_countUp.Text = "Tăng dần";
            chb_countUp.UseVisualStyleBackColor = true;
            chb_countUp.Click += chb_countUp_CheckedChanged;
            // 
            // chb_countDown
            // 
            chb_countDown.AutoSize = true;
            chb_countDown.Location = new Point(126, 24);
            chb_countDown.Name = "chb_countDown";
            chb_countDown.Size = new Size(95, 24);
            chb_countDown.TabIndex = 11;
            chb_countDown.Text = "Giảm dần";
            chb_countDown.UseVisualStyleBackColor = true;
            chb_countDown.Click += chb_countDown_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chb_countUp);
            groupBox1.Controls.Add(chb_countDown);
            groupBox1.Location = new Point(12, 63);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(255, 54);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sắp xếp theo giá trị hóa đơn";
            // 
            // Form_Report_ThongKeDoanhThu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(1279, 767);
            ControlBox = false;
            Controls.Add(groupBox1);
            Controls.Add(pic_out);
            Controls.Add(panel_rePort);
            Controls.Add(panel1);
            Name = "Form_Report_ThongKeDoanhThu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "THỐNG KÊ DOANH THU";
            Load += Form_Report_ThongKeDoanhThu_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_out).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private DateTimePicker dtp_denNgay;
        private Button btn_showSelected;
        private DateTimePicker dtp_tuNgay;
        private Button btn_showAll;
        private Panel panel_rePort;
        private Panel panel2;
        private PictureBox pic_out;
        private Label label3;
        private ComboBox comboBox_trangThaiHoaDon;
        private Label label4;
        private CheckBox chb_countUp;
        private CheckBox chb_countDown;
        private GroupBox groupBox1;
    }
}