using MediatR;
using Customer.Domain.Entities;

namespace Customer.Application.Features.LegalCustomer.Queries
{
    public class GetLegalCustomerByIdQuery : IRequest<LegalCustomerDTO>
    {
        public int Id { get; set; }
    }
}
