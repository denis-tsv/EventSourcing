namespace Shop.Web.UseCases.Orders.Dtos;

public class UpdateOrderDto
{
    public OrderItemDto[] Items { get; init; } = null!;
}