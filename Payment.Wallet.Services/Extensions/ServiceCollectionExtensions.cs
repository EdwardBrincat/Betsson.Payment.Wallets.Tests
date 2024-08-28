using Microsoft.Extensions.DependencyInjection;
using Payment.Wallet.Services.Service;

namespace Payment.Wallet.Services.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterPaymentWalletService(this IServiceCollection services)
    {
        return services.AddSingleton<IPaymentWalletService, PaymentWalletService>();
    }
}