using Payment.Wallet.Client.Model;
using Payment.Wallet.Services;

namespace Payment.Wallet.Command;

public interface IPaymentWalletCommandFactory
{
    Task<PaymentWalletResponse> ExecuteGetWalletBalanceCommand();
    Task<PaymentWalletResponse> ExecuteDepositCommand(PaymentWalletRequest paymentWalletRequest);
    Task<PaymentWalletResponse> ExecuteWithdrawCommand(PaymentWalletRequest paymentWalletRequest);
}

public class PaymentWalletCommandFactory
{
    private readonly PaymentWalletService _service;

    public PaymentWalletCommandFactory(
        PaymentWalletService service
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