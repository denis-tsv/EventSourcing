namespace Shop.Web.Entities;

public class Product : Aggregate
{
    public string Name { get; set; } = null!;

    public decimal Price { get; set; }
}