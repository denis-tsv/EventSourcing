namespace Shop.Web.UseCases.Orders.Dtos;

public class CreateOrderDto
{
    public OrderItemDto[] Items { get; init; } = null!;
}