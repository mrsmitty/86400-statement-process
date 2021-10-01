using System;

namespace Services.Core.DTO
{
    public class AccountSummary
    {
        public string AccountNumber { get; }
        public decimal Balance { get; }

        public AccountSummary(string accountNumber, decimal balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }
    }
}
