using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mapster;
using Customer.Domain.Entities;
using Customer.Infrastracture.Data;
using Customer.Application.Features.LegalCustomer.Commands;

namespace Customer.Application.Features.LegalCustomer.Commands
{
    public class DeleteLegalCustomerCommandHandler : IRequestHandler<DeleteLegalCustomerCommand, Unit>
    {
        private readonly MyDbContext _context;

        public DeleteLegalCustomerCommandHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteLegalCustomerCommand request, CancellationToken cancellationToken)
        {
            var legalCustomer = await _context.LegalCustomer.FindAsync(request.Id);
            if (legalCustomer == null)
            {
                throw new KeyNotFoundException("Legal customer not found");
            }

            _context.LegalCustomer.Remove(legalCustomer);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
