using AutoMapper;
using BookishMadness.DAL.Entities;

namespace BookishMadness.BLL
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Book, BookDTO>()
                .ReverseMap();
        }
    }
}
