using MediatR;
using System.Collections.Generic;
using Transaction.Application.DTOs;

namespace Transaction.Application.Features.Request.Queries
{
    public class GetAllRequestsQuery : IRequest<List<RequestDTO>> { }
}
