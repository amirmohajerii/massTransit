using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Transaction.Application.DTOs;
using TransactionMS.Infrastracture.Data;

namespace Transaction.Application.Features.Transaction.Queries
{
    public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, List<TransactionDTO>>
    {
        private readonly TransactionsDbContext _context;

        public GetAllTransactionsQueryHandler(TransactionsDbContext context)
        {
            _context = context;
        }

        public async Task<List<TransactionDTO>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _context.Transaction.ToListAsync(cancellationToken);
            return transactions.Adapt<List<TransactionDTO>>();
        }
    }
}
