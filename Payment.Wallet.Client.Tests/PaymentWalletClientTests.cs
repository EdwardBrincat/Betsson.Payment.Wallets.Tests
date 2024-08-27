using Payment.Wallet.Client.Model;

namespace Payment.Wallet.Client.Tests;

public class PaymentWalletClientTests
{
    private readonly IPaymentWalletClient _paymentWalletClient;

    public PaymentWalletClientTests()
    {
        _paymentWalletClient = new PaymentWalletClient();
    }

    [Test]
    public async Task PaymentWallet_GetBalances_IntegrationTest()
    {
        var response = await _paymentWalletClient.Get();

        Assert.True(response.IsSuccessStatusCode);
        Assert.NotNull(response.Content);
    }

    [Test]
    public async Task PaymentWallet_DepositAmount_IntegrationTest()
    {
        var request = new PaymentWalletRequest
        { Amount = 100 };

        var response = await _paymentWalletClient.Deposit(request);

        Assert.True(response.IsSuccessStatusCode);
        Assert.NotNull(response.Content);
    }

    [Test]
    public async Task PaymentWallet_WithdrawAmount_IntegrationTest()
    {
        var request = new PaymentWalletRequest
        { Amount = 10 };

        var response = await _paymentWalletClient.Withdraw(request);

        Assert.True(response.IsSuccessStatusCode);
        Assert.NotNull(response.Content);
    }
}