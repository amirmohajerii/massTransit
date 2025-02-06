using MediatR;
using System.Collections.Generic;
using Customer.Domain.Entities;

namespace Customer.Application.Features.IndividualCustomer.Queries
{
    public class GetAllIndividualCustomersQuery : IRequest<List<IndividualCustomerDTO>> { }
}
