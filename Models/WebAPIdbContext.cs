using DemoApps.MockRepository;
using DemoApps.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPIdemo.Models
{
    public class WebAPIdbContext : DbContext
    {
        public WebAPIdbContext(DbContextOptions options) : base(options) {}
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new MockProduct().GetAllProducts.ToList());
            modelBuilder.Entity<Category>().HasData(new MockCategory().GetAllCategories.ToList());
        }

    }
}
