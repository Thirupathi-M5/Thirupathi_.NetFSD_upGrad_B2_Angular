using System;

class BankAccount
{
    private double balance;

    public void Deposit(double amount)
    {
        balance = balance + amount;
    }

    public void Withdraw(double amount)
    {
        if (amount <= balance)
        {
            balance = balance - amount;
        }
        else
        {
            Console.WriteLine("Insufficient Balance");
        }
    }

    public double GetBalance()
    {
        return balance;
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount();

        account.Deposit(1000);
        account.Withdraw(300);

        Console.WriteLine("Current Balance = " + account.GetBalance());
    }
}