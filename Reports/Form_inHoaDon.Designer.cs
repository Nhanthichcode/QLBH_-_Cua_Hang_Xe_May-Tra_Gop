namespace DoAnBanHang_cuahangxemay.Reports
{
    partial class Form_inHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_inHoaDon));
            panel_boDy = new Panel();
            pic_logout = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pic_logout).BeginInit();
            SuspendLayout();
            // 
            // panel_boDy
            // 
            panel_boDy.Location = new Point(0, 66);
            panel_boDy.Name = "panel_boDy";
            panel_boDy.Size = new Size(1460, 625);
            panel_boDy.TabIndex = 0;
            // 
            // pic_logout
            // 
            pic_logout.Image = (Image)resources.GetObject("pic_logout.Image");
            pic_logout.Location = new Point(1398, 2);
            pic_logout.Name = "pic_logout";
            pic_logout.Size = new Size(60, 60);
            pic_logout.SizeMode = PictureBoxSizeMode.Zoom;
            pic_logout.TabIndex = 1;
            pic_logout.TabStop = false;
            pic_logout.Click += pic_logout_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DeepSkyBlue;
            label1.Location = new Point(542, 10);
            label1.Name = "label1";
            label1.Size = new Size(363, 43);
            label1.TabIndex = 2;
            label1.Text = "HÓA ĐƠN BÁN HÀNG";
            // 
            // Form_inHoaDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(1460, 691);
            ControlBox = false;
            Controls.Add(label1);
            Controls.Add(pic_logout);
            Controls.Add(panel_boDy);
            Name = "Form_inHoaDon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "In Hóa Đơn";
            Load += Form_inHoaDon_Load;
            ((System.ComponentModel.ISupportInitialize)pic_logout).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel_boDy;
        private PictureBox pic_logout;
        private Label label1;
    }
}