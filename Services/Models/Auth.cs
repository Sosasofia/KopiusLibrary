using System.ComponentModel.DataAnnotations;

namespace KopiusLibrary.Services.Models
{
    public class Auth
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }

        public string? Role { get; set; }
    }
}
