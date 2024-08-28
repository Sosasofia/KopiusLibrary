using KopiusLibrary.Models.Entities;
using KopiusLibrary.Models.DTO;
using KopiusLibrary.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


namespace KopiusLibrary.Repositories
{

    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;

        public BookRepository(LibraryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<BookDto>> Books()
        {
            var books = await _context.Books
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .Include(b => b.BookGenres)
                    .ThenInclude(bg => bg.Genre)
                .ToListAsync();

            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto> GetBook(string title)
        {
            var book = await _context.Books
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .Include(b => b.BookGenres)
                    .ThenInclude(bg => bg.Genre)
                .FirstOrDefaultAsync(b => b.Title.Contains(title));

            return _mapper.Map<BookDto>(book);
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
