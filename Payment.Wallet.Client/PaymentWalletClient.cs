using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Payment.Wallet.Client.Model;

namespace Payment.Wallet.Client;

public interface IPaymentWalletClient
{
    Task<HttpResponseMessage> Get();
    Task<HttpResponseMessage> Deposit(PaymentWalletRequest paymentWalletRequest);
    Task<HttpResponseMessage> Withdraw(PaymentWalletRequest paymentWalletRequest);
}

public class PaymentWalletClient : IPaymentWalletClient
{
    private readonly HttpClient _httpClient;
    private string BaseUrl { get; set; } = "http://localhost:52463/onlinewallet/";
    private MediaTypeWithQualityHeaderValue MediaType { get; set; } = new("application/json");

    public PaymentWalletClient()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(BaseUrl);
        _httpClient.DefaultRequestHeaders
            .Accept
            .Add(MediaType);
    }

    public async Task<HttpResponseMessage> Get()
        => await _httpClient.GetAsync("balance");

    public async Task<HttpResponseMessage> Deposit(PaymentWalletRequest paymentWalletRequest)
    {
        var content = new StringContent(JsonConvert.SerializeObject(paymentWalletRequest),
            Encoding.UTF8,
            MediaType);

        return await _httpClient.PostAsync("deposit", content);
    }

    public async Task<HttpResponseMessage> Withdraw(PaymentWalletRequest paymentWalletRequest)
    {
        var content = new StringContent(JsonConvert.SerializeObject(paymentWalletRequest),
            Encoding.UTF8,
            MediaType);

        return await _httpClient.PostAsync("withdraw", content);
    }
}