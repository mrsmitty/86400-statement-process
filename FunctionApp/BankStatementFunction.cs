using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FunctionApp.Models;
using FunctionApp.DTO;
using FunctionApp.Mapper;
using FunctionApp.Interfaces;
using System.Linq;

namespace FunctionApp
{
    public class BankStatementFunction
    {
        private readonly ITransactionRepository transactionRepository;

        public BankStatementFunction(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        public BankTransactionsContext Context { get; }

        [FunctionName("PostTransactions")]
        public async Task<IActionResult> PostTransactionsAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "transactions")] HttpRequest req,
            ILogger log)
        {
            var raw = await req.ParsePostBody<DocParserRoot>();
            var statement = raw.ToBankStatement();

            log.LogInformation($"Processiong {statement.BankTransactions.Count}");
            await transactionRepository.AddBankStatementAsync(statement);
            return new OkResult();
        }

        [FunctionName("GetTranasctions")]
        public async Task<IActionResult> GetTranasctionsAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "{account}/transactions")] HttpRequest req,
            string account,
            ILogger log)
        {
            var result = await transactionRepository.GetTransactionsAsync(account);
            return new OkObjectResult(result);
        }

        [FunctionName("PostTransactionCategory")]
        public async Task<IActionResult> PostTransactionCategoryAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "{id}/transactioncategory")] HttpRequest req,
            ILogger log)
        {
            var item = await req.ParsePostBody<TransactionCategoryRequest>();
            await transactionRepository.UpdateTransactionCategoryAsync(item);
            return new OkResult();
        }

        [FunctionName("GetTransactionCategories")]
        public async Task<IActionResult> GetTransactionCategoriesAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "transactioncategories")] HttpRequest req,
            ILogger log)
        {
            var transRequest = await req.ParsePostBody<TransactionCategoryRequest>();
            var items = await transactionRepository.GetCategories();
            return new OkObjectResult(items);
        }

        [FunctionName("GetAccounts")]
        public async Task<IActionResult> GetAccountsAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "accounts")] HttpRequest req,
            ILogger log)
        {
            var transRequest = await req.ParsePostBody<TransactionCategoryRequest>();
            var items = await transactionRepository.GetAccountNumbers();
            return new OkObjectResult(items);
        }
    }
}
