namespace Payment.Wallet.Client.Model;

public class PaymentWalletModel
{
    public string Amount { get; set; }
}

public class PaymentDepositRequest : PaymentWalletModel;

public class PaymentWithdrawRequest : PaymentWalletModel;

public class PaymentBalanceResponse : PaymentWalletModel
{
    public string Title { get; set; }
}