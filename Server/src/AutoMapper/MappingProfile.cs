using AutoMapper;
using DatabaseLayout.Models;
using Models.DTOs;

namespace AutoMapperProj
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.DTOs.User, DatabaseLayout.Models.User>();
            CreateMap<DatabaseLayout.Models.User, Models.DTOs.User>();
            CreateMap<Note, NoteDTO>();
            CreateMap<NoteDTO, Note>();
        }
    }
}
