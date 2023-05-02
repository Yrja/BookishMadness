using AutoMapper;
using BookishMadness.BLL.DTOs;
using BookishMadness.DAL.Entities;

namespace BookishMadness.BLL
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Book, BookDTO>()
                .ReverseMap();
            CreateMap<Author, AuthorDTO>()
                .ReverseMap();
            CreateMap<Genre, GenreDTO>()
                .ReverseMap();
        }
    }
}
