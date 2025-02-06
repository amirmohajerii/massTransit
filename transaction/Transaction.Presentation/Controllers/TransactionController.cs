using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Transaction.Application.Features.Transaction.Commands;
using Transaction.Application.Features.Transaction.Queries;
using Transaction.Application.DTOs;

namespace Transaction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/transaction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDTO>>> GetTransactions()
        {
            var query = new GetAllTransactionsQuery();
            var transactionDtos = await _mediator.Send(query);
            return Ok(transactionDtos);
        }

        // GET: api/transaction/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDTO>> GetTransactionById(int id)
        {
            var query = new GetTransactionByIdQuery { Id = id };
            var transactionDto = await _mediator.Send(query);
            return Ok(transactionDto);
        }

        // GET: api/transaction/paged
        [HttpGet("paged")]
        public async Task<ActionResult<IEnumerable<TransactionDTO>>> GetTransactionsWithPagination([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var query = new GetTransactionsWithPaginationQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            var transactionDtos = await _mediator.Send(query);
            return Ok(transactionDtos);
        }

        // POST: api/transaction
        [HttpPost]
        public async Task<ActionResult<int>> CreateTransaction([FromBody] CreateTransactionCommand command)
        {
            var transactionId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTransactionById), new { id = transactionId }, transactionId);
        }

        // PUT: api/transaction/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, [FromBody] UpdateTransactionCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Id in URL and command do not match");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/transaction/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var command = new DeleteTransactionCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
