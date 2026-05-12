namespace CustomerProfileService.Domain.Interfaces;

public interface IEventPublisher
{
    Task PublishAsync<T> (T message, Guid entityId, string eventname);
}