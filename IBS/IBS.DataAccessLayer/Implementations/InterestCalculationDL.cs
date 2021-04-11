using IBS.DataAccessLayer.Interfaces;
using IBS.EntitiesLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBS.DataAccessLayer.Implementations
{
    public class InterestCalculationDL : IInterestCalculationDL
    {
        private ApplicationDbContext database;

        public InterestCalculationDL(ApplicationDbContext database)
        {
            this.database = database;
        }

        /// <summary>
        /// this function calculates the interest of all the accounts in one go. If account typ is Saving then interest rate is 0.6%per month
        /// and 0.4 for fixed accounts. This can be done only on monthly basis
        /// After calculating interest task done information is stored in Adminwork table
        /// </summary>
        /// <param name="adminID">maintain which admin has performed this task</param>
        /// <returns>Function returns the confirmation that intrest has been calculated for all accounts</returns>
        public Adminwork CalculateInterest(string adminID)
        {
            decimal interestRate = 0;
            IEnumerable<Account> accounts = database.Accounts.ToList();
            foreach (Account account in accounts)
            {
                if (account.AccountType == "Savings")
                {
                     interestRate = Convert.ToDecimal(0.6); //0.6% permonth on savings account
                }
                else if (account.AccountType == "Fixed")
                {
                    interestRate = Convert.ToDecimal(0.4); //0.4% permonth on fixed account
                }
                database.Accounts.FromSqlRaw<Account>("CalculateInterest {0},{1}", account.AccountNumber, interestRate, adminID).ToList().FirstOrDefault();
            }

            //storing task info in adminwork table and returing it 
            Adminwork work = new Adminwork();
            work.WorkType = "InterestCalculation";
            work.WorkTime = DateTime.Now;
            work.Id = adminID;
            database.Adminworks.Add(work);
            database.SaveChanges();
            return work;
        }


        //returns the last date when the interest was calculated
        public DateTime lastInterestCalculation()
        {
            DateTime date = new DateTime(1000, 01, 01, 12, 00, 00);
            var res = from work in database.Adminworks
                   where work.WorkType == "InterestCalculation"
                   select work.WorkTime;
            if(res!=null)
                date = Convert.ToDateTime(res.LastOrDefault());

            return date;
        }


        //Customer add the money in interest balance to his available balance
        public Transaction AddInterest(string accountNumber)
        {
            return database.Transactions.FromSqlRaw<Transaction>("AddInterest {0}", accountNumber).ToList().FirstOrDefault();
        }


        //customer withdraws his intrest amount money
        public Transaction WithdrawInterest(string accountNumber)
        {
            return database.Transactions.FromSqlRaw<Transaction>("WithdrawInterest {0}", accountNumber).ToList().FirstOrDefault();
        }

    }
}
