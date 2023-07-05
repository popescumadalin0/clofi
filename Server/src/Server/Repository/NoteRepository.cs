using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayout.Context;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using Server.Interfaces;

namespace Server.Repository;

public class NoteRepository : INoteRepository
{
    private readonly ClofiContext _context;

    public NoteRepository(ClofiContext context)
    {
        _context = context;
    }
    public async Task<ICollection<Note>> GetNotes()
    {
        return await _context.Notes.OrderBy(n => n.Id).ToListAsync();
    }

    public async Task<Note> GetNote(int id)
    {
        return await _context.Notes.Where(n => n.Id == id).FirstOrDefaultAsync();
    }
}