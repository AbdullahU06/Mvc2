using Entities;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Store.Entities.Models;

namespace Repositories;

public class RepositoryContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }

    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, ProductName = "Laptop", Price = 17_000 },
            new Product { ProductId = 2, ProductName = "Smartphone", Price = 18_000, },
            new Product { ProductId = 3, ProductName = "Desk Chair", Price = 19_000, }
        );

        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Electronics" },
            new Category { CategoryId = 2, CategoryName = "Furniture" }
        );
    }
}

