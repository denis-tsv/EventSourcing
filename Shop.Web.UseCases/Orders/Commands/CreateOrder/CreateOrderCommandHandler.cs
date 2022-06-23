using AutoMapper;
using MediatR;
using Shop.Web.Entities;
using Shop.Web.Infrastructure.Interfaces;

namespace Shop.Web.UseCases.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IDbContext _dbContext;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(IDbContext dbContext, ICurrentUserService currentUserService, IMapper mapper)
    {
        _dbContext = dbContext;
        _currentUserService = currentUserService;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _mapper.Map<Order>(request.Dto);

        order.UserId = _currentUserService.Id;
        order.CreatedAt = DateTime.UtcNow;

        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return order.Id;
    }
}