using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayout.Context;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using Server.Interfaces;

namespace Server.Repository;

public class AlarmRepository : IAlarmRepository
{
    private readonly ClofiContext _context;

    public AlarmRepository(ClofiContext context)
    {
        _context = context;
    }
    public async Task<ICollection<Alarm>> GetAlarms()
    {
        return await _context.Alarms.OrderBy(a => a.Id).ToListAsync();
    }

    public async Task<Alarm> GetAlarm(int id)
    {
        return await _context.Alarms.Where(a => a.Id == id).FirstOrDefaultAsync();
    }
}