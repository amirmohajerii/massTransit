using MediatR;


namespace Customer.Application.Features.IndividualCustomer.Commands
{
    public class DeleteIndividualCustomerCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
