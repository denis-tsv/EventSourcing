namespace Shop.Models;

public class OrderModel : Model
{
    public DateTime CreatedAt { get; set; }

    public Guid UserId { get; set; }

}