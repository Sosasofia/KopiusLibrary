namespace KopiusLibrary.Models.DTO
{
    public class BookDto
    {
        public string Title { get; set; }
        public IEnumerable<AuthorDto> Authors { get; set; }
        public IEnumerable<GenreDto> Genres { get; set; }
    }
}
