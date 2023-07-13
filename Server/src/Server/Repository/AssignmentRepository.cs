using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayout.Context;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;
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