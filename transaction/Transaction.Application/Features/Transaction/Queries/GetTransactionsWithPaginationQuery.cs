using MediatR;
using System.Collections.Generic;
using Transaction.Application.DTOs;

namespace Transaction.Application.Features.Transaction.Queries
{
    public class GetTransactionsWithPaginationQuery : IRequest<List<TransactionDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
