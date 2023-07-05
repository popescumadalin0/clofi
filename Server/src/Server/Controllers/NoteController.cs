using DatabaseLayout.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Server.Interfaces;
using Server.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Server.Controllers;

public class NoteController : BaseController
{
    private readonly INoteRepository _noteRepository;

    public NoteController(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Note>))]
    public async Task<IActionResult> GetNotes()
    {
        var notes = await _noteRepository.GetNotes();
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(notes);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(Note))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetAssignment(int id)
    {
        var note = await _noteRepository.GetNote(id);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(note);
    }
}