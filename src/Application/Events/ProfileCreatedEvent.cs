namespace CustomerProfileService.Application.Events;

public class ProfileCreatedEvent:Event
{
    public Guid CustomerId { get; private set; }
    public Guid ProfileId { get; private set; }

    public ProfileCreatedEvent(Guid  customerId, Guid profileId)
    {
        CustomerId = customerId;
        ProfileId = profileId;
        this.Timestamp = DateTime.Now;
        this.Description = $"Perfil do usuário {customerId} criado com sucesso!";
    }
    
}