using IBS.BussinessLogicLayer.Interfaces;
using IBS.EntitiesLayer.Models;
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
    public class AccountController : ControllerBase
    {
        private IAccountBL ba;
        public AccountController(IAccountBL bl)
        {
            ba = bl;
        }

        [HttpGet]
        public IActionResult getAllAccounts()
        {

            try
            {
                return Ok(ba.GetAllAccounts());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }


        [HttpGet("{accountNumber:regex(\\w)}")]
        public ActionResult<Account> getAccountbyId(string accountNumber)
        {
            try
            {

                Account a = ba.GetAccountbyAccountNumber(accountNumber);

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
    }
}
