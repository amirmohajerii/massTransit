using MediatR;

namespace Customer.Application.Features.Customer.Commands
{
    public class CheckCustomerExistenceCommand : IRequest<bool>
    {
        public int CustomerId { get; set; }
    }
}
