using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Transaction.Application.DTOs;
using TransactionMS.Infrastracture.Data;

namespace Transaction.Application.Features.Transaction.Queries
{
    public class GetTransactionsWithPaginationQueryHandler : IRequestHandler<GetTransactionsWithPaginationQuery, List<TransactionDTO>>
    {
        private readonly TransactionsDbContext _context;

        public GetTransactionsWithPaginationQueryHandler(TransactionsDbContext context)
        {
            _context = context;
        }

        public async Task<List<TransactionDTO>> Handle(GetTransactionsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _context.Transaction
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            return transactions.Adapt<List<TransactionDTO>>();
        }
    }
}
