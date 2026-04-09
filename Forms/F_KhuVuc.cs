using ClosedXML.Excel;
using DoAnBanHang_cuahangxemay.Data_Table;
using DocumentFormat.OpenXml.InkML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnBanHang_cuahangxemay.Forms
{
    public partial class F_KhuVuc : Form
    {
        AppDbContext context = new AppDbContext();
        BindingSource bindingSource = new BindingSource();
        List<KhuVuc> khuVuvList = new List<KhuVuc>();
        int id_nguoiDung;
        int id_khuVuc;
        bool xuLyThem = false;

        void phanQuyenNguoiDung(bool tmp)
        {
            var nv = context.NhanVien.Find(id_nguoiDung);
            if (nv != null && nv.QuyenHan)
            {
                btn_Them.Enabled = btn_Sua.Enabled = btn_Xoa.Enabled = btn_Huy.Enabled = btn_XuatFile.Enabled = btn_NhapFile.Enabled = btn_Luulai.Enabled = true;
                btn_Them.Enabled = btn_Sua.Enabled = btn_Xoa.Enabled = btn_XuatFile.Enabled = btn_NhapFile.Enabled = tmp;
                btn_Huy.Enabled = btn_Luulai.Enabled = !tmp;
            }
            else
            {
                btn_Them.Enabled = true;
                btn_Sua.Enabled = btn_Xoa.Enabled = btn_Huy.Enabled = btn_XuatFile.Enabled = btn_NhapFile.Enabled = btn_Luulai.Enabled = false;

                btn_Them.Enabled = tmp;
                btn_Huy.Enabled = btn_Luulai.Enabled = !tmp;
            }
        }
        void Load_FormKhuVuc()
        {
            phanQuyenNguoiDung(true);
            khuVuvList = context.KhuVuc.ToList();
            bindingSource.DataSource = khuVuvList;
            txt_tenKhuVuc.DataBindings.Clear();
            txt_tenKhuVuc.DataBindings.Add("Text", bindingSource, "TenKhuVuc", true, DataSourceUpdateMode.Never);
            dtg_khuVuc.DataSource = bindingSource;
            dtg_khuVuc.Columns["KhuVucID"].HeaderText = "Mã khu vực";
            dtg_khuVuc.Columns["TenKhuVuc"].HeaderText = "Tên khu vực";
        }
        public F_KhuVuc(int nhanvienID)
        {
            InitializeComponent();
            id_nguoiDung = nhanvienID;
        }

        private void F_KhuVuc_Load(object sender, EventArgs e)
        {
            Load_FormKhuVuc();
        }

        bool kiemTra()
        {
            if (string.IsNullOrEmpty(txt_tenKhuVuc.Text))
            {
                MessageBox.Show("Tên khu vực không được để trống");
                return false;
            }
            var kv = context.KhuVuc.Any(x => x.TenKhuVuc == txt_tenKhuVuc.Text);
            if (kv)
            {
                MessageBox.Show("Tên khu vực đã tồn tại,\n Hãy nhập tên khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_tenKhuVuc.Focus();
                return false;
            }
            return true;
        }
        private void btn_Luulai_Click_1(object sender, EventArgs e)
        {
            if (!kiemTra())
            {
                return;
            }
            if (xuLyThem)
            {
                KhuVuc k = new KhuVuc();
                k.TenKhuVuc = txt_tenKhuVuc.Text;
                context.KhuVuc.Add(k);
            }
            else
            {
                int id_khuVuc = (int)dtg_khuVuc.CurrentRow.Cells["KhuVucID"].Value;
                var kv = context.KhuVuc.Find(id_khuVuc);
                if (kv == null)
                {
                    MessageBox.Show("Khu vực không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    kv.TenKhuVuc = txt_tenKhuVuc.Text;
                    context.KhuVuc.Update(kv);
                }
            }
            context.SaveChanges();
            Load_FormKhuVuc();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            phanQuyenNguoiDung(false);
            txt_tenKhuVuc.Text = "";
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            phanQuyenNguoiDung(false);
            txt_tenKhuVuc.Focus();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            id_khuVuc = (int)dtg_khuVuc.CurrentRow.Cells["KhuVucID"].Value;
            if (id_khuVuc == 0)
            {
                MessageBox.Show("Vui lòng chọn khu vực để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var nv_khuVuc = context.NhanVien.Any(n => n.KhuVucID == id_khuVuc);
            var kh_khuVuc = context.KhachHang.Any(n => n.KhuVucID == id_khuVuc);
            if (nv_khuVuc || kh_khuVuc)
            {
                MessageBox.Show("Khu vực này đang được sử dụng,\n không thể xóa bây giờ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var kv = context.KhuVuc.Find(id_khuVuc);
            if (MessageBox.Show("Bạn có muốn xóa khu vực: " + kv.TenKhuVuc ?? "Khu vực không xác định" + " không?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                context.KhuVuc.Remove(kv);
                context.SaveChanges();
                Load_FormKhuVuc();
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            Load_FormKhuVuc();
        }

        private void btn_XuatFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu ra tập tin Excel";
            saveFileDialog.Filter = "Tập tin Excel | *.xls;*.xlsx";
            saveFileDialog.FileName = "KhuVuc_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    dataTable.Columns.Add("KhuVucID", typeof(int));
                    dataTable.Columns.Add("TenKhuVuc", typeof(string));
                    var khuvuc = context.KhuVuc.ToList();
                    if (khuvuc != null)
                    {
                        List<HangSanXuat> ds = new List<HangSanXuat>();
                        if (khuvuc != null)
                        {
                            foreach (var p in khuvuc)
                            {
                                dataTable.Rows.Add(p.KhuVucID, p.TenKhuVuc);
                            }
                        }
                    }
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(dataTable, "KhuVuc");
                        sheet.Columns().AdjustToContents();
                        wb.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Đã xuất dữ liệu Khu Vực ra tập tin Excel thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi Xuất File");
                }
            }
        }

        private void btn_NhapFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Nhập dữ liệu từ tập tin Excel";
            op.Filter = "Tập tin Excel |*.xls ;*.xlsx";
            op.Multiselect = false;
            if (op.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    using (XLWorkbook xlw = new XLWorkbook(op.FileName))
                    {
                        IXLWorksheet xLWorksheet = xlw.Worksheet(1);
                        bool firstRow = true;
                        string ReadRange = "1:1";
                        foreach (IXLRow row in xLWorksheet.RowsUsed())
                        {
                            if (firstRow)
                            {
                                ReadRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                                foreach (IXLCell cell in row.Cells(ReadRange))
                                {
                                    dataTable.Columns.Add(cell.Value.ToString());
                                    firstRow = false;
                                }
                            }
                            else
                            {
                                dataTable.Rows.Add();
                                int cellIndex = 0;
                                foreach (IXLCell cell in row.Cells(ReadRange))
                                {
                                    dataTable.Rows[dataTable.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                    cellIndex++;
                                }
                            }
                        }
                        if (dataTable.Rows.Count > 0)
                        {
                            List<KhuVuc> khuVucMoi= new List<KhuVuc>();
                            var khuVucDatonTai = context.KhuVuc.Select(s => s.TenKhuVuc).ToList();
                            int cout = 0;
                            foreach (DataRow row in dataTable.Rows)
                            {
                                string tenKV = row["TenKhuVuc"].ToString();
                                if (string.IsNullOrEmpty(tenKV)) continue;
                                if (!context.KhuVuc.Any(x => x.TenKhuVuc == tenKV))
                                {
                                    KhuVuc k = new KhuVuc
                                    {
                                        TenKhuVuc = tenKV,
                                    };
                                    khuVucMoi.Add(k);
                                    khuVucDatonTai.Add(tenKV);
                                    cout++;
                                }                                
                            }
                            if (cout > 0)
                            {
                                if (MessageBox.Show("Tìm thấy ( " + cout + " ) khu vực mới !\nBạn có muốn thêm váo danh sách không?", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                {
                                    context.KhuVuc.AddRange(khuVucMoi);
                                    context.SaveChanges();
                                    F_KhuVuc_Load(sender, e);
                                    MessageBox.Show($"Đã nhập thành công {cout} khu vực", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    khuVucMoi.Clear();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không có gì mới cả !!!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }                           
                            if (firstRow)
                            {
                                MessageBox.Show("Tập tin Excel rỗng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }

            }
        }
    }
}