using Server.Interfaces;
using AutoMapper;

namespace Server.Controllers;

public class NoteController : BaseController
{
    private readonly INoteRepository _noteRepository;
    private readonly IMapper _mapper;

    public NoteController(INoteRepository noteRepository, IMapper mapper)
    {
        _noteRepository = noteRepository;
        _mapper = mapper;
    }
}