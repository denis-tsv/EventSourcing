using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Web.Entities;
using Shop.Web.Infrastructure.Interfaces;
using Shop.Web.UseCases.Exceptions;
using Shop.Web.UseCases.Orders.Dtos;

namespace Shop.Web.UseCases.Orders.Queries;

public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDto>
{
    private readonly IReadDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetOrderQueryHandler(IReadDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await _dbContext
            .Orders
            .Include(x => x.Items)
            .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (order == null) throw new EntityNotFoundException(request.Id, nameof(Order));

        return _mapper.Map<OrderDto>(order);
    }
}