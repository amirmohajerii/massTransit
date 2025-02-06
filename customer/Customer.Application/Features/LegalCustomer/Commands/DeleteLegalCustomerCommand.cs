using MediatR;


namespace Customer.Application.Features.LegalCustomer.Commands
{
    public class DeleteLegalCustomerCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
