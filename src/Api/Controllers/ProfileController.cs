using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{

    
    private IProfileService _profileService;
    
    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }


    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateProfile(CreateProfileRequest request)
    {
        var createProfileInput = request.MapToInput();
        
        var profile = await _profileService.CreateProfile(createProfileInput);
        
        return Ok(profile);
    }
}