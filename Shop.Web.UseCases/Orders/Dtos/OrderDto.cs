namespace Shop.Web.UseCases.Orders.Dtos;

public class OrderDto
{
    public int Id { get; init; }
    public DateTime CreatedAt { get; init; }
    public OrderItemDto[] Items { get; init; } = null!;
}