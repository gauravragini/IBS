using IBS.EntitiesLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IBS.PresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }


        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                @ViewData["message"] = TempData["message"];
                return View();
            }
            else
            {
                ApplicationUser user = await userManager.GetUserAsync(HttpContext.User);
                if (user.Status == "admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                return RedirectToAction("Index", "Customer");
            }
        }


        //Displays Admin Registration form
        [AllowAnonymous]
        public IActionResult RegisterAdmin()
        {
            return View();
        }


        //Creates admin user
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(RegisterAdmin model)
        {
            //checking if user exists or not
            var userExist = await userManager.FindByNameAsync(model.UserName);
            if (userExist != null)
                TempData["message"] = "User Already Exists";

            //checking age valid
            int age = 0;
            age = DateTime.Now.Year - model.Dob.Year;
            if (DateTime.Now.DayOfYear < model.Dob.DayOfYear)
                age = age - 1;
            if (age >= 0 && age < 18)
            {
                TempData["message"] = "You Are below 18 years, So Your Account Cannot be created";
                return RedirectToAction("Index");
            }
            else if (age < 0 || age > 100)
            {
                TempData["message"] = "You have Entered false Date of birth";
                return RedirectToAction("Index");
            }

            //creating user
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
            {
                TempData["message"] = $"{result.Errors.ToList()[0].Description}";
            }
            else
            {
                //adding role
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                if (await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await userManager.AddToRolesAsync(user, new List<string>() { UserRoles.Admin });
                }
                TempData["message"] = "Admin User Registered Successfuly. You Can LogIn Into Your Account using your Email and Password";
            }

                return RedirectToAction("Index");
        }


        //Displays Customer Registration form
        [AllowAnonymous]
        public IActionResult RegisterCustomer()
        {
            return View();
        }


        //Creates Customer User
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterCustomer(RegisterCustomer model)
        {
            var userExist = await userManager.FindByNameAsync(model.UserName);
            if (userExist != null)
                TempData["message"] = "User Already Exists";

            //checking age valid
            int age = 0;
            age = DateTime.Now.Year - model.Dob.Year;
            if (DateTime.Now.DayOfYear < model.Dob.DayOfYear)
                age = age - 1;
            if (age >= 0 && age < 18)
            {
                TempData["message"] = "You Are below 18 years, So Your Account Cannot be created";
                return RedirectToAction("Index");
            }
            else if (age < 0 || age > 100)
            {
                TempData["message"] = "You have Entered false Date of birth";
                return RedirectToAction("Index");
            }

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
                TempData["message"] = $"{result.Errors.ToList()[0].Description}";
            }
            else
            {
                //adding role
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                if (await roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await userManager.AddToRolesAsync(user, new List<string>() { UserRoles.User });
                }

                //creating bank account object for customer
                var usercreated = await userManager.FindByNameAsync(model.UserName);
                string accountNumber = "IBS00000" + usercreated.UserName.Substring(0, 6).ToUpper();
                Account account = new Account();
                account.AccountNumber = accountNumber;
                account.AccountType = model.AccountType;
                account.InterestAmount = 0;
                account.AvailableBalance = 0;
                account.AccountCreationTime = DateTime.Now;
                account.Id = usercreated.Id;

                //Creates customer account
                Response content;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:10293/api/Account");

                    //HTTP POST
                    var response = client.PostAsJsonAsync<Account>("Account/CreateBankAccount", account).Result;
                    var resultbank = response.Content.ReadAsStringAsync().Result;
                    content = JsonConvert.DeserializeObject<Response>(resultbank);
                    if (response.IsSuccessStatusCode)
                    {
                        TempData["message"] = "Customer User Registered Successfuly. You Can LogIn Into Your Account using your Email and Password to check the status of Your Application";
                    }
                    else
                    {
                        TempData["message"] = "Customer User Creation Failed : " + content.Message;
                        
                    }
                }

            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Login login)
        {
            
            ApplicationUser appUser = await userManager.FindByNameAsync(login.UserName);
            if (appUser != null)
            {
                await signInManager.SignOutAsync();
                Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(appUser, login.Password, false, false);
                if (result.Succeeded)
                {
                    if (appUser != null)
                    {
                        if (appUser.Status == "admin")
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        else if (appUser.Status == "approved")
                        {
                            return RedirectToAction("Index", "Customer");
                        }
                        else if (appUser.Status == "applied")
                        {
                            TempData["message"] = "Your Application Has not been approved yet by the administrator. Check Again Later";
                            await signInManager.SignOutAsync();
                            HttpContext.Session.Clear();
                            return RedirectToAction("Index","Account");
                        }
                    }
                }                
            }
            TempData["message"] = "Invalid username or password";
            return RedirectToAction("Index");
        }


        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Account");
        }





    }
}
