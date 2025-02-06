using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Transaction.Application.DTOs;
using TransactionMS.Infrastracture.Data;

namespace Transaction.Application.Features.Request.Queries
{
    public class GetRequestsWithPaginationQueryHandler : IRequestHandler<GetRequestsWithPaginationQuery, List<RequestDTO>>
    {
        private readonly TransactionsDbContext _context;

        public GetRequestsWithPaginationQueryHandler(TransactionsDbContext context)
        {
            _context = context;
        }

        public async Task<List<RequestDTO>> Handle(GetRequestsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var requestEntities = await _context.Request
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            return requestEntities.Adapt<List<RequestDTO>>();
        }
    }
}
