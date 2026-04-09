using DoAnBanHang_cuahangxemay.Data_Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnBanHang_cuahangxemay.NhatKyDangNhap
{
    public partial class F_Log : Form
    {
        AppDbContext context = new AppDbContext();
        List<DanhSach_LogDangNhapThanhCong> list_Log = new List<DanhSach_LogDangNhapThanhCong>();
        string conText;
        public F_Log(string _context)
        {
            conText = _context;
            InitializeComponent();
        }

        private void LoadLogNhatKy()
        {
            title_form.Text = "NHẬT KÝ ĐĂNH NHẬP\n         THẤT BẠI";
            string jsonFilePath = @"D:\Lập Trình Quản Lý\Đồ án 00\Đồ án 00-traGop\Đồ án 00\DoAnBanHang_cuahangxemay\NhatKyDangNhap\LogDangNhapThatBai.json";
            if (!File.Exists(jsonFilePath))
            {
                MessageBox.Show("Không có nhật ký nào để hiển thị.");
                return;
            }
            string json = File.ReadAllText(jsonFilePath);
            List<LoginLog> logs = JsonSerializer.Deserialize<List<LoginLog>>(json);
            dtg_logNhatKy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_logNhatKy.DataSource = logs;
            dtg_logNhatKy.Columns[0].HeaderText = "Thời gian đăng nhập";
            dtg_logNhatKy.Columns[1].HeaderText = "Tên đăng nhập";
            dtg_logNhatKy.Columns[2].HeaderText = "IP";
            dtg_logNhatKy.Columns[3].HeaderText = "Lý Do";
        }

        private void F_Log_Load(object sender, EventArgs e)
        {
            dtg_logNhatKy.DataSource = null;
            if (conText != null)
            {
                
                LoadLogNhatKy();
            }
            else
            {
               
                title_form.Text = "    NHẬT KÝ ĐĂNH NHẬP";
                var danhsach = context.LogDangNhapThanhCongs
                    .Where(x => x.TimeLogIn != null)
                    .OrderByDescending(x => x.TimeLogIn)
                    .ToList();
                if (danhsach.Count == 0)
                {
                    MessageBox.Show("Không có nhật ký nào để hiển thị.");
                    return;
                }
                list_Log = danhsach.Select(x => new DanhSach_LogDangNhapThanhCong
                {
                    LogID = x.LogID,
                    NhanVienID = x.NhanVienID,
                    TenNhanVien = context.NhanVien?.FirstOrDefault(n => n.NhanVienID == x.NhanVienID)?.HoVaTen ?? "Không xác định",
                    TimeLogIn = x.TimeLogIn,
                    TimeLogOut = x.TimeLogOut,
                    IP = x.IP
                }).ToList();

                dtg_logNhatKy.DataSource = list_Log;
                dtg_logNhatKy.Columns[0].Visible = false;
                dtg_logNhatKy.Columns[1].HeaderText = "Mã Nhân Viên";
                dtg_logNhatKy.Columns[2].HeaderText = "Tên Nhân Viên";
                dtg_logNhatKy.Columns[3].HeaderText = "Thời gian đăng nhập";
                dtg_logNhatKy.Columns[4].HeaderText = "Thời gian đăng xuất";
                dtg_logNhatKy.Columns[5].HeaderText = "IP đăng nhập";
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (conText != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhật ký đăng nhập thất bại không?", "Xóa nhật ký", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                string jsonFilePath = @"D:\Lập Trình Quản Lý\Đồ án 00\Đồ án 00-traGop\Đồ án 00\DoAnBanHang_cuahangxemay\NhatKyDangNhap\LogDangNhapThatBai.json";
                File.Delete(jsonFilePath);
                MessageBox.Show("Xóa thành công nhật ký đăng nhập thất bại");
                F_Log_Load(sender, e);              
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhật ký đăng nhập không?", "Xóa nhật ký", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                if (context.LogDangNhapThanhCongs != null)
                {
                    var log = context.LogDangNhapThanhCongs.ToList();
                    foreach (var item in log)
                    {
                        context.LogDangNhapThanhCongs.Remove(item);
                    }
                    context.SaveChanges();
                    MessageBox.Show("Xóa thành công nhật ký đăng nhập");
                    F_Log_Load(sender, e);
                }
                else
                {
                   
                    MessageBox.Show("Không có nhật ký nào để xóa.");
                }
            }
        }

        private void btn_XuatFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text Files (*.txt)|*.txt";
                sfd.FileName = "dataLog_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    int columnCount = dtg_logNhatKy.Columns.Count;
                    int[] maxColumnWidths = new int[columnCount];

                    // Tính chiều rộng lớn nhất mỗi cột (bao gồm cả tên cột)
                    for (int i = 0; i < columnCount; i++)
                    {
                        maxColumnWidths[i] = dtg_logNhatKy.Columns[i].HeaderText.Length;

                        foreach (DataGridViewRow row in dtg_logNhatKy.Rows)
                        {
                            if (row.IsNewRow) continue;
                            var value = row.Cells[i].Value?.ToString() ?? "";
                            if (value.Length > maxColumnWidths[i])
                                maxColumnWidths[i] = value.Length;
                        }
                    }

                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                    {
                        // Ghi dòng tiêu đề (Header)
                        for (int i = 0; i < columnCount; i++)
                        {
                            string header = dtg_logNhatKy.Columns[i].HeaderText;
                            sw.Write(header.PadRight(maxColumnWidths[i] + 2)); // +2 cho khoảng trắng
                        }
                        sw.WriteLine();

                        // Ghi dữ liệu từng hàng
                        foreach (DataGridViewRow row in dtg_logNhatKy.Rows)
                        {
                            if (row.IsNewRow) continue;

                            for (int i = 0; i < columnCount; i++)
                            {
                                string cellText = row.Cells[i].Value?.ToString() ?? "";
                                sw.Write(cellText.PadRight(maxColumnWidths[i] + 2));
                            }
                            sw.WriteLine();
                        }
                    }
                    MessageBox.Show("✅ Xuất dữ liệu hoàn tất!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
