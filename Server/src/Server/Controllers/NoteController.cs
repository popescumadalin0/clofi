using DatabaseLayout.Models;
using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Models.DTOs;

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