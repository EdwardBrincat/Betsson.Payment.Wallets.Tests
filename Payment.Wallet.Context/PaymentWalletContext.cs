using Payment.Wallet.Api.Fixtures.PaymentWallet;
using Payment.Wallets.Core;

namespace Payment.Wallet.Context;

public class PaymentWalletContext
{
    public ScenarioContext ScenarioContext { get; set; }
    public PaymentWalletApiFixture PaymentWalletApiFixture { get; }
    public PaymentWalletApiCompositeFixture PaymentWalletApiCompositeFixture { get; }

    public PaymentWalletContext(
        ScenarioContext scenarioContext,
        PaymentWalletApiFixture paymentWalletApiFixture,
        PaymentWalletApiCompositeFixture paymentWalletApiCompositeFixture
    )
    {
        ScenarioContext = scenarioContext;
        PaymentWalletApiFixture = paymentWalletApiFixture;
        PaymentWalletApiCompositeFixture = paymentWalletApiCompositeFixture;
    }
}