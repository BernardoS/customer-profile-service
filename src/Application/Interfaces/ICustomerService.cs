public interface ICustomerService
{
    Task<Customer> CreateCustomer(CreateCustomerInput request);
    Task<Customer> GetCustomer(Guid id);
}