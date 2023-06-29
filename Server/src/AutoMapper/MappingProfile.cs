using AutoMapper;
using DatabaseLayout.Models;
using Models.DTOs;

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
