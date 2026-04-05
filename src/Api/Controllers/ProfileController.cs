using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{

    public ProfileController()
    {
    }


    [HttpPost]
    public IActionResult CreateProfile()
    {
        return Ok();
    }
}