using Shop.Web.Entities;

namespace Shop.Web.Infrastructure.Interfaces;

public interface IAggregateStore
{
    Task<TAggregate?> LoadAsync<TAggregate>(Guid id, CancellationToken token) where TAggregate : Aggregate, new();

    Task SaveAsync<TAggregate>(TAggregate aggregate, CancellationToken token) where TAggregate : Aggregate;
}