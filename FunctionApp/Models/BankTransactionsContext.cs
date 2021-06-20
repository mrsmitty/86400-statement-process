using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp.Models
{
    public class BankTransactionsContext : DbContext
    {
        public BankTransactionsContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<BankStatement> BankStatements { get; set; }
        public DbSet<BankTransaction> BankTransactions { get; set; }
    }
}
