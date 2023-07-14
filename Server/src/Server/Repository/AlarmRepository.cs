using DatabaseLayout.Context;
using Server.Interfaces;

namespace Server.Repository;

public class AlarmRepository : IAlarmRepository
{
    private readonly IClofiContext _context;

    public AlarmRepository(IClofiContext context)
    {
        _context = context;
    }
}