using Server.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Repository;
using System.Threading.Tasks;

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

    [HttpGet]
    public async Task<IActionResult> GetNotes()
    {
        var notes = await _noteRepository.GetNotes();
        return ApiServiceResponse.ApiServiceResult(notes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetNote(int id)
    {
        var note = await _noteRepository.GetNote(id);
        return ApiServiceResponse.ApiServiceResult(note);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNote([FromBody] global::Models.DTOs.Note newNoteDto)
    {
        var result = await _noteRepository.CreateNote(newNoteDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateNote([FromBody] global::Models.DTOs.Note updatedNoteDto)
    {
        var result = await _noteRepository.UpdateNote(updatedNoteDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNote(int id)
    {
        var result = await _noteRepository.DeleteNote(id);
        return ApiServiceResponse.ApiServiceResult(result);
    }
}