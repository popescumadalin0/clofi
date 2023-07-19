using DatabaseLayout.Context;
using Server.Interfaces;

namespace Server.Repository;

public class AssignmentRepository : IAssignmentRepository
{
    private readonly IClofiContext _context;

    public AssignmentRepository(IClofiContext context)
    {
        _context = context;
    }
}