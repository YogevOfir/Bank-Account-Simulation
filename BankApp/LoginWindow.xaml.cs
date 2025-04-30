using System.Windows;
using System.Windows.Media;

namespace BankApp
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void SetMessage(string message, bool isSuccess)
        {
            txtMessage.Text = message;
            txtMessage.Foreground = isSuccess ? Brushes.Green : Brushes.Red;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                SetMessage("Please enter both username and password.", false);
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
                SetMessage("Invalid username or password.", false);
            }
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                SetMessage("Please enter both username and password.", false);
                return;
            }

            if (UserManager.CreateUser(username, password))
            {
                SetMessage("Account created successfully! Please login.", true);
            }
            else
            {
                SetMessage("Username already exists. Please choose another.", false);
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