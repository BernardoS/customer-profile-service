using CustomerProfileService.Domain.Interfaces;

namespace CustomerProfileService.Application.Services
{
    public class CustomerService : ICustomerService
    {
        public ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
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

            return newCustomer;
        }

        public async Task<Customer?> GetCustomer(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            return customer;
        }
    }
}