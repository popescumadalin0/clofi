using AutoMapper;
using Alarm = Models.Alarm;
using Assignment = Models.Assignment;
using Note = Models.Note;
using User = Models.User;
using UserConfig = Models.UserConfig;

namespace AutoMapperProj;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, DatabaseLayout.Models.User>();
        CreateMap<DatabaseLayout.Models.User, User>();

        CreateMap<Alarm, DatabaseLayout.Models.Alarm>();
        CreateMap<DatabaseLayout.Models.Alarm, Alarm>();

        CreateMap<Assignment, DatabaseLayout.Models.Assignment>();
        CreateMap<DatabaseLayout.Models.Assignment, Assignment>();

        CreateMap<Note, DatabaseLayout.Models.Note>();
        CreateMap<DatabaseLayout.Models.Note, Note>();

        CreateMap<UserConfig, DatabaseLayout.Models.UserConfig>();
        CreateMap<DatabaseLayout.Models.UserConfig, UserConfig>();
    }
}