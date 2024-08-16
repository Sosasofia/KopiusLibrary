using Microsoft.AspNetCore.Mvc;

namespace KopiusLibrary.Controllers
{
    public class BookController : ControllerBase
    {
        private readonly IConfiguration _config;

        public BookController(IConfiguration configuration)
        {
            _config = configuration;
        }
    }
}
