namespace Payment.Wallet.Client.Model;

public class PaymentWalletModel
{
    public int Amount { get; set; }
}

public class PaymentDepositRequest : PaymentWalletModel;

public class PaymentWithdrawRequest : PaymentWalletModel;

public class PaymentBalanceResponse : PaymentWalletModel;