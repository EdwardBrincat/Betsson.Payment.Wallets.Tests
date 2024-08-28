using Microsoft.Extensions.DependencyInjection;
using Payment.Wallet.Client.Client;

namespace Payment.Wallet.Client.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterPaymentWalletClients(this IServiceCollection services)
    {
        return services.AddTransient<IPaymentWalletClient, PaymentWalletClient>();
    }
}