using KopiusLibrary.Models;

namespace KopiusLibrary.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        public readonly LibraryContext _context;

        public PublisherRepository(LibraryContext context)
        {

            _context = context;
        }

        public bool Exists(Guid id)
        {
            return _context.Publishers.Any(a => a.Id == id);
        }
    }
}
