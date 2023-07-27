using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Interfaces;

public interface IAssignmentRepository
{
    Task<ServiceResponse<List<global::Models.Assignment>>> GetAssignmentsAsync();
    Task<ServiceResponse<global::Models.Assignment>> GetAssignmentAsync(int id);
    Task<ServiceResponse> CreateAssignmentAsync(global::Models.Assignment assignment);
    Task<ServiceResponse> UpdateAssignmentAsync(global::Models.Assignment assignment);
    Task<ServiceResponse> DeleteAssignmentAsync(int id);
}