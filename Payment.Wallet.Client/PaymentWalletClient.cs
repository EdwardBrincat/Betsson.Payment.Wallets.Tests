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
    protected string BaseUrl { get; set; } = "http://localhost:52463/onlinewallet/";

    public PaymentWalletClient()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(BaseUrl);
        _httpClient.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<HttpResponseMessage> Get()
    {
        var response = await _httpClient.GetAsync("balance");
        // var responseContent = await response.Content.ReadAsStringAsync();
        // var paymentWalletResponse = JsonConvert.DeserializeObject<PaymentWalletResponse>(responseContent);
        // return paymentWalletResponse;
        return response;
    }

    public async Task<HttpResponseMessage> Deposit(PaymentWalletRequest paymentWalletRequest)
    {
        var content = new StringContent(JsonConvert.SerializeObject(paymentWalletRequest),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.PostAsync("deposit", content);
        // var responseContent = await response.Content.ReadAsStringAsync();
        // var paymentWalletResponse = JsonConvert.DeserializeObject<PaymentWalletResponse>(responseContent);
        // return paymentWalletResponse;
        return response;
    }

    public async Task<HttpResponseMessage> Withdraw(PaymentWalletRequest paymentWalletRequest)
    {
        var content = new StringContent(JsonConvert.SerializeObject(paymentWalletRequest),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.PostAsync("withdraw", content);
        // var responseContent = await response.Content.ReadAsStringAsync();
        // var paymentWalletResponse = JsonConvert.DeserializeObject<PaymentWalletResponse>(responseContent);
        // return paymentWalletResponse;
        return response;
    }
}