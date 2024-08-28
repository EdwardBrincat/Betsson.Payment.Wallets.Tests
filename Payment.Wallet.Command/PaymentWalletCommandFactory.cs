using Payment.Wallet.Client.Model;
using Payment.Wallet.Services;

namespace Payment.Wallet.Command;

public class PaymentWalletCommandFactory
{
    private readonly IPaymentWalletService _service;

    public PaymentWalletCommandFactory(
        IPaymentWalletService service
    )
    {
        _service = service;
    }

    public Task<PaymentWalletResponse> ExecuteGetWalletBalanceCommand()
        => _service.GetWalletBalance();

    public Task<PaymentWalletResponse> ExecuteDepositCommand(PaymentWalletRequest paymentWalletRequest)
        => _service.Deposit(paymentWalletRequest);

    public Task<PaymentWalletResponse> ExecuteWithdrawCommand(PaymentWalletRequest paymentWalletRequest)
        => _service.Withdraw(paymentWalletRequest);
}