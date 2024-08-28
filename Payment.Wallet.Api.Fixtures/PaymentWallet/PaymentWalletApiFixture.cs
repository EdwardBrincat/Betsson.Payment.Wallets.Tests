using Payment.Wallet.Command.PaymentWallet;
using Payment.Wallet.Contracts;
using Payment.Wallets.Core;
using Payment.Wallets.Core.Common;

namespace Payment.Wallet.Api.Fixtures.PaymentWallet;

public class PaymentWalletApiFixture
{
    private readonly PaymentWalletCommandFactory _paymentWalletCommandFactory;
    public ScenarioContext ScenarioContext { get; set; }

    public PaymentWalletApiFixture(PaymentWalletCommandFactory paymentWalletCommandFactory)
    {
        _paymentWalletCommandFactory = paymentWalletCommandFactory;
    }

    public async Task A_get_wallet_balance_action_is_requested()
    {
        var result = await _paymentWalletCommandFactory.ExecuteGetWalletBalanceCommand();
        ScenarioContext.AddOrUpdateValue($"{PaymentKeys.Balance}", result);
    }

    public async Task A_deposit_amount_action_is_requested(PaymentDepositInput paymentDepositInput)
    {
        var result = await _paymentWalletCommandFactory.ExecuteDepositCommand(paymentDepositInput);
        ScenarioContext.AddOrUpdateValue($"{PaymentKeys.Deposit}", result);
    }

    public async Task A_withdraw_amount_action_is_requested(PaymentWithdrawInput paymentWithdrawInput)
    {
        var result = await _paymentWalletCommandFactory.ExecuteWithdrawCommand(paymentWithdrawInput);
        ScenarioContext.AddOrUpdateValue($"{PaymentKeys.Withdrawal}", result);
    }
}