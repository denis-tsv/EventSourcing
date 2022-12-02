using MediatR;

namespace Shop.Web.UseCases.Orders.Commands.DeleteOrder;

public class DeleteOrderCommand : IRequest
{
    public Guid Id { get; init; }
}