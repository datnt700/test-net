using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

// Đây là class ApplicationDbContext kế thừa từ DbContext – class cơ sở của Entity Framework Core dùng để kết nối CSDL, định nghĩa các bảng, thực hiện các truy vấn.
//
//     Bạn có thể coi ApplicationDbContext là “cánh cổng” để truy cập vào database của bạn.
public class ApplicationDbContext: DbContext
{
    // Đây là đối tượng cấu hình mà bạn truyền vào khi khởi tạo DbContext.
    //
    //     Nó chứa thông tin như:
    //
    // Loại CSDL (SQL Server, SQLite...)
    //
    // Chuỗi kết nối (connection string)
    //
    // Các tùy chọn logging, lazy loading, tracking.
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    // DbSet
    //     Cho phép bạn dùng LINQ hoặc các phương thức như Add(), Remove(), Find(), ToList() để thao tác với bảng tương ứng trong database.
    public DbSet<Category> Categories { get; set; }
    public DbSet<Cours> Courses { get; set; }
}