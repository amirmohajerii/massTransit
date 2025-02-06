using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mapster;
using MassTransit;
using TransactionMS.Infrastracture.Data;
using Transaction.Infrastracture.http;
using Transaction.Application.Contracts;
using Customer.Application.Contracts;

namespace Transaction.Application.Features.Request.Commands
{
    public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, int>
    {
        private readonly TransactionsDbContext _context;
        private readonly ICustomerService _httpCustomerService;
        // Ensure correct services are being used
        private readonly GrpcCustomerService _grpcCustomerService;
        private readonly IRequestClient<CustomerExists> _customerExistsClient;

        public CreateRequestCommandHandler(TransactionsDbContext context, ICustomerService httpCustomerService, GrpcCustomerService grpcCustomerService, IRequestClient<CustomerExists> customerExistsClient)
        {
            _context = context;
            _httpCustomerService = httpCustomerService;
            _grpcCustomerService = grpcCustomerService;
            _customerExistsClient = customerExistsClient;
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
                var response = await _customerExistsClient.GetResponse<CustomerExistsResponse>(new CustomerExists { CustomerId = request.CustomerId });
                customerExists = response.Message.Exists;
            }

            if (!customerExists)
            {
                throw new ApplicationException("Customer does not exist.");
            }

            var requestEntity = request.Adapt<RequestEN>(); // Using Mapster to map command to entity

            _context.Request.Add(requestEntity);
            await _context.SaveChangesAsync(cancellationToken);

            return requestEntity.Id;
        }
    }
}
