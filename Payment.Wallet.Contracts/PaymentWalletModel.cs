namespace Payment.Wallet.Contracts;

public class PaymentWalletBase
{
    public string Amount { get; set; }
}

public class PaymentDepositInput : PaymentWalletBase;

public class PaymentWithdrawInput : PaymentWalletBase;

public class PaymentBalanceResult : PaymentWalletBase
{
    public string Title { get; set; }
}