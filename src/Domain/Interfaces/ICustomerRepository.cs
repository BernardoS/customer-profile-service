namespace CustomerProfileService.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> AddAsync(Customer customer);
        Task<Customer?> GetByIdAsync(Guid id);
    }
}