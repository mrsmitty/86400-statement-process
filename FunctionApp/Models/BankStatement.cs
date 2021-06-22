using System;
using System.Collections.Generic;

namespace FunctionApp.Models
{
    public class BankStatement
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string Filename { get; set; }
        public string DocumentId { get; set; }
        public DateTime ImportDate { get; set; }
        public DateTime ProcessDate { get; set; }
        public ICollection<BankTransaction> BankTransactions { get; set; }
    }
}