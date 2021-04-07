using IBS.EntitiesLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IBS.PresentationLayer.Controllers
{
    public class AuthenticationController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterCustomer(RegisterCustomer model)
        {
            Response cont;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:10293/api/Authentication");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<RegisterCustomer>("Authentication/RegisterCustomer", model);
                postTask.Wait();

                var result = postTask.Result;

                var res = result.Content.ReadAsStringAsync().Result;
                cont = JsonConvert.DeserializeObject<Response>(res);
                return Content(res);


            }

            // return Content("Ok");

        }

        public IActionResult RegisterAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterAdmin(RegisterAdmin model)
        {
            Response cont;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:10293/api/Authentication");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<RegisterAdmin>("Authentication/RegisterAdmin", model);
                postTask.Wait();

                var result = postTask.Result;

                var res = result.Content.ReadAsStringAsync().Result;
                cont = JsonConvert.DeserializeObject<Response>(res);
                return Content(cont.Message);


            }

           // return Content("Ok");

        }


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login model)
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:10293/api/Authentication");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Login>("Authentication/Login", model);
                postTask.Wait();

                var result = postTask.Result;

                var res = result.Content.ReadAsStringAsync().Result;
                var cont = JsonConvert.DeserializeObject<Response>(res);


                if (result.IsSuccessStatusCode)
                {
                    if(cont.userstatus=="admin")
                        return RedirectToAction("Index","Admin");
                    else
                        return RedirectToAction("Index", "Customer");

                }

                return Content(cont.Message+cont.token);

            }

        }




    }
}
