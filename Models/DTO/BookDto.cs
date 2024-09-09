namespace KopiusLibrary.Models.DTO
{
    public class BookDto
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Published { get; set; }

        public string? Isbn { get; set; }


        public BranchDto? Branch { get; set; }
        public PublisherDto? Publisher { get; set; }


        public IEnumerable<AuthorDto> Authors { get; set; }
        public IEnumerable<GenreDto> Genres { get; set; }
    }
}
