using MediatR;
using Customer.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using Customer.Infrastracture.Data;
using Customer.Application.Features.LegalCustomer.Commnads;

namespace Customer.Application.Features.IndividualCustomer.Commands
{
    public class CreateLegalCustomerCommandHandler : IRequestHandler<CreateLegalCustomerCommand, int>
    {
        private readonly MyDbContext _context;

        public CreateLegalCustomerCommandHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateLegalCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = request.Adapt<Domain.Entities.LegalCustomer>();

            _context.LegalCustomer.Add(customer);
            await _context.SaveChangesAsync(cancellationToken);

            return customer.Id;
        }
    }
}
