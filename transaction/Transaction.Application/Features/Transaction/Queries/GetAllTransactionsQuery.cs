using MediatR;
using System.Collections.Generic;
using Transaction.Application.DTOs;

namespace Transaction.Application.Features.Transaction.Queries
{
    public class GetAllTransactionsQuery : IRequest<List<TransactionDTO>> { }
}
