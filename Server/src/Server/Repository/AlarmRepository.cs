using AutoMapper;
using DatabaseLayout.Context;
using Microsoft.EntityFrameworkCore;
using Server.Interfaces;
using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Models;

namespace Server.Repository;

public class AlarmRepository : IAlarmRepository
{
    private readonly IClofiContext _context;
    private readonly IMapper _mapper;

    public AlarmRepository(IClofiContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<Alarm>>> GetAlarmsAsync()
    {
        try
        {
            var alarms = await _context.Alarms.ToListAsync();
            var result = _mapper.Map<List<Alarm>>(alarms);
            return new ServiceResponse<List<Alarm>>(result);
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<Alarm>>(ex);
        }
    }

    public async Task<ServiceResponse<Alarm>> GetAlarmAsync(int id)
    {
        try
        {
            var alarm = await _context.Alarms.FindAsync(id);
            var result = _mapper.Map<Alarm>(alarm);
            return new ServiceResponse<Alarm>(result);
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Alarm>(ex);
        }
    }

    public async Task<ServiceResponse> CreateAlarmAsync(Alarm alarmDto)
    {
        try
        {
            var alarm = _mapper.Map<DatabaseLayout.Models.Alarm>(alarmDto);
            _context.Alarms.Add(alarm);
            await _context.SaveChangesAsync();
            return new ServiceResponse();
        }
        catch (Exception ex)
        {
            return new ServiceResponse(ex);
        }
    }

    public async Task<ServiceResponse> UpdateAlarmAsync(Alarm alarmDto)
    {
        try
        {
            var alarm = await _context.Alarms.FindAsync(alarmDto.Id);
            _mapper.Map(alarmDto, alarm);
            await _context.SaveChangesAsync();
            return new ServiceResponse();
        }
        catch (Exception ex)
        {
            return new ServiceResponse(ex);
        }
    }

    public async Task<ServiceResponse> DeleteAlarmAsync(int id)
    {
        try
        {
            var alarm = await _context.Alarms.FindAsync(id);
            if (alarm != null)
            {
                _context.Alarms.Remove(alarm);
                await _context.SaveChangesAsync();
                return new ServiceResponse();
            }
            return new ServiceResponse(errorMessage: "Alarm does not found!");
        }
        catch (Exception ex)
        {
            return new ServiceResponse(ex);
        }

    }
}