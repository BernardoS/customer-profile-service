public class CustomerService : ICustomerService
{
    public ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer> CreateCustomer(CreateCustomerInput request)
    {

        if (request.Name.Length < 3)
        {
            throw new Exception("Nome de usuário muito curto, digite um nome acima de 3 caracteres");
        }

        var customer = new Customer(
            name: request.Name,
            email: request.Email,
            birthdate: request.BirthDate,
            profession: request.Profession
        );

        var newCustomer = await _customerRepository.AddAsync(customer);

        return newCustomer;
    }

    public Customer GetCustomer(Guid id)
    {
        throw new NotImplementedException();
    }
}