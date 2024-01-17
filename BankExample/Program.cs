using BankExample;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        BankAccount account1 = new BankAccount("111", "dolar", 5000);
        BankAccount account2 = new BankAccount("222", "dolar", 8000);

        Console.WriteLine("Hesap Numaranızı Girin: ");
        string inputAccountNumber = Console.ReadLine();

        BankAccount sendAccount = null;

        if (account1.AccountNumber == inputAccountNumber)
        {
            sendAccount = account1;
        }
        else if (account2.AccountNumber == inputAccountNumber)
        {
            sendAccount = account2;
        }
        else
        {
            Console.WriteLine("HATA");
            return;
        }

        Console.WriteLine("Transfer Miktarını Girin: ");
        double transferAmount = Convert.ToDouble(Console.ReadLine());

        try
        {
            sendAccount.GetTransfer(transferAmount);
            Console.WriteLine("BAŞARILI");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("HATA: " + ex.Message);
        }
    }
}

namespace BankExample
{
    public class BankAccount
    {
        public string AccountNumber { get; private set; }
        public string Currency { get; private set; }

        public double AccountValue { get; private set; }

        public BankAccount(string accountNumber, string currency, double accountValue)
        {
            AccountNumber = accountNumber;
            Currency = currency;
            AccountValue = accountValue;
        }

        public void GetInvest(double amount)
        {
            AccountValue += amount;
        }

        public void GetTransfer(double amount)
        {
            if (AccountValue >= amount)
            {
                AccountValue -= amount;
            }
            else
            {
                Console.WriteLine("Yetersiz Bakiye");
            }
        }
    }
}
