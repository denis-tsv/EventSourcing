using MediatR;
using Shop.Web.Entities;
using Shop.Web.Infrastructure.Interfaces;
using Shop.Web.UseCases.Exceptions;

namespace Shop.Web.UseCases.Orders.Commands.DeleteOrder;

public class DeleteOrderRequestHandler : AsyncRequestHandler<DeleteOrderCommand>
{
    private readonly IDbContext _dbContext;

    public DeleteOrderRequestHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    protected override async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        _dbContext.Orders.Remove(new Order { Id = request.Id });

        var count = await _dbContext.SaveChangesAsync(cancellationToken);

        if (count == 0) throw new EntityNotFoundException(request.Id, nameof(Order));
    }
}