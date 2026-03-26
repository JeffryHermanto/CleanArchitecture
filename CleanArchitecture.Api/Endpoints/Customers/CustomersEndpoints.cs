using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Commands.AddCustomer;
using CleanArchitecture.Application.Commands.DeleteCustomer;
using CleanArchitecture.Application.Commands.UpdateCustomer;
using CleanArchitecture.Application.Queries.GetAllCustomers;
using CleanArchitecture.Application.Queries.GetCustomerById;
using CleanArchitecture.Application.Utilities.SimpleMediator;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Endpoints.Customers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerEndpoints(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddCustomerAsync([FromBody] AddCustomerRequestDTO addCustomerRequestDTO)
        {
            var result = await mediator.Send(new AddCustomerCommand(addCustomerRequestDTO));

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            var result = await mediator.Send(new GetAllCustomersQuery());

            return Ok(result);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerByIdAsync([FromRoute] Guid customerId)
        {
            var result = await mediator.Send(new GetCustomerByIdQuery(customerId));

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateCustomerAsync(
            [FromRoute] Guid customerId,
            [FromBody] UpdateCustomerRequestDTO updateCustomerRequestDTO)
        {
            var result = await mediator.Send(new UpdateCustomerCommand(customerId, updateCustomerRequestDTO));

            return Ok(result);
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomerAsync([FromRoute] Guid customerId)
        {
            var result = await mediator.Send(new DeleteCustomerCommand(customerId));

            return Ok(result);
        }
    }
}
