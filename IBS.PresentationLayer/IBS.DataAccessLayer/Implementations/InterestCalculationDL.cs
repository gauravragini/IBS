using IBS.DataAccessLayer.Interfaces;
using IBS.EntitiesLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBS.DataAccessLayer.Implementations
{
    public class InterestCalculationDL : IIntererstCalculationDL
    {
        private ApplicationDbContext database;

        public InterestCalculationDL(ApplicationDbContext database)
        {
            this.database = database;
        }
        public Adminwork CalculateInterest(string adminID)
        {
            decimal interestRate = 0;
            IEnumerable<Account> accounts = database.Accounts.ToList();
            foreach (Account account in accounts)
            {
                if (account.AccountType == "Savings")
                {
                     interestRate = Convert.ToDecimal(0.6);
                }
                else if (account.AccountType == "Fixed")
                {
                    interestRate = Convert.ToDecimal(0.4);
                }
                database.Accounts.FromSqlRaw<Account>("CalculateInterest {0},{1}", account.AccountNumber, interestRate, adminID).ToList().FirstOrDefault();
            }

            Adminwork work = new Adminwork();
            work.WorkType = "InterestCalculation";
            work.WorkTime = DateTime.Now;
            work.Id = adminID;
            database.Adminworks.Add(work);
            database.SaveChanges();

            return work;
        }

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
    }
}
