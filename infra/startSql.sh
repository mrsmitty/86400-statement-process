sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=XGBPi6ODYS8O" \
   -p 1433:1433 --name BankTransactions -h BankTransactions \
   -d mcr.microsoft.com/mssql/server:2019-latest