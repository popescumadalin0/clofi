using AutoMapper;
using DatabaseLayout.Context;
using Microsoft.EntityFrameworkCore;
using Server.Interfaces;
using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Models;
using Microsoft.Extensions.Logging;

namespace Server.Repository;

public class AssignmentRepository : IAssignmentRepository
{
    private readonly IClofiContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<AssignmentRepository> _logger;

    public AssignmentRepository(IClofiContext context, IMapper mapper, ILogger<AssignmentRepository> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ServiceResponse<List<Assignment>>> GetAssignmentsAsync()
    {
        try
        {
            var assignments = await _context.Assignments.ToListAsync();
            var result = _mapper.Map<List<Assignment>>(assignments);
            return new ServiceResponse<List<Assignment>>(result);
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message);
            return new ServiceResponse<List<Assignment>>(ex);
        }
    }

    public async Task<ServiceResponse<Assignment>> GetAssignmentAsync(int id)
    {
        try
        {
            var assignment = await _context.Assignments.FindAsync(id);
            var result = _mapper.Map<Assignment>(assignment);
            return new ServiceResponse<Assignment>(result);
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message);
            return new ServiceResponse<Assignment>(ex);
        }
    }

    public async Task<ServiceResponse> CreateAssignmentAsync(Assignment assignmentDto)
    {
        try
        {
            var assignment = _mapper.Map<DatabaseLayout.Models.Assignment>(assignmentDto);
            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();
            return new ServiceResponse();
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message);
            return new ServiceResponse(ex);
        }
    }

    public async Task<ServiceResponse> UpdateAssignmentAsync(Assignment assignmentDto)
    {
        try
        {
            var assignment = await _context.Assignments.FindAsync(assignmentDto.Id);
            _mapper.Map(assignmentDto, assignment);
            await _context.SaveChangesAsync();
            return new ServiceResponse();
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message);
            return new ServiceResponse(ex);
        }
    }

    public async Task<ServiceResponse> DeleteAssignmentAsync(int id)
    {
        try
        {
            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment != null)
            {
                _context.Assignments.Remove(assignment);
                await _context.SaveChangesAsync();
                return new ServiceResponse();
            }
            return new ServiceResponse(errorMessage: "Assignment does not found!");
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message);
            return new ServiceResponse(ex);
        }

    }
}