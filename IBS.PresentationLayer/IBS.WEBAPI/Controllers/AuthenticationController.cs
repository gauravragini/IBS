using IBS.EntitiesLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IBS.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;  
        private readonly IConfiguration _configuration;

        private ApplicationDbContext db;

        public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, ApplicationDbContext d)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            this.db = d;
        }


        [HttpPost]
        [Route("RegisterCustomer")]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomer model)
        {
            var userExist = await userManager.FindByNameAsync(model.UserName);
            if (userExist != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Already exist" });

            ApplicationUser user = new ApplicationUser()
            {
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Dob = model.Dob,
                Gender = model.Gender,
                FathersName = model.FathersName,
                MothersName = model.MothersName,
                Address = model.Address,
                Pincode = model.Pincode,
                Status = "applied",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var password = "IBS" + model.FirstName.Substring(3).ToLower() + "@X09";
            var result = await userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Creation Failed" });
            }
            else
            {
                var usercreated = await userManager.FindByNameAsync(model.UserName);
                string accountno = "IBS000" + usercreated.UserName.Substring(0, 7).ToUpper();
                Account account = new Account();
                account.AccountNumber = accountno;
                account.AccountType = model.AccountType;
                account.InterestAmount = 0;
                account.AvailableBalance = 0;
                account.AccountCreationTime = DateTime.Now;
                account.Id = usercreated.Id;
                db.Accounts.Add(account);
                db.SaveChanges();
                return Ok(new Response { Status = "Success", Message = accountno, userid = usercreated.UniqueNo.ToString() });

            }

        }



        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterAdmin model)
        {
            var userExist = await userManager.FindByNameAsync(model.UserName);
            if (userExist != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = " User Already Exist" });

            ApplicationUser user = new ApplicationUser
            {
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Dob = model.Dob,
                Gender = model.Gender,
                FathersName = model.FathersName,
                MothersName = model.MothersName,
                Address = model.Address,
                Pincode = model.Pincode,
                Status = model.Status,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = $"{result.Errors.ToList()[0].Code}", Message = $"{result.Errors.ToList()[0].Description}" });

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRolesAsync(user, new List<string>() { UserRoles.Admin });
            }

            return Ok(new Response { Status = "Success", Message = "User Created Successfully" });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                //var userRoles = await userManager.GetRolesAsync(user);
                //var authClaims = new List<Claim>
                //{
                //    new Claim(ClaimTypes.Name,user.UserName),
                //    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                //};
                //foreach (var userRole in userRoles)
                //{
                //    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                //}
                //var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));
                //var token = new JwtSecurityToken(
                //    issuer: _configuration["JWT:ValidIssuer"],
                //    audience: _configuration["JWT:ValidAudience"],
                //    expires: DateTime.Now.AddHours(5),
                //    claims: authClaims,
                //    signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
                //    );
                return Ok(new Response
                {
                    Status = "success",
                   // token = new JwtSecurityTokenHandler().WriteToken(token),
                   // ValidTo = token.ValidTo.ToString("yyyy-MM-ddThh:mm:ss"),
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    userid = user.Id,
                    userstatus = user.Status
                });
            }
            return Unauthorized();
        }
    }
}
