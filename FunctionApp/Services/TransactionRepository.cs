using FunctionApp.Interfaces;
using FunctionApp.Models;
using Microsoft.EntityFrameworkCore;
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
        
        public async Task WriteBankStatementAsync(Models.BankStatement statement)
        {
            context.BankStatements.Add(statement);
            await context.SaveChangesAsync();
        }

        public async Task UpgradeDatabaseAsync()
        {
            var sql = await File.ReadAllTextAsync("DDL.sql");
            context.Database.ExecuteSqlRaw(sql);
        }

        public async Task WriteBankTransactionsAsync(IEnumerable<BankTransaction> transactions)
        {
            context.BankTransactions.AddRange(transactions);
            await context.SaveChangesAsync();
        }
    }
}
