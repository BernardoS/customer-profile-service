namespace CustomerProfileService.Application.Events;

public class ProfileCreatedEvent:Event
{
    public Guid CustomerId { get; private set; }
    public Guid ProfileId { get; private set; }

    public ProfileCreatedEvent(Guid customerId, Guid profileId):
        base(
        eventName:"profile_created_event",
        description: $"Perfil do usuário {customerId} criado com sucesso!")
    {
        CustomerId = customerId;
        ProfileId = profileId;
    }
    
}