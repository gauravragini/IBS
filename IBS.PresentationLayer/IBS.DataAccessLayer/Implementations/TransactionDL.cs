﻿using IBS.DataAccessLayer.Interfaces;
using IBS.EntitiesLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBS.DataAccessLayer.Implementations
{
    public class TransactionDL : ITransactionDL
    {
        private ApplicationDbContext database;

        public TransactionDL(ApplicationDbContext database)
        {
            this.database = database;
        }

        public IEnumerable<Transaction> GetTransactionsofAccount(string accountNumber)
        {
            var transactionList = from transac in database.Transactions
                                  where transac.AccountNumber == accountNumber
                                  select transac;

            return transactionList.ToList();
        }


        public Transaction DepositMoney(string accountNumber, decimal amount)
        {
            return database.Transactions.FromSqlRaw<Transaction>("DepositMoney {0},{1}", accountNumber, amount).ToList().FirstOrDefault();
        }


        public Transaction WithdrawMoney(string accountNumber, decimal amount)
        {
            return database.Transactions.FromSqlRaw<Transaction>("WithdrawMoney {0},{1}", accountNumber, amount).ToList().FirstOrDefault();
        }


        public Transaction TransferMoney(string accountNumber, string toAccountNumber, decimal amount)
        {
            return database.Transactions.FromSqlRaw<Transaction>("TransferMoney {0},{1},{2}", accountNumber, toAccountNumber, amount).ToList().FirstOrDefault();
        }


        public Transaction AddInterest(string accountNumber)
        {
            return database.Transactions.FromSqlRaw<Transaction>("AddInterest {0}", accountNumber).ToList().FirstOrDefault();
        }


        public Transaction WithdrawInterest(string accountNumber)
        {
            return database.Transactions.FromSqlRaw<Transaction>("WithdrawInterest {0}", accountNumber).ToList().FirstOrDefault();
        }


        public decimal AvailableBalance(string accountNumber)
        {
            var balance = from account in database.Accounts
                          where account.AccountNumber == accountNumber
                          select account.AvailableBalance;

            return Convert.ToDecimal(balance.ToList().FirstOrDefault());
        }
    }
}
