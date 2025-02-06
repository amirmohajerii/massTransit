using System.Threading.Tasks;
using Grpc.Core;
using Customer.Presentation.Protos;
using Microsoft.EntityFrameworkCore;
using Customer.Infrastracture.Data;

namespace Customer.Grpc.Services
{
    public class CustomerService : Presentation.Protos.CustomerService.CustomerServiceBase
    {
        private readonly MyDbContext _context;

        public CustomerService(MyDbContext context)
        {
            _context = context;
        }

        public override async Task<CustomerResponse> CheckCustomerExistence(CustomerRequest request, ServerCallContext context)
        {
            var exists = await _context.IndividualCustomer.AnyAsync(c => c.Id == request.CustomerId) ||
                         await _context.LegalCustomer.AnyAsync(c => c.Id == request.CustomerId);

            return new CustomerResponse { Exists = exists };
        }
    }
}
