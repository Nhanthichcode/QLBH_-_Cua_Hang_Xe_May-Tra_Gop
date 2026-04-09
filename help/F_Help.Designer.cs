namespace DoAnBanHang_cuahangxemay.help
{
    partial class F_Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Help));
            richTextBoxHelp = new RichTextBox();
            SuspendLayout();
            // 
            // richTextBoxHelp
            // 
            richTextBoxHelp.BackColor = Color.MintCream;
            richTextBoxHelp.BorderStyle = BorderStyle.None;
            richTextBoxHelp.Font = new Font("Segoe UI", 10F);
            richTextBoxHelp.Location = new Point(28, 12);
            richTextBoxHelp.Name = "richTextBoxHelp";
            richTextBoxHelp.ReadOnly = true;
            richTextBoxHelp.Size = new Size(1112, 618);
            richTextBoxHelp.TabIndex = 2;
            richTextBoxHelp.Text = "";
            // 
            // F_Help
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MintCream;
            ClientSize = new Size(1153, 640);
            Controls.Add(richTextBoxHelp);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "F_Help";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trợ Giúp";
            Load += F_Help_Load;
            KeyDown += F_Help_KeyDown;
            ResumeLayout(false);
        }

        #endregion
        private RichTextBox richTextBoxHelp;
    }
}