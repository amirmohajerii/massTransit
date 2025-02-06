using MediatR;
using Customer.Domain.Entities;

namespace Customer.Application.Features.IndividualCustomer.Queries
{
    public class GetIndividualCustomerByIdQuery : IRequest<IndividualCustomerDTO>
    {
        public int Id { get; set; }
    }
}
