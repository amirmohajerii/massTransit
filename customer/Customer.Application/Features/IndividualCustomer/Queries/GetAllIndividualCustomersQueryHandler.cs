using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mapster;
using Customer.Infrastracture.Data;
using Customer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Customer.Application.Features.IndividualCustomer.Queries
{
    public class GetAllIndividualCustomersQueryHandler : IRequestHandler<GetAllIndividualCustomersQuery, List<IndividualCustomerDTO>>
    {
        private readonly MyDbContext _context;

        public GetAllIndividualCustomersQueryHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<IndividualCustomerDTO>> Handle(GetAllIndividualCustomersQuery request, CancellationToken cancellationToken)
        {
            var individualCustomers = await _context.IndividualCustomer.ToListAsync(cancellationToken);
            var individualCustomerDTOs = individualCustomers.Adapt<List<IndividualCustomerDTO>>();
            return individualCustomerDTOs;
        }
    }
}
