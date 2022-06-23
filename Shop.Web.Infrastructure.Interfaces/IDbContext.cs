using Microsoft.EntityFrameworkCore;
using Shop.Web.Entities;

namespace Shop.Web.Infrastructure.Interfaces;

public interface IDbContext
{
    DbSet<Order> Orders { get; }

    DbSet<Product> Products { get; }

    DbSet<User> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}