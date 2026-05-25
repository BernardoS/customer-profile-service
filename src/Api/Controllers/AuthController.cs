using System.IdentityModel.Tokens.Jwt;
using CustomerProfileService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerProfileService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost]
    [Route("Login")]
    public async Task<ActionResult> Login(Guid customerId)
    {
        var authToken = await _authService.Login(customerId);

        return Ok(new {
            token = authToken
        });
    }
    
}