using KopiusLibrary.Models.Entities;
using KopiusLibrary.Models.DTO;
using KopiusLibrary.Models;
using Microsoft.EntityFrameworkCore;


namespace KopiusLibrary.Repositories
{

    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookDto>> Books()
        {
            var books = await _context.Books
                .Select(b => new BookDto
                {
                    Title = b.Title,
                    Authors = b.BookAuthors
                        .Select(ba => new AuthorDto
                        {
                            AuthorId = ba.Author.Id,
                            Name = ba.Author.Name
                        })
                        .ToList(),
                    Genres = b.BookGenres
                        .Select(g => new GenreDto
                        {
                            GenreId = g.GenreId,
                            Name = g.Genre.Name
                        })
                })
                .ToListAsync();

            return books;
        }

        public async Task<BookDto> GetBook(string title)
        {
            var book = await _context.Books
                .Select(b => new BookDto
                {
                    Title = b.Title,
                    Authors = b.BookAuthors
                        .Select(ba => new AuthorDto
                        {
                            AuthorId = ba.Author.Id,
                            Name = ba.Author.Name
                        })
                        .ToList(),
                    Genres = b.BookGenres
                        .Select(g => new GenreDto
                        {
                            GenreId = g.GenreId,
                            Name = g.Genre.Name
                        })
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
