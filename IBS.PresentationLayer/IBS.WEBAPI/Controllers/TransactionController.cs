using IBS.BussinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IBS.Exceptions.Exceptions;

namespace IBS.WEBAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private ITransactionBL bmt;

        public TransactionController(ITransactionBL t)
        {
            bmt = t;
        }


        [HttpGet("{accno:regex(\\w)}")]
        public IActionResult getTransactionsofAccount(string accno)
        {
            try
            {
                return Ok(bmt.GetTransactionsofAccount(accno));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }



        [HttpGet("{accountNumber:regex(\\w)}/{amount:decimal}")]
        public IActionResult DepositMoney(string accountNumber, decimal amount)
        {
            try
            {
                return Ok(bmt.DepositMoney(accountNumber, amount));
            }
            catch (FirstDepositException e)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }



        [HttpGet("{accno:regex(\\w)}/{amount:decimal}")]
        public IActionResult WithdrawMoney(string accno, decimal amount)
        {
            try
            {
                return Ok(bmt.WithdrawMoney(accno, amount));
            }
            catch (InsufficientBalanceException e)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }

        [HttpGet("{accno:regex(\\w)}/{toaccno:regex(\\w)}/{amount:decimal}")]
        public IActionResult TransferMoney(string accno, string toaccno, decimal amount)
        {
            try
            {
                return Ok(bmt.TransferMoney(accno, toaccno, amount));
            }
            catch (InsufficientBalanceException e)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, e.Message);
            }
            catch (AccountDoesNotExistException e)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }


        [HttpGet("{accno:regex(\\w)}")]
        public IActionResult AddInterest(string accno)
        {
            try
            {
                return Ok(bmt.AddInterest(accno));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }

        [HttpGet("{accno:regex(\\w)}")]
        public IActionResult WithdrawInterest(string accno)
        {
            try
            {
                return Ok(bmt.WithdrawInterest(accno));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }

    }
}
