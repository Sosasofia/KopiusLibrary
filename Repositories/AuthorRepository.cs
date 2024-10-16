using KopiusLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace KopiusLibrary.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _context;

        public AuthorRepository(LibraryContext context)
        {
            _context = context;
        }

        public bool Exists(Guid id)
        {
            return _context.Authors.Any(a => a.Id == id);
        }

        public bool AllExist(IEnumerable<Guid> authorIds)
        {
            return _context.Authors
                           .Where(a => authorIds.Contains(a.Id))
                           .Count() == authorIds.Count();
        }
    }
}
