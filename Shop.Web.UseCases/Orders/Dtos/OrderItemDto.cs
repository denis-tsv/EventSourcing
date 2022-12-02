namespace Shop.Web.UseCases.Orders.Dtos;

public class OrderItemDto
{
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
}