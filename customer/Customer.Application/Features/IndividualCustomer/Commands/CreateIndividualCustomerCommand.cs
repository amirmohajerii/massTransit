using MediatR;


namespace Customer.Application.Features.IndividualCustomer.Commands
{
    public class CreateIndividualCustomerCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string NationalId { get; set; }
        public int UserId { get; set; }
    }
}
