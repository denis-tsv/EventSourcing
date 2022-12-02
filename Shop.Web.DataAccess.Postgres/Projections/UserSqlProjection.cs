using Shop.Models;

namespace Shop.Web.DataAccess.Postgres.Projections;

public class UserSqlProjection : SqlProjection<UserModel>
{
    public UserSqlProjection(AppDbContext dbContext) : base(dbContext)
    {
    }
}