using FluentAssertions;
using Payment.Wallet.Command.PaymentWallet;
using Payment.Wallet.Contracts;
using Payment.Wallets.Core;
using Payment.Wallets.Core.Common;

namespace Payment.Wallet.Api.Fixtures.PaymentWallet;

public class PaymentWalletApiFixture
{
    public ScenarioContext ScenarioContext { get; set; }
    private readonly PaymentWalletCommandFactory _paymentWalletCommandFactory;

    public PaymentWalletApiFixture(
        ScenarioContext scenarioContext,
        PaymentWalletCommandFactory paymentWalletCommandFactory)
    {
        ScenarioContext = scenarioContext;
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

    public void The_wallet_balance_should_be_set_to_amount_AMOUNT(int amount)
    {
        var balance = ScenarioContext.GetValue<PaymentBalanceResult>($"{PaymentKeys.Balance}");
        balance.Amount.Should().Be(amount);
    }
}