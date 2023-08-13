using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SoccerClub.Data;
namespace SoccerClub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<SoccerClubContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SoccerClubContext") ?? throw new InvalidOperationException("Connection string 'SoccerClubContext' not found.")));
            builder.Services.AddSession(x =>
            {
                x.IdleTimeout = TimeSpan.FromMinutes(5);
                x.Cookie.IsEssential = true;
            });
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseCookiePolicy();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}