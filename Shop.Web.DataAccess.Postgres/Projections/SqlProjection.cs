using Shop.Models;

namespace Shop.Web.DataAccess.Postgres.Projections;

public abstract class SqlProjection<T> where T : Model
{
    protected readonly AppDbContext _dbContext;

    protected SqlProjection(AppDbContext dbContext)
    {
        _dbContext = dbContext; //TODO Implement projection
    }
}