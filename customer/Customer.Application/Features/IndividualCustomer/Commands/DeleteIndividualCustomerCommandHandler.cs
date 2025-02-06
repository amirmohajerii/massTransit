using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mapster;
using Customer.Domain.Entities;
using Customer.Infrastracture.Data;
using Customer.Application.Features.IndividualCustomer.Commands;

namespace Customer.Application.Features.IndividualCustomer.Commands
{
    public class DeleteIndividualCustomerCommandHandler : IRequestHandler<DeleteIndividualCustomerCommand, Unit>
    {
        private readonly MyDbContext _context;

        public DeleteIndividualCustomerCommandHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
            var individualCustomer = await _context.IndividualCustomer.FindAsync(request.Id);
            if (individualCustomer == null)
            {
                throw new KeyNotFoundException("Individual customer not found");
            }

            _context.IndividualCustomer.Remove(individualCustomer);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
