using Microsoft.EntityFrameworkCore;
using NguyenNhuToi2410900075_exam.Models;

namespace NguyenNhuToi2410900075_exam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Lấy chuỗi kết nối từ appsettings.json
            var nntConnection = builder.Configuration.GetConnectionString("NntStudentConnection");
            builder.Services.AddDbContext<NntStudent2410900075DbContext>(x => x.UseSqlServer(nntConnection));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
