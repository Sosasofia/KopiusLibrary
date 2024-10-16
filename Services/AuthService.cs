using KopiusLibrary.Services.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KopiusLibrary.Services
{
    public class AuthService : IAuthService
    {
        private List<Auth> users = new List<Auth>()
        {
            new Auth{ Username = "admin", Password = "admin", Role = "admin" }
        };

        private readonly IConfiguration _config;

        public AuthService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public string Login(Auth userCredentials)
        {
            var loginUser = users.SingleOrDefault(x => x.Username == userCredentials.Username && x.Password == userCredentials.Password);

            if (loginUser == null)
            {
                return string.Empty;
            }

            var userToken = GenerateToken(userCredentials);

            return userToken;
        }

        private string GenerateToken(Auth auth)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var tokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, "admin"),
                    new Claim(ClaimTypes.Name, auth.Username),
                }),
                Expires = DateTime.UtcNow.Add(TimeSpan.FromMinutes(30)),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature),
                Issuer = _config["Jwt:Issuer"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string userToken = tokenHandler.WriteToken(token);

            return userToken;
        }
    }
}
