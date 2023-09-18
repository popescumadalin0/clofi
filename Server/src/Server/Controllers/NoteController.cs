using Server.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using System.Threading.Tasks;
<<<<<<< HEAD
using Services;
=======
using Microsoft.Extensions.Logging;
using Models;
>>>>>>> main

namespace Server.Controllers;

public class NoteController : BaseController
{
    private readonly INoteRepository _noteRepository;
    private readonly ILogger<NoteController> _logger;

    public NoteController(INoteRepository noteRepository, ILogger<NoteController> logger)
    {
        _noteRepository = noteRepository;
        _logger = logger;
    }

    [HttpGet]
    [JwtAuth]
    public async Task<IActionResult> GetNotesAsync()
    {
        _logger.LogInformation("Get all notes");
        var notes = await _noteRepository.GetNotesAsync();
        return ApiServiceResponse.ApiServiceResult(notes);
    }

    [HttpGet("{id}")]
    [JwtAuth]
    public async Task<IActionResult> GetNoteAsync(int id)
    {
        _logger.LogInformation($"Get note by id: {id}");
        var note = await _noteRepository.GetNoteAsync(id);
        return ApiServiceResponse.ApiServiceResult(note);
    }

    [HttpPost]
<<<<<<< HEAD
    [JwtAuth]
    public async Task<IActionResult> CreateNoteAsync([FromBody] global::Models.Note newNoteDto)
=======
    public async Task<IActionResult> CreateNoteAsync([FromBody] Note newNoteDto)
>>>>>>> main
    {
        _logger.LogInformation("Create note");
        var result = await _noteRepository.CreateNoteAsync(newNoteDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpPut]
<<<<<<< HEAD
    [JwtAuth]
    public async Task<IActionResult> UpdateNoteAsync([FromBody] global::Models.Note updatedNoteDto)
=======
    public async Task<IActionResult> UpdateNoteAsync([FromBody] Note updatedNoteDto)
>>>>>>> main
    {
        _logger.LogInformation($"Update note: {updatedNoteDto.Id}");
        var result = await _noteRepository.UpdateNoteAsync(updatedNoteDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpDelete("{id}")]
    [JwtAuth]
    public async Task<IActionResult> DeleteNoteAsync(int id)
    {
        _logger.LogInformation($"Delete note: {id}");
        var result = await _noteRepository.DeleteNoteAsync(id);
        return ApiServiceResponse.ApiServiceResult(result);
    }
}