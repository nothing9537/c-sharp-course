var bankAccount = new BankAccount(10_000);
var user = new User(1000, bankAccount.Balance);

bankAccount.OnBalanceDecreased += user.ReduceFunds;

bankAccount.DecreaseBalance(100);

public delegate void OnBalanceDecreased(decimal balance);

public class BankAccount
{
    public decimal Balance { get; private set; }
    public BankAccount(decimal initialBalance)
    {
        Balance = initialBalance;
    }
    public event OnBalanceDecreased OnBalanceDecreased;

    public void DecreaseBalance(decimal price)
    {
        Balance -= price;

        OnBalanceDecreased.Invoke(price);
    }

}

public class User
{
    public decimal Funds { get; private set; }

    public User(decimal cash, decimal moneyInBank)
    {
        Funds = cash + moneyInBank;
    }

    public void ReduceFunds(decimal balanceReduced)
    {
        Funds -= balanceReduced;
    }
}