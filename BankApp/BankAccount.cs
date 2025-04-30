namespace BankApp
{
    public static class BankAccountManager
    {
        private static Dictionary<string, BankAccount> accounts = new Dictionary<string, BankAccount>();

        public static BankAccount GetOrCreateAccount(string username)
        {
            if (!accounts.ContainsKey(username))
            {
                accounts[username] = new BankAccount(username, 0);
            }
            return accounts[username];
        }
    }

    public class BankAccount
    {
        public string AccountHolder { get; private set; }
        public double Balance { get; private set; }
        public List<string> TransactionHistory { get; private set; }

        public BankAccount(string holder, double initialBalance)
        {
            AccountHolder = holder;
            Balance = initialBalance;
            TransactionHistory = new List<string>();
            TransactionHistory.Add($"Account created for {holder} with initial balance: {initialBalance:C}");
        }

        public void Deposit(double amount)
        {
            Balance += amount;
            TransactionHistory.Add($"Deposit: +{amount:C} (New Balance: {Balance:C})");
        }

        public bool Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                TransactionHistory.Add($"Withdrawal: -{amount:C} (New Balance: {Balance:C})");
                return true;
            }
            return false;
        }
    }
} 