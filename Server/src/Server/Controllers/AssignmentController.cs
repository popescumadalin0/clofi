using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using Server.Models;
using Services;
using System.Threading.Tasks;

namespace Server.Controllers;

public class AssignmentController : BaseController
{
    private readonly IAssignmentRepository _assignmentRepository;

    public AssignmentController(IAssignmentRepository assignmentRepository)
    {
        _assignmentRepository = assignmentRepository;
    }

    [HttpGet]
    [JwtAuth]
    public async Task<IActionResult> GetAssignmentsAsync()
    {
        var assignments = await _assignmentRepository.GetAssignmentsAsync();
        return ApiServiceResponse.ApiServiceResult(assignments);
    }

    [HttpGet("{id}")]
    [JwtAuth]
    public async Task<IActionResult> GetAssignmentAsync(int id)
    {
        var assignment = await _assignmentRepository.GetAssignmentAsync(id);
        return ApiServiceResponse.ApiServiceResult(assignment);
    }

    [HttpPost]
    [JwtAuth]
    public async Task<IActionResult> CreateAssignmentAsync([FromBody] global::Models.Assignment newAssignmentDto)
    {
        var result = await _assignmentRepository.CreateAssignmentAsync(newAssignmentDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpPut]
    [JwtAuth]
    public async Task<IActionResult> UpdateAssignmentAsync([FromBody] global::Models.Assignment updatedAssignmentDto)
    {
        var result = await _assignmentRepository.UpdateAssignmentAsync(updatedAssignmentDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpDelete("{id}")]
    [JwtAuth]
    public async Task<IActionResult> DeleteAssignmentAsync(int id)
    {
        var result = await _assignmentRepository.DeleteAssignmentAsync(id);
        return ApiServiceResponse.ApiServiceResult(result);
    }
}