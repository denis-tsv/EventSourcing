using Shop.Models;

namespace Shop.Web.DataAccess.Postgres.Projections;

public class ProductSqlProjection : SqlProjection<ProductModel>
{
    public ProductSqlProjection(AppDbContext dbContext) : base(dbContext)
    {
    }
}