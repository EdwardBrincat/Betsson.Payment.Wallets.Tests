using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Payment.Wallet.Client.Model;
using Payment.Wallet.Config;

namespace Payment.Wallet.Client.Client;

public interface IPaymentWalletClient
{
    Task<HttpResponseMessage> Get();
    Task<HttpResponseMessage> Deposit(PaymentDepositRequest paymentDepositRequest);
    Task<HttpResponseMessage> Withdraw(PaymentWithdrawRequest paymentWithdrawRequest);
}

public class PaymentWalletClient : IPaymentWalletClient
{
    private readonly HttpClient _httpClient;
    private MediaTypeWithQualityHeaderValue MediaType { get; set; } = new("application/json");

    public PaymentWalletClient()
    {
        var serviceSettings = ConfigFetcher.GetSettingsConfiguration();
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(serviceSettings.BaseUrl);
        _httpClient.DefaultRequestHeaders
            .Accept
            .Add(MediaType);
    }

    public async Task<HttpResponseMessage> Get()
        => await _httpClient.GetAsync("balance");

    public async Task<HttpResponseMessage> Deposit(PaymentDepositRequest paymentDepositRequest)
    {
        var content = new StringContent(JsonConvert.SerializeObject(paymentDepositRequest),
            Encoding.UTF8,
            MediaType);

        return await _httpClient.PostAsync("deposit", content);
    }

    public async Task<HttpResponseMessage> Withdraw(PaymentWithdrawRequest paymentWithdrawRequest)
    {
        var content = new StringContent(JsonConvert.SerializeObject(paymentWithdrawRequest),
            Encoding.UTF8,
            MediaType);

        return await _httpClient.PostAsync("withdraw", content);
    }
}