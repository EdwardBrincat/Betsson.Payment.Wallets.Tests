using Payment.Wallet.Client;
using Payment.Wallet.Client.Model;
using Payment.Wallet.Command;
using Payment.Wallet.Services;
using Payment.Wallets.Core;
using Payment.Wallets.Core.Common;

namespace Payment.Wallet.Api.Fixtures;

public class PaymentWalletApiFixture
{
    private readonly PaymentWalletCommandFactory _paymentWalletCommandFactory;
    public ScenarioContext ScenarioContext { get; set; }

    public PaymentWalletApiFixture()
    {
        var client = new PaymentWalletClient();
        var service = new PaymentWalletService(client);
        _paymentWalletCommandFactory = new PaymentWalletCommandFactory(service);
    }

    public async Task A_get_wallet_balance_action_is_requested()
    {
        var result = await _paymentWalletCommandFactory.ExecuteGetWalletBalanceCommand();
        ScenarioContext.AddOrUpdateValue($"{PaymentKeys.Balance}", result);
    }

    public async Task A_deposit_amount_action_is_requested(PaymentWalletRequest paymentWalletRequest)
    {
        var result = await _paymentWalletCommandFactory.ExecuteDepositCommand(paymentWalletRequest);
        ScenarioContext.AddOrUpdateValue($"{PaymentKeys.Deposit}", result);
    }

    public async Task A_withdraw_amount_action_is_requested(PaymentWalletRequest paymentWalletRequest)
    {
        var result = await _paymentWalletCommandFactory.ExecuteWithdrawCommand(paymentWalletRequest);
        ScenarioContext.AddOrUpdateValue($"{PaymentKeys.Withdrawal}", result);
    }
}