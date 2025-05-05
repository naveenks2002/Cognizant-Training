using System;
using System.Collections.Generic;

namespace Banking_Application
{
    internal class BankAccount
    {
        public int AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public decimal Balance { get; private set; }

        public BankAccount(int accountNumber, string accountHolder, decimal initialBalance) {
                AccountNumber = accountNumber;
                AccountHolder = accountHolder;
                Balance = initialBalance;   
        }
        public void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposited {amount:C}. New balance is {Balance:C}.");
        }
        public bool Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew {amount:C}. New balance is {Balance:C}.");
                return true;
            }
            else
            {
                Console.WriteLine("Insufficient Funds");
                return false;
            }

        }
        public void DisplayBalance()
        {
            Console.WriteLine($"Account {AccountNumber} balance: {Balance:C} ");
        }
 
    }
}
