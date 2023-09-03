using Server.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using System.Threading.Tasks;
using Services;

namespace Server.Controllers;

public class NoteController : BaseController
{
    private readonly INoteRepository _noteRepository;

    public NoteController(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    [HttpGet]
    [JwtAuth]
    public async Task<IActionResult> GetNotesAsync()
    {
        var notes = await _noteRepository.GetNotesAsync();
        return ApiServiceResponse.ApiServiceResult(notes);
    }

    [HttpGet("{id}")]
    [JwtAuth]
    public async Task<IActionResult> GetNoteAsync(int id)
    {
        var note = await _noteRepository.GetNoteAsync(id);
        return ApiServiceResponse.ApiServiceResult(note);
    }

    [HttpPost]
    [JwtAuth]
    public async Task<IActionResult> CreateNoteAsync([FromBody] global::Models.Note newNoteDto)
    {
        var result = await _noteRepository.CreateNoteAsync(newNoteDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpPut]
    [JwtAuth]
    public async Task<IActionResult> UpdateNoteAsync([FromBody] global::Models.Note updatedNoteDto)
    {
        var result = await _noteRepository.UpdateNoteAsync(updatedNoteDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpDelete("{id}")]
    [JwtAuth]
    public async Task<IActionResult> DeleteNoteAsync(int id)
    {
        var result = await _noteRepository.DeleteNoteAsync(id);
        return ApiServiceResponse.ApiServiceResult(result);
    }
}