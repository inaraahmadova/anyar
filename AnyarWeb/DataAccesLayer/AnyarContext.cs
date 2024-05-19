using AnyarWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnyarWeb.DataAccesLayer
{
    public class AnyarContext : IdentityDbContext
    {
        public AnyarContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=LAPTOP-ACG39MDK\\SQLEXPRESS;Database=Anyar;Trusted_Connection=true;TrustServerCertificate = True;");
            base.OnConfiguring(options);
        }
    }
}
