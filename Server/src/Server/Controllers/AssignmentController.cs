using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using Server.Models;
<<<<<<< HEAD
using Services;
=======
>>>>>>> main
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Models;

namespace Server.Controllers;

public class AssignmentController : BaseController
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly ILogger<AssignmentController> _logger;

    public AssignmentController(IAssignmentRepository assignmentRepository, ILogger<AssignmentController> logger)
    {
        _assignmentRepository = assignmentRepository;
        _logger = logger;
    }

    [HttpGet]
    [JwtAuth]
    public async Task<IActionResult> GetAssignmentsAsync()
    {
        _logger.LogInformation("Get all assignments");
        var assignments = await _assignmentRepository.GetAssignmentsAsync();
        return ApiServiceResponse.ApiServiceResult(assignments);
    }

    [HttpGet("{id}")]
    [JwtAuth]
    public async Task<IActionResult> GetAssignmentAsync(int id)
    {
        _logger.LogInformation($"Get assignment by id: {id}");
        var assignment = await _assignmentRepository.GetAssignmentAsync(id);
        return ApiServiceResponse.ApiServiceResult(assignment);
    }

    [HttpPost]
<<<<<<< HEAD
    [JwtAuth]
    public async Task<IActionResult> CreateAssignmentAsync([FromBody] global::Models.Assignment newAssignmentDto)
=======
    public async Task<IActionResult> CreateAssignmentAsync([FromBody] Assignment newAssignmentDto)
>>>>>>> main
    {
        _logger.LogInformation("Create assignment");
        var result = await _assignmentRepository.CreateAssignmentAsync(newAssignmentDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpPut]
<<<<<<< HEAD
    [JwtAuth]
    public async Task<IActionResult> UpdateAssignmentAsync([FromBody] global::Models.Assignment updatedAssignmentDto)
=======
    public async Task<IActionResult> UpdateAssignmentAsync([FromBody] Assignment updatedAssignmentDto)
>>>>>>> main
    {
        _logger.LogInformation($"Update assignment: {updatedAssignmentDto.Id}");
        var result = await _assignmentRepository.UpdateAssignmentAsync(updatedAssignmentDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpDelete("{id}")]
    [JwtAuth]
    public async Task<IActionResult> DeleteAssignmentAsync(int id)
    {
        _logger.LogInformation($"Delete assignment: {id}");
        var result = await _assignmentRepository.DeleteAssignmentAsync(id);
        return ApiServiceResponse.ApiServiceResult(result);
    }
}