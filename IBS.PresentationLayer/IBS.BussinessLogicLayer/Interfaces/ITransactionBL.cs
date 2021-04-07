using IBS.EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBS.BussinessLogicLayer.Interfaces
{
    public interface ITransactionBL
    {
        IEnumerable<Transaction> GetTransactionsofAccount(string accountNumber);

        Transaction DepositMoney(string accountNumber, decimal amount);
        Transaction WithdrawMoney(string accountNumber, decimal amount);
        Transaction TransferMoney(string accountNumber, string toAccountNumber, decimal amount);

        Transaction AddInterest(string accountNumber);
        Transaction WithdrawInterest(string accountNumber);
    }
}
