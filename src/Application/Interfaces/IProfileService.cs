using CustomerProfileService.Application.DTOs;

public interface IProfileService
{
    Task<Profile> CreateProfile(CreateProfileInput input);
    Task<Profile> GetProfile(Guid id);
}