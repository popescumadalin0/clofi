using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using Server.Models;
using Server.Repository;
using System.Threading.Tasks;

namespace Server.Controllers;

public class AssignmentController : BaseController
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly IMapper _mapper;

    public AssignmentController(IAssignmentRepository assignmentRepository, IMapper mapper)
    {
        _assignmentRepository = assignmentRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAssignments()
    {
        var assignments = await _assignmentRepository.GetAssignments();
        return ApiServiceResponse.ApiServiceResult(assignments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAssignment(int id)
    {
        var assignment = await _assignmentRepository.GetAssignment(id);
        return ApiServiceResponse.ApiServiceResult(assignment);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAssignment([FromBody] global::Models.DTOs.Assignment newAssignmentDto)
    {
        var result = await _assignmentRepository.CreateAssignment(newAssignmentDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAssignment([FromBody] global::Models.DTOs.Assignment updatedAssignmentDto)
    {
        var result = await _assignmentRepository.UpdateAssignment(updatedAssignmentDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAssignment(int id)
    {
        var result = await _assignmentRepository.DeleteAssignment(id);
        return ApiServiceResponse.ApiServiceResult(result);
    }
}