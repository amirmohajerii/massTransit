using MediatR;

namespace Transaction.Application.Features.Request.Commands
{
    public class CreateRequestCommand : IRequest<int>
    {
        public int CustomerId { get; set; }
        public string RequestType { get; set; }
        public DateTime RequestDate { get; set; }
        public int Method { get; set; } // 1 for HTTP, 2 for gRPC
    }
}
