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
        private readonly IAuthorRepository _authorRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public BookRepository(
            LibraryContext context, 
            IMapper mapper, 
            IGenreRepository genreRepository,
            IAuthorRepository authorRepository) 
        {
            _context = context;
            _mapper = mapper;
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
        }
        

        public async Task<IEnumerable<BookDto>> All()
        {
            var books = await _context.Books
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .Include(b => b.BookGenres)
                    .ThenInclude(bg => bg.Genre)
                .Include(b => b.Branch)
                .Include(b => b.Publisher)
                .ToListAsync();

            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto> ByTitle(string title)
        {
            var book = await _context.Books
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .Include(b => b.BookGenres)
                    .ThenInclude(bg => bg.Genre)
                .Include(b => b.Branch)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(b => b.Title.Contains(title));

            return _mapper.Map<BookDto>(book);
        }

        public void Create(BookCreationDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);

       
            var authorBooks = bookDto.Authors.Select(authorId => new AuthorBook
            {
                AuthorId = authorId
            }).ToList();

            var genreBooks = bookDto.Genres.Select(genreId => new BookGenre
            {
                GenreId = genreId
            }).ToList();

            book.BookGenres = genreBooks;
            book.BookAuthors = authorBooks;


            // Esto no va aca
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Delete(Book book)
        {
            throw new NotImplementedException();
        }

        public void Update(Book book)
        {
            throw new NotImplementedException();
        }

        public bool ByIsbn(string isbn)
        {
            return  _context.Books.Any(b => b.Isbn == isbn);
        }
    }
}
