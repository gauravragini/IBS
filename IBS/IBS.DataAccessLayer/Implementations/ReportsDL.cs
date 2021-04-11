using IBS.DataAccessLayer.Interfaces;
using IBS.EntitiesLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBS.DataAccessLayer.Implementations
{
    public class ReportsDL : IReportsDL
    {
        private ApplicationDbContext database;
        private readonly UserManager<ApplicationUser> userManager;

        public ReportsDL(ApplicationDbContext database, UserManager<ApplicationUser> userManager)
        {
            this.database = database;
            this.userManager = userManager;
        }

        /// <summary>
        ///  It takes all the users and selects the users whose status is applied. and then retrievs its account information. It then stores all the details in a list (using RegisterCustomer Model)
        /// </summary>
        /// <returns>This function returns the list of newy registered customers.</returns>
        public IEnumerable<RegisterCustomer> GetNewCustomers()
        {
            List<RegisterCustomer> newCustomersList = new List<RegisterCustomer>();
            var users = userManager.Users;
            
            foreach ( var user in users)
            {
                if(user.Status == "applied")
                {
                    RegisterCustomer customer = new RegisterCustomer();
                    customer.UserName = user.UserName;
                    customer.PhoneNumber = user.PhoneNumber;
                    customer.FirstName = user.FirstName;
                    customer.LastName = user.LastName;
                    customer.Dob = user.Dob;
                    customer.Gender = user.Gender;
                    customer.FathersName = user.FathersName;
                    customer.MothersName = user.MothersName;
                    customer.Address = user.Address;
                    customer.Pincode = user.Pincode;
                    customer.Id = user.Id;

                    newCustomersList.Add(customer);
                 }
            }
                return newCustomersList;
        }


        //Function to return list of all the transactions performed by all the users
        public IEnumerable<Transaction> GetAllTransactions()
        {
            return database.Transactions.ToList();
        }
 

        //function to return list of all the accounts
        public IEnumerable<Account> GetAllAccounts()
        {
            return database.Accounts.ToList();
        }


        //function to get account information using the account number
        public Account GetAccountbyAccountNumber(string accountNumber)
        {
            Account account = database.Accounts.SingleOrDefault(account => account.AccountNumber == accountNumber);
            return account;
        }


        //function to get list of all the transactions performed by a specific accountholder (using accountnumber)
        public IEnumerable<Transaction> GetTransactionsofAccount(string accountNumber)
        {
            var transactionList = from transac in database.Transactions
                                  where transac.AccountNumber == accountNumber
                                  select transac;

            return transactionList.ToList();
        }

        public Account GetAccountbyId(string userID)
        {
            Account account = database.Accounts.SingleOrDefault(account => account.Id == userID);
            return account;
        }
    }
}
