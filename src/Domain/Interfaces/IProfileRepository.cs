namespace CustomerProfileService.Domain.Interfaces
{
    public interface IProfileRepository
    {
        Task<Profile> AddAsync(Profile profile);
        Task<Profile?> GetByIdAsync(Guid id);
    }
}