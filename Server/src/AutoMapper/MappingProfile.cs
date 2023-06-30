using AutoMapper;
using DatabaseLayout.DTOs;
using Models.Models;

namespace AutoMapperProj
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
        }
    }
}
