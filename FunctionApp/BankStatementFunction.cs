using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FunctionApp.Models;
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

        [FunctionName("BankStatement")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var raw = JsonConvert.DeserializeObject<DocParserRoot>(requestBody);
            var statement = raw.ToBankStatement();

            log.LogInformation($"Processiong {statement.BankTransactions.Count}");
            await transactionRepository.AddBankStatementAsync(statement);
            return new OkResult();
        }
    }
}
