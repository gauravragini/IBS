using IBS.BussinessLogicLayer.Interfaces;
using IBS.EntitiesLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBS.WEBAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private IReportsBL reportsbussinessLayer;

        public ReportsController(IReportsBL reportsbussinessLayer)
        {
            this.reportsbussinessLayer = reportsbussinessLayer;
        }

        //web api to get the list of newly registred customers
        [HttpGet]
        public IActionResult GetNewCustomers()
        {
            return Ok(reportsbussinessLayer.GetNewCustomers());

            //try
            //{
            //    return Ok(reportsbussinessLayer.GetNewCustomers());
            //}
            //catch (Exception e)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            //}
        }

        //web api to get the list of all the accounts 
        [HttpGet]
        public IActionResult GetAllAccounts()
        {

            try
            {
                return Ok(reportsbussinessLayer.GetAllAccounts());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }


        //web api to get the list of all the transactions
        [HttpGet]
        public IActionResult GetAllTransactions()
        {

            try
            {
                return Ok(reportsbussinessLayer.GetAllTransactions());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }


        //webapi to get details of an account using accountnumber
        [HttpGet("{accountNumber:regex(\\w)}")]
        public ActionResult<Account> GetAccountbyAccountNumber(string accountNumber)
        {
            try
            {

                Account a = reportsbussinessLayer.GetAccountbyAccountNumber(accountNumber);

                if (a == null)
                {
                    return NotFound();
                }
                return a;
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }


        //webapi to get list of transactions done by a specific account
        [HttpGet("{accountNumber:regex(\\w)}")]
        public IActionResult getTransactionsofAccount(string accountNumber)
        {
            try
            {
                return Ok(reportsbussinessLayer.GetTransactionsofAccount(accountNumber));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }


        //webapi to get list of transactions done by a specific account
        [HttpGet("{userID:regex(\\w)}")]
        public IActionResult GetAccountbyId(string userID)
        {
            try
            {
                return Ok(reportsbussinessLayer.GetAccountbyId(userID));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }

    }
}
