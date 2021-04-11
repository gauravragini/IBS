using IBS.EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace IBS.BussinessLogicLayer.Interfaces
{
    public interface IReportsBL
    {
        IEnumerable<RegisterCustomer> GetNewCustomers();
        IEnumerable<EntitiesLayer.Models.Transaction> GetAllTransactions();
        IEnumerable<Account> GetAllAccounts();
        Account GetAccountbyAccountNumber(string accountNumber);
        IEnumerable<EntitiesLayer.Models.Transaction> GetTransactionsofAccount(string accountNumber);

        Account GetAccountbyId(string userID);

    }
}
