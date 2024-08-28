using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.MsTest2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Wallet.Context;

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
            .AddAsyncSteps(
                given => given.PaymentWalletApiFixture.A_get_wallet_balance_action_is_requested())
            .AddSteps(
                then => then.PaymentWalletApiFixture.The_wallet_balance_should_be_set_to_zero())
            .RunAsync();
}