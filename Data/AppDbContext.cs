using Microsoft.EntityFrameworkCore;
using bai_tap_Advance.Properties.Models;

namespace bai_tap_Advance.Properties.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=QuanLySanPham;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
