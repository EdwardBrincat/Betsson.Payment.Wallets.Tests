namespace Payment.Wallet.Feature;

public class ScenarioConst
{
    public const int NoAmount = 0;
    public const int DepositAmount = 300;
    public const int WithdrawAmount = 100;
    public const int WithdrawLargerAmount = 400;
    public const string InvalidAmount = "e";
}

public class ScenarioMessagesConst
{
    public const string InsufficientFunds = "Invalid withdrawal amount. There are insufficient funds.";
    public const string ValidationError = "One or more validation errors occurred.";
}