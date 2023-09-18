using AutoMapper;
using DatabaseLayout.Context;
using Microsoft.EntityFrameworkCore;
using Server.Interfaces;
using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Models;
using Microsoft.Extensions.Logging;

namespace Server.Repository;

public class NoteRepository : INoteRepository
{
    private readonly IClofiContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<NoteRepository> _logger;

    public NoteRepository(IClofiContext context, IMapper mapper, ILogger<NoteRepository> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ServiceResponse<List<Note>>> GetNotesAsync()
    {
        try
        {
            var notes = await _context.Notes.ToListAsync();
            var result = _mapper.Map<List<Note>>(notes);
            return new ServiceResponse<List<Note>>(result);
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message);
            return new ServiceResponse<List<Note>>(ex);
        }
    }

    public async Task<ServiceResponse<Note>> GetNoteAsync(int id)
    {
        try
        {
            var note = await _context.Notes.FindAsync(id);
            var result = _mapper.Map<Note>(note);
            return new ServiceResponse<Note>(result);
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message);
            return new ServiceResponse<Note>(ex);
        }
    }

    public async Task<ServiceResponse> CreateNoteAsync(Note noteDto)
    {
        try
        {
            var note = _mapper.Map<DatabaseLayout.Models.Note>(noteDto);
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return new ServiceResponse();
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message);
            return new ServiceResponse(ex);
        }
    }

    public async Task<ServiceResponse> UpdateNoteAsync(Note noteDto)
    {
        try
        {
            var note = await _context.Notes.FindAsync(noteDto.Id);
            _mapper.Map(noteDto, note);
            await _context.SaveChangesAsync();
            return new ServiceResponse();
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message);
            return new ServiceResponse(ex);
        }
    }

    public async Task<ServiceResponse> DeleteNoteAsync(int id)
    {
        try
        {
            var note = await _context.Notes.FindAsync(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
                return new ServiceResponse();
            }
            return new ServiceResponse(errorMessage: "Note does not found!");
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message);
            return new ServiceResponse(ex);
        }

    }
}