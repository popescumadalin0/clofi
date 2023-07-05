using DatabaseLayout.Models;
using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using Server.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers;

public class AssignmentController : BaseController
{
    private readonly IAssignmentRepository _assignmentRepository;

    public AssignmentController(IAssignmentRepository assignmentRepository)
    {
        _assignmentRepository = assignmentRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Assignment>))]
    public async Task<IActionResult> GetAssignments()
    {
        var assignments = await _assignmentRepository.GetAssignments();
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(assignments);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(Assignment))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetAssignment(int id)
    {
        var assignment = await _assignmentRepository.GetAssignment(id);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(assignment);
    }
}