using System.Linq;
using System.Threading.Tasks;
using DatabaseLayout.Context;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using Server.Interfaces;

namespace Server.Repository;

public class UserConfigRepository : IUserConfigRepository
{
    private readonly IClofiContext _context;

    public UserConfigRepository(IClofiContext context)
    {
        _context = context;
    }
}