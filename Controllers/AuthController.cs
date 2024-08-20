using Microsoft.AspNetCore.Mvc;
using KopiusLibrary.Services.Models;
using Microsoft.AspNetCore.Authorization;
using KopiusLibrary.Services;
using System.Security.Claims;


namespace KopiusLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _config;

        public AuthController(IAuthService configuration)
        {
            _config = configuration;
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Get()
        {
            string name = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Name).Value;
            return Ok($"Hello {name}");
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Post(Auth auth)
        {
            var token = _config.Login(auth);

            if (token == null || token == string.Empty)
            {
                return BadRequest(new { message = "UserName or Password is incorrect" });
            }

            return Ok(token);
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
