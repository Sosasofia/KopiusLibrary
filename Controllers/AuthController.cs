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
    }
}
