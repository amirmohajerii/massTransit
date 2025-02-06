using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Customer.Domain.Entities;
using Customer.Infrastracture.Data;
using Customer.Application.Features.IndividualCustomer.Commands;

namespace Customer.Application.Features.IndividualCustomer.Commands
{
    public class UpdateIndividualCustomerCommandHandler : IRequestHandler<UpdateIndividualCustomerCommand, Unit>
    {
        private readonly MyDbContext _context;

        public UpdateIndividualCustomerCommandHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
            var individualCustomer = await _context.IndividualCustomer.FindAsync(request.Id);
            if (individualCustomer == null)
            {
                throw new KeyNotFoundException("Individual customer not found");
            }

            request.Adapt(individualCustomer);

            _context.IndividualCustomer.Update(individualCustomer);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
