using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Web.Entities;
using Shop.Web.Infrastructure.Interfaces;
using Shop.Web.UseCases.Exceptions;

namespace Shop.Web.UseCases.Orders.Commands.UpdateOrder;

public class UpdateOrderCommandHandler : AsyncRequestHandler<UpdateOrderCommand>
{
    private readonly IDbContext _dbContext;
    private readonly IMapper _mapper;

    public UpdateOrderCommandHandler(IDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    protected override async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _dbContext.Orders
            .Include(x => x.Items)
            .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (order == null) throw new EntityNotFoundException(request.Id, nameof(Order));

        _mapper.Map(request.Dto, order);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}