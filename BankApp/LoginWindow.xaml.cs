using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BankApp
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            SetupPlaceholderText();
        }

        private void SetupPlaceholderText()
        {
            txtUsername.Text = "Enter username";
            txtUsername.Foreground = Brushes.Gray;

            txtUsername.GotFocus += (sender, e) =>
            {
                if (txtUsername.Text == "Enter username")
                {
                    txtUsername.Text = "";
                    txtUsername.Foreground = Brushes.Black;
                }
            };

            txtUsername.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    txtUsername.Text = "Enter username";
                    txtUsername.Foreground = Brushes.Gray;
                }
            };
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password;

            if (username == "Enter username" || string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter your username.", "Login Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your password.", "Login Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (UserManager.AuthenticateUser(username, password))
            {
                BankWindow bankWindow = new BankWindow(username);
                bankWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtPassword.Password = "";
            }
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password;

            if (username == "Enter username" || string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter a username.", "Create Account Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter a password.", "Create Account Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Create Account Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (UserManager.CreateUser(username, password))
            {
                MessageBox.Show("Account created successfully! Please login with your new credentials.", "Account Created", MessageBoxButton.OK, MessageBoxImage.Information);
                txtPassword.Password = "";
            }
            else
            {
                MessageBox.Show("Username already exists. Please choose another username.", "Create Account Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtPassword.Password = "";
            }
        }
    }

    public static class UserManager
    {
        private static Dictionary<string, string> users = new Dictionary<string, string>();

        static UserManager()
        {
            // Add some test users
            users["admin"] = "admin123";
            users["user"] = "password123";
        }

        public static bool AuthenticateUser(string username, string password)
        {
            if (users.TryGetValue(username, out string? storedPassword))
            {
                return storedPassword == password;
            }
            return false;
        }

        public static bool CreateUser(string username, string password)
        {
            if (users.ContainsKey(username))
            {
                return false;
            }

            users[username] = password;
            return true;
        }
    }
} 