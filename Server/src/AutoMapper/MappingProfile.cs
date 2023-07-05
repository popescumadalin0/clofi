using AutoMapper;
using DatabaseLayout.Models;
using Models;
using Models.DTOs;

namespace AutoMapperProj
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDTO>();
        }
    }
}
