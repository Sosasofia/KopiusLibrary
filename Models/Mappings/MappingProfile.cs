using AutoMapper;
using KopiusLibrary.Models.DTO;
using KopiusLibrary.Models.Entities;

namespace KopiusLibrary.Models.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Branch, BranchDto>();
            CreateMap<Publisher, PublisherDto>();
            CreateMap<BookCreationDto, Book>();

            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.BookAuthors))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.BookGenres));

            CreateMap<AuthorBook, AuthorDto>()
                .ForMember(dest => dest.Biography, opt => opt.MapFrom(src => src.Author.Biography))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.Author.BirthDate))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Author.Country));
      
            CreateMap<BookGenre, GenreDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Genre.Name));

            CreateMap<Book, BookCreationDto>()
                .ForMember(dest => dest.Authors, opt => opt.Ignore())
                .ForMember(dest => dest.Genres, opt => opt.Ignore());
        }
    }
}
