using AutoMapper;
using MediatR;
using Shop.Events.Orders;
using Shop.Web.Entities;
using Shop.Web.Infrastructure.Interfaces;
using Shop.Web.UseCases.Exceptions;

namespace Shop.Web.UseCases.Orders.Commands.UpdateOrder;

public class UpdateOrderCommandHandler : OrderCommandHandler, IRequestHandler<UpdateOrderCommand, Unit>
{
    private readonly IAggregateStore _aggregateStore;
    
    public UpdateOrderCommandHandler(IAggregateStore aggregateStore, IMapper mapper, IReadDbContext dbContext) : base(dbContext)
    {
        _aggregateStore = aggregateStore;
    }

    public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        await EnsureProductsExistsAsync(request.Dto.Items.Select(x => x.ProductId).ToArray(), cancellationToken);

        var order = await _aggregateStore.LoadAsync<Order>(request.Id, cancellationToken);

        if (order == null) throw new EntityNotFoundException(request.Id, nameof(Order));

        order.Update(request.Dto.Items.Select(x => new OrderItem { ProductId = x.ProductId, Quantity = x.Quantity}).ToArray());

        return Unit.Value;
    }
}