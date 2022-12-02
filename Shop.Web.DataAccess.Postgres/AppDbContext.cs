using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Shop.Events.Products;
using Shop.Events.Users;
using Shop.Models;
using Shop.Web.DataAccess.Postgres.Configurations;
using Shop.Web.Infrastructure.Interfaces;

namespace Shop.Web.DataAccess.Postgres;

public class AppDbContext : DbContext, IReadDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<StoredEvent> Events { get; set; } = null!;

    public DbSet<OrderModel> Orders { get; set; } = null!;
    public DbSet<ProductModel> Products { get; set; } = null!;
    public DbSet<UserModel> Users { get; set; } = null!;

    IQueryable<ProductModel> IReadDbContext.Products => Products.AsNoTracking();
    IQueryable<UserModel> IReadDbContext.Users => Users.AsNoTracking();
    IQueryable<OrderModel> IReadDbContext.Orders => Orders.AsNoTracking();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderModelConfiguration).Assembly);

        var userId = Guid.Parse("EFA9A19C-A85B-41F5-AF21-BB27776986AA");
        var product1Id = Guid.Parse("EFA9A19C-A85B-41F5-AF21-BB27776986AB");
        var product2Id = Guid.Parse("EFA9A19C-A85B-41F5-AF21-BB27776986AC");
        modelBuilder.Entity<StoredEvent>()
            .HasData(new[]
            {
                new StoredEvent
                {
                    Id = Guid.Parse("4e80a596-02e7-4892-ac45-6cb8f01c0cf1"),
                    AggregateId = userId,
                    CreatedAt = new DateTime(2022, 06, 28),
                    Type = nameof(UserCreatedEvent),
                    Data = JsonSerializer.Serialize(new UserCreatedEvent
                    {
                        Id = userId,
                        FirstName = "FirstName1",
                        LastName = "LastName1"
                    })
                },
                new StoredEvent
                {
                    Id = Guid.Parse("88c44318-728e-4dbf-9e85-890a5367dbac"),
                    AggregateId = product1Id,
                    CreatedAt = new DateTime(2022, 06, 28),
                    Type = nameof(ProductCreatedEvent),
                    Data = JsonSerializer.Serialize(new ProductCreatedEvent
                    {
                        Id = product1Id,
                        Name = "Product1",
                        Price = 1
                    })
                },
                new StoredEvent
                {
                    Id = Guid.Parse("ebbfe1f8-8ff4-49c9-b49e-fd7754bc95e6"),
                    AggregateId = product2Id,
                    CreatedAt = new DateTime(2022, 06, 28),
                    Type = nameof(ProductCreatedEvent),
                    Data = JsonSerializer.Serialize(new ProductCreatedEvent
                    {
                        Id = product2Id,
                        Name = "Product2",
                        Price = 20
                    })
                },
            });
    }
}