using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Interfaces;

public interface INoteRepository
{
    Task<ServiceResponse<List<global::Models.DTOs.Note>>> GetNotes();
    Task<ServiceResponse<global::Models.DTOs.Note>> GetNote(int id);
    Task<ServiceResponse> CreateNote(global::Models.DTOs.Note note);
    Task<ServiceResponse> UpdateNote(global::Models.DTOs.Note note);
    Task<ServiceResponse> DeleteNote(int id);
}