using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DoAnBanHang_cuahangxemay.Data_Table
{
    public static class enum_ThongTin
    {
        public enum enum_HoaDon
        {
            [Description("Đã thanh toán")]
            DaThanhToan = 0,

            [Description("Đang thanh toán")]
            DangThanhToan = 1,

            [Description("Chưa thanh toán")]
            ChuaThanhToan = 2,

            [Description("Đã hủy")]
            DaHuy = 3,

            [Description("Đã khôi phục")]
            DaKhoiPhuc = 4,
        }

        public enum enum_QuyenHan
        {
            [Description("Admin")]
            Admin = 0,

            [Description("Nhân viên")]
            NhanVien = 1,

            [Description("Khách hàng")]
            KhachHang = 2,
        }

        public enum enum_PhuongThucThanhToan
        {
            [Description("Tiền mặt")]
            TienMat = 0,

            [Description("Chuyển khoản")]
            ChuyenKhoan = 1,

            [Description("Thẻ ngân hàng")]
            TheNganHang = 2,

            [Description("Trả góp")]
            TraGop = 3
        }

        public enum enum_TrangThaiThanhToan
        {
            [Description("Mới tạo")]
            MoiTao = 0,

            [Description("Đã thanh toán")]
            DaThanhToan = 1,

            [Description("Đang thanh toán")]
            DangThanhToan = 2,

            [Description("Chưa thanh toán")]
            ChuaThanhToan = 3,
        }

        public enum enum_TrangThai_HSX
        {
            [Description("Đang hoạt động")]
            DangHoatDong = 0,

            [Description("Ngừng hoạt động")]
            NgungHoatDong = 1,

            [Description("Đang cập nhật")]
            DangCapNhat = 2
        }

        public enum enum_SanPham_TrangThai
        {
            [Description("Còn hàng")]
            ConHang = 0,
            [Description("Hết hàng")]
            HetHang = 1,
            [Description("Đang nhập hàng")]
            DangNhaphang = 2,
        }

        // Hàm lấy mô tả từ enum
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }

        // Hàm lấy danh sách mô tả để hiển thị lên ComboBox
        public static Dictionary<int, string> GetEnumDescriptions(Type enumType)
        {
            if (!enumType.IsEnum)
                throw new ArgumentException("Type must be an enum");

            var descriptions = new Dictionary<int, string>();
            foreach (Enum value in Enum.GetValues(enumType))
            {
                int intValue = Convert.ToInt32(value);
                string description = value.GetDescription();
                descriptions.Add(intValue, description);
            }
            return descriptions;
        }

        // Hàm bind dữ liệu vào ComboBox
        public static void BindEnumToComboBox(Type enumType, ComboBox comboBox)
        {            
            var descriptions = GetEnumDescriptions(enumType);
            comboBox.DataSource = new BindingSource(descriptions, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }
    }
}