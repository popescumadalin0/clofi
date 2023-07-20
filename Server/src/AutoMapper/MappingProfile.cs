using AutoMapper;
using DatabaseLayout.Models;
using Models.DTOs;

namespace AutoMapperProj;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Models.DTOs.User, DatabaseLayout.Models.User>();
        CreateMap<DatabaseLayout.Models.User, Models.DTOs.User>();

        CreateMap<Models.DTOs.Alarm, DatabaseLayout.Models.Alarm>();
        CreateMap<DatabaseLayout.Models.Alarm, Models.DTOs.Alarm>();

        CreateMap<Models.DTOs.Assignment, DatabaseLayout.Models.Assignment>();
        CreateMap<DatabaseLayout.Models.Assignment, Models.DTOs.Assignment>();

        CreateMap<Models.DTOs.Note, DatabaseLayout.Models.Note>();
        CreateMap<DatabaseLayout.Models.Note, Models.DTOs.Note>();

        CreateMap<Models.DTOs.UserConfig, DatabaseLayout.Models.UserConfig>();
        CreateMap<DatabaseLayout.Models.UserConfig, Models.DTOs.UserConfig>();
    }
}