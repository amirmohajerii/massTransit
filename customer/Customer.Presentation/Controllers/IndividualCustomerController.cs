using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Customer.Application.Features.IndividualCustomer.Commands;
using Customer.Application.Features.IndividualCustomer.Queries;
using Customer.Domain.Entities;
using Customer.Application.Features.IndividualCustomer.Commands;

namespace Customer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualCustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IndividualCustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/individualcustomer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IndividualCustomerDTO>>> GetIndividualCustomers()
        {
            var query = new GetAllIndividualCustomersQuery();
            var customerDtos = await _mediator.Send(query);
            return Ok(customerDtos);
        }

        // GET: api/individualcustomer/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<IndividualCustomerDTO>> GetIndividualCustomerById(int id)
        {
            var query = new GetIndividualCustomerByIdQuery { Id = id };
            var customerDto = await _mediator.Send(query);
            return Ok(customerDto);
        }

        // GET: api/individualcustomer/paged
        [HttpGet("paged")]
        public async Task<ActionResult<IEnumerable<IndividualCustomerDTO>>> GetIndividualCustomersWithPagination([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var query = new GetIndividualCustomersWithPaginationQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            var customerDtos = await _mediator.Send(query);
            return Ok(customerDtos);
        }

        // POST: api/individualcustomer
        [HttpPost]
        public async Task<ActionResult<int>> CreateIndividualCustomer([FromBody] CreateIndividualCustomerCommand command)
        {
            var customerId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetIndividualCustomerById), new { id = customerId }, customerId);
        }

        // PUT: api/individualcustomer/
        [HttpPut]
        public async Task<IActionResult> UpdateIndividualCustomer([FromBody] UpdateIndividualCustomerCommand command)
        {

            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/individualcustomer/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIndividualCustomer(int id)
        {
            var command = new DeleteIndividualCustomerCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
