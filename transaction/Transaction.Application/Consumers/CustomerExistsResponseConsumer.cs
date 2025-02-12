using System.Threading.Tasks;
using MassTransit;
using Application.Contracts;
using Transaction.Application.Features.Request.Commands;

namespace Transaction.Application.Consumers
{
    public class CustomerExistsResponseConsumer : IConsumer<CustomerExistsResponse>
    {
        private readonly CreateRequestCommandHandler _handler;

        public CustomerExistsResponseConsumer(CreateRequestCommandHandler handler)
        {
            _handler = handler;
        }

        public Task Consume(ConsumeContext<CustomerExistsResponse> context)
        {
            _handler.HandleCustomerExistsResponse(context.Message);
            return Task.CompletedTask;
        }
    }

    public class CustomerExistsResponseConsumerDefinition : ConsumerDefinition<CustomerExistsResponseConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<CustomerExistsResponseConsumer> consumerConfigurator,
            IRegistrationContext context)
        {
            endpointConfigurator.UseInMemoryInboxOutbox(context);
        }
    }
}
