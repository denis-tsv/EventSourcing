namespace Shop.Events.Users;

public class UserCreatedEvent : Event
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}