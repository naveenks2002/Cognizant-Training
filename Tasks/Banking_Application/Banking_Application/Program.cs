using System;
using System.Collections.Generic;

namespace Banking_Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<BankAccount> accounts = new List<BankAccount>();
             int accountNumberCounter = 786891;

            while (true)
            {
                Console.WriteLine("Welcome to Zyskee Banking Systems");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. View Balance");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter account holder name : ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Initial Deposit : ");
                        decimal initialDeposit = decimal.Parse(Console.ReadLine());
                        BankAccount newAccount = new BankAccount(accountNumberCounter++,name,initialDeposit);
                        accounts.Add(newAccount);
                        Console.WriteLine($"Account number successfully created with {newAccount.AccountNumber}.");
                        break;

                    case 2:
                        Console.WriteLine("Enter Account Number: ");
                        int accountNumber = int.Parse(Console.ReadLine());
                        BankAccount account = accounts.Find(x => x.AccountNumber == accountNumber);
                        if (account != null){
                            Console.WriteLine("Enter deposit amount: ");
                            decimal depositAmount = decimal.Parse(Console.ReadLine());
                            account.Deposit(depositAmount);
                        }
                        else
                        {
                            Console.WriteLine("Account not Found");
                        }
                         break;

                    case 3:
                        Console.WriteLine("Enter Account Number: ");
                        accountNumber = int.Parse(Console.ReadLine());
                        account = accounts.Find(x=>x.AccountNumber == accountNumber);
                        if (account != null)
                        {
                            Console.WriteLine("Enter Withdrawl Amount: ");
                            decimal withdrawAmount = decimal.Parse(Console.ReadLine()); 
                            account.Withdraw(withdrawAmount);
                        }
                        else
                        {
                            Console.WriteLine("Account not Found");
                        }
                            break;

                    case 4:
                        Console.WriteLine("Enter Account Number: ");
                        accountNumber = int.Parse(Console.ReadLine());
                        account = accounts.Find(x => x.AccountNumber == accountNumber);

                        if(account != null)
                        {
                            account.DisplayBalance();

                        }
                        else
                        {
                            Console.WriteLine("Account Not Found");
                        }
                            break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Invalid Option. Please Try Again!");
                        break;

                }
            }
        }
    }
}

