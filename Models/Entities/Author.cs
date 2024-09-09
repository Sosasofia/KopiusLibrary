namespace KopiusLibrary.Models.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }

        public string? Biography { get; set; }
        public string? Country { get; set; }

       
        public IEnumerable<AuthorBook> BookAuthors { get; set; } 
    }
}
