using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Payment.Wallet.Command.Extensions;
using Payment.Wallet.Services.Extensions;

namespace Payment.Wallet.Command.Tests;

public class PaymentWalletComponentTestsStartUp
{
    private IServiceProvider _serviceProvider;
    public ServiceCollection Services { get; protected set; }
    public IServiceProvider ServiceProvider => _serviceProvider ??= Services.BuildServiceProvider();

    public ServiceCollection BuildContainer()
    {
        Services = new ServiceCollection();

        var mapperConfig = new MapperConfiguration(cfg => { cfg.AddPaymentWalletsMappingProfiles(); });

        Services.AddSingleton(provider => mapperConfig.CreateMapper(provider.GetService));

        Services.RegisterPaymentWalletService();
        Services.AddPaymentWalletMockClients();
        Services.AddPaymentWalletClientCommands();


        return Services;
    }
}