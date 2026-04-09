using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnBanHang_cuahangxemay.help
{
    public partial class F_Help : Form
    {
        private string _context;

        public F_Help(string context)
        {
            InitializeComponent();
            _context = context;
        }
        private void LoadHelpContent()
        {
            string exeDir = AppDomain.CurrentDomain.BaseDirectory;

            // Lên 3 cấp từ /bin/Debug/netX.0/
            string projectRoot = Path.GetFullPath(Path.Combine(exeDir, @"..\..\..\"));

            // Ghép đường dẫn tới thư mục help
            string helpFile = Path.Combine(projectRoot, "help", $"{_context}.txt");
            try
            {
                if (File.Exists(helpFile))
                {
                    richTextBoxHelp.Text = File.ReadAllText(helpFile);
                }
                else
                {
                    richTextBoxHelp.Text = $"Không tìm thấy file trợ giúp tại:\n{helpFile}";
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message + " / " + ex.StackTrace); }
        }

        private void F_Help_Load(object sender, EventArgs e)
        {
            LoadHelpContent();
        }

        private void F_Help_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
