using AutoMapper;
using NexusLibrary.Core.DTOs;
using NexusLibrary.Core.Entities;

namespace NexusLibrary.Infraestructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Editorial, EditorialDto>().ReverseMap();
        }
    }
}
