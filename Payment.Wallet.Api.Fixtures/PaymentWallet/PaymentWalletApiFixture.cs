using AutoFixture;
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
    
    public async Task A_withdraw_amount_action_that_exceeds_the_wallet_balance_is_requested_and_return_message_should_be_MESSAGE(PaymentWithdrawInput paymentWithdrawInput, string message)
    {
        var result = await _paymentWalletCommandFactory.ExecuteWithdrawCommand(paymentWithdrawInput);
        result.Title.Should().Be(message);
    }
    
    public async Task A_deposit_amount_action_with_an_invalid_is_requested_and_return_message_should_be_MESSAGE(PaymentDepositInput paymentDepositInput, string message)
    {
        var result = await _paymentWalletCommandFactory.ExecuteDepositCommand(paymentDepositInput);
        result.Title.Should().Be(message);
    }

    public void The_wallet_balance_should_be_set_to_amount_AMOUNT(string amount)
    {
        var balance = ScenarioContext.GetValue<PaymentBalanceResult>($"{PaymentKeys.Balance}");
        balance.Amount.Should().Be(amount);
    }
    
    public async Task A_withdraw_amount_all_amount_action_is_requested()
    {
        var balance = ScenarioContext.GetValue<PaymentBalanceResult>($"{PaymentKeys.Balance}");
        
        if(balance.Amount == "0")
            return;
        var result = await _paymentWalletCommandFactory.ExecuteWithdrawCommand(new Fixture().BuildTyrData<PaymentWithdrawInput>()
            .With(p => p.Amount, balance.Amount)
            .Create());
    }
}