using KopiusLibrary.Models.Entities;
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

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> Books()
        {
            var books =  await _bookRepository.Books();

            if(null == books)
            {
                return NotFound();
            }

            return Ok(books);
        }


        [HttpGet("{title}")]
        public async Task<IActionResult> GetBookByTitle(string title)
        {
            var book = await _bookRepository.GetBook(title);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            if (book == null)
                return BadRequest();

            var newBook = new Book() { };


            var createdBook = await _bookRepository.CreateBook(newBook);

            return CreatedAtAction(nameof(GetBookByTitle),
                   new { id = createdBook.Id }, createdBook);
        }
        

        [HttpDelete]
        public ActionResult Delete(Book book)
        {
            _bookRepository.DeleteBook(book);
            return NoContent();
        }
    }
}
