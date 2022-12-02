using Shop.Models;

namespace Shop.Web.DataAccess.Postgres.Projections;

public class OrderSqlProjection : SqlProjection<OrderModel>
{
    public OrderSqlProjection(AppDbContext dbContext) : base(dbContext)
    {
    }
}