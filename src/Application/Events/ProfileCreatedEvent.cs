namespace CustomerProfileService.Application.Events;

public class ProfileCreatedEvent:Event
{
    public Guid CustomerId { get; private set; }
    public Guid ProfileId { get; private set; }

    public ProfileCreatedEvent(Guid customerId, Guid profileId):base()
    {
        EventName = "profile_created_event";
        CustomerId = customerId;
        ProfileId = profileId;
        Description = $"Perfil do usuário {customerId} criado com sucesso!";
    }
    
}