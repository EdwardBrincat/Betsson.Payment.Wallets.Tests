using FluentAssertions;
using Payment.Wallet.Contracts;

namespace Payment.Wallet.Validators.PaymentWallet;

public class PaymentWalletValidator
{
    public void ValidatePaymentDepositInput(PaymentDepositInput input)
    {
        input.Amount.Should().BeGreaterThan(0);
    }

    public void ValidatePaymentWithdrawInput(PaymentWithdrawInput input)
    {
        input.Amount.Should().BeGreaterThan(0);
    }
}