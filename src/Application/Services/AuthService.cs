using System.IdentityModel.Tokens.Jwt;
using CustomerProfileService.Application.Interfaces;

namespace CustomerProfileService.Application.Services;

public class AuthService :IAuthService
{
    private readonly ICustomerService _customerService;
    private readonly ITokenService _tokenService;

    public AuthService(ICustomerService customerService, ITokenService tokenService)
    {
        _customerService = customerService;
        _tokenService = tokenService;
    }
    
    public async Task<string> Login(Guid customerId)
    {
        try
        {
            var customer = await _customerService.GetCustomer(customerId);
            
            if(customer == null)
                throw new Exception($"Customer {customerId} not found");

            var token = _tokenService.GenerateAccessToken(customer);

            return token;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}