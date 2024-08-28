using System.ComponentModel.DataAnnotations.Schema;

namespace KopiusLibrary.Models.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; } // Prologue
        public string? Isbn { get; set; }
        public string? Published { get; set; }

        public Branch Branch { get; set; }
        public Publisher Publisher { get; set; }


        public ICollection<AuthorBook> BookAuthors { get; set; } = new List<AuthorBook>();

        [NotMapped]
        public List<string> names { get; set; }

        public IEnumerable<BookGenre> BookGenres { get; set; } = Enumerable.Empty<BookGenre>();
        public IEnumerable<Reservation>? Reservations { get; set; }
    }
}
