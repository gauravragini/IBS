using IBS.DataAccessLayer.Interfaces;
using IBS.EntitiesLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBS.DataAccessLayer.Implementations
{
    public class AccountDL : IAccountDL
    {
        private ApplicationDbContext database;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountDL(ApplicationDbContext database, UserManager<ApplicationUser> userManager)
        {
            this.database = database;
            this.userManager = userManager;
        }

        public string AcceptCustomer(string id)
        {
           // var user =  userManager.FindByIdAsync(id).Result;
           // user.Status = "approved";
          //  IdentityResult result = userManager.UpdateAsync(user).Result;

            return id;
        }

        public string RejectCustomer(string id)
        {
            var user = userManager.FindByIdAsync(id).Result;
            userManager.DeleteAsync(user);
            return id;

        }
    }
}
