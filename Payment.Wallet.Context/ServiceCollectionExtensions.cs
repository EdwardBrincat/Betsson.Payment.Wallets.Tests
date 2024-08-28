using Microsoft.Extensions.DependencyInjection;
using Payment.Wallet.Api.Fixtures.Extension;

namespace Payment.Wallet.Context;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPaymentWalletContext(this IServiceCollection services)
    {
        services.AddPaymentWalletApiFixtures();
        services.AddScoped<PaymentWalletContext>();

        return services;
    }
}