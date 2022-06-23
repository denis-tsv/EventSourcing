using Microsoft.EntityFrameworkCore;
using Shop.Web.DataAccess.Postgres.Configurations;
using Shop.Web.Entities;
using Shop.Web.Infrastructure.Interfaces;

namespace Shop.Web.DataAccess.Postgres;

public class AppDbContext : DbContext, IDbContext, IReadDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    IQueryable<Product> IReadDbContext.Products => Products.AsNoTracking();
    IQueryable<User> IReadDbContext.Users => Users.AsNoTracking();
    IQueryable<Order> IReadDbContext.Orders => Orders.AsNoTracking();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderConfiguration).Assembly);

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Product1",
                Price = 1
            },
            new Product
            {
                Id = 2,
                Name = "Product2",
                Price = 20
            });

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                FirstName = "First1",
                LastName = "Last1"
            });
    }
}