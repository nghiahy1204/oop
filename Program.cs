using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4
{
    internal class Program
    {
        class Transaction
        {
            public DateTime Date { get; set; }
            public string TransactionType { get; set; }
            public decimal Amount { get; set; }
        }

        class Account
        {
            public string AccountNumber { get; }
            public string IdNumber { get; }
            public string OwnerName { get; }
            public decimal Balance { get; private set; }
            public decimal InterestRate { get; }
            private List<Transaction> Transactions { get; set; }

            public Account(string accountNumber, string idNumber, string ownerName, decimal initialBalance, decimal interestRate)
            {
                AccountNumber = accountNumber;
                IdNumber = idNumber;
                OwnerName = ownerName;
                Balance = initialBalance;
                InterestRate = interestRate;
                Transactions = new List<Transaction>();
            }

            public void Deposit(decimal amount, DateTime date)
            {
                Balance += amount;
                Transactions.Add(new Transaction { Date = date, TransactionType = "Deposit", Amount = amount });
            }

            public void Withdraw(decimal amount, DateTime date)
            {
                if (Balance >= amount)
                {
                    Balance -= amount;
                    Transactions.Add(new Transaction { Date = date, TransactionType = "Withdrawal", Amount = amount });
                }
                else
                {
                    Console.WriteLine("Insufficient balance!");
                }
            }

            public void CalculateInterest()
            {
                decimal interest = (Balance * InterestRate) / 100;
                Balance += interest;
            }

            public decimal GetBalance()
            {
                return Balance;
            }

            public List<Transaction> GetTransactions()
            {
                return Transactions;
            }
        }

        class Bank
        {
            private Dictionary<string, Account> Accounts { get; }

            public Bank()
            {
                Accounts = new Dictionary<string, Account>();
            }

            public void OpenAccount(string accountNumber, string idNumber, string ownerName, decimal initialBalance, decimal interestRate)
            {
                if (!Accounts.ContainsKey(accountNumber))
                {
                    Account account = new Account(accountNumber, idNumber, ownerName, initialBalance, interestRate);
                    Accounts[accountNumber] = account;
                }
                else
                {
                    Console.WriteLine("Account number already exists!");
                }
            }

            public void PrintReport()
            {
                foreach (var account in Accounts.Values)
                {
                    Console.WriteLine($"Account Number: {account.AccountNumber}");
                    Console.WriteLine($"Owner Name: {account.OwnerName}");
                    Console.WriteLine($"Balance: {account.GetBalance()} Euros");
                    Console.WriteLine("Transactions:");
                    foreach (var transaction in account.GetTransactions())
                    {
                        Console.WriteLine($"{transaction.Date}: {transaction.TransactionType} {transaction.Amount} Euros");
                    }
                    Console.WriteLine();
                }
            }
        }


        static void Main()
        {
            Bank bank = new Bank();
            bank.OpenAccount("001", "901", "Alice", 100, 5);
            bank.OpenAccount("002", "902", "Bob", 50, 5);
            bank.OpenAccount("003", "901", "Alice", 200, 10);
            bank.OpenAccount("004", "903", "Eve", 200, 10);

            bank.Accounts["001"].Deposit(100, new DateTime(2005, 7, 15));
            bank.Accounts["001"].Deposit(100, new DateTime(2005, 7, 31));
            bank.Accounts["002"].Deposit(150, new DateTime(2005, 7, 1));
            bank.Accounts["002"].Deposit(150, new DateTime(2005, 7, 15));
            bank.Accounts["003"].Deposit(200, new DateTime(2005, 7, 5));
            bank.Accounts["004"].Deposit(250, new DateTime(2005, 7, 31));

            bank.Accounts["001"].Withdraw(10, new DateTime(2005, 7, 10));
            bank.Accounts["002"].Withdraw(20, new DateTime(2005, 7, 15));
            bank.Accounts["003"].Withdraw(30, new DateTime(2005, 7, 31));
            bank.Accounts["004"].Withdraw(40, new DateTime(2005, 7, 31));

            foreach (var account in bank.Accounts.Values)
            {
                account.CalculateInterest();
            }

            bank.PrintReport();
        }

    }
}
