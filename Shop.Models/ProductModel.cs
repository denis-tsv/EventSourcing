namespace Shop.Models;

public class ProductModel : Model
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
}