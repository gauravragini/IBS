using IBS.EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBS.DataAccessLayer.Interfaces
{
    public interface IReportsDL
    {
        IEnumerable<RegisterCustomer> GetNewCustomers();
        IEnumerable<Transaction> GetAllTransactions();
        IEnumerable<Account> GetAllAccounts();
        Account GetAccountbyAccountNumber(string accountNumber);
        IEnumerable<Transaction> GetTransactionsofAccount(string accountNumber);

        Account GetAccountbyId(string userID);

    }
}
