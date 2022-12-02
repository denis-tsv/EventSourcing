using Shop.Events;

namespace Shop.Web.Entities;

public abstract class Entity
{
    public Guid Id { get; protected set; }

    protected readonly List<Event> _events = new();

    public IReadOnlyList<Event> Events => _events; 

    public abstract void Apply(Event @event);

    protected void AddEvent(Event @event)
    {
        Apply(@event);

        _events.Add(@event);
    }
}