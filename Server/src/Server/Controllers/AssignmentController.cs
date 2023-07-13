using DatabaseLayout.Models;
using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Controllers;

public class AssignmentController : BaseController
{
    private readonly IAssignmentRepository _assignmentRepository;

    public AssignmentController(IAssignmentRepository assignmentRepository)
    {
        _assignmentRepository = assignmentRepository;
    }
}