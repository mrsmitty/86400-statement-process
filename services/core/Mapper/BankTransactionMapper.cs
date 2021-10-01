using Services.Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Services.Core.Mapper
{
    public static class BankTransactionMapper
    {
        public static BankTransaction ToBankTransaction(this TableData src)
        {
            return new BankTransaction
            {
                TransactionDate = ParseDate(src),
                Description = src.key_1,
                Debit = DollarToDecimal(src.key_2),
                Credit = DollarToDecimal(src.key_3),
                Balance = (decimal)DollarToDecimal(src.key_4)
            };
        }
        private static decimal? DollarToDecimal(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            else
            {
                return decimal.Parse(value.Replace("$", ""));
            }
        }
        private static DateTime ParseDate(TableData src)
        {
            DateTime date;
            if (DateTime.TryParseExact(src.key_0, "dd MMM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return date;
            else
                throw new Exception("Could not parse date");
        }
    }
}
