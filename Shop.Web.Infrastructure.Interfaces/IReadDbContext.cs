using Shop.Web.Entities;

namespace Shop.Web.Infrastructure.Interfaces;

public interface IReadDbContext
{
    IQueryable<Order> Orders { get; }

    IQueryable<Product> Products { get; }

    IQueryable<User> Users { get; }
}