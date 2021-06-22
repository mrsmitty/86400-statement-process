using FunctionApp.DTO;
using FunctionApp.Interfaces;
using FunctionApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionApp.Services
{
    public class TransactionRepository : BaseRepository, ITransactionRepository
    {

        public TransactionRepository(BankTransactionsContext context) : base(context)
        {
        }

        public async Task AddBankStatementAsync(BankStatement statement)
        {
            var items = await GetItemsAsync<BankStatement>(x => x.DocumentId == statement.DocumentId);
            if (items.Any())
                await base.DeleteItemAsync(items.First());

            await base.AddItemAsync(statement);
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
                AccountNumber = x.BankStatement.AccountNumber
            }).ToList();
        }
    }
}
