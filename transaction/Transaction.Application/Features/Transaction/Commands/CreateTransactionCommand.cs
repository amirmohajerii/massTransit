using MediatR;

namespace Transaction.Application.Features.Transaction.Commands
{
    public class CreateTransactionCommand : IRequest<int>
    {
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public int RequestId { get; set; }
    }
}
