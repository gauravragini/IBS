using IBS.EntitiesLayer.Models;
using IBS.PresentationLayer.Helper;
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

namespace IBS.PresentationLayer.Controllers
{
   
    public class AdminController : Controller
    {   
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("JWToken") != null)
                return View();
            else
                return Content("Not Authorized");
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
                        ViewData["error"] = response.Content.ReadAsStringAsync().Result;
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
                        ViewBag.error = response.Content.ReadAsStringAsync().Result;
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
                        ViewBag.error = response.Content.ReadAsStringAsync().Result;
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
                        ViewBag.error = response.Content.ReadAsStringAsync().Result;
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

    }
}
