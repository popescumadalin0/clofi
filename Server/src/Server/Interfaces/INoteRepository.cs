using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Interfaces;

public interface INoteRepository
{
    Task<ServiceResponse<List<global::Models.Note>>> GetNotesAsync();
    Task<ServiceResponse<global::Models.Note>> GetNoteAsync(int id);
    Task<ServiceResponse> CreateNoteAsync(global::Models.Note note);
    Task<ServiceResponse> UpdateNoteAsync(global::Models.Note note);
    Task<ServiceResponse> DeleteNoteAsync(int id);
}