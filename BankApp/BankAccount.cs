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

        public static bool AccountExists(string username)
        {
            return accounts.ContainsKey(username);
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

        public bool Transfer(string recipientUsername, double amount)
        {
            if (amount <= 0 || amount > Balance)
            {
                return false;
            }

            if (!BankAccountManager.AccountExists(recipientUsername))
            {
                return false;
            }

            BankAccount recipient = BankAccountManager.GetOrCreateAccount(recipientUsername);
            
            // Withdraw from sender
            Balance -= amount;
            TransactionHistory.Add($"Transfer to {recipientUsername}: -{amount:C} (New Balance: {Balance:C})");
            
            // Deposit to recipient
            recipient.Balance += amount;
            recipient.TransactionHistory.Add($"Transfer from {AccountHolder}: +{amount:C} (New Balance: {recipient.Balance:C})");
            
            return true;
        }
    }
} 