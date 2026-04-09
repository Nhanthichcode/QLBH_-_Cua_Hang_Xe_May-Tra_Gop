namespace DoAnBanHang_cuahangxemay.NhatKyDangNhap
{
    partial class F_Log
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Log));
            dtg_logNhatKy = new DataGridView();
            title_form = new Label();
            richTextBox_dangNhapThatbai = new RichTextBox();
            dataSet_thongKe1 = new Reports.DataSet_thongKe();
            menuStrip1 = new MenuStrip();
            btn_Xoa = new ToolStripMenuItem();
            btn_XuatFile = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dtg_logNhatKy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataSet_thongKe1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dtg_logNhatKy
            // 
            dtg_logNhatKy.AllowUserToAddRows = false;
            dtg_logNhatKy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_logNhatKy.BackgroundColor = SystemColors.ActiveCaption;
            dtg_logNhatKy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_logNhatKy.Location = new Point(323, 229);
            dtg_logNhatKy.Name = "dtg_logNhatKy";
            dtg_logNhatKy.ReadOnly = true;
            dtg_logNhatKy.RowHeadersWidth = 51;
            dtg_logNhatKy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_logNhatKy.Size = new Size(776, 367);
            dtg_logNhatKy.TabIndex = 0;
            // 
            // title_form
            // 
            title_form.AutoSize = true;
            title_form.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            title_form.ForeColor = Color.DeepSkyBlue;
            title_form.Location = new Point(533, 114);
            title_form.Name = "title_form";
            title_form.Size = new Size(398, 86);
            title_form.TabIndex = 1;
            title_form.Text = "NHẬT KÝ ĐĂNH NHẬP\r\n        THÀNH CÔNG";
            // 
            // richTextBox_dangNhapThatbai
            // 
            richTextBox_dangNhapThatbai.Location = new Point(323, 229);
            richTextBox_dangNhapThatbai.Name = "richTextBox_dangNhapThatbai";
            richTextBox_dangNhapThatbai.Size = new Size(776, 367);
            richTextBox_dangNhapThatbai.TabIndex = 2;
            richTextBox_dangNhapThatbai.Text = "";
            richTextBox_dangNhapThatbai.Visible = false;
            // 
            // dataSet_thongKe1
            // 
            dataSet_thongKe1.DataSetName = "DataSet_thongKe";
            dataSet_thongKe1.Namespace = "http://tempuri.org/DataSet_thongKe.xsd";
            dataSet_thongKe1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.MediumTurquoise;
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { btn_Xoa, btn_XuatFile });
            menuStrip1.Location = new Point(503, 615);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(551, 85);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
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
            btn_Xoa.Size = new Size(172, 51);
            btn_Xoa.Text = "Xóa tất cả";
            btn_Xoa.TextAlign = ContentAlignment.MiddleRight;
            btn_Xoa.Click += btn_Xoa_Click;
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
            // F_Log
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(1469, 744);
            Controls.Add(menuStrip1);
            Controls.Add(title_form);
            Controls.Add(dtg_logNhatKy);
            Controls.Add(richTextBox_dangNhapThatbai);
            Name = "F_Log";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nhật Ký Đăng Nhập";
            Load += F_Log_Load;
            ((System.ComponentModel.ISupportInitialize)dtg_logNhatKy).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataSet_thongKe1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtg_logNhatKy;
        private Label title_form;
        private RichTextBox richTextBox_dangNhapThatbai;
        private Reports.DataSet_thongKe dataSet_thongKe1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem btn_Xoa;
        private ToolStripMenuItem btn_XuatFile;
    }
}