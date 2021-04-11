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
    public class InterestController : ControllerBase
    {
        private InterestController interestBusinessLayer ;

        public InterestController(InterestController interestBusinessLayer)
        {
           this.interestBusinessLayer = interestBusinessLayer;
        }


        //service to Calculate interest of all accounts by admin //it calls bussiness layer function
        [HttpGet("{ID:regex(\\w)}")]
        public IActionResult CalculateInterest(string ID)
        {
            try
            {
                return Ok(interestBusinessLayer.CalculateInterest(ID));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Message = e.Message });
            }
        }

        //service to add intrest amount to his available balance by customer //it calls bussiness layer function
        [HttpGet("{accountNumber:regex(\\w)}")]
        public IActionResult AddInterest(string accountNumber)
        {
            try
            {
                return Ok(interestBusinessLayer.AddInterest(accountNumber));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Message = e.Message });
            }
        }

        //service to withdraw intrest amount by customer //it calls bussiness layer function
        [HttpGet("{accountNumber:regex(\\w)}")]
        public IActionResult WithdrawInterest(string accountNumber)
        {
            try
            {
                return Ok(interestBusinessLayer.WithdrawInterest(accountNumber));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Message = e.Message });
            }
        }

    }
}
