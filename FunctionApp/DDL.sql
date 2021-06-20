
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BankTransactions]') AND type in (N'U'))
    DROP TABLE [BankTransactions]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BankStatements]') AND type in (N'U'))
    DROP TABLE [BankStatements]

CREATE TABLE [BankStatements]
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    AccountNumber NVARCHAR(10),
    Filename NVARCHAR(100),
    DocumentId NVARCHAR(100),
    ImportDate DATETIME2,
    ProcessDate DATETIME2 DEFAULT(GETUTCDATE())
)


CREATE TABLE [BankTransactions]
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TransactionDate DATETIME,
    Description NVARCHAR(200),
    Debit DECIMAL(10,2),
    Credit DECIMAL(10,2),
    Amount as ISNULL(Credit, 0) - ISNULL(Debit, 0),
    Balance DECIMAL(10,2),
    Category NVARCHAR(100)
)