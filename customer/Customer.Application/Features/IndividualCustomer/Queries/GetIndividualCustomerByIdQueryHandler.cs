using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mapster;
using Customer.Infrastracture.Data;
using Customer.Application;
using Customer.Domain.Entities;

namespace Customer.Application.Features.IndividualCustomer.Queries
{
    public class GetIndividualCustomerByIdQueryHandler : IRequestHandler<GetIndividualCustomerByIdQuery, IndividualCustomerDTO>
    {
        private readonly MyDbContext _context;

        public GetIndividualCustomerByIdQueryHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IndividualCustomerDTO> Handle(GetIndividualCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var individualCustomer = await _context.IndividualCustomer.FindAsync(request.Id);
            if (individualCustomer == null)
            {
                // Handle not found, throw an exception or return a suitable response
                throw new KeyNotFoundException("Individual customer not found");
            }

            var individualCustomerDTO = individualCustomer.Adapt<IndividualCustomerDTO>();
            return individualCustomerDTO;
        }
    }
}
