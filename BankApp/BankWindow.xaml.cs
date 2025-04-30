using System.Windows;

namespace BankApp
{
    public partial class BankWindow : Window
    {
        private BankAccount account;
        private string username;

        public BankWindow(string username)
        {
            InitializeComponent();
            this.username = username;
            account = BankAccountManager.GetOrCreateAccount(username);
            UpdateTransactionHistory();
            txtBalance.Text = account.Balance.ToString("C");
        }

        private void UpdateTransactionHistory()
        {
            if (account != null)
            {
                lstTransactions.Items.Clear();
                foreach (var transaction in account.TransactionHistory)
                {
                    lstTransactions.Items.Add(transaction);
                }
            }
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            if (account == null)
            {
                MessageBox.Show("Please create an account first.");
                return;
            }

            if (double.TryParse(txtAmount.Text, out double amount) && amount > 0)
            {
                account.Deposit(amount);
                txtBalance.Text = account.Balance.ToString("C");
                UpdateTransactionHistory();
            }
            else
            {
                MessageBox.Show("Please enter a valid amount.");
            }
        }

        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            if (account == null)
            {
                MessageBox.Show("Please create an account first.");
                return;
            }

            if (double.TryParse(txtAmount.Text, out double amount) && amount > 0)
            {
                if (account.Withdraw(amount))
                {
                    txtBalance.Text = account.Balance.ToString("C");
                    UpdateTransactionHistory();
                }
                else
                {
                    MessageBox.Show("Insufficient funds.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid amount.");
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
} 