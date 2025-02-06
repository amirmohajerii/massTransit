using MediatR;

namespace Customer.Application.Features.IndividualCustomer.Commands
{
    public class UpdateIndividualCustomerCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public string NationalId { get; set; }
        public int UserId { get; set; }
        public int Id { get; set; }
    }
}
