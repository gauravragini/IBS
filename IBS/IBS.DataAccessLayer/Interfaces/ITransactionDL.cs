using IBS.EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBS.DataAccessLayer.Interfaces
{
    public interface ITransactionDL
    {      
        Transaction DepositMoney(string accountNumber, decimal amount);
        Transaction WithdrawMoney(string accountNumber, decimal amount);
        Transaction TransferMoney(string accountNumber, string toAccountNumber, decimal amount); 
        decimal AvailableBalance(string accountNumber);
    }
}
