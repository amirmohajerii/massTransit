using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Transaction.Application.Features.Request.Commands;
using Transaction.Application.Features.Request.Queries;
using Transaction.Application.DTOs;

namespace Transaction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/request
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestDTO>>> GetRequests()
        {
            var query = new GetAllRequestsQuery();
            var requestDtos = await _mediator.Send(query);
            return Ok(requestDtos);
        }

        // GET: api/request/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestDTO>> GetRequestById(int id)
        {
            var query = new GetRequestByIdQuery { Id = id };
            var requestDto = await _mediator.Send(query);
            return Ok(requestDto);
        }

        // GET: api/request/paged
        [HttpGet("paged")]
        public async Task<ActionResult<IEnumerable<RequestDTO>>> GetRequestsWithPagination([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var query = new GetRequestsWithPaginationQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            var requestDtos = await _mediator.Send(query);
            return Ok(requestDtos);
        }

        // POST: api/request
        [HttpPost]
        public async Task<ActionResult<int>> CreateRequest([FromBody] CreateRequestCommand command)
        {
            var requestId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetRequestById), new { id = requestId }, requestId);
        }

        // PUT: api/request/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequest(int id, [FromBody] UpdateRequestCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Id in URL and command do not match");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/request/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var command = new DeleteRequestCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
