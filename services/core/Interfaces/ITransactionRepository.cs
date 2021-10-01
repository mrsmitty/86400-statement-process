using Services.Core.DTO;
using Services.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Core.Interfaces
{
    public interface ITransactionRepository
    {
        Task AddBankStatementAsync(BankStatement statement);
        Task<IList<AccountSummary>> GetAccountNumbers();
        Task<IList<string>> GetCategories();
        Task<IList<TransactionEntry>> GetTransactionsAsync(string accountNumber);
        Task UpdateTransactionCategoryAsync(TransactionCategoryRequest request);
    }
}
