using Shop.Models;

namespace Shop.Web.Infrastructure.Interfaces;

public interface IReadDbContext
{
    IQueryable<OrderModel> Orders { get; }

    IQueryable<ProductModel> Products { get; }

    IQueryable<UserModel> Users { get; }
}