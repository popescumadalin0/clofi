using DatabaseLayout.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Interfaces;

public interface INoteRepository
{
    Task<ICollection<Note>> GetNotes();
    Task<Note> GetNote(int id);
}