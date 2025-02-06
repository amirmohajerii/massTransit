using MediatR;
using System.Collections.Generic;
using Customer.Domain.Entities;

namespace Customer.Application.Features.LegalCustomer.Queries
{
    public class GetAllLegalCustomersQuery : IRequest<List<LegalCustomerDTO>> { }
}
