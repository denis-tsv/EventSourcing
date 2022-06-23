namespace Shop.Web.Entities;

public class Order : Aggregate
{
    public DateTime CreatedAt { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }

    public List<OrderItem> Items { get; set; } = null!;
}