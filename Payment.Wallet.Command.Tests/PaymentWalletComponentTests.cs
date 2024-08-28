using System.Net;
using Moq;
using Newtonsoft.Json;
using Payment.Wallet.Client;
using Payment.Wallet.Client.Model;
using Payment.Wallet.Services;
using Assert = Xunit.Assert;

namespace Payment.Wallet.Command.Tests;

public class PaymentWalletComponentTests
{
    private readonly Mock<IPaymentWalletClient> _clientMock;
    private readonly PaymentWalletService _service;
    private readonly PaymentWalletCommandFactory _subject;

    public PaymentWalletComponentTests()
    {
        _clientMock = new Mock<IPaymentWalletClient>();
        _service = new PaymentWalletService(_clientMock.Object);
        _subject = new PaymentWalletCommandFactory(_service);
    }

    [Test]
    public void Get_Wallet_Balance_is_Correct()
    {
        var paymentWalletResponse = new PaymentWalletResponse
        { Amount = 100 };

        var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
        { Content = new StringContent(JsonConvert.SerializeObject(new PaymentWalletResponse
          { Amount = 100 })) };

        _clientMock.Setup(s => s.Get())
            .ReturnsAsync(httpResponse);

        var result = _subject.ExecuteGetWalletBalanceCommand();

        Assert.Equal(paymentWalletResponse.Amount, result.Result.Amount);

        _clientMock.Verify(v => v.Get(), Times.Once);
        _clientMock.VerifyNoOtherCalls();
    }

    [Test]
    public void Execute_Deposit_Amount_is_Correct()
    {
        var paymentWalletRequest = new PaymentWalletRequest
        { Amount = 100 };

        var paymentWalletResponse = new PaymentWalletResponse
        { Amount = 100 };

        var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
        { Content = new StringContent(JsonConvert.SerializeObject(new PaymentWalletResponse
          { Amount = 100 })) };

        _clientMock.Setup(s => s.Deposit(It.IsAny<PaymentWalletRequest>()))
            .ReturnsAsync(httpResponse);

        var result = _subject.ExecuteDepositCommand(paymentWalletRequest);

        Assert.Equal(paymentWalletResponse.Amount, result.Result.Amount);

        _clientMock.Verify(v => v.Deposit(It.IsAny<PaymentWalletRequest>()), Times.Once);
        _clientMock.VerifyNoOtherCalls();
    }

    [Test]
    public void Execute_Withdraw_Amount_is_Correct()
    {
        var paymentWalletRequest = new PaymentWalletRequest
        { Amount = 100 };

        var paymentWalletResponse = new PaymentWalletResponse
        { Amount = 100 };

        var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
        { Content = new StringContent(JsonConvert.SerializeObject(new PaymentWalletResponse
          { Amount = 100 })) };

        _clientMock.Setup(s => s.Withdraw(It.IsAny<PaymentWalletRequest>()))
            .ReturnsAsync(httpResponse);

        var result = _subject.ExecuteWithdrawCommand(paymentWalletRequest);

        Assert.Equal(paymentWalletResponse.Amount, result.Result.Amount);

        _clientMock.Verify(v => v.Withdraw(It.IsAny<PaymentWalletRequest>()), Times.Once);
        _clientMock.VerifyNoOtherCalls();
    }
}