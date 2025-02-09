using System.Threading.Tasks;
using Application.Contracts;
using MassTransit;
using Transaction.Application.Features.Request.Commands; // Ensure this namespace

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
}
