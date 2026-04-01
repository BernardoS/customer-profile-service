public interface ICustomerService
{
    Task<Customer> CreateCustomer(CreateCustomerInput request);
    Customer GetCustomer(Guid id);
}