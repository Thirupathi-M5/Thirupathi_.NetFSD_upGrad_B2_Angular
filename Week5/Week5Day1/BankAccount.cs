using System;

class BankAccount
{
    private int accountNumber;
    private double balance;

    public int AccountNumber
    {
        get { return accountNumber; }
        set { accountNumber = value; }
    }

    public double Balance
    {
        get { return balance; }
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance = balance + amount;
            Console.WriteLine("Deposit successful");
        }
        else
        {
            Console.WriteLine("Invalid deposit amount");
        }
    }

    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid withdrawal amount");
        }
        else if (amount > balance)
        {
            Console.WriteLine("Insufficient balance");
        }
        else
        {
            balance = balance - amount;
            Console.WriteLine("Withdrawal successful");
        }
    }
}

class BankAccount1
{
    static void Main()
    {
        BankAccount account = new BankAccount();

        account.AccountNumber = 101;

        account.Deposit(5000);
        account.Withdraw(2000);

        Console.WriteLine("Current Balance = " + account.Balance);
    }
}