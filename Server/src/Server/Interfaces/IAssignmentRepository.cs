using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout.Models;

namespace Server.Interfaces;

public interface IAssignmentRepository
{
    Task<ICollection<Assignment>> GetAssignments();
    Task<Assignment> GetAssignment(int id);
    Task<bool> CreateAssignment(Assignment assignment);
    Task<bool> Save();
}