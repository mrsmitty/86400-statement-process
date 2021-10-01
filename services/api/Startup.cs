using Services.Core.Interfaces;
using Services.Core.Models;
using Services.Core.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Services.Api.Startup))]

namespace Services.Api
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