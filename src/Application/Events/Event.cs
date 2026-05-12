namespace CustomerProfileService.Application.Events;

public abstract class Event
{
    public Guid EventId { get;  set; }
    public string EventName { get; set; }
    public string Description { get; set; }
    public DateTime Timestamp { get; set; }

    public Event()
    {
        EventId = Guid.NewGuid();
        Timestamp = DateTime.Now;
        Description = string.Empty;
        EventName = string.Empty;
    }
    
}