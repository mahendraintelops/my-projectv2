using AutoMapper;

using Application.Commands.MyResourceService;

using Application.Responses;
using Core.Entities;

namespace Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          
            CreateMap<MyResource, MyResourceResponse>().ReverseMap();
            CreateMap<MyResource, CreateMyResourceCommand>().ReverseMap();
            CreateMap<MyResource, UpdateMyResourceCommand>().ReverseMap();
          
        }
    }
}
