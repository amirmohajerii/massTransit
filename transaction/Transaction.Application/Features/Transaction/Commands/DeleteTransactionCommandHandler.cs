using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TransactionMS.Infrastracture.Data;

namespace Transaction.Application.Features.Transaction.Commands
{
    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, Unit>
    {
        private readonly TransactionsDbContext _context;

        public DeleteTransactionCommandHandler(TransactionsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _context.Transaction.FindAsync(request.Id);
            if (transaction == null)
            {
                throw new KeyNotFoundException("Transaction not found");
            }

            _context.Transaction.Remove(transaction);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
