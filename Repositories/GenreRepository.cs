using KopiusLibrary.Models.Entities;
using KopiusLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace KopiusLibrary.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly LibraryContext _context;

        public GenreRepository(LibraryContext context)
        {
            _context = context;
        }

        public bool Exists(Guid id)
        {
            return _context.Authors.Any(a => a.Id == id);
        }

        public bool AllExist(IEnumerable<Guid> genreIds)
        {
            return _context.Genres.Where(a => genreIds.Contains(a.Id)).Count() == genreIds.Count();
        }
    }
}
