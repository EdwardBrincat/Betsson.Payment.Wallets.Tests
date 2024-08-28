using System.Net;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using Payment.Wallet.Client.Client;
using Payment.Wallet.Client.Model;
using Payment.Wallet.Services.Service;
using Assert = Xunit.Assert;

namespace Payment.Wallet.Command.Tests.PaymentWallet;

public class PaymentWalletComponentTests
{
    private readonly Mock<IPaymentWalletClient> _clientMock;
    private readonly IPaymentWalletService _subject;
    private readonly IMapper _mapper;

    public PaymentWalletComponentTests()
    {
        var startup = new PaymentWalletComponentTestsStartUp();
        startup.BuildContainer();
        var serviceProvider = startup.ServiceProvider;

        _clientMock = serviceProvider.GetService<Mock<IPaymentWalletClient>>() ?? null!;
        _subject = serviceProvider.GetService<IPaymentWalletService>() ?? null!;
    }

    [Test]
    public void Get_Wallet_Balance_is_Correct()
    {
        var paymentBalanceResponse = new PaymentBalanceResponse
        { Amount = 100 };

        var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
        { Content = new StringContent(JsonConvert.SerializeObject(paymentBalanceResponse)) };

        _clientMock.Setup(s => s.Get())
            .ReturnsAsync(httpResponse);

        var result = _subject.GetWalletBalance();

        Assert.Equal(paymentBalanceResponse.Amount, result.Result.Amount);

        _clientMock.Verify(v => v.Get(), Times.Once);
        _clientMock.VerifyNoOtherCalls();
    }

    [Test]
    public void Execute_Deposit_Amount_is_Correct()
    {
        var paymentDepositRequest = new PaymentDepositRequest
        { Amount = 100 };

        var paymentBalanceResponse = new PaymentBalanceResponse
        { Amount = 100 };

        var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
        { Content = new StringContent(JsonConvert.SerializeObject(paymentBalanceResponse)) };

        _clientMock.Setup(s => s.Deposit(It.IsAny<PaymentDepositRequest>()))
            .ReturnsAsync(httpResponse);

        var result = _subject.Deposit(paymentDepositRequest);

        Assert.Equal(paymentBalanceResponse.Amount, result.Result.Amount);

        _clientMock.Verify(v => v.Deposit(It.IsAny<PaymentDepositRequest>()), Times.Once);
        _clientMock.VerifyNoOtherCalls();
    }

    [Test]
    public void Execute_Withdraw_Amount_is_Correct()
    {
        var paymentWithdrawRequest = new PaymentWithdrawRequest
        { Amount = 100 };

        var paymentBalanceResponse = new PaymentBalanceResponse
        { Amount = 100 };

        var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
        { Content = new StringContent(JsonConvert.SerializeObject(paymentBalanceResponse)) };

        _clientMock.Setup(s => s.Withdraw(It.IsAny<PaymentWithdrawRequest>()))
            .ReturnsAsync(httpResponse);

        var result = _subject.Withdraw(paymentWithdrawRequest);

        Assert.Equal(paymentWithdrawRequest.Amount, result.Result.Amount);

        _clientMock.Verify(v => v.Withdraw(It.IsAny<PaymentWithdrawRequest>()), Times.Once);
        _clientMock.VerifyNoOtherCalls();
    }
}