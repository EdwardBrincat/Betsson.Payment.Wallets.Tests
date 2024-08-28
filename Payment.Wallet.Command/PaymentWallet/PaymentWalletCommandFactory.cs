using AutoMapper;
using Payment.Wallet.Client.Model;
using Payment.Wallet.Contracts;
using Payment.Wallet.Services.Service;

namespace Payment.Wallet.Command.PaymentWallet;

public class PaymentWalletCommandFactory
{
    private readonly IPaymentWalletService _service;
    private readonly IMapper _mapper;

    public PaymentWalletCommandFactory(
        IMapper mapper,
        IPaymentWalletService service
    )
    {
        _mapper = mapper;
        _service = service;
    }

    public async Task<PaymentBalanceResult> ExecuteGetWalletBalanceCommand()
    {
        var response = _service.GetWalletBalance();
        return _mapper.Map<PaymentBalanceResult>(response.Result);
    }


    public async Task<PaymentBalanceResult> ExecuteDepositCommand(PaymentDepositInput paymentDepositInput)
    {
        var request = _mapper.Map<PaymentDepositRequest>(paymentDepositInput);
        var response = _service.Deposit(request);
        return _mapper.Map<PaymentBalanceResult>(response.Result);
    }


    public async Task<PaymentBalanceResult> ExecuteWithdrawCommand(PaymentWithdrawInput paymentWithdrawInput)
    {
        var request = _mapper.Map<PaymentWithdrawRequest>(paymentWithdrawInput);
        var response = _service.Withdraw(request);
        return _mapper.Map<PaymentBalanceResult>(response.Result);
    }
}