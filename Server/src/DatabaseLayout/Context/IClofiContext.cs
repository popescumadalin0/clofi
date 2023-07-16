using System.Threading.Tasks;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;


namespace DatabaseLayout.Context;

public interface IClofiContext
{
    public DbSet<User> Users { get; set; }
    public Task<int> SaveChangesAsync();
}
