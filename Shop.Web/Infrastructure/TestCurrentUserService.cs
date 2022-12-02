using Shop.Web.Infrastructure.Interfaces;

namespace Shop.Web.Infrastructure;

public class TestCurrentUserService : ICurrentUserService
{
    public Guid Id => Guid.Parse("EFA9A19C-A85B-41F5-AF21-BB27776986AA");
}