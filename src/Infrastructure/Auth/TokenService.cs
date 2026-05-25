using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CustomerProfileService.Application.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CustomerProfileService.Infrastructure.Auth;

public class TokenService : ITokenService
{
    private readonly JwtSettings _jwtSettings;
    
    public TokenService(IOptions<JwtSettings> settings)
    {
        _jwtSettings = settings.Value;
    }


    public string GenerateAccessToken(Customer customer)
    {
        var privateKey = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);

        var signingCredentials =
            new SigningCredentials(new SymmetricSecurityKey(privateKey), SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(
                new Claim[]
                {
                    new Claim(ClaimTypes.Name, customer.Name),
                    new Claim("Id", customer.Id.ToString()),
                }),
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.TokenValidityInMinutes),
            //Audience = _jwtSettings.ValidAudience,
            //Issuer = _jwtSettings.ValidIssuer,
            SigningCredentials = signingCredentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.WriteToken(tokenHandler.CreateJwtSecurityToken(tokenDescriptor));
        

        return token;
    }
}