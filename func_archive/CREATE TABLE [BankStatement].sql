CREATE TABLE [BankStatement]
(
    Id int IDENTITY(1,1) PRIMARY KEY,
    AccountNumber NVARCHAR(10),
    Filename NVARCHAR(20),
    DocumentId NVARCHAR(100),
    ImportDate DATETIME2,
    ProcessDate DATETIME2 DEFAULT(GETUTCDATE())
)

CREATE TABLE [BankTransaction]
(
    Id int IDENTITY(1,1) PRIMARY KEY,
    AccountNumber NVARCHAR(10),
    Filename NVARCHAR(20),
    DocumentId NVARCHAR(100),
    ImportDate DATETIME2,
    ProcessDate DATETIME2 DEFAULT(GETUTCDATE())
)