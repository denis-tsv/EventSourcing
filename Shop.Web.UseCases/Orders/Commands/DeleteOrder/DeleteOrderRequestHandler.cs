using MediatR;
using Shop.Web.Entities;
using Shop.Web.Infrastructure.Interfaces;
using Shop.Web.UseCases.Exceptions;

namespace Shop.Web.UseCases.Orders.Commands.DeleteOrder;

public class DeleteOrderRequestHandler : AsyncRequestHandler<DeleteOrderCommand>
{
    private readonly IAggregateStore _aggregateStore;

    public DeleteOrderRequestHandler(IAggregateStore aggregateStore)
    {
        _aggregateStore = aggregateStore;
    }

    protected override async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _aggregateStore.LoadAsync<Order>(request.Id, cancellationToken);
        
        if (order == null) throw new EntityNotFoundException(request.Id, nameof(Order));

        order.Delete();

        await _aggregateStore.SaveAsync(order, cancellationToken);
    }
}