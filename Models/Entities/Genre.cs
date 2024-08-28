using System.Text.Json.Serialization;

namespace KopiusLibrary.Models.Entities
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<BookGenre> BookGenres { get; set; } = Enumerable.Empty<BookGenre>();
    }
}
