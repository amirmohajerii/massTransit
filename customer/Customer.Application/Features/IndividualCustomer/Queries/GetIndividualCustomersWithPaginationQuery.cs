
using MediatR;
using System.Collections.Generic;
using Customer.Domain.Entities;

namespace Customer.Application.Features.IndividualCustomer.Queries
{
    public class GetIndividualCustomersWithPaginationQuery : IRequest<List<IndividualCustomerDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
