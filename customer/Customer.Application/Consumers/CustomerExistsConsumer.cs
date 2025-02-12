using System.Threading.Tasks;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Application.Contracts;
using Customer.Infrastracture.Data;

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

            await context.Publish(new CustomerExistsResponse
            {
                CustomerId = context.Message.CustomerId,
                Exists = exists
            });
        }
    }

    public class CustomerExistsConsumerDefinition : ConsumerDefinition<CustomerExistsConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<CustomerExistsConsumer> consumerConfigurator,
            IRegistrationContext context)
        {
            endpointConfigurator.UseInMemoryInboxOutbox(context);
        }
    }
}
