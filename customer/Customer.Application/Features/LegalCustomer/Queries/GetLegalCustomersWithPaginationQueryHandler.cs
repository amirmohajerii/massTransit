using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Customer.Infrastracture.Data;
using Customer.Domain.Entities;
using Customer.Application.Features.LegalCustomer.Queries;

namespace Customer.Application.Features.LegalCustomer.Queries
{
    public class GetLegalCustomersWithPaginationQueryHandler : IRequestHandler<GetLegalCustomersWithPaginationQuery, List<LegalCustomerDTO>>
    {
        private readonly MyDbContext _context;

        public GetLegalCustomersWithPaginationQueryHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<LegalCustomerDTO>> Handle(GetLegalCustomersWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var legalCustomers = await _context.LegalCustomer
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var legalCustomerDTOs = legalCustomers.Adapt<List<LegalCustomerDTO>>();
            return legalCustomerDTOs;
        }
    }
}
