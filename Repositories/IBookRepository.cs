using KopiusLibrary.Models.Entities;
using KopiusLibrary.Models.DTO;


namespace KopiusLibrary.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookDto>> All();

        Task<BookDto> ByTitle(string title);

        void Create(BookCreationDto dto); 

        void Update(Book product);

        void Delete(Book book);

        bool ByIsbn(string isbn);
    }
}
