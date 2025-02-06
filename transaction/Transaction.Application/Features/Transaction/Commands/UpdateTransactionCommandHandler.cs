using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TransactionMS.Infrastracture.Data;

namespace Transaction.Application.Features.Transaction.Commands
{
    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, Unit>
    {
        private readonly TransactionsDbContext _context;

        public UpdateTransactionCommandHandler(TransactionsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _context.Transaction.FindAsync(request.Id);
            if (transaction == null)
            {
                throw new KeyNotFoundException("Transaction not found");
            }

            transaction.CustomerId = request.CustomerId;
            transaction.Amount = request.Amount;
            transaction.TransactionDate = request.TransactionDate;
            transaction.RequestId = request.RequestId;

            _context.Transaction.Update(transaction);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
