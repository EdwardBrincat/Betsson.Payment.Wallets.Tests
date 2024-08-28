using Microsoft.Extensions.DependencyInjection;
using Moq;
using Payment.Wallet.Client.Client;

namespace Payment.Wallet.Command.Tests;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPaymentWalletMockClients(this IServiceCollection services)
    {
        var paymentWalletClient = new Mock<IPaymentWalletClient>();
        services.AddSingleton(paymentWalletClient.Object);
        services.AddSingleton(paymentWalletClient);

        return services;
    }
}