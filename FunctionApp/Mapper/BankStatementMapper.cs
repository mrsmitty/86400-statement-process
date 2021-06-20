using FunctionApp.Models;
using System;
using System.Collections.Generic;
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
                ProcessDate = src.processed_at
            };
        }
    }
}
