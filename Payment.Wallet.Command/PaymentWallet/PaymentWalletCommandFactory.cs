using AutoMapper;
using Payment.Wallet.Client.Model;
using Payment.Wallet.Contracts;
using Payment.Wallet.Services.Service;

namespace Payment.Wallet.Command.PaymentWallet;

public class PaymentWalletCommandFactory
{
    private readonly PaymentWalletService _service;
    private readonly IMapper _mapper;

    public PaymentWalletCommandFactory(
        IMapper mapper,
        PaymentWalletService service
    )
    {
        _mapper = mapper;
        _service = service;
    }

    public Task<PaymentBalanceResult> ExecuteGetWalletBalanceCommand()
    {
        var response = _service.GetWalletBalance();
        return Task.FromResult(_mapper.Map<PaymentBalanceResult>(response));
    }


    public Task<PaymentBalanceResult> ExecuteDepositCommand(PaymentDepositInput paymentDepositInput)
    {
        var request = _mapper.Map<PaymentDepositRequest>(paymentDepositInput);
        var response = _service.Deposit(request);
        return Task.FromResult(_mapper.Map<PaymentBalanceResult>(response));
    }


    public Task<PaymentBalanceResult> ExecuteWithdrawCommand(PaymentWithdrawInput paymentWithdrawInput)
    {
        var request = _mapper.Map<PaymentWithdrawRequest>(paymentWithdrawInput);
        var response = _service.Withdraw(request);
        return Task.FromResult(_mapper.Map<PaymentBalanceResult>(response));
    }
}