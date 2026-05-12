namespace CustomerProfileService.Application.Events;

public abstract class Event
{
    public string Description { get; set; }
    public DateTime Timestamp { get; set; }
}