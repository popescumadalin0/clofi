using DatabaseLayout.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DatabaseLayout.Context;

public interface IClofiContext
{
    public DbSet<UserDTO> Users { get; set; }
    public Task<int> SaveChangesAsync();
}
