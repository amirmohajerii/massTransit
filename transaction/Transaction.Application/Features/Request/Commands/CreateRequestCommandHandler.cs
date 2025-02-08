using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mapster;
using MassTransit;
using TransactionMS.Infrastracture.Data;
using Transaction.Infrastracture.http;
using Transaction.Application.Contracts;

namespace Transaction.Application.Features.Request.Commands
{
    public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, int>
    {
        private readonly TransactionsDbContext _context;
        private readonly ICustomerService _httpCustomerService;
        private readonly GrpcCustomerService _grpcCustomerService;
        private readonly IPublishEndpoint _publishEndpoint; // Use IPublishEndpoint

        public CreateRequestCommandHandler(TransactionsDbContext context, ICustomerService httpCustomerService, GrpcCustomerService grpcCustomerService, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _httpCustomerService = httpCustomerService;
            _grpcCustomerService = grpcCustomerService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<int> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {
            bool customerExists = false;

            if (request.Method == 1) // HTTP
            {
                customerExists = await _httpCustomerService.CustomerExistsAsync(request.CustomerId);
            }
            else if (request.Method == 2) // gRPC
            {
                customerExists = await _grpcCustomerService.CustomerExistsAsync(request.CustomerId);
            }
            else if (request.Method == 3) // RabbitMQ
            {
                await _publishEndpoint.Publish(new CustomerExists { CustomerId = request.CustomerId }, cancellationToken);
                // Note: Add appropriate logic to handle asynchronous message processing response here
                customerExists = true; // For demonstration purposes, assume response is always true
            }

            if (!customerExists)
            {
                throw new ApplicationException("Customer does not exist.");
            }

            var requestEntity = request.Adapt<RequestEN>();
            _context.Request.Add(requestEntity);
            await _context.SaveChangesAsync(cancellationToken);

            return requestEntity.Id;
        }
    }
}
