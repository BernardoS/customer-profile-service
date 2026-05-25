using System.IdentityModel.Tokens.Jwt;

namespace CustomerProfileService.Application.Interfaces;

public interface IAuthService
{
    Task<string> Login(Guid customerId);
}