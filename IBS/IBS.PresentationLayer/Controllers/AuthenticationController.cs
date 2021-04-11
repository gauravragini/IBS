using IBS.EntitiesLayer.Models;
using Microsoft.AspNetCore.Http;
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
        const string sessionUserid = "userid";
        const string sessionName = "name";

        public IActionResult Index()
        {
            @ViewData["message"] = TempData["message"];
            return View();
        }

        public IActionResult RegisterAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterAdmin(RegisterAdmin model)
        {
            try
            {
                Response content;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:10293/api/Account");

                    //HTTP POST
                    var response = client.PostAsJsonAsync<RegisterAdmin>("Account/RegisterAdmin", model).Result;
                    var result = response.Content.ReadAsStringAsync().Result;
                    content = JsonConvert.DeserializeObject<Response>(result);
                    TempData["message"] = content.Message;
                    return RedirectToAction("Index");
                  
                }
            }
            catch (Exception e)
            {
                ViewData["error"] = e.Message;
                return View("~/Views/Shared/ExceptionError.cshtml");
            }

        }



        public IActionResult RegisterCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterCustomer(RegisterCustomer model)
        {
            try
            {
                Response content;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:10293/api/Account");

                    //HTTP POST
                    var response = client.PostAsJsonAsync<RegisterCustomer>("Account/RegisterCustomer", model).Result;
                    var result = response.Content.ReadAsStringAsync().Result;
                    content = JsonConvert.DeserializeObject<Response>(result);
                    TempData["message"] = content.Message;
                    return RedirectToAction("Index");

                }
            }
            catch (Exception e)
            {
                ViewData["error"] = e.Message;
                return View("~/Views/Shared/ExceptionError.cshtml");
            }

        }


        [HttpPost]
        public IActionResult Login(Login model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:10293/api/Account");

                    //HTTP POST
                    var response = client.PostAsJsonAsync<Login>("Account/Login", model).Result;
                    var result = response.Content.ReadAsStringAsync().Result;
                    var content = JsonConvert.DeserializeObject<Response>(result);

                    if (response.IsSuccessStatusCode)
                    {
                        HttpContext.Session.SetString("JWToken", content.token);
                        if (content.userstatus == "admin")
                        {
                            HttpContext.Session.SetString(sessionUserid, content.userid);
                            HttpContext.Session.SetString(sessionName, content.FirstName + " " + content.LastName);
                            return RedirectToAction("Index", "Admin");

                        }
                        else if(content.userstatus =="applied")
                        {
                            TempData["message"] = "Your Application is User Review !!! Check Again Later";
                            return RedirectToAction("Index", "Authentication");
                        }
                        else if(content.userstatus == "approved")
                        {
                            TempData["message"] = "Your Application has been approved !!!";                            
                            HttpContext.Session.SetString(sessionUserid, content.userid);
                            HttpContext.Session.SetString(sessionName, "Ragini Gaurav");
                            return RedirectToAction("Index", "Customer");
                        }
                        return RedirectToAction("Index", "Authentication");

                    }
                    else
                    {
                        TempData["message"] = content.Message;
                        return RedirectToAction("Index","Authentication");
                    }
                }
            }
            catch(Exception e)
            {
                ViewData["error"] = e.Message;
                return View("~/Views/Shared/ExceptionError.cshtml");
            }

           
        }


        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Authentication/Index");
        }

    }
}