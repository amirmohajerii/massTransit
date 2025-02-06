using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mapster;
using Transaction.Application.DTOs;
using TransactionMS.Infrastracture.Data;

namespace Transaction.Application.Features.Request.Queries
{
    public class GetRequestByIdQueryHandler : IRequestHandler<GetRequestByIdQuery, RequestDTO>
    {
        private readonly TransactionsDbContext _context;

        public GetRequestByIdQueryHandler(TransactionsDbContext context)
        {
            _context = context;
        }

        public async Task<RequestDTO> Handle(GetRequestByIdQuery request, CancellationToken cancellationToken)
        {
            var requestEntity = await _context.Request.FindAsync(request.Id);
            if (requestEntity == null)
            {
                throw new KeyNotFoundException("Request not found");
            }

            return requestEntity.Adapt<RequestDTO>();
        }
    }
}
