using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mapster;
using Customer.Infrastracture.Data;
using Customer.Application;
using Customer.Domain.Entities;

namespace Customer.Application.Features.LegalCustomer.Queries
{
    public class GetLegalCustomerByIdQueryHandler : IRequestHandler<GetLegalCustomerByIdQuery, LegalCustomerDTO>
    {
        private readonly MyDbContext _context;

        public GetLegalCustomerByIdQueryHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<LegalCustomerDTO> Handle(GetLegalCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var legalCustomer = await _context.LegalCustomer.FindAsync(request.Id);
            if (legalCustomer == null)
            {
                throw new KeyNotFoundException("Legal customer not found");
            }

            var legalCustomerDTO = legalCustomer.Adapt<LegalCustomerDTO>();
            return legalCustomerDTO;
        }
    }
}
