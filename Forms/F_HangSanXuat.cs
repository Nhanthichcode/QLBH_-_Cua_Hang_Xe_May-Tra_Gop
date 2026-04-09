using DoAnBanHang_cuahangxemay.Data_Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using DoAnBanHang_cuahangxemay.help;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Bibliography;
using static DoAnBanHang_cuahangxemay.Data_Table.enum_ThongTin;

namespace DoAnBanHang_cuahangxemay.Forms
{
    public partial class F_HangSanXuat : Form
    {
        AppDbContext context = new AppDbContext();
        bool xulythem = false;
        int id_hangsanxuat;
        int id_nguoiDung;
        BindingSource bindingSource = new BindingSource();
        List<DanhSachHangSanXuat> hangSanXuats = new List<DanhSachHangSanXuat>();

        #region Methods
        void phanQuyenNguoiDung(bool tmp)
        {
            var quyen = context.NhanVien.Find(id_nguoiDung);
            if (quyen != null)
            {
                if (quyen.QuyenHan == true)
                {
                    btn_Them.Enabled = btn_Sua.Enabled = btn_NhapFile.Enabled = btn_XuatFile.Enabled = btn_Xoa.Enabled = true;
                    btn_Luulai.Enabled = btn_Huy.Enabled = cbb_trangThai.Enabled = !true;

                    btn_Them.Enabled = btn_Sua.Enabled = btn_Xoa.Enabled = btn_NhapFile.Enabled = btn_XuatFile.Enabled = !tmp;
                    btn_Luulai.Enabled = btn_Huy.Enabled = cbb_trangThai.Enabled = tmp;
                }
                else
                {
                    btn_Them.Enabled = true;
                    btn_Sua.Enabled = btn_NhapFile.Enabled = btn_XuatFile.Enabled = btn_Xoa.Enabled = false;
                    btn_Luulai.Enabled = btn_Huy.Enabled = cbb_trangThai.Enabled = !true;

                    btn_Them.Enabled = !tmp;
                    btn_Luulai.Enabled = btn_Huy.Enabled = cbb_trangThai.Enabled = tmp;
                }
            }
        }
        bool _kiemTraNhap()
        {
            if (string.IsNullOrEmpty(txt_tenhangsanxuat.Text))
            {
                MessageBox.Show("Hãy nhập tên hảng sản xuất", "Thiếu tên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_tenhangsanxuat.Focus();
                return false;
            }

            else if (cbb_trangThai.SelectedIndex == -1)
            {
                MessageBox.Show("Hãy chọn 1 trạng thái", "Thiếu trạng thái", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbb_trangThai.Focus();
                return false;
            }
            return true;
        }
        #endregion


        #region Event
        public F_HangSanXuat(int nhanvienID)
        {
            InitializeComponent();
            id_nguoiDung = nhanvienID;
        }

        private void F_HangSanXuat_Load(object sender, EventArgs e)
        {
            phanQuyenNguoiDung(false);

            try
            {
                hangSanXuats = context.HangSanXuat.Select(x => new DanhSachHangSanXuat
                {
                    HangSanXuatID = x.HangSanXuatID,
                    TenHangSanXuat = x.TenHangSanXuat,
                    TrangThai = x.TrangThai
                }).ToList();
                bindingSource.DataSource = hangSanXuats;

                txt_tenhangsanxuat.DataBindings.Clear();
                txt_tenhangsanxuat.DataBindings.Add("Text", bindingSource, "TenHangSanXuat", false, DataSourceUpdateMode.Never);

                cbb_trangThai.DataBindings.Clear();
                cbb_trangThai.DataBindings.Add("SelectedValue", bindingSource, "TrangThai", false, DataSourceUpdateMode.Never);


                dtg_HangSanXuat.DataSource = bindingSource;
                BindEnumToComboBox(typeof(enum_TrangThai_HSX), cbb_trangThai);

                dtg_HangSanXuat.Columns["TenHangSanXuat"].HeaderText = "Tên hãng";
                dtg_HangSanXuat.Columns["TrangThaiVietnamese"].HeaderText = "Trạng thái";

                dtg_HangSanXuat.Columns["HangSanXuatID"].Visible = false;
                dtg_HangSanXuat.Columns["TrangThai"].Visible = false;  // Ẩn cột TrangThai gốc (chuỗi)
                dtg_HangSanXuat.Columns["TrangThaiValue"].Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (dtg_HangSanXuat.CurrentRow == null || dtg_HangSanXuat.Rows.Count == 0)
            {
                MessageBox.Show("Chọn 1 hàng muốn sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            phanQuyenNguoiDung(true);
            xulythem = false;
            id_hangsanxuat = Convert.ToInt32(dtg_HangSanXuat.CurrentRow.Cells["HangSanXuatID"].Value.ToString());
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            int id_hangsanxuat = Convert.ToInt32(dtg_HangSanXuat.CurrentRow.Cells["HangSanXuatID"].Value.ToString());
            HangSanXuat h = context.HangSanXuat.Find(id_hangsanxuat);
            if (h != null)
            {
                if (MessageBox.Show($"Bạn có muốn xóa hảng sản xuất {h.TenHangSanXuat} không ?", "Xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    context.HangSanXuat.Remove(h);
                    context.SaveChanges();
                    F_HangSanXuat_Load(sender, e);
                }
            }
        }

        private void btn_luulai_Click(object sender, EventArgs e)
        {
            if (!_kiemTraNhap())
            {
                return;
            }
            else
            {
                if (xulythem)
                {
                    HangSanXuat h = new HangSanXuat();
                    h.TenHangSanXuat = txt_tenhangsanxuat.Text;
                    h.TrangThai = ((enum_ThongTin.enum_TrangThai_HSX)cbb_trangThai.SelectedValue).ToString();
                    context.HangSanXuat.Add(h);
                }
                else
                {
                    HangSanXuat h = context.HangSanXuat.Find(id_hangsanxuat);
                    if (h != null)
                    {
                        h.TenHangSanXuat = txt_tenhangsanxuat.Text;
                        h.TrangThai = ((enum_ThongTin.enum_TrangThai_HSX)cbb_trangThai.SelectedValue).ToString();

                        context.HangSanXuat.Update(h);
                    }
                }
                context.SaveChanges();
                F_HangSanXuat_Load(sender, e);
            }
        }

        private void btn_huybo_Click(object sender, EventArgs e)
        {
            F_HangSanXuat_Load(sender, e);
        }

        private void btn_xuatFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu ra tập tin Excel";
            saveFileDialog.Filter = "Tập tin Excel | *.xls;*.xlsx";
            saveFileDialog.FileName = "HangSanXuat_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    dataTable.Columns.Add("HangSanXuatID", typeof(int));
                    dataTable.Columns.Add("TenHangSanXuat", typeof(string));
                    dataTable.Columns.Add("TrangThai", typeof(string));
                    var hangSanXuat = context.HangSanXuat.ToList();
                    if (hangSanXuat != null)
                    {
                        List<HangSanXuat> ds = new List<HangSanXuat>();
                        if (hangSanXuat != null)
                        {
                            foreach (var p in hangSanXuat)
                            {
                                dataTable.Rows.Add(p.HangSanXuatID, p.TenHangSanXuat, p.TrangThai);
                            }
                        }
                    }
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(dataTable, "HangSanXuat");
                        sheet.Columns().AdjustToContents();
                        wb.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Đã xuất dữ liệu Hãng Sản Xuất ra tập tin Excel thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi Xuất File");
                }
            }

        }

        private void btn_nhapFile_Click(object sender, EventArgs e)
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
                            List<HangSanXuat> hsxNew = new List<HangSanXuat>();
                            int cout = 0;
                            var tenDaTonTai = context.HangSanXuat.Select(x => x.TenHangSanXuat.ToLower()).ToHashSet();
                            foreach (DataRow row in dataTable.Rows)
                            {
                                string tenHangSanXuat = row["TenHangSanXuat"].ToString().Trim();
                                if (string.IsNullOrEmpty(tenHangSanXuat)) continue;
                                if (!tenDaTonTai.Contains(tenHangSanXuat.ToLower()))
                                {
                                    HangSanXuat s = new HangSanXuat
                                    {
                                        TenHangSanXuat = tenHangSanXuat,
                                        TrangThai = row["TrangThai"].ToString()
                                    };
                                    hsxNew.Add(s);
                                    tenDaTonTai.Add(tenHangSanXuat.ToLower());
                                    cout++;
                                }
                            }
                            if (cout > 0)
                            {
                                if (MessageBox.Show("Tìm thấy ( " + cout + " ) Hảng sản xuất !\nBạn có muốn thêm váo danh sách không?", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                {
                                    context.HangSanXuat.AddRange(hsxNew);
                                    context.SaveChanges();
                                    F_HangSanXuat_Load(sender, e);
                                    MessageBox.Show($"Đã nhập thành công {cout} Hảng Sản Xuất", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    hsxNew.Clear();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không có gì mới cả !!!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                        }
                        if (firstRow)
                        {
                            MessageBox.Show("Tập tin Excel rỗng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }
        private void dtg_HangSanXuat_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra rằng chỉ nhấp vào một dòng (không phải tiêu đề)
            {
                cbb_trangThai.SelectedValue = Convert.ToInt32(dtg_HangSanXuat.CurrentRow.Cells["TrangThaiValue"].Value);
            }
        }
        private void pictureBox_troVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            txt_tenhangsanxuat.Clear();
            phanQuyenNguoiDung(true);
            xulythem = true;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            F_Help helpForm = new F_Help("hangsanxuat"); // "login" là tên tương ứng file login.txt
            helpForm.ShowDialog();
        }
        #endregion
    }
}
