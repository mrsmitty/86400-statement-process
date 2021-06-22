using FunctionApp.Interfaces;
using FunctionApp.Models;
using FunctionApp.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(FunctionApp.Startup))]

namespace FunctionApp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var Configuration = builder.GetContext().Configuration;
            // builder.Services.AddHttpClient();
            builder.Services.AddDbContext<BankTransactionsContext>(options =>
            {
                options.UseSqlServer(Configuration.GetValue<string>("BankStatementsDatabase"));
            });

            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
        }
    }
}