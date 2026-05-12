namespace CustomerProfileService.Application.Events;

public class CustomerCreatedEvent : Event
{
    public Guid CustomerId { get; private set; }

    public CustomerCreatedEvent(
        Guid customerId
        ): base(
            eventName:"customer_created_event",
            description:$"Conta do usuário {customerId} criada com sucesso!") 
    {
        CustomerId = customerId;
    }
    
}