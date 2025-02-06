using MediatR;

namespace Customer.Application.Features.legalCustomer.Commands
{
    public class UpdateLegalCustomerCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public string CompanyRegistrationNumber { get; set; }
        public int UserId { get; set; }
        public int Id { get; set; }
    }
}
