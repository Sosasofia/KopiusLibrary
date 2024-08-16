using Microsoft.AspNetCore.Mvc;
using KopiusLibrary.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;


namespace KopiusLibrary.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(Auth auth)
        {
            if (auth.Username == "admin" && auth.Password == "admin")
            {
                var token = GenerateToken();

                return Ok(token);
            }

            return BadRequest();
        }

        private string GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtInfo = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(4)),
                signingCredentials: credentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtInfo);

            return token;
        }

        //[Authorize]
        //public ActionResult Logout()
        //{
        //}

        //[HttpPost]
        //[Route("login")]
        //public ActionResult Login(string username, string password)
        //{
        //}
    }
}
