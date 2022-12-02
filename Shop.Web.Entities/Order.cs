using Shop.Events;
using Shop.Events.Orders;

namespace Shop.Web.Entities;

public class Order : Aggregate
{
    public DateTime CreatedAt { get; private set; }

    public Guid UserId { get; private set; }

    public bool IsDeleted { get; private set; }

    private readonly List<OrderItem> _items = new();

    public IReadOnlyCollection<OrderItem> Items => _items;

    public void Create(Guid id, OrderItem[] items, Guid createdBy, DateTime createdAd)
    {
        EnsureNotDeleted();

        var evt = new OrderCreatedEvent
        {
            Id = id,
            Items = items.Select(x => new Events.Orders.OrderItem
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity
            }).ToArray(),
            CreatedAt = createdAd,
            CreatedBy = createdBy
        };

        AddEvent(evt);
    }

    public void Update(OrderItem[] items)
    {
        EnsureNotDeleted();

        var evt = new OrderUpdatedEvent();

        var oldProductIds = _items.Select(x => x.ProductId).ToHashSet();

        evt.RemovedProducts = oldProductIds.Except(items.Select(e => e.ProductId)).ToArray();
        
        evt.AddedItems = items
            .Where(x => !oldProductIds.Contains(x.ProductId))
            .ToArray();

        evt.UpdatedItems = _items
            .Join(items, o => o.ProductId, n => n.ProductId, (o, n) => new { o.ProductId, OldQuantity = o.Quantity, NewQuantity = n.Quantity })
            .Where(x => x.NewQuantity != x.OldQuantity)
            .Select(x => new OrderItem
            {
                ProductId = x.ProductId,
                Quantity = x.NewQuantity
            })
            .ToArray();

        if (evt.AddedItems.Any() || evt.RemovedProducts.Any() || evt.UpdatedItems.Any())
        {
            AddEvent(evt);
        }
    }

    public void Delete()
    {
        EnsureNotDeleted();

        var @event = new OrderDeletedEvent
        {
            Id = Id
        };

        AddEvent(@event);
    }

    protected void EnsureNotDeleted()
    {
        if (IsDeleted) throw new InvalidOperationException($"Order {Id} already deleted");
    }

    public override void Apply(Event @event)
    {
        if (@event is OrderCreatedEvent created)
        {
            Id = created.Id;
            CreatedAt = created.CreatedAt;
            UserId = created.CreatedBy;
            IsDeleted = false;

            _items.AddRange(created.Items);
        }

        if (@event is OrderUpdatedEvent updated)
        {
            if (updated.AddedItems != null)
            {
                _items.AddRange(updated.AddedItems);
            }

            if (updated.RemovedProducts != null)
            {
                _items.RemoveAll(x => updated.RemovedProducts.Contains(x.ProductId));
            }

            if (updated.UpdatedItems != null)
            {
                var updatedProducts = updated.UpdatedItems.Select(x => x.ProductId).ToHashSet();
                _items.RemoveAll(x => updatedProducts.Contains(x.ProductId));
                _items.AddRange(updated.UpdatedItems);
            }
        }

        if (@event is OrderDeletedEvent)
        {
            IsDeleted = true;
        }
    }
}