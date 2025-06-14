using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

// builder.Services	Truy cập vào dịch vụ Dependency Injection container trong ASP.NET Core
// AddDbContext<ApplicationDbContext>()	Đăng ký ApplicationDbContext để nó có thể được inject ở các nơi khác
// options => options.UseSqlite(...)	Cấu hình để EF Core biết dùng SQLite làm database provider
// builder.Configuration.GetConnectionString("DefaultConnection")	Lấy chuỗi kết nối từ appsettings.json phần "ConnectionStrings"
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
