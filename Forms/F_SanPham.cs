using ClosedXML.Excel;
using DoAnBanHang_cuahangxemay.Data_Table;
using DoAnBanHang_cuahangxemay.Forms;
using DoAnBanHang_cuahangxemay.help;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.InkML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DoAnBanHang_cuahangxemay.Data_Table.enum_ThongTin;
using static DoAnBanHang_cuahangxemay.Data_Table.SanPham;
namespace DoAnBanHang_cuahangxemay.Forms
{
    public partial class F_SanPham : Form
    {
        // các khai báo biến
        AppDbContext context = new AppDbContext();
        bool xulythem = false;
        int id_sanPham;
        string image_filePath = "";
        string imageFolder = Application.StartupPath.Replace("bin\\Debug\\net5.0-windows", "images");
        BindingSource bindingSource = new BindingSource();
        int quyenNguoiDung = 3;
        int nhanVienID;
        List<DanhSachSanPham> dsach = new List<DanhSachSanPham>();

        #region Methods
        void phanQuyenNguoiDung()
        {
            if (quyenNguoiDung == 1) // nếu là admin thì cho phép thêm, sửa, xóa
            {
                btn_Them.Enabled = btn_Sua.Enabled = btn_Xoa.Enabled = btn_NhapFile.Enabled = btn_XuatFile.Enabled = btn_DoiAnh.Enabled = true;
                btn_Huybo.Enabled = btn_ChonAnh.Enabled = false;
            }
            else if (quyenNguoiDung == 0) // nếu là nhân viên thì chỉ cho phép sửa và xóa
            {
                btn_Them.Enabled = true;
                btn_Huybo.Enabled = btn_DoiAnh.Enabled = btn_Sua.Enabled = btn_Xoa.Enabled = btn_NhapFile.Enabled = btn_XuatFile.Enabled = btn_Luu.Enabled = btn_ChonAnh.Enabled = !true;
            }
            else // nếu là khách hàng thì không cho phép thêm, sửa, xóa
            {
                btn_Them.Enabled = btn_Sua.Enabled = btn_Xoa.Enabled
                = btn_NhapFile.Enabled = btn_XuatFile.Enabled
                = btn_DoiAnh.Enabled = btn_Huybo.Enabled = btn_ChonAnh.Enabled = btn_Luu.Enabled = false;
            }
        }
        void BatTatChucNang(bool tmp)
        {

            var quyenhan = context.NhanVien.Find(nhanVienID);
            if (quyenhan == null)
            {
                quyenNguoiDung = 2; // khách hàng
            }
            else
            {
                quyenNguoiDung = quyenhan.QuyenHan == true ? 1 : 0;
            }

            if (quyenNguoiDung == 1) // nếu là admin thì cho phép thêm, sửa, xóa
            {
                //btn_Them.Enabled = btn_Sua.Enabled = btn_Xoa.Enabled = true;
                btn_Them.Enabled = btn_Sua.Enabled = btn_Xoa.Enabled = btn_NhapFile.Enabled = btn_XuatFile.Enabled = btn_DoiAnh.Enabled = tmp;
                btn_Luu.Enabled = btn_Huybo.Enabled = btn_ChonAnh.Enabled = cbb_trangThaiSanPham.Enabled = cbb_hangsx.Enabled = !tmp;
            }
            else if (quyenNguoiDung == 0)// nếu là nhân viên thì chỉ cho phép sửa và xóa
            {
                btn_Them.Enabled = tmp; //bật nút
                btn_ChonAnh.Enabled = btn_Luu.Enabled = btn_Huybo.Enabled = cbb_trangThaiSanPham.Enabled = cbb_hangsx.Enabled = !tmp; //tắt nút
            }
            else // nếu là khách hàng thì không cho phép thêm, sửa, xóa
            {
                btn_Them.Enabled = btn_Sua.Enabled = btn_Xoa.Enabled
                = btn_NhapFile.Enabled = btn_XuatFile.Enabled
                = btn_DoiAnh.Enabled = btn_Huybo.Enabled
                = btn_ChonAnh.Enabled = btn_Luu.Enabled
                = cbb_trangThaiSanPham.Enabled = cbb_hangsx.Enabled = false;
            }
            btn_DoiAnh.Enabled = false; // tắt nút đổi ảnh
        }

        bool KiemTraLoi()
        {
            if (pic_hinhAnhSanPham.Image == null)
            {
                MessageBox.Show("Hãy chọn 1 hình ảnh cho sản phầm", "Chọn ảnh", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                return false;
            }
            if (txt_mota.Text == "")
            {
                MessageBox.Show("Hãy nhập mô tả cho sản phầm", "Nhập mô tả", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txt_mota.Focus();
                return false;
            }
            if (txt_tenSP.Text == "")
            {
                MessageBox.Show("Hãy tên cho sản phầm", "Nhập tên", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txt_tenSP.Focus();
                return false;
            }
            if (cbb_trangThaiSanPham.SelectedIndex == -1)
            {
                MessageBox.Show("Hãy cho khách hàng biết trạng thái của sản phẩm", "Nhập trạng thái", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (num_giaBan.Value == 0)
            {
                MessageBox.Show("Giá của sản phẩm đang sai", "Sai về giá", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                num_giaBan.Focus();
                return false;
            }
            return true;
        }
        void batTatGiaTri()
        {
            txt_mota.Clear();
            txt_tenSP.Clear();
            pic_hinhAnhSanPham.Image = null;
            num_giaBan.Value = 0;
            num_soLuongTon.Value = 0;
            //cbb_hangsx.SelectedIndex = 0;
        }
        void load_cbbHangsx()
        {
            cbb_hangsx.DataSource = context.HangSanXuat.Distinct().ToList();
            cbb_hangsx.DisplayMember = "TenHangSanXuat";
            cbb_hangsx.ValueMember = "HangSanXuatID";
        }

        #endregion

        #region Event

        public F_SanPham(int nhanvienID)
        {
            InitializeComponent();
            nhanVienID = nhanvienID;
            pic_hinhAnhSanPham.AllowDrop = true;
        }
        private void F_SanPham_Load(object sender, EventArgs e)
        {
            load_sanPham();
        }
        void load_sanPham()
        {
            dsach = context.SanPham.Select(r => new DanhSachSanPham
            {
                SanPhamID = r.SanPhamID,
                HangSanXuatID = r.HangSanXuatID,
                TenHangSanXuat = r.HangSanXuat.TenHangSanXuat,
                GiaBan = r.GiaBan,
                TrangThai = r.TrangThai,
                TenSanPham = r.TenSanPham,
                SoLuongTon = r.SoLuongTon,
                NamSX = r.NamSX,
                MoTa = r.MoTa ?? string.Empty,
                HinhAnh = r.HinhAnh ?? string.Empty,
            }).ToList();

            bindingSource.DataSource = dsach;

            // Các binding khác giữ nguyên...

            // Sửa binding cho ComboBox trạng thái
            cbb_trangThaiSanPham.DataBindings.Clear();
            cbb_trangThaiSanPham.DataBindings.Add("SelectedValue", bindingSource, "TrangThaiValue", false, DataSourceUpdateMode.Never);

            txt_mota.DataBindings.Clear();
            txt_mota.DataBindings.Add("Text", bindingSource, "MoTa", false, DataSourceUpdateMode.Never);

            txt_tenSP.DataBindings.Clear();
            txt_tenSP.DataBindings.Add("Text", bindingSource, "TenSanPham", false, DataSourceUpdateMode.Never);

            num_giaBan.DataBindings.Clear();
            num_giaBan.DataBindings.Add("Value", bindingSource, "GiaBan", false, DataSourceUpdateMode.Never);

            num_soLuongTon.DataBindings.Clear();
            num_soLuongTon.DataBindings.Add("Value", bindingSource, "SoLuongTon", false, DataSourceUpdateMode.Never);

            dtpic_namSX.DataBindings.Clear();
            dtpic_namSX.DataBindings.Add("Value", bindingSource, "NamSX", true, DataSourceUpdateMode.Never);

            cbb_hangsx.DataBindings.Clear();
            cbb_hangsx.DataBindings.Add("SelectedValue", bindingSource, "HangSanXuatID", false, DataSourceUpdateMode.Never);

            cbb_trangThaiSanPham.DataBindings.Clear();
            cbb_trangThaiSanPham.DataBindings.Add("SelectedValue", bindingSource, "TrangThai", false, DataSourceUpdateMode.Never);

            pic_hinhAnhSanPham.DataBindings.Clear();
            Binding imageBinding = new Binding("ImageLocation", bindingSource, "HinhAnh", true);
            imageBinding.Format += (sender, e) =>
            {
                if (string.IsNullOrEmpty(e.Value?.ToString()))
                {
                    e.Value = null; // Hoặc đường dẫn ảnh mặc định
                }
                else
                {
                    string fullPath = Path.Combine(imageFolder, e.Value.ToString());
                    e.Value = File.Exists(fullPath) ? fullPath : null;
                }
            };
            imageBinding.Parse += (sender, e) =>
            {
                // Xử lý khi cần update ngược từ control vào datasource
                if (e.Value != null)
                {
                    e.Value = Path.GetFileName(e.Value.ToString());
                }
            };
            pic_hinhAnhSanPham.DataBindings.Add(imageBinding);

            dtg_sanPham.DataSource = bindingSource;

            BindEnumToComboBox(typeof(enum_ThongTin.enum_SanPham_TrangThai), cbb_trangThaiSanPham);
            load_cbbHangsx();
            BatTatChucNang(true);
            phanQuyenNguoiDung();
            batTatGiaTri();
            themThuocTinh();
        }
        void themThuocTinh()
        {
            dtg_sanPham.Columns["SanPhamID"].Visible = false;
            dtg_sanPham.Columns["HangSanXuatID"].Visible = false;
            dtg_sanPham.Columns["HinhAnh"].Visible = false;

            dtg_sanPham.Columns["GiaBan"].DefaultCellStyle.Format = "#,##0 'VNĐ'";
            dtg_sanPham.Columns["MoTa"].HeaderText = "Mô tả";
            dtg_sanPham.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            dtg_sanPham.Columns["TenHangSanXuat"].HeaderText = "Hảng sản xuất";
            dtg_sanPham.Columns["NamSX"].HeaderText = "Năm sản xuất";
            dtg_sanPham.Columns["SoLuongTon"].HeaderText = "Số lượng tồn";
            dtg_sanPham.Columns["GiaBan"].HeaderText = "Giá bán";
            dtg_sanPham.Columns["TrangThaiVietnamese"].HeaderText = "Trạng thái";

            dtg_sanPham.Columns["TrangThai"].Visible = false;  // Ẩn cột TrangThai gốc (chuỗi)
            dtg_sanPham.Columns["TrangThaiValue"].Visible = false;

            //dtg_sanPham.Columns["TrangThaiHienThi"].HeaderText = "Trạng thái";

        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            batTatGiaTri();
            xulythem = true;
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            xulythem = false;
            pic_hinhAnhSanPham.Image = null;
            id_sanPham = Convert.ToInt32(dtg_sanPham.CurrentRow.Cells["SanPhamID"].Value.ToString());
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            id_sanPham = Convert.ToInt32(dtg_sanPham.CurrentRow.Cells["SanPhamID"].Value.ToString());
            SanPham sp = context.SanPham.Find(id_sanPham);
            var isTonTai = context.HoaDon_ChiTiet.Where(ct => ct.SanPhamID == id_sanPham).Count();
            if (isTonTai > 0)
            {
                MessageBox.Show("Không thể xóa sản phẩm này vì đã có hóa đơn liên quan", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (sp != null)
            {
                if (MessageBox.Show($"Bạn có muốn xóa Sản phẩm {sp.TenSanPham} không ?", "Xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    context.SanPham.Remove(sp);
                    context.SaveChanges();
                    F_SanPham_Load(sender, e);
                }
            }

        }

        private void btn_luulai_Click(object sender, EventArgs e)
        {
            if (KiemTraLoi())
            {
                if (xulythem)
                {
                    SanPham s = new SanPham();
                    s.HangSanXuatID = Convert.ToInt32(cbb_hangsx.SelectedValue?.ToString() ?? "");
                    s.TenSanPham = txt_tenSP.Text;
                    s.MoTa = txt_mota.Text;
                    int namsx = dtpic_namSX.Value.Year;
                    s.NamSX = namsx;
                    s.TrangThai = ((enum_ThongTin.enum_SanPham_TrangThai)cbb_trangThaiSanPham.SelectedValue).ToString();
                    s.SoLuongTon = Convert.ToInt32(num_soLuongTon.Value);
                    s.GiaBan = decimal.Parse(num_giaBan.Value.ToString());
                    s.HinhAnh = image_filePath;
                    context.SanPham.Add(s);
                }
                else
                {
                    SanPham s = context.SanPham.Find(id_sanPham);
                    if (s != null)
                    {
                        s.HangSanXuatID = Convert.ToInt32(cbb_hangsx.SelectedValue?.ToString() ?? "");
                        s.TenSanPham = txt_tenSP.Text;
                        s.MoTa = txt_mota.Text;
                        int namsx = dtpic_namSX.Value.Year;
                        s.NamSX = namsx;
                        s.TrangThai = s.TrangThai = ((enum_ThongTin.enum_SanPham_TrangThai)cbb_trangThaiSanPham.SelectedValue).ToString();
                        s.SoLuongTon = Convert.ToInt32(num_soLuongTon.Value);
                        s.GiaBan = decimal.Parse(num_giaBan.Value.ToString());
                        s.HinhAnh = image_filePath;

                        context.SanPham.Update(s);
                    }
                }
                context.SaveChanges();
                F_SanPham_Load(sender, e);
            }

        }


        private void btn_huy_Click(object sender, EventArgs e)
        {
            F_SanPham_Load(sender, e);
        }

        private void btn_xuatFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu ra tập tin Excel";
            saveFileDialog.Filter = "Tập tin Excel | *.xls;*.xlsx";
            saveFileDialog.FileName = "SanPham_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    dataTable.Columns.Add("SanPhamID", typeof(int));
                    dataTable.Columns.Add("HangSanXuatID", typeof(int));
                    dataTable.Columns.Add("TenHangSanXuat", typeof(string));
                    dataTable.Columns.Add("TenSanPham", typeof(string));
                    dataTable.Columns.Add("GiaBan", typeof(decimal));
                    dataTable.Columns.Add("SoLuongTon", typeof(int));
                    dataTable.Columns.Add("HinhAnh", typeof(string));
                    dataTable.Columns.Add("MoTa", typeof(string));
                    dataTable.Columns.Add("NamSX", typeof(int));
                    dataTable.Columns.Add("TrangThai", typeof(string));
                    var sanPham = context.SanPham.ToList();
                    if (sanPham != null)
                    {
                        List<DanhSachSanPham> ds = new List<DanhSachSanPham>();
                        foreach (var p in sanPham)
                        {
                            ds = context.SanPham.Select(r => new DanhSachSanPham
                            {
                                SanPhamID = r.SanPhamID,
                                HangSanXuatID = r.HangSanXuat.HangSanXuatID,
                                TenHangSanXuat = r.HangSanXuat.TenHangSanXuat,
                                TenSanPham = r.TenSanPham,
                                GiaBan = r.GiaBan,
                                SoLuongTon = r.SoLuongTon,
                                MoTa = r.MoTa ?? "Không cớ",
                                NamSX = r.NamSX,
                                HinhAnh = r.HinhAnh,
                                TrangThai = r.TrangThai,
                            }).ToList();
                        }
                        foreach (var item in ds)
                        {
                            DataRow row = dataTable.NewRow();
                            row["SanPhamID"] = item.SanPhamID;
                            row["HangSanXuatID"] = item.HangSanXuatID;
                            row["TenHangSanXuat"] = item.TenHangSanXuat;
                            row["TenSanPham"] = item.TenSanPham;
                            row["GiaBan"] = item.GiaBan;
                            row["SoLuongTon"] = item.SoLuongTon;
                            row["MoTa"] = item.MoTa;
                            row["HinhAnh"] = item.HinhAnh;
                            row["NamSX"] = item.NamSX;
                            row["TrangThai"] = item.TrangThai;
                            dataTable.Rows.Add(row);
                        }
                    }
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(dataTable, "SanPham");
                        sheet.Columns().AdjustToContents();
                        wb.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Đã xuất dữ liệu sản phẩm ra tập tin Excel thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }

        }

        private void btn_nhapFile_Click(object sender, EventArgs e)
        {
            batTatGiaTri();
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
                            foreach (DataRow row in dataTable.Rows)
                            {
                                SanPham s = new SanPham();
                                s.HangSanXuatID = Convert.ToInt32(row["HangSanXuatID"].ToString());
                                s.TrangThai = (row["TrangThai"].ToString());
                                s.SoLuongTon = Convert.ToInt32(row["SoLuongTon"].ToString());
                                s.GiaBan = Convert.ToInt32(row["GiaBan"].ToString());
                                s.MoTa = (row["MoTa"].ToString());
                                s.HinhAnh = (row["HinhAnh"].ToString());
                                s.NamSX = Convert.ToInt32(row["NamSX"].ToString());
                                s.TenSanPham = row["TenSanPham"].ToString();
                                context.SanPham.Add(s);
                            }
                            context.SaveChanges();
                            MessageBox.Show($"Đã nhập thành công {dataTable.Rows.Count} Sản Phẩm", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            F_SanPham_Load(sender, e);

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

        private void btn_chonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Cập nhật hình ảnh sản phẩm";
            openFileDialog.Filter = "Tập tin hình ảnh|*.jpg;*.jpeg;*.png;*.gif;*.bmp"; openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy tên và phần mở rộng của tệp
                string fileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                string ext = Path.GetExtension(openFileDialog.FileName);
                // Xác định đường dẫn lưu hình ảnh
                string fileSavePath = Path.Combine(imageFolder, fileName + ext);
                try
                {
                    // Giải phóng tài nguyên hình ảnh trong PictureBox nếu có
                    if (pic_hinhAnhSanPham.Image != null)
                    {
                        pic_hinhAnhSanPham.Image.Dispose();
                        pic_hinhAnhSanPham.Image = null;
                    }
                    // Sao chép tệp hình ảnh vào thư mục đích
                    File.Copy(openFileDialog.FileName, fileSavePath, true);
                    // Thêm hình ảnh vào PictureBox (nếu cần)
                    image_filePath = fileName + ext;
                    pic_hinhAnhSanPham.Image = Image.FromFile(fileSavePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn_doiAnh_Click(object sender, EventArgs e)
        {
            if (dtg_sanPham.CurrentRow == null || dtg_sanPham.CurrentRow.Cells["SanPhamID"].Value == null)
            {
                MessageBox.Show("Chọn sản phẩm muốn đổi ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                id_sanPham = Convert.ToInt32(dtg_sanPham.CurrentRow.Cells["SanPhamID"].Value.ToString());

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Cập nhật hình ảnh sản phẩm";
                openFileDialog.Filter = "Tập tin hình ảnh|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy tên và phần mở rộng của tệp
                    string fileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                    string ext = Path.GetExtension(openFileDialog.FileName);

                    // Xác định đường dẫn lưu hình ảnh
                    string fileSavePath = Path.Combine(imageFolder, fileName + ext);

                    try
                    {
                        // Giải phóng tài nguyên hình ảnh trong PictureBox nếu có
                        var oldImage = pic_hinhAnhSanPham.Image;
                        pic_hinhAnhSanPham.Image = null;
                        oldImage?.Dispose();

                        // Sao chép tệp hình ảnh vào thư mục đích
                        File.Copy(openFileDialog.FileName, fileSavePath, true);

                        // Lấy ID sản phẩm và cập nhật hình ảnh trong cơ sở dữ liệu
                        var sp = context.SanPham.Find(id_sanPham);
                        if (sp != null)
                        {
                            try
                            {
                                sp.HinhAnh = fileName + ext;
                                context.SanPham.Update(sp);
                                context.SaveChanges();
                                F_SanPham_Load(sender, e);
                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message); }
                        }
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"Lỗi khi sao chép hình ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void pictureBox_troVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            F_Help helpForm = new F_Help("sanpham"); // "login" là tên tương ứng file login.txt
            helpForm.ShowDialog();
        }

        #endregion

        private void textBox_searchByName_TextChanged(object sender, EventArgs e)
        {
            if (textBox_searchByName.Text != "")
            {
                textBox_searchByHSX.Clear();
                var searchName = textBox_searchByName.Text.ToLower();
                var filteredList = context.SanPham
                    .Where(p => p.TenSanPham.ToLower().Contains(searchName))
                    .Select(r => new DanhSachSanPham
                    {
                        SanPhamID = r.SanPhamID,
                        HangSanXuatID = r.HangSanXuatID,
                        TenHangSanXuat = r.HangSanXuat.TenHangSanXuat,
                        GiaBan = r.GiaBan,
                        TrangThai = r.TrangThai,
                        TenSanPham = r.TenSanPham,
                        SoLuongTon = r.SoLuongTon,
                        NamSX = r.NamSX,
                        MoTa = r.MoTa ?? "",
                        HinhAnh = r.HinhAnh,
                    }).ToList();
                bindingSource.DataSource = filteredList;
                themThuocTinh();
            }
            else
            {
                F_SanPham_Load(sender, e);
            }
        }

        private void textBox_searchByHSX_TextChanged(object sender, EventArgs e)
        {
            if (textBox_searchByHSX.Text != "")
            {
                textBox_searchByName.Clear();
                var searchHSX = textBox_searchByHSX.Text.ToLower();
                var filteredList = context.SanPham
                    .Where(p => p.HangSanXuat.TenHangSanXuat.ToLower().Contains(searchHSX))
                    .Select(r => new DanhSachSanPham
                    {
                        SanPhamID = r.SanPhamID,
                        HangSanXuatID = r.HangSanXuatID,
                        TenHangSanXuat = r.HangSanXuat.TenHangSanXuat,
                        GiaBan = r.GiaBan,
                        TrangThai = r.TrangThai,
                        TenSanPham = r.TenSanPham,
                        SoLuongTon = r.SoLuongTon,
                        NamSX = r.NamSX,
                        MoTa = r.MoTa ?? "",
                        HinhAnh = r.HinhAnh,
                    }).ToList();
                bindingSource.DataSource = filteredList;
                themThuocTinh();
            }
            else
            {
                F_SanPham_Load(sender, e);
            }
        }

        private void dtg_sanPham_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void pic_hinhAnhSanPham_DragDrop(object sender, DragEventArgs e)
        {
            id_sanPham = Convert.ToInt32(dtg_sanPham.CurrentRow.Cells["SanPhamID"].Value.ToString());
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string file = files[0];
                string ext = Path.GetExtension(file).ToLower();

                // Kiểm tra loại file ảnh hợp lệ
                if (!new[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif" }.Contains(ext))
                {
                    MessageBox.Show("Chỉ hỗ trợ file ảnh!");
                    return;
                }

                string fileName = Path.GetFileName(file);
                string destPath = Path.Combine(imageFolder, fileName);

                try
                {
                    // Kiểm tra thư mục đích có tồn tại không, nếu không thì tạo mới
                    if (!Directory.Exists(imageFolder))
                    {
                        Directory.CreateDirectory(imageFolder);
                    }

                    // Giải phóng tài nguyên hình ảnh trong PictureBox
                    if (pic_hinhAnhSanPham.Image != null)
                    {
                        var oldImage = pic_hinhAnhSanPham.Image;
                        pic_hinhAnhSanPham.Image = null;
                        oldImage.Dispose();
                        GC.Collect(); // Gọi garbage collector để giải phóng tài nguyên ngay lập tức
                    }

                    // Tạo tên file mới để tránh xung đột
                    string newFileName = $"{Path.GetFileNameWithoutExtension(fileName)}_{DateTime.Now:yyyyMMddHHmmss}{ext}";
                    string newDestPath = Path.Combine(imageFolder, newFileName);

                    // Đọc file với FileStream và copy với buffer
                    using (FileStream sourceStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (FileStream destStream = new FileStream(newDestPath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            byte[] buffer = new byte[1024 * 1024]; // Buffer 1MB
                            int bytesRead;
                            while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                destStream.Write(buffer, 0, bytesRead);
                            }
                        }
                    }

                    // Lấy ID sản phẩm và cập nhật hình ảnh trong cơ sở dữ liệu
                    var sp = context.SanPham.Find(id_sanPham);
                    if (sp != null)
                    {
                        // Xóa file ảnh cũ nếu tồn tại
                        if (!string.IsNullOrEmpty(sp.HinhAnh))
                        {
                            string oldImagePath = Path.Combine(imageFolder, sp.HinhAnh);
                            try
                            {
                                if (File.Exists(oldImagePath))
                                {
                                    File.Delete(oldImagePath);
                                }
                            }
                            catch (IOException ex)
                            {
                                // Nếu không xóa được file cũ, có thể bỏ qua hoặc log lại
                                Debug.WriteLine($"Không thể xóa file ảnh cũ: {ex.Message}");
                            }
                        }

                        sp.HinhAnh = newFileName;
                        context.SaveChanges();

                        // Hiển thị ảnh mới
                        using (var tempImage = new Bitmap(newDestPath))
                        {
                            pic_hinhAnhSanPham.Image = new Bitmap(tempImage);
                        }

                        // Làm mới dữ liệu nếu cần
                        F_SanPham_Load(sender, e);
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Lỗi khi sao chép hình ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pic_hinhAnhSanPham_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string ext = Path.GetExtension(files[0]).ToLower();

                if (new[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif" }.Contains(ext))
                {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }
            e.Effect = DragDropEffects.None;
        }

        private void dtg_sanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cbb_trangThaiSanPham.SelectedValue = Convert.ToInt32(dtg_sanPham.CurrentRow.Cells["TrangThaiValue"].Value);
            }
        }
    }
}



