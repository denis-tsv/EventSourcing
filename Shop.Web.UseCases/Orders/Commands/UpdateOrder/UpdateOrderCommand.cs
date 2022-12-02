using MediatR;
using Shop.Web.UseCases.Orders.Dtos;

namespace Shop.Web.UseCases.Orders.Commands.UpdateOrder;

public class UpdateOrderCommand : IRequest
{
    public Guid Id { get; init; }

    public UpdateOrderDto Dto { get; init; } = null!;
}