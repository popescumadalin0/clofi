using DatabaseLayout.Context;
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