namespace Shop.Web.Entities;

public class User : Aggregate
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}