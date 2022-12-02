using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Shop.Events;
using Shop.Web.Entities;
using Shop.Web.Infrastructure.Interfaces;

namespace Shop.Web.DataAccess.Postgres;

public class SqlAggregateStore : IAggregateStore
{
    private readonly AppDbContext _dbContext;

    public SqlAggregateStore(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TAggregate?> LoadAsync<TAggregate>(Guid id, CancellationToken token) where TAggregate : Aggregate, new()
    {
        var events = await _dbContext.Events.AsNoTracking()
            .Where(x => x.AggregateId == id)
            .OrderBy(x => x.CreatedAt)
            .ToListAsync(token);

        if (!events.Any()) return null;

        var result = new TAggregate();
        events.ForEach(x => result.Apply(Deserialize(x.Data, x.Type)));
        return result;
    }

    private Event Deserialize(string data, string type)
    {
        return (Event)JsonSerializer.Deserialize(data, Type.GetType(type)!)!;
    }

    public async Task SaveAsync<TAggregate>(TAggregate aggregate, CancellationToken token) where TAggregate : Aggregate
    {
        var events = aggregate.Events.Select(x => new StoredEvent
            {
                Id = Guid.NewGuid(),
                AggregateId = aggregate.Id,
                CreatedAt = DateTime.UtcNow,
                Data = JsonSerializer.Serialize(x),
                Type = x.GetType().Name
            })
            .ToList();
        
        _dbContext.Events.AddRange(events);
        
        await _dbContext.SaveChangesAsync(token);
    }
}