using CustomerProfileService.Domain.Interfaces;

namespace CustomerProfileService.Application.Events;

public class Event : IEvent
{
    public Guid EventId { get; private set; } = Guid.NewGuid();
    public string EventName { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public DateTime Timestamp { get; private set; } = DateTime.Now;

    public Event(string eventName, string description)
    {
        this.EventName = eventName;
        this.Description = description;
    }
}