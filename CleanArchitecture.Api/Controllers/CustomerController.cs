using CleanArchitecture.Application.Commands;
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
    }
}
