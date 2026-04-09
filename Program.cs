using DoAnBanHang_cuahangxemay.Data_Table;
using DoAnBanHang_cuahangxemay.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DoAnBanHang_cuahangxemay;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        try
        {
            // Kiểm tra sự tồn tại của appsettings.json trước khi đọc cấu hình
            string configPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            if (!File.Exists(configPath))
            {
                MessageBox.Show("Không tìm thấy file cấu hình: appsettings.json", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Khởi tạo cấu hình từ appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Kiểm tra kết nối có hợp lệ không
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Chuỗi kết nối không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Khởi tạo DbContextOptions với cấu hình đúng
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            using var db = new AppDbContext(optionsBuilder.Options);

            // Kiểm tra nếu cơ sở dữ liệu chưa tồn tại
            if (!db.Database.CanConnect())
            {
                MessageBox.Show("Cơ sở dữ liệu chưa tồn tại. Đang tạo mới...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 db.Database.EnsureCreated(); // Tạo mới nếu chưa có

                if (!db.Database.CanConnect())
                {
                    MessageBox.Show("Không thể kết nối với cơ sở dữ liệu ngay cả sau khi tạo mới. Kiểm tra lại cấu hình.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Khởi động ứng dụng
            ApplicationConfiguration.Initialize();
            Application.Run(new F_MainTrangChu());
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khởi động ứng dụng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
