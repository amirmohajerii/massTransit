using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mapster;
using Transaction.Application.DTOs;
using TransactionMS.Infrastracture.Data;

namespace Transaction.Application.Features.Transaction.Queries
{
    public class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, TransactionDTO>
    {
        private readonly TransactionsDbContext _context;

        public GetTransactionByIdQueryHandler(TransactionsDbContext context)
        {
            _context = context;
        }

        public async Task<TransactionDTO> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            var transaction = await _context.Transaction.FindAsync(request.Id);
            if (transaction == null)
            {
                throw new KeyNotFoundException("Transaction not found");
            }

            return transaction.Adapt<TransactionDTO>();
        }
    }
}
