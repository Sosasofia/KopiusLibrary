using AutoMapper;
using KopiusLibrary.Models.DTO;
using KopiusLibrary.Models.Entities;

namespace KopiusLibrary.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Genre, GenreDto>()
                 .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.BookAuthors))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.BookGenres));

            CreateMap<AuthorBook, AuthorDto>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.Author.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Author.Name));

            CreateMap<BookGenre, GenreDto>()
                .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.Genre.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Genre.Name));
        }
    }
}
