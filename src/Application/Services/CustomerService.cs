using CustomerProfileService.Application.Events;
using CustomerProfileService.Domain.Interfaces;

namespace CustomerProfileService.Application.Services
{
    public class CustomerService : ICustomerService
    {
        public ICustomerRepository _customerRepository;
        public IEventPublisher _eventPublisher;

        public CustomerService(
            ICustomerRepository customerRepository,
            IEventPublisher eventPublisher)
        {
            _customerRepository = customerRepository;
            _eventPublisher = eventPublisher;
        }

        public async Task<Customer> CreateCustomer(CreateCustomerInput request)
        {
            var customer = new Customer(
                name: request.Name,
                email: request.Email,
                birthdate: request.BirthDate,
                profession: request.Profession
            );

            var newCustomer = await _customerRepository.AddAsync(customer);

            var customerCreatedEvent = new CustomerCreatedEvent(newCustomer.Id);

            await _eventPublisher.PublishAsync(
                customerCreatedEvent, 
                customerCreatedEvent.EventId,
                customerCreatedEvent.EventName);

            return newCustomer;
        }

        public async Task<Customer?> GetCustomer(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            return customer;
        }
    }
}