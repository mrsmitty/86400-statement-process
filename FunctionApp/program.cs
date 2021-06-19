using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using FunctionApp.Models;
using FunctionApp.Interfaces;
using FunctionApp.Services;

[assembly: FunctionsStartup(typeof(FunctionApp.Startup))]

namespace FunctionApp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // builder.Services.AddHttpClient();
            builder.services.AddDbContext<BankTransactionsContext>(options =>
            {
                options.UseSqlServer("");
            });

            builder.services.AddSingleton<ITransactionRepository, TransactionRepository>();
        }
    }
}