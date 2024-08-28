using AutoMapper;
using Payment.Wallet.Services.MappingProfiles;

namespace Payment.Wallet.Services.Extensions;

public static class PaymentWalletServicesMapperProfileExtensions
{
    public static IMapperConfigurationExpression AddPaymentWalletsMappingProfiles(this IMapperConfigurationExpression mapper)
	{
		mapper.AddProfile<PaymentWalletMappingProfile>();

		return mapper;
	}
}