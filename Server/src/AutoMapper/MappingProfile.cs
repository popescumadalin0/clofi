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
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Note, NoteDTO>();
            CreateMap<NoteDTO, Note>();
        }
    }
}
