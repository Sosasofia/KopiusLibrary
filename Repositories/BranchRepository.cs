using KopiusLibrary.Models;

namespace KopiusLibrary.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        public readonly LibraryContext _context;

        public BranchRepository(LibraryContext context)
        {

            _context = context; 
        }

        public bool Exists(Guid id)
        {
            return _context.Branchs.Any(a => a.Id == id);
        }
    }
}
