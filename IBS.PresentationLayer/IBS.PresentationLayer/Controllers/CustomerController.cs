using IBS.EntitiesLayer.Models;
using IBS.PresentationLayer.Helper;
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
        const string SessionName = "accno";
        IBSAPI api = new IBSAPI();
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpContext.Session.SetString(SessionName, "IBS000AKSHAJ@");
            ViewBag.accno = HttpContext.Session.GetString(SessionName);
            var accountNumber = "IBS000AKSHAJ@";
            Account account = new Account();
            HttpClient client = api.Initial();
            HttpResponseMessage res = await client.GetAsync("Account/getAccountbyId/" + accountNumber);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                account = JsonConvert.DeserializeObject<Account>(result);
            }

            return View(account);
        }

        //view all my transactions
        [HttpGet]
        public async Task<IActionResult> ViewTransactions(string accountNumber)
        {
            ViewBag.accno = HttpContext.Session.GetString(SessionName);
            List<Transaction> transactions = new List<Transaction>();
            HttpClient client = api.Initial();
            HttpResponseMessage res = await client.GetAsync("Transaction/getTransactionsofAccount/" + accountNumber);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                transactions = JsonConvert.DeserializeObject<List<Transaction>>(result);
            }
            return View(transactions);
        }


        //deposit money
        [HttpGet]
        public IActionResult Deposit(string accountNumber)
        {
            ViewBag.accno = HttpContext.Session.GetString(SessionName);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Deposit2()
        {
            string accountNumber = Request.Form["accno"];
            decimal amount = Convert.ToDecimal(Request.Form["amount"]);
            ViewBag.accountno = HttpContext.Session.GetString(SessionName);

            Transaction transaction = new Transaction();
            HttpClient client = api.Initial();
            HttpResponseMessage res = await client.GetAsync("Transaction/DepositMoney/" + accountNumber + "/" + amount);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                transaction = JsonConvert.DeserializeObject<Transaction>(result);
                return View("TransactionDone", transaction);

            }
            else
            {
                ViewBag.error = res.Content.ReadAsStringAsync().Result;
                return View("TransactionFailed");
            }
        }


        //withdraw money
        [HttpGet]
        public IActionResult Withdraw(string accno)
        {
            ViewBag.accno = HttpContext.Session.GetString(SessionName);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Withdraw2()
        {
            string accno = Request.Form["accno"];
            decimal amount = Convert.ToDecimal(Request.Form["amount"]);
            ViewBag.accno = HttpContext.Session.GetString(SessionName);

            Transaction transaction = new Transaction();
            HttpClient client = api.Initial();
            HttpResponseMessage res = await client.GetAsync("Transaction/WithdrawMoney/" + accno + "/" + amount);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                transaction = JsonConvert.DeserializeObject<Transaction>(result);
                return View("TransactionDone", transaction);
            }
            else
            {
                ViewBag.error = res.Content.ReadAsStringAsync().Result;
                return View("TransactionFailed");
            }
        }

        //Transfer Money
        [HttpGet]
        public IActionResult Transfer(string accno)
        {
            ViewBag.accno = HttpContext.Session.GetString(SessionName);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Transfer2()
        {
            string accno = Request.Form["accno"];
            string toaccno = Request.Form["toaccno"];
            decimal amount = Convert.ToDecimal(Request.Form["amount"]);
            ViewBag.accountno = HttpContext.Session.GetString(SessionName);
            Transaction transaction = new Transaction();
            HttpClient client = api.Initial();
            HttpResponseMessage res = await client.GetAsync("Transaction/TransferMoney/" + accno + "/" + toaccno + "/" + amount);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                transaction = JsonConvert.DeserializeObject<Transaction>(result);
                return View("TransactionDone", transaction);
            }
            else
            {
                ViewBag.error = res.Content.ReadAsStringAsync().Result;
                return View("TransactionFailed");
            }

        }

        //View Intrest account
        public async Task<IActionResult> ViewInterest(string accno)
        {
            ViewBag.accno = HttpContext.Session.GetString(SessionName);
            Account account = new Account();
            HttpClient client = api.Initial();
            HttpResponseMessage res = await client.GetAsync("Account/getAccountbyId/" + accno);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                account = JsonConvert.DeserializeObject<Account>(result);
            }
            return View(account);
        }

        //addInterest
        [HttpGet]
        public async Task<IActionResult> AddInterest(string accno)
        {
            ViewBag.accno = HttpContext.Session.GetString(SessionName);
            Transaction transaction = new Transaction();
            HttpClient client = api.Initial();
            HttpResponseMessage res = await client.GetAsync("Transaction/AddInterest/" + accno);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                transaction = JsonConvert.DeserializeObject<Transaction>(result);
            }
            return View("TransactionDone", transaction);
        }

        //withdrawInterest
        [HttpGet]
        public async Task<IActionResult> WithdrawInterest(string accno)
        {
            ViewBag.accno = HttpContext.Session.GetString(SessionName);
            Transaction transaction = new Transaction();
            HttpClient client = api.Initial();
            HttpResponseMessage res = await client.GetAsync("Transaction/WithdrawInterest/" + accno);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                transaction = JsonConvert.DeserializeObject<Transaction>(result);
            }
            return View("TransactionDone", transaction);
        }
    }
}
