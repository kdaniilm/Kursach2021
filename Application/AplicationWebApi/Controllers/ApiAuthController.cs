using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AplicationWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiAuthController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public IActionResult Login(AdminLoginModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid data");
            }
            else if (model.Login == "admin" && model.Password == "admin")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));

                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tockenOptions = new JwtSecurityToken(issuer: "https://localhost:44318/",
                    audience: "https://localhost:44318/",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: signinCredentials);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tockenOptions);

                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }

        }
    }
}
