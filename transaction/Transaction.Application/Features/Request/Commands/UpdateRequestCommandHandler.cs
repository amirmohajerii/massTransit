using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TransactionMS.Infrastracture.Data;

namespace Transaction.Application.Features.Request.Commands
{
    public class UpdateRequestCommandHandler : IRequestHandler<UpdateRequestCommand, Unit>
    {
        private readonly TransactionsDbContext _context;

        public UpdateRequestCommandHandler(TransactionsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateRequestCommand request, CancellationToken cancellationToken)
        {
            var requestEntity = await _context.Request.FindAsync(request.Id);
            if (requestEntity == null)
            {
                throw new KeyNotFoundException("Request not found");
            }

            requestEntity.CustomerId = request.CustomerId;
            requestEntity.RequestType = request.RequestType;
            requestEntity.RequestDate = request.RequestDate;

            _context.Request.Update(requestEntity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
