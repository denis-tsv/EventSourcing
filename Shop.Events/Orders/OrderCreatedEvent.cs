namespace Shop.Events.Orders;

public class OrderCreatedEvent : Event
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public OrderItem[] Items { get; set; } = null!;
}