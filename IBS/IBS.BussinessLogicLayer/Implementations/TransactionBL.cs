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
        private IReportsDL reportDataLayer;
        public TransactionBL(ITransactionDL transactionDataLayer, IReportsDL reportDataLayer)
        {
            this.transactionDataLayer = transactionDataLayer;
            this.reportDataLayer = reportDataLayer;
        }


        public Transaction DepositMoney(string accountNumber, decimal amount)
        {
            decimal availbal = transactionDataLayer.AvailableBalance(accountNumber);

            //first deposit should always be greater the minimun balance ie 1000
            if (availbal == 0 && amount < 1000)
            {
                throw new FirstDepositException("The amount deposited for the first time should be greater than or equal to 1000");
            }

            return transactionDataLayer.DepositMoney(accountNumber, amount);
        }

 
        public Transaction TransferMoney(string accountNumber, string toAccountNumber, decimal amount)
        {
            //setting minimum balance to 1000
            decimal minimumBalance = 1000;
            decimal availableBalance = transactionDataLayer.AvailableBalance(accountNumber);

            //checking amount left after transaferring should be greater then 1000
            if (availableBalance - amount < minimumBalance)
            {
                throw new InsufficientBalanceException("Insufficient Balance. The Minimum Balance in the amount should be 1000 after withdrawal");
            }

            //Checkig if the account in which money is to be transferred exists or not
            if (reportDataLayer.GetAccountbyAccountNumber(toAccountNumber) == null)
            {
                throw new AccountDoesNotExistException("You have Entered  account number that Doesnot exist");
            }

            return transactionDataLayer.TransferMoney(accountNumber, toAccountNumber, amount);
        }


        public Transaction WithdrawMoney(string accountNumber, decimal amount)
        {
            //setting minimum balance to 1000
            decimal minbal = 1000;
            decimal availbal = transactionDataLayer.AvailableBalance(accountNumber); //chacking available balance
            if (availbal - amount < minbal)
            {
                throw new InsufficientBalanceException("Insufficient Balance. The Minimum Balance in the amount should be 1000 after withdrawal");
            }

            return transactionDataLayer.WithdrawMoney(accountNumber, amount);
        }

    }
}
