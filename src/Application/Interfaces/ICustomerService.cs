public interface ICustomerService
{
    Customer CreateCustomer(CreateCustomerInput request);
    Customer GetCustomer(Guid id);
}