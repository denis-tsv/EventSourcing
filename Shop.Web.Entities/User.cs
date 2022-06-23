namespace Shop.Web.Entities;

public class User : Aggregate
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}