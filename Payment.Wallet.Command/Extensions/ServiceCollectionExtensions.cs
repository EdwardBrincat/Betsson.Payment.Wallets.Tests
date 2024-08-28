using Microsoft.Extensions.DependencyInjection;
using Payment.Wallet.Command.PaymentWallet;

namespace Payment.Wallet.Command.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPaymentWalletClientCommands(this IServiceCollection services)
    {
        services.AddSingleton<PaymentWalletCommandFactory>();
        return services;
    }
}