using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
            txtWelcome.Text = $"Welcome to Your Bank Account, {username}";

            // Set up placeholder text behavior
            SetupPlaceholderText(txtAmount, "Enter amount");
            SetupPlaceholderText(txtRecipient, "Enter recipient username");
            SetupPlaceholderText(txtTransferAmount, "Enter amount to transfer");
        }

        private void SetupPlaceholderText(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.Foreground = Brushes.Gray;

            textBox.GotFocus += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.Foreground = Brushes.Black;
                }
            };

            textBox.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.Foreground = Brushes.Gray;
                }
            };
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

            if (txtAmount.Text == "Enter amount")
            {
                MessageBox.Show("Please enter a valid amount.");
                return;
            }

            if (double.TryParse(txtAmount.Text, out double amount) && amount > 0)
            {
                account.Deposit(amount);
                txtBalance.Text = account.Balance.ToString("C");
                UpdateTransactionHistory();
                txtAmount.Text = "Enter amount";
                txtAmount.Foreground = Brushes.Gray;
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

            if (txtAmount.Text == "Enter amount")
            {
                MessageBox.Show("Please enter a valid amount.");
                return;
            }

            if (double.TryParse(txtAmount.Text, out double amount) && amount > 0)
            {
                if (account.Withdraw(amount))
                {
                    txtBalance.Text = account.Balance.ToString("C");
                    UpdateTransactionHistory();
                    txtAmount.Text = "Enter amount";
                    txtAmount.Foreground = Brushes.Gray;
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

        private void btnTransfer_Click(object sender, RoutedEventArgs e)
        {
            if (account == null)
            {
                MessageBox.Show("Please create an account first.");
                return;
            }

            string recipientUsername = txtRecipient.Text.Trim();
            if (recipientUsername == "Enter recipient username" || string.IsNullOrEmpty(recipientUsername))
            {
                MessageBox.Show("Please enter a recipient username.");
                return;
            }

            if (recipientUsername == username)
            {
                MessageBox.Show("You cannot transfer money to yourself.");
                return;
            }

            if (txtTransferAmount.Text == "Enter amount to transfer")
            {
                MessageBox.Show("Please enter a valid amount.");
                return;
            }

            if (double.TryParse(txtTransferAmount.Text, out double amount) && amount > 0)
            {
                if (account.Transfer(recipientUsername, amount))
                {
                    txtBalance.Text = account.Balance.ToString("C");
                    UpdateTransactionHistory();
                    txtRecipient.Text = "Enter recipient username";
                    txtRecipient.Foreground = Brushes.Gray;
                    txtTransferAmount.Text = "Enter amount to transfer";
                    txtTransferAmount.Foreground = Brushes.Gray;
                }
                else
                {
                    MessageBox.Show("Transfer failed. Please check the recipient username and your balance.");
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