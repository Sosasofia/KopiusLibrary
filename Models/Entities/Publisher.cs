using System.Text.Json.Serialization;

namespace KopiusLibrary.Models.Entities
{
    public class Publisher
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

    
        public IEnumerable<Book>? Books { get; set; } = new List<Book>();
    }
}
