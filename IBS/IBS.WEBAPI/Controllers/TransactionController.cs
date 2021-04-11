using IBS.BussinessLogicLayer.Interfaces;
using IBS.EntitiesLayer.Models;
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
        private ITransactionBL transactionbussinessLayer;

        public TransactionController(ITransactionBL transactionbussinessLayer)
        {
            this.transactionbussinessLayer = transactionbussinessLayer; //the http get methods of this controller calls Bussiness layers functions
        }


        ///Action method to call deposit function of bussiness layer ... if first deposit is done then the amount should be >1000.
        [HttpGet("{accountNumber:regex(\\w)}/{amount:decimal}")]
        public IActionResult DepositMoney(string accountNumber, decimal amount)
        {
            try
            {
                return Ok(transactionbussinessLayer.DepositMoney(accountNumber, amount));
            }
            catch (FirstDepositException e)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, new Response { Message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Message = e.Message });
            }
        }


        //Action method to call withdraw function of bussiness layer
        [HttpGet("{accountNumber:regex(\\w)}/{amount:decimal}")]
        public IActionResult WithdrawMoney(string accountNumber, decimal amount)
        {
            try
            {
                return Ok(transactionbussinessLayer.WithdrawMoney(accountNumber, amount));
            }
            catch (InsufficientBalanceException e)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, new Response { Message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Message = e.Message });
            }
        }


        //Action method to call transfermoney function of bussiness layer
        [HttpGet("{accountNumber:regex(\\w)}/{toAccountNumber:regex(\\w)}/{amount:decimal}")]
        public IActionResult TransferMoney(string accountNumber, string toAccountNumber, decimal amount)
        {
            try
            {
                return Ok(transactionbussinessLayer.TransferMoney(accountNumber, toAccountNumber, amount));
            }
            catch (InsufficientBalanceException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Message=e.Message });
            }
            catch (AccountDoesNotExistException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Message = e.Message });
            }
        }


    

    }
}
