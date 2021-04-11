using IBS.BussinessLogicLayer.Interfaces;
using IBS.EntitiesLayer.Models;
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
        private readonly UserManager<ApplicationUser> userManager;
        //private SignInManager<IdentityUser> signinManager;
        private readonly IConfiguration _configuration;
        private ApplicationDbContext db;

        private IAccountBL accountbussinessLayer;

        public AccountController(UserManager<ApplicationUser> userManager, /*SignInManager<IdentityUser> signinManager,*/ IConfiguration configuration, ApplicationDbContext d, IAccountBL accountbussinessLayer)
        {
            this.userManager = userManager;
            //  this.signinManager = signinManager;
            _configuration = configuration;
            this.db = d;
            this.accountbussinessLayer = accountbussinessLayer;
        }


        [HttpPost]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomer model)
        {
            var userExist = await userManager.FindByNameAsync(model.UserName);
            if (userExist != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Already exist" });

            ApplicationUser user = new ApplicationUser()
            {
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Dob = model.Dob,
                Gender = model.Gender,
                FathersName = model.FathersName,
                MothersName = model.MothersName,
                Address = model.Address,
                Pincode = model.Pincode,
                Status = "applied",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Creation Failed" });
            }
            else
            {
                var usercreated = await userManager.FindByNameAsync(model.UserName);
                string accountNumber = "IBS00000" + usercreated.UserName.Substring(0, 6).ToUpper();
                Account account = new Account();
                account.AccountNumber = accountNumber;
                account.AccountType = model.AccountType;
                account.InterestAmount = 0;
                account.AvailableBalance = 0;
                account.AccountCreationTime = DateTime.Now;
                account.Id = usercreated.Id;
                db.Accounts.Add(account);
                db.SaveChanges();




                //if (model.NomineeName != "" || model.NomineeName != null)
                //{
                //    Nominee nominee = new Nominee();
                //    nominee.NomineeName = model.NomineeName;
                //    nominee.NomineeRelation = model.NomineeRelation;
                //    nominee.NomineeAge = model.NomineeAge;
                //    nominee.NomineeGender = model.NomineeGender;
                //    nominee.NomineeMobileNumber = model.NomineeMobileNumber;
                //    nominee.NomineeAddress = model.NomineeAddress;
                //    nominee.Id = usercreated.Id;
                //    db.Nominees.Add(nominee);
                //    db.SaveChanges();
                //}

                return Ok(new Response { Status = "Success", Message = "Customer Registration Done : Use Your Registration id to check the status of your Application" });
            }

        }



        [HttpPost]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterAdmin model)
        {
            var userExist = await userManager.FindByNameAsync(model.UserName);
            if (userExist != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = " User Already Exist" });

            ApplicationUser user = new ApplicationUser
            {
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Dob = model.Dob,
                Gender = model.Gender,
                FathersName = model.FathersName,
                MothersName = model.MothersName,
                Address = model.Address,
                Pincode = model.Pincode,
                Status = "admin",
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = $"{result.Errors.ToList()[0].Code}", Message = $"{result.Errors.ToList()[0].Description}" });

            return Ok(new Response { Status = "Success", Message = "User Created Successfully" });
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                return Ok(new Response
                {
                    Status = "success",
                    Message = "Logged In",
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    userid = user.Id,
                    username = user.UserName,
                    userstatus = user.Status
                });
            }
            return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Fail", Message = "Incorrect Credentials" });
        }


        //public async Task<IActionResult> Logout()
        //{
        //    await signinManager.SignOutAsync();
        //    return RedirectToAction("Index", "Authentication");
        //}



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
        {   var user = await userManager.FindByNameAsync(username);
            var result = await userManager.DeleteAsync(user);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Fail", Message = "Some error occurred" });

            return Ok(new Response { Status = "Success", Message = "Customer Rejected" });
        }
    }
}