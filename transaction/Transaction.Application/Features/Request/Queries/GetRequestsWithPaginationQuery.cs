using MediatR;
using System.Collections.Generic;
using Transaction.Application.DTOs;

namespace Transaction.Application.Features.Request.Queries
{
    public class GetRequestsWithPaginationQuery : IRequest<List<RequestDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
