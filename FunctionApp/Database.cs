using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FunctionApp.Interfaces;

namespace FunctionApp
{
    public class DatabaseFunctions
    {
        private readonly ITransactionRepository transactionRepository;

        public DatabaseFunctions(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        [FunctionName("Database")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            await transactionRepository.UpgradeDatabaseAsync();
            return new OkResult();
        }
    }
}
