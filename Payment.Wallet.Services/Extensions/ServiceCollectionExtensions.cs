using Microsoft.Extensions.DependencyInjection;
using Payment.Wallet.Client.Client;
using Payment.Wallet.Services.Service;

namespace Payment.Wallet.Services.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterPaymentWalletService(this IServiceCollection services)
    {
        return services.AddTransient<IPaymentWalletService, PaymentWalletService>();
    }
}