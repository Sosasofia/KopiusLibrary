using System.ComponentModel.DataAnnotations;

namespace KopiusLibrary.Models.DTO
{
    public class BookCreationDto
    {
        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public string? Published { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "ISBN must be exactly 13 characters long.")]
        public string? Isbn { get; set; }

        [Required]
        public Guid BranchId { get; set; }

        [Required] 
        public Guid PublisherId { get; set; }

        [Required(ErrorMessage = "At least one author must be specified.")]
        public IEnumerable<Guid> Authors { get; set; } 

        [Required(ErrorMessage = "At least one genre must be specified.")]
        public IEnumerable<Guid> Genres { get; set; }
    }
}
