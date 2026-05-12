using Microsoft.AspNetCore.Mvc;

namespace CustomerProfileService.Api.Controllers
{
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
        public IActionResult Get(Guid id)
        {
            var savedCustomer = _customerService.GetCustomer(id);

            return Ok(savedCustomer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerRequest request)
        {
            var customerInput = request.MapToInput();

            var createdCustomer = await _customerService.CreateCustomer(customerInput);

            return Ok(createdCustomer);
        }
    }
}

