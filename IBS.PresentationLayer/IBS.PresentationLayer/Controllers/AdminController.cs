using IBS.EntitiesLayer.Models;
using IBS.PresentationLayer.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IBS.PresentationLayer.Controllers
{
  
    public class AdminController : Controller
    {
        const string SessionName = "accno";
        IBSAPI api = new IBSAPI();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ViewNewCustomers()
        {
          
           
        }

    }
}
