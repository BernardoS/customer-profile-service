namespace CustomerProfileService.Infrastructure.Auth;

public class JwtSettings
{
    public string ValidIssuer { get; set; }
    public string ValidAudience { get; set; }
    public string SecretKey { get; set; }
    public int TokenValidityInMinutes { get; set; }
    public int RefreshTokenValidityInMinutes { get; set; }
    
}