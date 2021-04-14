using IBS.EntitiesLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IBS.EntitiesLayer;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace IBS.PresentationLayer.Controllers
{

    [Authorize(Roles = UserRoles.Admin)]
    public class AdminController : Controller
    {

        private UserManager<ApplicationUser> userManager;

        public AdminController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["passwordsuccess"] = TempData["passwordsuccess"];

            ApplicationUser user = await userManager.GetUserAsync(HttpContext.User);
            HttpContext.Session.SetString("userid", user.Id);
            HttpContext.Session.SetString("username", user.UserName);
            HttpContext.Session.SetString("name", user.FirstName + " " + user.LastName);
            return View(user);
        }


        //Action method to get the list of newly registered customers
        public async Task<IActionResult> GetNewCustomers()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    List<RegisterCustomer> customers = new List<RegisterCustomer>();
                    client.BaseAddress = new Uri("http://localhost:10293/api/Reports");             
                    HttpResponseMessage response = await client.GetAsync("Reports/GetNewCustomers");

                    var result = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        customers = JsonConvert.DeserializeObject<List<RegisterCustomer>>(result);
                        return View(customers);
                    }
                    else
                    {
                        var content = JsonConvert.DeserializeObject<Response>(result);
                        ViewData["error"] = content.Message;
                        return View("error");
                    }
                }
            }
            catch (Exception e)
            {
                ViewData["error"] = e.Message;
                return View("~/Views/Shared/ExceptionError.cshtml");
            }
        }


        //Action method to get the list of all customers
        public async Task<IActionResult> GetAllAccounts()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    List<Account> accounts = new List<Account>();
                    client.BaseAddress = new Uri("http://localhost:10293/api/Reports");
                    HttpResponseMessage response = await client.GetAsync("Reports/GetAllAccounts");

                    var result = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        accounts = JsonConvert.DeserializeObject<List<Account>>(result);
                        return View(accounts);
                    }
                    else
                    {
                        var content = JsonConvert.DeserializeObject<Response>(result);
                        ViewData["error"] = content.Message;
                        return View("error");
                    }
                }
            }
            catch (Exception e)
            {
                ViewData["error"] = e.Message;
                return View("~/Views/Shared/ExceptionError.cshtml");
            }
        }


        //Action method to Calculate interest of all customers
        [HttpGet]
        public async Task<IActionResult> CalculateInterest(string ID)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    Adminwork work = new Adminwork();
                    client.BaseAddress = new Uri("http://localhost:10293/api/Interest");
                    HttpResponseMessage response = await client.GetAsync("Interest/CalculateInterest/" + ID);

                    var result = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        work = JsonConvert.DeserializeObject<Adminwork>(result);
                        return View(work);
                    }
                    else
                    {
                        var content = JsonConvert.DeserializeObject<Response>(result);
                        ViewData["error"] = content.Message;
                        return View("error");
                    }
                }
            }
            catch (Exception e)
            {
                ViewData["error"] = e.Message;
                return View("~/Views/Shared/ExceptionError.cshtml");
            }
        }


        //Action method to get the list of all transactions
        public async Task<IActionResult> GetAllTransactions()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    List<Transaction> transactions = new List<Transaction>();
                    client.BaseAddress = new Uri("http://localhost:10293/api/Reports");
                    HttpResponseMessage response = await client.GetAsync("Reports/GetAllTransactions");
                   
                    var result = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        transactions = JsonConvert.DeserializeObject<List<Transaction>>(result);
                        return View(transactions);
                    }
                    else
                    {
                        var content = JsonConvert.DeserializeObject<Response>(result);
                        ViewData["error"] = content.Message;
                        return View("error");
                    }
                }
            }
            catch (Exception e)
            {
                ViewData["error"] = e.Message;
                return View("~/Views/Shared/ExceptionError.cshtml");
            }

        }



        //action method to approve a customer application
        [HttpGet]
        public async Task<IActionResult> ApproveCustomer(string username)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:10293/api/Account");
                    HttpResponseMessage response = await client.GetAsync("Account/ApproveCustomer/" + username);

                    var result = response.Content.ReadAsStringAsync().Result;
                    Response content = JsonConvert.DeserializeObject<Response>(result);
                    if (response.IsSuccessStatusCode)
                    {
                        ViewData["message"] = "Customer Approved";
                        return RedirectToAction("GetNewCustomers");
                    }
                    else
                    {
                        ViewData["error"] = content.Message;
                        return View("error");
                    }
                }
            }
            catch (Exception e)
            {
                ViewData["error"] = e.Message;
                return View("~/Views/Shared/ExceptionError.cshtml");
            }
        }


        //action method to reject a customer application
        [HttpGet]
        public async Task<IActionResult> RejectCustomer(string username)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:10293/api/Account");
                    HttpResponseMessage response = await client.GetAsync("Account/RejectCustomer/"+ username);

                    var result = response.Content.ReadAsStringAsync().Result;
                    Response content = JsonConvert.DeserializeObject<Response>(result);

                    if (response.IsSuccessStatusCode)
                    {
                        ViewData["message"] = "Customer Rejected";
                        return RedirectToAction("GetNewCustomers");
                    }
                    else
                    {
                        ViewData["error"] = content.Message;
                        return View("error");
                    }
                }
            }
            catch (Exception e)
            {
                ViewData["error"] = e.Message;
                return View("~/Views/Shared/ExceptionError.cshtml");
            }
        }


        //updates password

        public IActionResult UpdatePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePassword(UpdatePassword model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    Transaction transaction = new Transaction();
                    client.BaseAddress = new Uri("http://localhost:10293/api/Account");
                    HttpResponseMessage response = await client.PostAsJsonAsync<UpdatePassword>("Account/UpdatePassword/", model);
                    var result = response.Content.ReadAsStringAsync().Result;
                    Response content = JsonConvert.DeserializeObject<Response>(result);
                    if (response.IsSuccessStatusCode)
                    {
                        TempData["passwordsuccess"] = content.Message;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewData["passworderror"] = content.Message;
                        return View();
                    }

                }
            }
            catch (Exception e)
            {
                ViewData["error"] = e.Message;
                return View("~/Views/Shared/ExceptionError.cshtml");
            }
        }

    


    }
}
