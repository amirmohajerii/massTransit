using MediatR;

namespace Transaction.Application.Features.Request.Commands
{
    public class UpdateRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string RequestType { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
