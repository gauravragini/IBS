using IBS.BussinessLogicLayer.Interfaces;
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

        [HttpGet("{ID:regex(\\w)}")]
        public IActionResult CalculateInterest(string ID)
        {
            try
            {
                return Ok(interestBusinessLayer.CalculateInterest(ID));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }
    }
}
