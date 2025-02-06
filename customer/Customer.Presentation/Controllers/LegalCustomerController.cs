using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Customer.Application.Features.LegalCustomer.Commands;
using Customer.Application.Features.LegalCustomer.Queries;
using Customer.Domain.Entities;
using Customer.Application.Features.IndividualCustomer.Commands;
using Customer.Application.Features.LegalCustomer.Commnads;
using Customer.Application.Features.legalCustomer.Commands;

namespace Customer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegalCustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LegalCustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/legalcustomer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LegalCustomerDTO>>> GetLegalCustomers()
        {
            var query = new GetAllLegalCustomersQuery();
            var customerDtos = await _mediator.Send(query);
            return Ok(customerDtos);
        }

        // GET: api/legalcustomer/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<LegalCustomerDTO>> GetLegalCustomerById(int id)
        {
            var query = new GetLegalCustomerByIdQuery { Id = id };
            var customerDto = await _mediator.Send(query);
            return Ok(customerDto);
        }

        // GET: api/legalcustomer/paged
        [HttpGet("paged")]
        public async Task<ActionResult<IEnumerable<LegalCustomerDTO>>> GetLegalCustomersWithPagination([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var query = new GetLegalCustomersWithPaginationQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            var customerDtos = await _mediator.Send(query);
            return Ok(customerDtos);
        }

        // POST: api/legalcustomer
        [HttpPost]
        public async Task<ActionResult<int>> CreateLegalCustomer([FromBody] CreateLegalCustomerCommand command)
        {
            var customerId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetLegalCustomerById), new { id = customerId }, customerId);
        }

        // PUT: api/legalcustomer/
        [HttpPut]
        public async Task<IActionResult> UpdateLegalCustomer([FromBody] UpdateLegalCustomerCommand command)
        {

            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/legalcustomer/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLegalCustomer(int id)
        {
            var command = new DeleteLegalCustomerCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
