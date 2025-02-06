using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mapster;
using Customer.Infrastracture.Data;
using Customer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Customer.Application.Features.LegalCustomer.Queries
{
    public class GetAllLegalCustomersQueryHandler : IRequestHandler<GetAllLegalCustomersQuery, List<LegalCustomerDTO>>
    {
        private readonly MyDbContext _context;

        public GetAllLegalCustomersQueryHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<LegalCustomerDTO>> Handle(GetAllLegalCustomersQuery request, CancellationToken cancellationToken)
        {
            var legalCustomers = await _context.LegalCustomer.ToListAsync(cancellationToken);
            var legalCustomerDTOs = legalCustomers.Adapt<List<LegalCustomerDTO>>();
            return legalCustomerDTOs;
        }
    }
}
