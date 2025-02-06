using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Transaction.Infrastracture.http;

public class CustomerService : ICustomerService
{
    private readonly HttpClient _httpClient;

    public CustomerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> CustomerExistsAsync(int customerId)
    {
        var response = await _httpClient.GetFromJsonAsync<bool>($"api/customer/exists/{customerId}");
        return response;
    }
}
