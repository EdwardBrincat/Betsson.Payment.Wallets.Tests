using Microsoft.Extensions.Configuration;
using Payment.Wallet.Config.Model;

namespace Payment.Wallet.Config;

public static class ConfigFetcher
{
    public static ServiceSettings GetSettingsConfiguration()
    {
        var serviceSettings = new ServiceSettings();
        var config = new ConfigurationBuilder()
            .SetBasePath($"{Directory.GetCurrentDirectory()}")
            .AddJsonFile("config.json", false)
            .Build();
        config.GetSection("ServiceSettings").Bind(serviceSettings);

        return serviceSettings;
    }
}