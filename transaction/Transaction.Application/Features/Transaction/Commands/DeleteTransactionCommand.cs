using MediatR;

namespace Transaction.Application.Features.Transaction.Commands
{
    public class DeleteTransactionCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
