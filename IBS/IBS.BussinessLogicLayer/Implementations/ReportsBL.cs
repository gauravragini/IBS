using IBS.BussinessLogicLayer.Interfaces;
using IBS.DataAccessLayer.Interfaces;
using IBS.EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace IBS.BussinessLogicLayer.Implementations
{
    public class ReportsBL : IReportsBL
    {

        private IReportsDL reportDataLayer;
        public ReportsBL(IReportsDL reportDataLayer)
        {
            this.reportDataLayer = reportDataLayer;
        }


        //in this class all the functions all the data layer functions

        public IEnumerable<RegisterCustomer> GetNewCustomers()
        {
            return reportDataLayer.GetNewCustomers();
        }


        public IEnumerable<Account> GetAllAccounts()
        {
            return reportDataLayer.GetAllAccounts();
        }


        IEnumerable<EntitiesLayer.Models.Transaction> IReportsBL.GetAllTransactions()
        {
            return reportDataLayer.GetAllTransactions();
        }

        public Account GetAccountbyAccountNumber(string accountNumber)
        {
            return reportDataLayer.GetAccountbyAccountNumber(accountNumber);
        }


        public IEnumerable<EntitiesLayer.Models.Transaction> GetTransactionsofAccount(string accountNumber)
        {
            return reportDataLayer.GetTransactionsofAccount(accountNumber);
        }

        public Account GetAccountbyId(string userID)
        {
            return reportDataLayer.GetAccountbyId(userID);
        }
    }
}
