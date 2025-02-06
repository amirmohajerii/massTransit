using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Customer.Domain.Entities;
using Customer.Infrastracture.Data;
using Customer.Application.Features.LegalCustomer.Commands;
using Customer.Application.Features.IndividualCustomer.Commands;
using Customer.Application.Features.legalCustomer.Commands;

namespace Customer.Application.Features.LegalCustomer.Commands
{
    public class UpdateLegalCustomerCommandHandler : IRequestHandler<UpdateLegalCustomerCommand, Unit>
    {
        private readonly MyDbContext _context;

        public UpdateLegalCustomerCommandHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateLegalCustomerCommand request, CancellationToken cancellationToken)
        {
            var legalCustomer = await _context.LegalCustomer.FindAsync(request.Id);
            if (legalCustomer == null)
            {
                throw new KeyNotFoundException("Legal customer not found");
            }

            request.Adapt(legalCustomer);

            _context.LegalCustomer.Update(legalCustomer);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
