using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DatabaseLayout.Context;

public interface IClofiContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<UserConfig> UserConfigs { get; set; }
    public DbSet<Alarm> Alarms { get; set; }
    public Task<int> SaveChangesAsync();
}
