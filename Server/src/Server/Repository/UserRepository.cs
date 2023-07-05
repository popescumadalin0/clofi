using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayout.Context;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using Server.Interfaces;

namespace Server.Repository;

public class UserRepository : IUserRepository
{
    private readonly ClofiContext _context;

    public UserRepository(ClofiContext context)
    {
        _context = context;
    }

    public async Task<ICollection<User>> GetUsers()
    {
        return await _context.Users.OrderBy(u => u.Id).ToListAsync();
    }

    public async Task<User> GetUser(int id)
    {
        return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
    }

    public async Task<ICollection<Assignment>> GetAssignments(int userId)
    {
        return await _context.Assignments.OrderBy(a => a.User.Id == userId).ToListAsync();
    }

    public async Task<ICollection<Note>> GetNotes(int userId)
    {
        return await _context.Notes.OrderBy(n => n.User.Id == userId).ToListAsync();
    }

    public async Task<ICollection<Alarm>> GetAlarms(int userId)
    {
        return await _context.Alarms.OrderBy(a => a.User.Id == userId).ToListAsync();
    }

    public async Task<UserConfig> GetUserConfig(int userId)
    {
        return await _context.UserConfigs.Where(u => u.User.Id == userId).FirstOrDefaultAsync();
    }
}