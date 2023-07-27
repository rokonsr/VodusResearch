using Microsoft.EntityFrameworkCore;
using VodusResearch.Models;

namespace VodusResearch.Context
{
    public class ProductDbContext : DbContext
    {
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ProductDbContext(DbContextOptions<ProductDbContext> context) : base(context) { }
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().ToTable(nameof(User), t => t.ExcludeFromMigrations());
            //modelBuilder.Entity<Logger>().ToTable(nameof(Logger), t => t.ExcludeFromMigrations());

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Mobile",
                Description = "Apple Mobile",
                Price = 1000
            },
            new Product
            {
                Id = 2,
                Name = "Laptop",
                Description = "Mac Book Pro",
                Price = 2500
            },
            new Product
            {
                Id = 3,
                Name = "Headphone",
                Description = "Headphone for call",
                Price = 500
            });
        }
    }
}
