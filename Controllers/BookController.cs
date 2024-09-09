using KopiusLibrary.Models.Entities;
using KopiusLibrary.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using KopiusLibrary.Repositories;

namespace KopiusLibrary.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IPublisherRepository _publisherRepository;


        public BookController(
            IBookRepository bookRepository, 
            IAuthorRepository authorRepository, 
            IGenreRepository genreRepository,
            IBranchRepository branchRepository,
            IPublisherRepository publisherRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
            _branchRepository = branchRepository;
            _publisherRepository = publisherRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            var books = await _bookRepository.All();

            if (null == books)
            {
                return NotFound();
            }

            return Ok(books);
        }


        [HttpGet("{title}")]
        public async Task<IActionResult> GetBookByTitle(string title)
        {
            var book = await _bookRepository.ByTitle(title);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }


        [HttpPost]
        public ActionResult CreateBook(BookCreationDto book) 
        {
            // Valida si existen autores, generos, publisher y branch
            var validationResult = Validate(book);

            if (validationResult is BadRequestObjectResult badRequestResult)
            {
                return badRequestResult;
            }

            _bookRepository.Create(book);

            return Ok();
        }


        [HttpPut("{id}")]
        public ActionResult UpdateBook([FromBody] Book book)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public ActionResult DeleteBook(Book book)
        {
            throw new NotImplementedException();
        }


        private ActionResult Validate(BookCreationDto book)
        {
            var validationErrors = new List<string>();

            // Verifico si ya existe libro por Isbn
            bool alreadyExists = _bookRepository.ByIsbn(book.Isbn);

            if (alreadyExists)
            {
                validationErrors.Add($"Book with ISBN {book.Isbn} already exists.");
            }

            if (book.Authors == null || !book.Authors.Any())
            {
                validationErrors.Add("No authors specified.");
            }
            else if (!_authorRepository.AllExist(book.Authors))
            {
                validationErrors.Add("One or more author IDs are invalid.");
            }

            if (book.Genres == null || !book.Genres.Any())
            {
                validationErrors.Add("No genre specified.");
            }
            else if (!_genreRepository.AllExist(book.Genres))
            {
                validationErrors.Add("One or more genre IDs are invalid.");
            }

            if (book.BranchId == null || !_branchRepository.Exists(book.BranchId))
            {
                validationErrors.Add("The specified branch does not exist.");
            }

            if (book.PublisherId == null || !_publisherRepository.Exists(book.PublisherId))
            {
                validationErrors.Add("The specified publisher does not exist.");
            }

            if (validationErrors.Any())
            {
                return BadRequest(new { Errors = validationErrors });
            }

            return Ok();
        }
    }
}
