using System.Threading.Tasks;
using MassTransit;
using Customer.Application.Contracts;
using Customer.Infrastracture.Data;
using Microsoft.EntityFrameworkCore;

namespace Customer.Application.Consumers
{
    public class CustomerExistsConsumer : IConsumer<CustomerExists>
    {
        private readonly MyDbContext _context;

        public CustomerExistsConsumer(MyDbContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<CustomerExists> context)
        {
            var exists = await _context.IndividualCustomer
                .AnyAsync(c => c.Id == context.Message.CustomerId) ||
                         await _context.LegalCustomer
                .AnyAsync(c => c.Id == context.Message.CustomerId);

            await context.RespondAsync(new CustomerExistsResponse { Exists = exists });
        }
    }
}
