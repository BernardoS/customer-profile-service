namespace CustomerProfileService.Application.Interfaces;

public interface ITokenService
{ 
    string GenerateAccessToken(Customer customer);
}