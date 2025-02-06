using MediatR;

namespace Transaction.Application.Features.Request.Commands
{
    public class DeleteRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
