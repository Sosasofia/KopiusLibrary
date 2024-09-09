using KopiusLibrary.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KopiusLibrary.Repositories
{
    public interface IGenreRepository
    {
        bool Exists(Guid id);
        bool AllExist(IEnumerable<Guid> ids);
    }
}
