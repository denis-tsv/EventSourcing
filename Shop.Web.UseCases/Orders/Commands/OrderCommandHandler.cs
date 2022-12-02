using Microsoft.EntityFrameworkCore;
using Shop.Web.Entities;
using Shop.Web.Infrastructure.Interfaces;
using Shop.Web.UseCases.Exceptions;

namespace Shop.Web.UseCases.Orders.Commands;

public abstract class OrderCommandHandler
{
    protected readonly IReadDbContext _dbContext;

    protected OrderCommandHandler(IReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    protected async Task EnsureProductsExistsAsync(Guid[] ids, CancellationToken cancellationToken)
    {
        var dbIds = await _dbContext.Products
            .Where(x => ids.Contains(x.Id))
            .Select(x => x.Id)
            .ToListAsync(cancellationToken);

        var notExistIds = ids.Except(dbIds).ToList();

        if (notExistIds.Any()) throw new EntityNotFoundException(notExistIds.First(), nameof(Product));
    }
}