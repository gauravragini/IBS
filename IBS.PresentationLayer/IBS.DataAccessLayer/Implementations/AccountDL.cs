using IBS.DataAccessLayer.Interfaces;
using IBS.EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBS.DataAccessLayer.Implementations
{
    public class AccountDL : IAccountDL
    {
        private ApplicationDbContext database;

        public AccountDL(ApplicationDbContext database)
        {
            this.database = database;
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return database.Accounts.ToList();
        }

        public Account GetAccountbyAccountNumber(string accountNumber)
        {
            Account a = database.Accounts.SingleOrDefault(acc => acc.AccountNumber == accountNumber);
            return a;
        }
    }
}
