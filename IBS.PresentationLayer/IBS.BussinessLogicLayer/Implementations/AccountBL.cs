using IBS.BussinessLogicLayer.Interfaces;
using IBS.DataAccessLayer.Interfaces;
using IBS.EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBS.BussinessLogicLayer.Implementations
{
    public class AccountBL : IAccountBL
    {
        private IAccountDL accountDataLayer;
        public AccountBL(IAccountDL accountDataLayer)
        {
            this.accountDataLayer = accountDataLayer;
        }
        public Account GetAccountbyAccountNumber(string accountNumber)
        {
            return accountDataLayer.GetAccountbyAccountNumber(accountNumber);
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return accountDataLayer.GetAllAccounts();
        }
    }
}
