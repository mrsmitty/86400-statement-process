using FunctionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp.Interfaces
{
    public interface ITransactionRepository
    {
        Task WriteBankStatementAsync();
    }
}
