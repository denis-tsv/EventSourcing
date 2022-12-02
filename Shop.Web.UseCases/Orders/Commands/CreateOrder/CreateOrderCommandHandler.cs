using MediatR;
using Shop.Events.Orders;
using Shop.Web.Entities;
using Shop.Web.Infrastructure.Interfaces;

namespace Shop.Web.UseCases.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : OrderCommandHandler, IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IAggregateStore _aggregateStore;
    private readonly ICurrentUserService _currentUserService;

    public CreateOrderCommandHandler(IAggregateStore aggregateStore, ICurrentUserService currentUserService, IReadDbContext dbContext) 
        : base(dbContext)
    {
        _aggregateStore = aggregateStore;
        _currentUserService = currentUserService;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        await EnsureProductsExistsAsync(request.Dto.Items.Select(x => x.ProductId).ToArray(), cancellationToken);

        var order = new Order();

        order.Create(
            Guid.NewGuid(),
            request.Dto.Items.Select(x => new OrderItem
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity
            }).ToArray(),
            _currentUserService.Id,
            DateTime.UtcNow
            );

        await _aggregateStore.SaveAsync(order, cancellationToken);
        
        return order.Id;
    }
}