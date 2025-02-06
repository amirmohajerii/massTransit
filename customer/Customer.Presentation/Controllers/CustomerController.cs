using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Customer.Application.Features.Customer.Commands;

namespace Customer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/customer/exists/{customerId}
        [HttpGet("exists/{customerId}")]
        public async Task<ActionResult<bool>> CustomerExists(int customerId)
        {
            var command = new CheckCustomerExistenceCommand { CustomerId = customerId };
            var exists = await _mediator.Send(command);
            return Ok(exists);
        }
    }
}
