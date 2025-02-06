using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TransactionMS.Infrastracture.Data;

namespace Transaction.Application.Features.Request.Commands
{
    public class DeleteRequestCommandHandler : IRequestHandler<DeleteRequestCommand, Unit>
    {
        private readonly TransactionsDbContext _context;

        public DeleteRequestCommandHandler(TransactionsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRequestCommand request, CancellationToken cancellationToken)
        {
            var requestEntity = await _context.Request.FindAsync(request.Id);
            if (requestEntity == null)
            {
                throw new KeyNotFoundException("Request not found");
            }

            _context.Request.Remove(requestEntity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
