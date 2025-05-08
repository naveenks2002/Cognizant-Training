using System;
using System.Data.SqlClient;

namespace Banking_Application
{
    internal class BankAccount
    {
        public int AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public decimal Balance { get; private set; }

        private static string connectionString= "Data Source=LTIN593398\\SQLEXPRESS;Integrated Security=True";

        public BankAccount(int accountNumber, string accountHolder, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            UpdateBalanceInDatabase();
            Console.WriteLine($"Deposited {amount:C}. New balance is {Balance:C}.");
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                UpdateBalanceInDatabase();
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

        public void SaveToDatabase()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO BankAccounts (AccountNumber, AccountHolderName, Balance) VALUES (@AccountNumber, @AccountHolderName, @Balance)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
                    command.Parameters.AddWithValue("@AccountHolderName", AccountHolder);
                    command.Parameters.AddWithValue("@Balance", Balance);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void UpdateBalanceInDatabase()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE BankAccounts SET Balance = @Balance WHERE AccountNumber = @AccountNumber";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Balance", Balance);
                    command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static BankAccount GetAccountFromDatabase(int accountNumber)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM BankAccounts WHERE AccountNumber = @AccountNumber";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountNumber", accountNumber);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string accountHolder = reader["AccountHolderName"].ToString();
                            decimal balance = (decimal)reader["Balance"];
                            return new BankAccount(accountNumber, accountHolder, balance);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
    }
}
