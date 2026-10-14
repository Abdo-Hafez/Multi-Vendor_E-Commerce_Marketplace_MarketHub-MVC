using System;

namespace BankVault.Models
{
   
    public class BankAccount
    {
        // ===== Properties =====
        public string AccountNumber { get; private set; }
        public string OwnerName { get; private set; }
        public decimal Balance { get; private set; }
        public AccountType Type { get; private set; }
        public DateTime OpenedDate { get; private set; }

        // ===== Constructor =====
        public BankAccount(string accountNumber, string ownerName, decimal initialBalance, AccountType type)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
                throw new ArgumentException("Account number cannot be empty or whitespace.", nameof(accountNumber));

            if (string.IsNullOrWhiteSpace(ownerName))
                throw new ArgumentException("Owner name cannot be empty or whitespace.", nameof(ownerName));

            if (initialBalance < 0)
                throw new ArgumentException("Initial balance cannot be negative.", nameof(initialBalance));

            AccountNumber = accountNumber.Trim();
            OwnerName = ownerName.Trim();
            Balance = initialBalance;
            Type = type;
            OpenedDate = DateTime.Now;
        }

        // ===== Public Methods =====

       
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be greater than zero.", nameof(amount));

            Balance += amount;
        }

      
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdraw amount must be greater than zero.", nameof(amount));

            if (amount > Balance)
                throw new InvalidOperationException("Insufficient funds for this withdrawal.");

            Balance -= amount;
        }

       
        public override string ToString()
        {
            return $"Account: {AccountNumber} | Owner: {OwnerName} | Type: {Type} | Balance: {Balance:C} | Opened: {OpenedDate:yyyy-MM-dd}";
        }
    }

  
    public enum AccountType
    {
        Savings,
        Current
    }
}