using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Queries;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddCustomerAsync([FromBody] CustomerEntity customer)
        {
            var result = await sender.Send(new AddCustomerCommand(customer));

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
    }
}
