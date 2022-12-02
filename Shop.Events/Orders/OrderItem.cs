namespace Shop.Events.Orders;

public class OrderItem
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}