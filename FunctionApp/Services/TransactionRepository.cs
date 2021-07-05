using FunctionApp.DTO;
using FunctionApp.Interfaces;
using FunctionApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionApp.Services
{
    public class TransactionRepository : BaseRepository, ITransactionRepository
    {
        private readonly ILogger<TransactionRepository> logger;

        public TransactionRepository(BankTransactionsContext context, ILogger<TransactionRepository> logger) : base(context)
        {
            this.logger = logger;
        }

        public async Task AddBankStatementAsync(BankStatement statement)
        {
            try
            {
                var items = await GetItemsAsync<BankStatement>(x => x.DocumentId == statement.DocumentId);
                if (items.Any())
                {
                    logger.LogInformation($"DocumentID '{statement.DocumentId}' exists. Removing");
                    await DeleteItemAsync(items.First());
                }

                await AddItemAsync(statement);
            }
            catch (Exception ex)
            {
                logger.LogError("Failed to write records to database", ex);
                throw;
            }
        }

        public async Task<IList<TransactionEntry>> GetTransactionsAsync(string accountNumber)
        {
            var result = await GetItemsAsync<BankTransaction>(
                x => x.BankStatement.AccountNumber == accountNumber,
                x => x.BankStatement);
            return result.Select(x => new TransactionEntry
            {
                Id = x.Id,
                TransactionDate = x.TransactionDate,
                Description = x.Description,
                Debit = x.Debit,
                Credit = x.Credit,
                Amount = x.Amount,
                Balance = x.Balance,
                Category = x.Category,
                AccountNumber = x.BankStatement.AccountNumber
            }).ToList();
        }

        public async Task UpdateTransactionCategoryAsync(TransactionCategoryRequest request)
        {
            var item = new BankTransaction{ Id = request.Id, Category = request.Category};
            context.Entry(item).Property(x => x.Category).IsModified = true;
            await context.SaveChangesAsync();
        }

        public async Task<IList<string>> GetCategories()
        {
            return await (from t in context.BankTransactions
                          select t.Category).Distinct().ToListAsync();
        }

        public async Task<IList<string>> GetAccountNumbers()
        {
            return await (from s in context.BankStatements
                          select s.AccountNumber).Distinct().ToListAsync();
        }
    }
}
