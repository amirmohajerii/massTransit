using MediatR;
using Transaction.Application.DTOs;

namespace Transaction.Application.Features.Request.Queries
{
    public class GetRequestByIdQuery : IRequest<RequestDTO>
    {
        public int Id { get; set; }
    }
}
