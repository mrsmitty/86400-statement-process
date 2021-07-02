using System;

namespace FunctionApp.DTO
{
    public class TransactionEntry
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public string AccountNumber { get; set; }
        public string Category { get; set; }
    }
}
