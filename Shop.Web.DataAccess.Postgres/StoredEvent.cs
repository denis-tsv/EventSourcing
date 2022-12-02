namespace Shop.Web.DataAccess.Postgres;

public class StoredEvent
{
    public Guid Id { get; set; }
    public Guid AggregateId { get; set; }
    public string Type { get; set; } = null!;
    public string Data { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}