using Microsoft.EntityFrameworkCore;

namespace KopiusLibrary.Models.Entities
{
    [Keyless]
    public class Auth
    {
        public string? Username { get; set; }

        public string? Password { get; set; }
    }
}
