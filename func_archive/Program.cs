using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using FunctionApp.Interfaces;
using FunctionApp.Services;
using System;
using FunctionApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FunctionApp
{
    public class Program
    {
        static Task Main()
        {
            string sqlConnectionString = Environment.GetEnvironmentVariable("BankStatementsDatabase");
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(services =>
                {
                    services.AddDbContext<BankTransactionsContext>(options =>
                        options.UseSqlServer(sqlConnectionString)
                        );

                    services.AddSingleton<ITransactionRepository, TransactionRepository>();
                })
                .Build();

            return host.RunAsync();
        }
    }
}