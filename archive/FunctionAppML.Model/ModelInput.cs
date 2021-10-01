// This file was auto-generated by ML.NET Model Builder. 

using Microsoft.ML.Data;

namespace FunctionAppML.Model
{
    public class ModelInput
    {
        [ColumnName("Id"), LoadColumn(0)]
        public float Id { get; set; }


        [ColumnName("TransactionDate"), LoadColumn(1)]
        public string TransactionDate { get; set; }


        [ColumnName("Description"), LoadColumn(2)]
        public string Description { get; set; }


        [ColumnName("Debit"), LoadColumn(3)]
        public float Debit { get; set; }


        [ColumnName("Credit"), LoadColumn(4)]
        public float Credit { get; set; }


        [ColumnName("Amount"), LoadColumn(5)]
        public float Amount { get; set; }


        [ColumnName("Balance"), LoadColumn(6)]
        public float Balance { get; set; }


        [ColumnName("Category"), LoadColumn(7)]
        public string Category { get; set; }


        [ColumnName("BankStatementId"), LoadColumn(8)]
        public float BankStatementId { get; set; }


    }
}