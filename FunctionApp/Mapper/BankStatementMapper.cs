using FunctionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionApp.Mapper
{
    public static class BankStatementMapper
    {
        public static Models.BankStatement ToBankStatement(this DocParserRoot src)
        {
            return new Models.BankStatement
            {
                Filename = src.file_name,
                DocumentId = src.document_id,
                ImportDate = DateTime.UtcNow,
                ProcessDate = src.processed_at,
                BankTransactions = src.table_data.Select(x => x.ToBankTransaction()).ToList(),
                AccountNumber = src.account_number
            };
        }
    }
}
