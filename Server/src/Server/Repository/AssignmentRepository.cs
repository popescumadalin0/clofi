using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayout.Context;
using DatabaseLayout.Models;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.EntityFrameworkCore;
using Server.Interfaces;

namespace Server.Repository;

public class AssignmentRepository : IAssignmentRepository
{
    private readonly ClofiContext _context;

    public AssignmentRepository(ClofiContext context)
    {
        _context = context;
    }
    public async Task<ICollection<Assignment>> GetAssignments()
    {
        return await _context.Assignments.OrderBy(a => a.Id).ToListAsync();
    }

    public async Task<Assignment> GetAssignment(int id)
    {
        return await _context.Assignments.Where(a => a.Id == id).FirstOrDefaultAsync();
    }

    public async Task<bool> CreateAssignment(Assignment assignment)
    {
        await _context.AddAsync(assignment);
        return await Save();
    }

    public async Task<bool> Save()
    {
        var saved = await _context.SaveChangesAsync();
        return saved > 0;
    }
}