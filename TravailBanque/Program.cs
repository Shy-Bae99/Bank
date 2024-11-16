using System;


public class Person
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime Birthdate { get; set; }
}

public class CurrentAccount
{
    public string Number { get; set; }
    public double CreditLine { get; set; }
    public Person Owner { get; set; }
    private double _balance;
    public double Balance => _balance;

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            _balance += amount;
        }
    }

    public void Withdraw(double amount)
    {
        if (amount > 0 && _balance - amount >= -CreditLine)
        {
            _balance -= amount;
        }
    }
}

public class Bank
{ 
    private Dictionary<string, CurrentAccount> _accounts = new Dictionary<string, CurrentAccount>();
    
    public IReadOnlyDictionary<string, CurrentAccount> Accounts => _accounts;
    
    public string Name{ get; set; }

    public void AddAccount(CurrentAccount account)
    {
        if (!_accounts.ContainsKey(account.Number))
        {
            _accounts[account.Number] = account;
        }
    }

    public void DeleteAccount(string number)
    {
        if (_accounts.ContainsKey(number))
        {
            _accounts.Remove(number);
        }
    }
    public double GetBalance(string accountNumber)
     {
         if (_accounts.ContainsKey(accountNumber))
         {
             return _accounts[accountNumber].Balance;
         }
         throw new ArgumentException("Account number not found.");
     }
     public double GetTotalBalance(Person owner)
     {
         double totalBalance = 0;
     
         foreach (var account in _accounts.Values)
         {
             if (account.Owner == owner)
             {
                 totalBalance += account.Balance;
             }
         }
     
         return totalBalance;
     }
}


