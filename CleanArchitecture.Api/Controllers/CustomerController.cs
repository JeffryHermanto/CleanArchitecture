using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddCustomerAsync([FromBody] AddCustomerRequestDTO addCustomerRequestDTO)
        {
            var result = await sender.Send(new AddCustomerCommand(addCustomerRequestDTO));

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            var result = await sender.Send(new GetAllCustomersQuery());

            return Ok(result);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerByIdAsync([FromRoute] Guid customerId)
        {
            var result = await sender.Send(new GetCustomerByIdQuery(customerId));

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateCustomerAsync(
            [FromRoute] Guid customerId,
            [FromBody] UpdateCustomerRequestDTO updateCustomerRequestDTO)
        {
            var result = await sender.Send(new UpdateCustomerCommand(customerId, updateCustomerRequestDTO));

            return Ok(result);
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomerAsync([FromRoute] Guid customerId)
        {
            var result = await sender.Send(new DeleteCustomerCommand(customerId));

            return Ok(result);
        }
    }
}
