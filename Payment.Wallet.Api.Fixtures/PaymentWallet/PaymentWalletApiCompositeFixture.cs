using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using Payment.Wallets.Core;

namespace Payment.Wallet.Api.Fixtures.PaymentWallet;

public class PaymentWalletApiCompositeFixture
{
    public ScenarioContext ScenarioContext { get; set; }
    public readonly PaymentWalletApiFixture _paymentWalletApiFixture;

    public PaymentWalletApiCompositeFixture(
        ScenarioContext scenarioContext,
        PaymentWalletApiFixture paymentWalletApiFixture)
    {
        ScenarioContext = scenarioContext;
        _paymentWalletApiFixture = paymentWalletApiFixture;
    }

    public CompositeStep A_clean_up_on_the_payment_wallet_is_requested_before_test_commence()
        => CompositeStep.DefineNew()
            .AddAsyncSteps(
                when => _paymentWalletApiFixture.A_get_wallet_balance_action_is_requested(),
                when => _paymentWalletApiFixture.A_withdraw_amount_all_amount_action_is_requested())
            .Build();
}