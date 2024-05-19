using AnyarWeb.DataAccesLayer;
using AnyarWeb.Models;
using Microsoft.AspNetCore.Identity;

namespace AnyarWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AnyarContext>();
            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequiredLength = 3;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.MaxFailedAccessAttempts = 2;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
            })
                .AddEntityFrameworkStores<AnyarContext>()
                .AddDefaultTokenProviders();


            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllerRoute(
                name: "areas",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=home}/{action=index}"
                );
            app.Run();
        }
    }
}
