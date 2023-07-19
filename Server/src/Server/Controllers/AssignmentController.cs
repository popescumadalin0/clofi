using Server.Interfaces;

namespace Server.Controllers;

public class AssignmentController : BaseController
{
    private readonly IAssignmentRepository _assignmentRepository;

    public AssignmentController(IAssignmentRepository assignmentRepository)
    {
        _assignmentRepository = assignmentRepository;
    }
}