using MediatR;
using Transaction.Application.DTOs;

namespace Transaction.Application.Features.Transaction.Queries
{
    public class GetTransactionByIdQuery : IRequest<TransactionDTO>
    {
        public int Id { get; set; }
    }
}
