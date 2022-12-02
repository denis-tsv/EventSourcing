using MediatR;
using Shop.Web.UseCases.Orders.Dtos;

namespace Shop.Web.UseCases.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<Guid>
{
    public CreateOrderDto Dto { get; init; } = null!;
}