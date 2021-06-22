using FunctionApp.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace FunctionApp
{
    public class StatementFunction
    {
        private readonly ITransactionRepository transactionRepository;

        public StatementFunction(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        [Function("HttpFunction")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("HttpFunction");
            logger.LogInformation("message logged");
            dynamic data = req.ReadFromJsonAsync<dynamic>();

            Console.WriteLine(data);
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Date", "Mon, 18 Jul 2016 16:06:00 GMT");
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to .NET 5!!");

            return response;
        }
    }
}