using MediatR;

namespace Transaction.Application.Features.Transaction.Commands
{
    public class UpdateTransactionCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public int RequestId { get; set; }
    }
}
