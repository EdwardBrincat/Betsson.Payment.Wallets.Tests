using Microsoft.Extensions.DependencyInjection;

namespace Payment.Wallets.Core.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddCore(this IServiceCollection services)
	{
		services.AddScoped<ScenarioContext>();
		return services;
	}
}