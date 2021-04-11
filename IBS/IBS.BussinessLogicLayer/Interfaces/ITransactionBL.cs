using IBS.EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBS.BussinessLogicLayer.Interfaces
{
    public interface ITransactionBL
    {
        Transaction DepositMoney(string accountNumber, decimal amount);
        Transaction WithdrawMoney(string accountNumber, decimal amount);
        Transaction TransferMoney(string accountNumber, string toAccountNumber, decimal amount);
    }
}
