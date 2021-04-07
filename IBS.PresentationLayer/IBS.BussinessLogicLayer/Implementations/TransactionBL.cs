using IBS.BussinessLogicLayer.Interfaces;
using IBS.DataAccessLayer.Interfaces;
using IBS.EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static IBS.Exceptions.Exceptions;

namespace IBS.BussinessLogicLayer.Implementations
{
    public class TransactionBL : ITransactionBL
    {
        private ITransactionDL transactionDataLayer;
        private IAccountDL accountDataLayer;
        public TransactionBL(ITransactionDL transactionDataLayer, IAccountDL accountDataLayer)
        {
            this.transactionDataLayer = transactionDataLayer;
            this.accountDataLayer = accountDataLayer;
        }

        public Transaction AddInterest(string accountNumber)
        {
            return transactionDataLayer.AddInterest(accountNumber);
        }

        public Transaction DepositMoney(string accountNumber, decimal amount)
        {
            decimal availbal = transactionDataLayer.AvailableBalance(accountNumber);

            if (availbal == 0 && amount < 1000)
            {
                throw new FirstDepositException("The amount deposited for the first time should be greater than or equal to 1000");
            }

            return transactionDataLayer.DepositMoney(accountNumber, amount);
        }

        public IEnumerable<Transaction> GetTransactionsofAccount(string accountNumber)
        {
            return transactionDataLayer.GetTransactionsofAccount(accountNumber);
        }

        public Transaction TransferMoney(string accountNumber, string toAccountNumber, decimal amount)
        {
            //setting minimum balance to 1000
            decimal minbal = 1000;
            decimal availbal = transactionDataLayer.AvailableBalance(accountNumber);
            if (availbal - amount < minbal)
            {
                throw new InsufficientBalanceException("Insufficient Balance. The Minimum Balance in the amount should be 1000 after withdrawal");
            }
            if (accountDataLayer.GetAccountbyAccountNumber(toAccountNumber) == null)
            {
                throw new AccountDoesNotExistException("You have Entered  account number that Doesnot exist");
            }
            return transactionDataLayer.TransferMoney(accountNumber, toAccountNumber, amount);
        }

        public Transaction WithdrawInterest(string accountNumber)
        {
            return transactionDataLayer.WithdrawInterest(accountNumber);
        }

        public Transaction WithdrawMoney(string accountNumber, decimal amount)
        {

            //setting minimum balance to 1000
            decimal minbal = 1000;
            decimal availbal = transactionDataLayer.AvailableBalance(accountNumber);
            if (availbal - amount < minbal)
            {
                throw new InsufficientBalanceException("Insufficient Balance. The Minimum Balance in the amount should be 1000 after withdrawal");
            }

            return transactionDataLayer.WithdrawMoney(accountNumber, amount);
        }

    }
}
