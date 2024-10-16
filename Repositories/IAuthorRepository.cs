namespace KopiusLibrary.Repositories
{
    public interface IAuthorRepository
    {
        bool Exists(Guid id);
        bool AllExist(IEnumerable<Guid> ids);
    }
}
