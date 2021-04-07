using IBS.EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBS.DataAccessLayer.Interfaces
{
    public interface IAccountDL
    {
        IEnumerable<Account> GetAllAccounts();
        Account GetAccountbyAccountNumber(string accountNumber);
    }
}
