using AutoMapper;
using DatabaseLayout.Models;
using Models.Models;

namespace AutoMapperProj
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>();
        }
    }
}
