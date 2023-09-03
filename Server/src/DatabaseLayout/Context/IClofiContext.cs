using System.Threading.Tasks;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;


namespace DatabaseLayout.Context;

public interface IClofiContext
{
<<<<<<< HEAD
    public DbSet<User> Users { get; set; }
    public Task<int> SaveChangesAsync();
=======
    DbSet<User> Users { get; set; }
    DbSet<Note> Notes { get; set; }
    DbSet<Assignment> Assignments { get; set; }
    DbSet<UserConfig> UserConfigs { get; set; }
    DbSet<Alarm> Alarms { get; set; }
    Task<int> SaveChangesAsync();
>>>>>>> main
}
