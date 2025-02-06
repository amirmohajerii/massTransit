using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Customer.Infrastracture.Data;
using Customer.Domain.Entities;

namespace Customer.Application.Features.IndividualCustomer.Queries
{
    public class GetIndividualCustomersWithPaginationQueryHandler : IRequestHandler<GetIndividualCustomersWithPaginationQuery, List<IndividualCustomerDTO>>
    {
        private readonly MyDbContext _context;

        public GetIndividualCustomersWithPaginationQueryHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<IndividualCustomerDTO>> Handle(GetIndividualCustomersWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var individualCustomers = await _context.IndividualCustomer
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var individualCustomerDTOs = individualCustomers.Adapt<List<IndividualCustomerDTO>>();
            return individualCustomerDTOs;
        }
    }
}
