using KopiusLibrary.Models.Entities;
using KopiusLibrary.Models;
using Microsoft.EntityFrameworkCore;


namespace KopiusLibrary.Repositories
{
    public class BookDto
    {
        public string Title { get; set; }
        public List<string> AuthorNames { get; set; }
        public List<string> Genres { get; set; }
    }

    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookDto>> Books()
        {
            var bookDto = await _context.Books
                .Select(b => new BookDto
                {
                    Title = b.Title,
                    AuthorNames = b.BookAuthors.Select(ba => ba.Author.Name).ToList(),
                    Genres = b.BookGenres.Select(x => x.Genre.Name).ToList()
                })
                .ToListAsync();

            return bookDto;
        }

        public async Task<BookDto> GetBook(string title)
        {
            var book = await _context.Books
                .Select(b => new BookDto
                {
                    Title = b.Title,
                    AuthorNames = b.BookAuthors.Select(ba => ba.Author.Name).ToList(),
                    Genres = b.BookGenres.Select(bg => bg.Genre.Name).ToList()
                })
                .FirstOrDefaultAsync(b => b.Title.Contains(title));
       

            return book;
        }

        public async Task<Book> CreateBook(Book book)
        {
            throw new NotImplementedException();
        }


        public void DeleteBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
