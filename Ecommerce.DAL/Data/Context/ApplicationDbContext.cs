using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed initial data
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // Seed categories
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Clothing" }
            // Add more categories as needed
        );

        // Seed products
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                CategoryId = 1,
                ProductCode = "PROD001",
                Name = "Smartphone",
                ImagePath = "/images/smartphone.jpg",
                Price = 499.99m,
                MinimumQuantity = 1,
                DiscountRate = 5
            },
            new Product
            {
                Id = 2,
                CategoryId = 2,
                ProductCode = "PROD002",
                Name = "T-Shirt",
                ImagePath = "/images/tshirt.jpg",
                Price = 19.99m,
                MinimumQuantity = 1,
                DiscountRate = 8
            }
            // Add more products as needed
        );

        // Seed users
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Username = "john_doe",
                Password = "password123",
                Email = "john@example.com",
                LastLoginTime = DateTime.UtcNow
            }
            // Add more users as needed
        );

        // Seed user-product associations (if necessary)
    }

}
