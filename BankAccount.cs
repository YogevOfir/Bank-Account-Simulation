using System;

class BankAccount
{
    private string AccountHolder {get; set;}
    private double Balance {get; set;}
    private string AccountType {get; set;}
    private List<string> transactionHistory = new List<string>();

    public BankAccount(string accountHolder, double balance)
    {
        AccountHolder = accountHolder;
        Balance = balance;
        AccountType = accountType;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            transactionHistory.Add($"Deposited: ${amount:F2} | New Balance: ${Balance:F2}");
            Console.WriteLine("Deposit successful");
        }
        else Console.WriteLine("Deposit amount must be positive");
    }

    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            transactionHistory.Add($"Withdrawn: ${amount:F2} | New Balance: ${Balance:F2}");
            Console.WriteLine("Withdrawal successful!");
        }
        else Console.WriteLine("Withdrawal amount must be positive and less than or equal to the balance");
    }

    public void DisplayTransactionHistory()
    {
        Console.WriteLine("\nTransaction History:");
        foreach (var transaction in transactionHistory)
        {
            Console.WriteLine(transaction);
        }
    }

    public void DisplayBalance()
    {
        Console.WriteLine($"Account Holder: {AccountHolder}");
        Console.WriteLine($"Balance: ${Balance:F2}");
    }
}