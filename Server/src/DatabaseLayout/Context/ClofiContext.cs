using System.Threading.Tasks;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayout.Context;

public class ClofiContext : DbContext, IClofiContext
{
    public ClofiContext(DbContextOptions options)
        : base(options) { }

    public DbSet<UserDto> Users { get; set; }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}
