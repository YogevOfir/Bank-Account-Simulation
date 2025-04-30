class User
{
    public string Name {get; private set;}
    private string Password {get; set;}
    public List<BankAccount> Accounts {get; private set;};

    public User(string name, string password)
    {
        Name = name;
        Password = password;
        Accounts = new List<BankAccount>();
    }

    public bool Authenticate(string enteredpassword)
    {
        return Password == enteredpassword;
    }

    public void AddAccount(BankAccount account)
    {
        Accounts.Add(account);
    }
}