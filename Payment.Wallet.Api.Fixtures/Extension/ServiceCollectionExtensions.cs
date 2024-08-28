using Microsoft.Extensions.DependencyInjection;
using Payment.Wallet.Api.Fixtures.PaymentWallet;

namespace Payment.Wallet.Api.Fixtures.Extension;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBackOfficeApiFixtures(this IServiceCollection services)
    {
       services.AddScoped<PaymentWalletApiFixture>();
       return services;
    }
}