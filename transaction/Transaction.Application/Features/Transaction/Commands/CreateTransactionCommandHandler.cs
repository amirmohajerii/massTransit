using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mapster;
using TransactionMS.Infrastracture.Data;
using TransactionMS.Domain.Entities;

namespace Transaction.Application.Features.Transaction.Commands
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, int>
    {
        private readonly TransactionsDbContext _context;

        public CreateTransactionCommandHandler(TransactionsDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = request.Adapt<TransactionEN>(); // Using Mapster to map command to entity

            _context.Transaction.Add(transaction);
            await _context.SaveChangesAsync(cancellationToken);

            return transaction.Id;
        }
    }
}
