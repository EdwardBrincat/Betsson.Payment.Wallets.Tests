using Newtonsoft.Json;
using Payment.Wallet.Client;
using Payment.Wallet.Client.Client;
using Payment.Wallet.Client.Model;

namespace Payment.Wallet.Services.Service;

public interface IPaymentWalletService
{
    Task<PaymentBalanceResponse> GetWalletBalance();
    Task<PaymentBalanceResponse> Deposit(PaymentDepositRequest paymentDepositRequest);
    Task<PaymentBalanceResponse> Withdraw(PaymentWithdrawRequest paymentWithdrawRequest);
}

public class PaymentWalletService : IPaymentWalletService
{
    private readonly IPaymentWalletClient _client;

    public PaymentWalletService(IPaymentWalletClient client)
    {
        _client = client;
    }

    public async Task<PaymentBalanceResponse> GetWalletBalance()
    {
        var response = await _client.Get();
        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<PaymentBalanceResponse>(responseContent)!;
    }

    public async Task<PaymentBalanceResponse> Deposit(PaymentDepositRequest paymentWalletRequest)
    {
        var response = await _client.Deposit(paymentWalletRequest);
        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<PaymentBalanceResponse>(responseContent)!;
    }

    public async Task<PaymentBalanceResponse> Withdraw(PaymentWithdrawRequest paymentWalletRequest)
    {
        var response = await _client.Withdraw(paymentWalletRequest);
        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<PaymentBalanceResponse>(responseContent)!;
    }
}