using Newtonsoft.Json;
using Payment.Wallet.Client;
using Payment.Wallet.Client.Model;

namespace Payment.Wallet.Services;

public interface IPaymentWalletService
{
    Task<PaymentWalletResponse> GetWalletBalance();
    Task<PaymentWalletResponse> Deposit(PaymentWalletRequest paymentWalletRequest);
    Task<PaymentWalletResponse> Withdraw(PaymentWalletRequest paymentWalletRequest);
}

public class PaymentWalletService
{
    private readonly IPaymentWalletClient _client;

    public PaymentWalletService(IPaymentWalletClient client)
    {
        _client = client;
    }

    public async Task<PaymentWalletResponse> GetWalletBalance()
    {
        var response = await _client.Get();
        var responseContent = await response.Content.ReadAsStringAsync();
        var paymentWalletResponse = JsonConvert.DeserializeObject<PaymentWalletResponse>(responseContent);
        return paymentWalletResponse;
    }

    public async Task<PaymentWalletResponse> Deposit(PaymentWalletRequest paymentWalletRequest)
    {
        var response = await _client.Deposit(paymentWalletRequest);
        var responseContent = await response.Content.ReadAsStringAsync();
        var paymentWalletResponse = JsonConvert.DeserializeObject<PaymentWalletResponse>(responseContent);
        return paymentWalletResponse;
    }

    public async Task<PaymentWalletResponse> Withdraw(PaymentWalletRequest paymentWalletRequest)
    {
        var response = await _client.Withdraw(paymentWalletRequest);
        var responseContent = await response.Content.ReadAsStringAsync();
        var paymentWalletResponse = JsonConvert.DeserializeObject<PaymentWalletResponse>(responseContent);
        return paymentWalletResponse;
    }
}