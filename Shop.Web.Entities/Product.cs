using Shop.Events;
using Shop.Events.Products;

namespace Shop.Web.Entities;

public class Product : Aggregate
{
    public string Name { get; protected set; } = null!;

    public decimal Price { get; protected set; }

    public override void Apply(Event @event)
    {
        if (@event is ProductCreatedEvent created)
        {
            Id = created.Id;
            Name = created.Name;
            Price = created.Price;
        }
    }
}