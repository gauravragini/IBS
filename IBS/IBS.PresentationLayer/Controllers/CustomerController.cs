using IBS.EntitiesLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IBS.PresentationLayer.Controllers
{
    public class CustomerController : Controller
    {
        const string sessionAccountNo = "accountNumber";


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var userid = HttpContext.Session.GetString("userid");
                    client.BaseAddress = new Uri("http://localhost:10293/api/Reports");
                    HttpResponseMessage response = await client.GetAsync("Reports/GetAccountbyId/" + userid);
                    var result = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Account account = JsonConvert.DeserializeObject<Account>(result);
                        HttpContext.Session.SetString(sessionAccountNo, account.AccountNumber);
                        return View(account);
                    }

                    else
                    {
                        Response content = JsonConvert.DeserializeObject<Response>(result);
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


        //view all my transactions
        [HttpGet]
        public async Task<IActionResult> ViewTransactions(string accountNumber)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    List<Transaction> transactions = new List<Transaction>();
                    client.BaseAddress = new Uri("http://localhost:10293/api/Reports");
                    HttpResponseMessage response = await client.GetAsync("Reports/getTransactionsofAccount/" + accountNumber);
                    var result = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        transactions = JsonConvert.DeserializeObject<List<Transaction>>(result);
                        return View(transactions);
                    }

                    else
                    {
                        Response content = JsonConvert.DeserializeObject<Response>(result);
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


        //deposit money form
        [HttpGet]
        public IActionResult Deposit(string accountNumber)
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Deposit()
        {

            try
            {
                using (var client = new HttpClient())
                {
                    string accountNumber = Request.Form["accountNumber"];
                    decimal amount = Convert.ToDecimal(Request.Form["amount"]);
                    Transaction transaction = new Transaction();

                    List<Transaction> transactions = new List<Transaction>();
                    client.BaseAddress = new Uri("http://localhost:10293/api/Transaction");
                    HttpResponseMessage response = await client.GetAsync("Transaction/DepositMoney/" + accountNumber + "/" + amount);
                    var result = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        transaction = JsonConvert.DeserializeObject<Transaction>(result);
                        return View("TransactionDone", transaction);
                    }

                    else
                    {
                        Response content = JsonConvert.DeserializeObject<Response>(result);
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


        //withdraw money
        [HttpGet]
        public IActionResult Withdraw(string accountNumber)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Withdraw()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string accountNumber = Request.Form["accountNumber"];
                    decimal amount = Convert.ToDecimal(Request.Form["amount"]);
                    Transaction transaction = new Transaction();

                    List<Transaction> transactions = new List<Transaction>();
                    client.BaseAddress = new Uri("http://localhost:10293/api/Transaction");
                    HttpResponseMessage response = await client.GetAsync("Transaction/WithdrawMoney/" + accountNumber + "/" + amount);
                    var result = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        transaction = JsonConvert.DeserializeObject<Transaction>(result);
                        return View("TransactionDone", transaction);
                    }

                    else
                    {
                        Response content = JsonConvert.DeserializeObject<Response>(result);
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

        //Transfer Money
        [HttpGet]
        public IActionResult Transfer(string accountNumber)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Transfer()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string accountNumber = Request.Form["accountNumber"];
                    string toAccountNumber = Request.Form["toAccountNumber"];
                    decimal amount = Convert.ToDecimal(Request.Form["amount"]);
                    Transaction transaction = new Transaction();

                    List<Transaction> transactions = new List<Transaction>();
                    client.BaseAddress = new Uri("http://localhost:10293/api/Transaction");
                    HttpResponseMessage response = await client.GetAsync("Transaction/TransferMoney/" + accountNumber + "/" + toAccountNumber + "/" + amount);
                    var result = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        transaction = JsonConvert.DeserializeObject<Transaction>(result);
                        return View("TransactionDone", transaction);
                    }

                    else
                    {
                        Response content = JsonConvert.DeserializeObject<Response>(result);
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

        //View Intrest account
        public async Task<IActionResult> ViewInterest(string accountNumber)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    Account account = new Account();
                    client.BaseAddress = new Uri("http://localhost:10293/api/Reports");
                    HttpResponseMessage response = await client.GetAsync("Reports/GetAccountbyAccountNumber/" + accountNumber);
                    var result = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        account = JsonConvert.DeserializeObject<Account>(result); ;
                        return View(account);
                    }
                    else
                    {
                        Response content = JsonConvert.DeserializeObject<Response>(result);
                        ViewData["error"] = content.Message ;
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

        //addInterest
        [HttpGet]
        public async Task<IActionResult> AddInterest(string accountNumber)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    Transaction transaction = new Transaction();
                    client.BaseAddress = new Uri("http://localhost:10293/api/Interest");
                    HttpResponseMessage response = await client.GetAsync("Interest/AddInterest/" + accountNumber);
                    var result = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        transaction = JsonConvert.DeserializeObject<Transaction>(result);
                        return View("TransactionDone", transaction);
                    }
                    else
                    {
                        Response content = JsonConvert.DeserializeObject<Response>(result);
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


        //withdrawInterest
        [HttpGet]
        public async Task<IActionResult> WithdrawInterest(string accountNumber)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    Transaction transaction = new Transaction();
                    client.BaseAddress = new Uri("http://localhost:10293/api/Interest");
                    HttpResponseMessage response = await client.GetAsync("Interest/WithdrawInterest/" + accountNumber);
                    var result = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        transaction = JsonConvert.DeserializeObject<Transaction>(result);
                        return View("TransactionDone",transaction);
                    }
                    else
                    {
                        Response content = JsonConvert.DeserializeObject<Response>(result);
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



        //updatePassword
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
                    HttpResponseMessage response = await client.PostAsJsonAsync<UpdatePassword>("Account/UpdatePassword/",model);
                    var result = response.Content.ReadAsStringAsync().Result;
                    Response content = JsonConvert.DeserializeObject<Response>(result);
                    return Content(content.Message);
          
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
