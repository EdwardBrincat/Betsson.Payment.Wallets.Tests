namespace Payment.Wallet.Contracts;

public class PaymentWalletBase
{
    public int Amount { get; set; }
}

public class PaymentDepositInput : PaymentWalletBase;

public class PaymentWithdrawInput : PaymentWalletBase;

public class PaymentBalanceResult : PaymentWalletBase;