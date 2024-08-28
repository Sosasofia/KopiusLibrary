using KopiusLibrary.Models.Entities;

namespace KopiusLibrary.Repositories
{
    public interface IBookRepository
    {
        //IEnumerable<BookDto> Books();
        Task<IEnumerable<BookDto>> Books();    

        Task<Book> CreateBook(Book book);

        Task<BookDto> GetBook(string title);

        void DeleteBook(Book book);
    }
}
