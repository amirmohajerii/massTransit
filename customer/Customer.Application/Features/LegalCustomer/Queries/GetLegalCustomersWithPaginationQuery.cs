
using MediatR;
using System.Collections.Generic;
using Customer.Domain.Entities;

namespace Customer.Application.Features.LegalCustomer.Queries
{
    public class GetLegalCustomersWithPaginationQuery : IRequest<List<LegalCustomerDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
