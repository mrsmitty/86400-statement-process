
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FunctionApp.Models
{
    public class BankTransaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public string Category { get; set; }
        public BankStatement BankStatement { get; set; }

    }
}