using System;
using System.Collections.Generic;

namespace BankVault.Models
{
   
    public class Customer
    {
        // ===== Properties =====
        public string Name { get; private set; }
        public string NationalId { get; private set; }
        public string MobileNumber { get; private set; }
        public List<BankAccount> Accounts { get; private set; }

        // ===== Constructor =====
        public Customer(string name, string nationalId, string mobileNumber)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Customer name cannot be empty or whitespace.", nameof(name));

            if (string.IsNullOrWhiteSpace(nationalId))
                throw new ArgumentException("National ID cannot be empty or whitespace.", nameof(nationalId));

            if (string.IsNullOrWhiteSpace(mobileNumber))
                throw new ArgumentException("Mobile number cannot be empty or whitespace.", nameof(mobileNumber));

            Name = name.Trim();
            NationalId = nationalId.Trim();
            MobileNumber = mobileNumber.Trim();
            Accounts = new List<BankAccount>();
        }

        // ===== Public Methods =====

       
        public void AddAccount(BankAccount account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account), "Account cannot be null.");

           
            foreach (var existing in Accounts)
            {
                if (existing.AccountNumber == account.AccountNumber)
                    throw new InvalidOperationException($"Account number {account.AccountNumber} already exists for this customer.");
            }

            Accounts.Add(account);
        }

        public override string ToString()
        {
            return $"Customer: {Name} | National ID: {NationalId} | Mobile: {MobileNumber} | Accounts: {Accounts.Count}";
        }
    }
}
