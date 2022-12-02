using Shop.Events;
using Shop.Events.Users;

namespace Shop.Web.Entities;

public class User : Aggregate
{
    public string FirstName { get; protected set; } = null!;
    public string LastName { get; protected set; } = null!;
    
    public override void Apply(Event @event)
    {
        if (@event is UserCreatedEvent created)
        {
            Id = created.Id;
            FirstName = created.FirstName;
            LastName = created.LastName;
        }
    }
}