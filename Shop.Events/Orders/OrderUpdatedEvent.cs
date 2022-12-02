namespace Shop.Events.Orders;

public class OrderUpdatedEvent : Event
{
    public OrderItem[]? AddedItems { get; set; }
    public OrderItem[]? UpdatedItems { get; set; }
    public Guid[]? RemovedProducts { get; set; }
}