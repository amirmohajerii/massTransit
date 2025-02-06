using System.Threading;
using System.Threading.Tasks;
using Customer.Infrastracture.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Customer.Application.Features.Customer.Commands
{
    public class CheckCustomerExistenceCommandHandler : IRequestHandler<CheckCustomerExistenceCommand, bool>
    {
        private readonly MyDbContext _context;

        public CheckCustomerExistenceCommandHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CheckCustomerExistenceCommand request, CancellationToken cancellationToken)
        {
            var exists = await _context.IndividualCustomer.AnyAsync(c => c.Id == request.CustomerId) ||
                         await _context.LegalCustomer.AnyAsync(c => c.Id == request.CustomerId);

            return exists;
        }
    }
}
