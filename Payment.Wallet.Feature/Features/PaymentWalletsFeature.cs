using AutoFixture;
using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.MsTest2;
using Payment.Wallet.Context;
using Payment.Wallet.Contracts;

namespace Payment.Wallet.Feature.Features;

[Label("FEAT 1 - Payment Wallet")]
[FeatureDescription(
    @"In order to manage the Payment Wallet
    As an api service
    I want to be able to deposit, withdraw and get current balance")]
[TestClass]
public class PaymentWalletsFeature : FeatureFixture
{
    [Label("SCENARIO 1 - Perform Payment Wallet Actions Happy Path")]
    [Scenario]
    public async Task Scenario_1_Perform_payment_wallet_actions_happy_path()
        => await Runner.WithContext<PaymentWalletContext>()
            .AddSteps(
                setup => setup.PaymentWalletApiCompositeFixture.A_clean_up_on_the_payment_wallet_is_requested_before_test_commence())
            .AddAsyncSteps(
                given => given.PaymentWalletApiFixture.A_get_wallet_balance_action_is_requested())
            .AddSteps(
                given => given.PaymentWalletApiFixture.The_wallet_balance_should_be_set_to_amount_AMOUNT(ScenarioConst.NoAmount.ToString()))
            .AddAsyncSteps(
                when => when.PaymentWalletApiFixture.A_deposit_amount_action_is_requested(new Fixture().BuildTyrData<PaymentDepositInput>()
                    .With(p => p.Amount, ScenarioConst.DepositAmount.ToString())
                    .Create()),
                then => then.PaymentWalletApiFixture.A_get_wallet_balance_action_is_requested())
            .AddSteps(
                then => then.PaymentWalletApiFixture.The_wallet_balance_should_be_set_to_amount_AMOUNT(ScenarioConst.DepositAmount.ToString()))
            .AddAsyncSteps(
                then => then.PaymentWalletApiFixture.A_withdraw_amount_action_is_requested(new Fixture().BuildTyrData<PaymentWithdrawInput>()
                    .With(p => p.Amount, ScenarioConst.WithdrawAmount.ToString())
                    .Create()),
                then => then.PaymentWalletApiFixture.A_get_wallet_balance_action_is_requested())
            .AddSteps(
                @finally => @finally.PaymentWalletApiFixture.The_wallet_balance_should_be_set_to_amount_AMOUNT($"{ScenarioConst.DepositAmount - ScenarioConst.WithdrawAmount}"))
            .RunAsync();

    [Label("SCENARIO 2 - Perform Payment Wallet Actions Negative Path")]
    [Scenario]
    public async Task Scenario_1_Perform_payment_wallet_actions_negative_path()
        => await Runner.WithContext<PaymentWalletContext>()
            .AddSteps(
                setup => setup.PaymentWalletApiCompositeFixture.A_clean_up_on_the_payment_wallet_is_requested_before_test_commence())
            .AddAsyncSteps(
                given => given.PaymentWalletApiFixture.A_withdraw_amount_action_that_exceeds_the_wallet_balance_is_requested_and_return_message_should_be_MESSAGE(new Fixture().BuildTyrData<PaymentWithdrawInput>()
                        .With(p => p.Amount, ScenarioConst.WithdrawAmount.ToString())
                        .Create(),
                    ScenarioMessagesConst.InsufficientFunds),
                when => when.PaymentWalletApiFixture.A_deposit_amount_action_is_requested(new Fixture().BuildTyrData<PaymentDepositInput>()
                    .With(p => p.Amount, ScenarioConst.DepositAmount.ToString())
                    .Create()),
                then => then.PaymentWalletApiFixture.A_withdraw_amount_action_that_exceeds_the_wallet_balance_is_requested_and_return_message_should_be_MESSAGE(new Fixture().BuildTyrData<PaymentWithdrawInput>()
                        .With(p => p.Amount, ScenarioConst.WithdrawLargerAmount.ToString())
                        .Create(),
                    ScenarioMessagesConst.InsufficientFunds),
                then => then.PaymentWalletApiFixture.A_get_wallet_balance_action_is_requested())
            .AddSteps(
                then => then.PaymentWalletApiFixture.The_wallet_balance_should_be_set_to_amount_AMOUNT(ScenarioConst.DepositAmount.ToString()))
            .AddAsyncSteps(
                then => then.PaymentWalletApiFixture.A_deposit_amount_action_with_an_invalid_is_requested_and_return_message_should_be_MESSAGE(new Fixture().BuildTyrData<PaymentDepositInput>()
                        .With(p => p.Amount, ScenarioConst.InvalidAmount)
                        .Create(),
                    ScenarioMessagesConst.ValidationError))
            .RunAsync();
}