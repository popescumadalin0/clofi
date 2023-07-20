using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Interfaces;

public interface IAssignmentRepository
{
    Task<ServiceResponse<List<global::Models.DTOs.Assignment>>> GetAssignments();
    Task<ServiceResponse<global::Models.DTOs.Assignment>> GetAssignment(int id);
    Task<ServiceResponse> CreateAssignment(global::Models.DTOs.Assignment assignment);
    Task<ServiceResponse> UpdateAssignment(global::Models.DTOs.Assignment assignment);
    Task<ServiceResponse> DeleteAssignment(int id);
}