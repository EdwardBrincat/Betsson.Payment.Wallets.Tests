using AutoMapper;
using LightBDD.Core.Configuration;
using LightBDD.Extensions.DependencyInjection;
using LightBDD.Framework.Configuration;
using LightBDD.Framework.Reporting.Formatters;
using LightBDD.MsTest2;
using Microsoft.Extensions.DependencyInjection;
using Payment.Wallet.Api.Fixtures.Extension;
using Payment.Wallet.Client.Extensions;
using Payment.Wallet.Command.Extensions;
using Payment.Wallet.Context;
using Payment.Wallet.Services.Extensions;
using Payment.Wallets.Core.Extensions;

[assembly: Parallelize(Scope = ExecutionScope.ClassLevel)]

namespace Payment.Wallet.Feature;

[TestClass]
internal class LightBddIntegration
{
    private static ServiceProvider Services { get; set; }

    [AssemblyInitialize]
    public static void Setup(TestContext testContext)
    {
        LightBddScope.Initialize(OnConfigure);
    }

    [AssemblyCleanup]
    public static void Cleanup()
    {
        LightBddScope.Cleanup();
    }

    private static void OnConfigure(LightBddConfiguration configuration)
    {
        Services = BuildContainer();

        configuration.DependencyContainerConfiguration()
            .UseContainer(Services, true);

        configuration.ExecutionExtensionsConfiguration();

        configuration
            .ReportWritersConfiguration()
            .AddFileWriter<XmlReportFormatter>("~\\Reports\\FeaturesReport.xml")
            .AddFileWriter<PlainTextReportFormatter>("~\\Reports\\{TestDateTimeUtc:yyyy-MM-dd-HH_mm_ss}_FeaturesReport.txt");
    }

    private static ServiceProvider BuildContainer()
    {
        var services = new ServiceCollection();
        var mapperConfig = new MapperConfiguration(cfg => { cfg.AddPaymentWalletsMappingProfiles(); });

        services.AddSingleton(provider => mapperConfig.CreateMapper(provider.GetService));
        services.RegisterPaymentWalletClients();
        services.RegisterPaymentWalletService();
        services.AddPaymentWalletClientCommands();
        services.AddPaymentWalletApiFixtures();
        services.AddPaymentWalletContext();
        services.AddCore();

        var serviceProvider = services
            .BuildServiceProvider();

        return serviceProvider;
    }
}