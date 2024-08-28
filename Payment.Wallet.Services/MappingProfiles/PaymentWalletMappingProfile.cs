using AutoMapper;
using Payment.Wallet.Client.Model;
using Payment.Wallet.Contracts;

namespace Payment.Wallet.Services.MappingProfiles;

public class PaymentWalletMappingProfile : Profile
{
    public PaymentWalletMappingProfile()
    {
        CreateMap<PaymentWalletModel, PaymentWalletBase>();
        CreateMap<PaymentBalanceResponse, PaymentBalanceResult>();
        CreateMap<PaymentDepositInput, PaymentDepositRequest>();
        CreateMap<PaymentWithdrawInput, PaymentWithdrawRequest>();
    }
}