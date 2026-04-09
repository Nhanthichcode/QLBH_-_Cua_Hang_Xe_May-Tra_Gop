namespace DoAnBanHang_cuahangxemay.Forms
{
    partial class F_DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_DangNhap));
            pictureBox_Unlock = new PictureBox();
            pic_canncel = new PictureBox();
            pic_ok = new PictureBox();
            pic_reSet = new PictureBox();
            pic_hidePass = new PictureBox();
            pic_showPass = new PictureBox();
            txt_passWord = new TextBox();
            txt_useName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btn_accept = new Button();
            pictureBox_lock = new PictureBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Unlock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic_canncel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic_ok).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic_reSet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic_hidePass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic_showPass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_lock).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_Unlock
            // 
            pictureBox_Unlock.BackColor = Color.Transparent;
            pictureBox_Unlock.Image = (Image)resources.GetObject("pictureBox_Unlock.Image");
            pictureBox_Unlock.Location = new Point(30, 80);
            pictureBox_Unlock.Margin = new Padding(4);
            pictureBox_Unlock.Name = "pictureBox_Unlock";
            pictureBox_Unlock.Size = new Size(256, 256);
            pictureBox_Unlock.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox_Unlock.TabIndex = 0;
            pictureBox_Unlock.TabStop = false;
            // 
            // pic_canncel
            // 
            pic_canncel.BackColor = Color.Transparent;
            pic_canncel.Image = (Image)resources.GetObject("pic_canncel.Image");
            pic_canncel.Location = new Point(624, 13);
            pic_canncel.Margin = new Padding(4);
            pic_canncel.Name = "pic_canncel";
            pic_canncel.Size = new Size(67, 61);
            pic_canncel.SizeMode = PictureBoxSizeMode.Zoom;
            pic_canncel.TabIndex = 1;
            pic_canncel.TabStop = false;
            pic_canncel.Click += pic_canncel_Click;
            // 
            // pic_ok
            // 
            pic_ok.BackColor = Color.Transparent;
            pic_ok.Image = (Image)resources.GetObject("pic_ok.Image");
            pic_ok.Location = new Point(614, 297);
            pic_ok.Margin = new Padding(4);
            pic_ok.Name = "pic_ok";
            pic_ok.Size = new Size(77, 79);
            pic_ok.SizeMode = PictureBoxSizeMode.Zoom;
            pic_ok.TabIndex = 2;
            pic_ok.TabStop = false;
            pic_ok.Click += pic_ok_Click;
            // 
            // pic_reSet
            // 
            pic_reSet.BackColor = Color.Transparent;
            pic_reSet.Image = (Image)resources.GetObject("pic_reSet.Image");
            pic_reSet.Location = new Point(366, 297);
            pic_reSet.Name = "pic_reSet";
            pic_reSet.Size = new Size(83, 79);
            pic_reSet.SizeMode = PictureBoxSizeMode.Zoom;
            pic_reSet.TabIndex = 3;
            pic_reSet.TabStop = false;
            pic_reSet.Click += pic_reSet_Click;
            // 
            // pic_hidePass
            // 
            pic_hidePass.BackColor = Color.Transparent;
            pic_hidePass.Image = (Image)resources.GetObject("pic_hidePass.Image");
            pic_hidePass.Location = new Point(646, 221);
            pic_hidePass.Name = "pic_hidePass";
            pic_hidePass.Size = new Size(48, 44);
            pic_hidePass.SizeMode = PictureBoxSizeMode.Zoom;
            pic_hidePass.TabIndex = 4;
            pic_hidePass.TabStop = false;
            pic_hidePass.Click += pic_hidePass_Click;
            // 
            // pic_showPass
            // 
            pic_showPass.BackColor = Color.Transparent;
            pic_showPass.Image = (Image)resources.GetObject("pic_showPass.Image");
            pic_showPass.Location = new Point(648, 222);
            pic_showPass.Name = "pic_showPass";
            pic_showPass.Size = new Size(45, 35);
            pic_showPass.SizeMode = PictureBoxSizeMode.Zoom;
            pic_showPass.TabIndex = 5;
            pic_showPass.TabStop = false;
            pic_showPass.Click += pic_showPass_Click;
            // 
            // txt_passWord
            // 
            txt_passWord.BackColor = Color.DarkSeaGreen;
            txt_passWord.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            txt_passWord.ForeColor = SystemColors.ActiveCaptionText;
            txt_passWord.Location = new Point(474, 180);
            txt_passWord.Margin = new Padding(3, 10, 3, 3);
            txt_passWord.Multiline = true;
            txt_passWord.Name = "txt_passWord";
            txt_passWord.Size = new Size(220, 35);
            txt_passWord.TabIndex = 6;
            txt_passWord.Text = "nhập mật khẩu";
            txt_passWord.Enter += txt_passWord_Enter;
            txt_passWord.Leave += txt_passWord_Leave;
            // 
            // txt_useName
            // 
            txt_useName.BackColor = Color.DarkSeaGreen;
            txt_useName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            txt_useName.ForeColor = SystemColors.ActiveCaptionText;
            txt_useName.Location = new Point(474, 137);
            txt_useName.Margin = new Padding(3, 10, 3, 3);
            txt_useName.Multiline = true;
            txt_useName.Name = "txt_useName";
            txt_useName.Size = new Size(220, 35);
            txt_useName.TabIndex = 0;
            txt_useName.Text = "nhập tên đăng nhập";
            txt_useName.Enter += txt_useName_Enter;
            txt_useName.Leave += txt_useName_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(280, 137);
            label1.Name = "label1";
            label1.Size = new Size(188, 29);
            label1.TabIndex = 8;
            label1.Text = "Tên đăng nhập";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(280, 180);
            label2.Name = "label2";
            label2.Size = new Size(117, 29);
            label2.TabIndex = 9;
            label2.Text = "Mật khẩu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Impact", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Azure;
            label3.Location = new Point(239, 38);
            label3.Name = "label3";
            label3.Size = new Size(319, 75);
            label3.TabIndex = 10;
            label3.Text = "ĐĂNG NHẬP";
            // 
            // btn_accept
            // 
            btn_accept.Location = new Point(626, 335);
            btn_accept.Name = "btn_accept";
            btn_accept.Size = new Size(1, 1);
            btn_accept.TabIndex = 11;
            btn_accept.UseVisualStyleBackColor = true;
            btn_accept.Click += btn_accept_Click;
            // 
            // pictureBox_lock
            // 
            pictureBox_lock.BackColor = Color.Transparent;
            pictureBox_lock.Image = (Image)resources.GetObject("pictureBox_lock.Image");
            pictureBox_lock.Location = new Point(30, 80);
            pictureBox_lock.Margin = new Padding(4);
            pictureBox_lock.Name = "pictureBox_lock";
            pictureBox_lock.Size = new Size(256, 256);
            pictureBox_lock.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox_lock.TabIndex = 12;
            pictureBox_lock.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(474, 237);
            label4.Name = "label4";
            label4.Size = new Size(130, 20);
            label4.TabIndex = 13;
            label4.Text = "Hiện mật khẩu";
            // 
            // F_DangNhap
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(720, 404);
            ControlBox = false;
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pictureBox_Unlock);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(txt_useName);
            Controls.Add(txt_passWord);
            Controls.Add(pic_showPass);
            Controls.Add(pic_hidePass);
            Controls.Add(pic_reSet);
            Controls.Add(pic_canncel);
            Controls.Add(btn_accept);
            Controls.Add(pic_ok);
            Controls.Add(pictureBox_lock);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(4);
            Name = "F_DangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ĐĂNG NHẬP";
            Load += F_DangNhap_Load;
            KeyDown += F_DangNhap_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox_Unlock).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_canncel).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_ok).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_reSet).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_hidePass).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_showPass).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_lock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox_Unlock;
        private PictureBox pic_canncel;
        private PictureBox pic_ok;
        private PictureBox pic_reSet;
        private PictureBox pic_hidePass;
        private PictureBox pic_showPass;
        private TextBox txt_passWord;
        private TextBox txt_useName;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btn_accept;
        private PictureBox pictureBox_lock;
        private Label label4;
    }
}