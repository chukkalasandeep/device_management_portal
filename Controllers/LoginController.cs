using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;

namespace DeviceManagementPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly string _secret;
        private readonly string _expDate;
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Suman", LastName = "Maity", Username = "suman", Password = "123" }
        };

        public LoginController(IConfiguration config)
        {
            _secret = config.GetSection("JwtConfig").GetSection("secret").Value;
            _expDate = config.GetSection("JwtConfig").GetSection("expirationInMinutes").Value;
        }
        [HttpPost]
        public IActionResult Post([FromBody] Login model)
        {
            try
            {
                var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });
                else
                {
                    var token ="bearer "+ GenerateSecurityToken(model.Username);
                    return Ok(token);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [NonAction]
        public string GenerateSecurityToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email)
                })
            ,
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
        public class Login
        {
            public string Username { get; set; }           
            public string Password { get; set; }
        }
        public class User
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Username { get; set; }

            [JsonIgnore]
            public string Password { get; set; }
        }
    }
}