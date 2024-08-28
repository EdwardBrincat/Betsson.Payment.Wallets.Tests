using AutoMapper;
using LightBDD.Core.Configuration;
using LightBDD.MsTest2;
using LightBDD.NUnit2;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Payment.Wallet.Api.Fixtures.Extension;
using Payment.Wallet.Command.Extensions;
using Payment.Wallet.Command.Tests;
using Payment.Wallet.Context;
using Payment.Wallet.Services.Extensions;

namespace Payment.Wallet.Tests;

internal class ConfiguredLightBddScopeAttribute : LightBddScopeAttribute
{
    public static ServiceCollection Services { get; protected set; }

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
        var mapperConfig = new MapperConfiguration(cfg => { cfg.AddPaymentWalletsMappingProfiles(); });

        Services.AddSingleton(provider => mapperConfig.CreateMapper(provider.GetService));

        Services.RegisterPaymentWalletService();
        Services.AddPaymentWalletMockClients();
        Services.AddPaymentWalletClientCommands();
        Services.AddPaymentWalletApiFixtures();
        Services.AddPaymentWalletContext();
    }
}