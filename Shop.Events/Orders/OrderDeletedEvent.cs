namespace Shop.Events.Orders;

public class OrderDeletedEvent : Event
{
    public Guid Id { get; set; }
}