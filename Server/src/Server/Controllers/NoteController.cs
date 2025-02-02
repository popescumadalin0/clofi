﻿using Server.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Models;

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
    public async Task<IActionResult> GetNotesAsync()
    {
        _logger.LogInformation("Get all notes");
        var notes = await _noteRepository.GetNotesAsync();
        return ApiServiceResponse.ApiServiceResult(notes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetNoteAsync(int id)
    {
        _logger.LogInformation($"Get note by id: {id}");
        var note = await _noteRepository.GetNoteAsync(id);
        return ApiServiceResponse.ApiServiceResult(note);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNoteAsync([FromBody] Note newNoteDto)
    {
        _logger.LogInformation("Create note");
        var result = await _noteRepository.CreateNoteAsync(newNoteDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateNoteAsync([FromBody] Note updatedNoteDto)
    {
        _logger.LogInformation($"Update note: {updatedNoteDto.Id}");
        var result = await _noteRepository.UpdateNoteAsync(updatedNoteDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNoteAsync(int id)
    {
        _logger.LogInformation($"Delete note: {id}");
        var result = await _noteRepository.DeleteNoteAsync(id);
        return ApiServiceResponse.ApiServiceResult(result);
    }
}