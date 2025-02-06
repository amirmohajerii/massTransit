using MediatR;
using Customer.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using Customer.Application.Features.IndividualCustomer.Commands;
using Customer.Infrastracture.Data;

namespace Customer.Application.Features.IndividualCustomer.Commands
{
    public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, int>
    {
        private readonly MyDbContext _context;

        public CreateIndividualCustomerCommandHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = request.Adapt<Domain.Entities.IndividualCustomer>();

            _context.IndividualCustomer.Add(customer);
            await _context.SaveChangesAsync(cancellationToken);

            return customer.Id;
        }
    }
}
