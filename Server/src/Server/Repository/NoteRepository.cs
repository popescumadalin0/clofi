using DatabaseLayout.Context;
using Server.Interfaces;

namespace Server.Repository;

public class NoteRepository : INoteRepository
{
    private readonly IClofiContext _context;

    public NoteRepository(IClofiContext context)
    {
        _context = context;
    }
}