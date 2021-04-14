using IBS.BussinessLogicLayer.Interfaces;
using IBS.EntitiesLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IBS.WEBAPI.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]

    public class AccountController : ControllerBase
    {

        private UserManager<ApplicationUser> userManager;
        private ApplicationDbContext db;
        private IAccountBL accountbussinessLayer;
        public AccountController(ApplicationDbContext d, IAccountBL accountbussinessLayer, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.db = d;
            this.accountbussinessLayer = accountbussinessLayer;
        }

        [HttpPost] 
        public ActionResult CreateBankAccount(Account account)
        {
            try
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Message = e.Message });
            }
            
        }




        //web api action method to accept the customer application
        [HttpGet("{username:regex(\\w)}")]
        public async Task<IActionResult> ApproveCustomer(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            user.Status = "approved";
            var result = await userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Fail", Message = "Some error occurred" });

            return Ok(new Response { Status = "Success", Message = "Customer Approved Successfully" });
        }


        //web api action method to reject the customer application
         [HttpGet("{username:regex(\\w)}")]
        public async Task<IActionResult> RejectCustomer(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            Account account = db.Accounts.SingleOrDefault(account => account.Id == user.Id);
            db.Accounts.Remove(account);
            db.SaveChanges();

            var result = await userManager.DeleteAsync(user);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Fail", Message = "Some error occurred" });

            return Ok(new Response { Status = "Success", Message = "Customer Rejected" });
        }


        [HttpPost]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePassword model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            var result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Fail", Message = error.Description });
            }

            return Ok(new Response { Status = "Success", Message = "Password Updated Successfully" });
        }



    }
}