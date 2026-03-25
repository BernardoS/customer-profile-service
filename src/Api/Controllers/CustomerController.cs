using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("API funcionando");
    }

    [HttpPost]
    public IActionResult CreateCustomer(CreateCustomerRequest request)
    {
        var customerInput = request.MapToInput();

        var createdCustomer = _customerService.CreateCustomer(customerInput);

        return Ok(createdCustomer);
    }
}