using System.Threading.Tasks;
using Customer.Grpc.Protos;
using Grpc.Net.Client;

public class GrpcCustomerService 
{
    private readonly Customer.Grpc.Protos.CustomerService.CustomerServiceClient _customerServiceClient;
    

    public GrpcCustomerService(Customer.Grpc.Protos.CustomerService.CustomerServiceClient customerServiceClient)
    {
        _customerServiceClient = customerServiceClient;
    }

    public async Task<bool> CustomerExistsAsync(int customerId)
    {
        var request = new CustomerRequest { CustomerId = customerId };
        var response = await _customerServiceClient.CheckCustomerExistenceAsync(request);
        return response.Exists;
    }
}
