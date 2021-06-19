using FunctionApp.Interfaces;
using FunctionApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp.Services
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly BankTransactionsContext context;

        public TransactionRepository(BankTransactionsContext context)
        {
            this.context = context;
        }
        
        public Task WriteBankStatementAsync()
        {
            return Task.CompletedTask;
        }

        public async Task UpgradeDatabase()
        {
            var sql = await File.ReadAllTextAsync("DDL.sql");
            // context.Database.ExecuteSqlCommand(sql);
            
        }
    }
}
