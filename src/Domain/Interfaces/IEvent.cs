namespace CustomerProfileService.Domain.Interfaces;

public interface IEvent
{
    public Guid EventId { get; }
    public string EventName { get; }
    public string Description { get; }
    public DateTime Timestamp { get; }
}