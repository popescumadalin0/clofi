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
    private readonly IClofiContext _context;

    public AlarmRepository(IClofiContext context)
    {
        _context = context;
    }
}