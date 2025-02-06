using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mapster;
using Transaction.Application.DTOs;
using Microsoft.EntityFrameworkCore;
using TransactionMS.Infrastracture.Data;

namespace Transaction.Application.Features.Request.Queries
{
    public class GetAllRequestsQueryHandler : IRequestHandler<GetAllRequestsQuery, List<RequestDTO>>
    {
        private readonly TransactionsDbContext _context;

        public GetAllRequestsQueryHandler(TransactionsDbContext context)
        {
            _context = context;
        }

        public async Task<List<RequestDTO>> Handle(GetAllRequestsQuery request, CancellationToken cancellationToken)
        {
            var requestEntities = await _context.Request.ToListAsync(cancellationToken);
            return requestEntities.Adapt<List<RequestDTO>>();
        }
    }
}
