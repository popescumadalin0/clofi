using System.Threading.Tasks;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;


namespace DatabaseLayout.Context;

public class ClofiContext : DbContext, IClofiContext
{
    public ClofiContext(DbContextOptions options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
<<<<<<< HEAD
=======
    public DbSet<Note> Notes { get; set; }
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<UserConfig> UserConfigs { get; set; }
    public DbSet<Alarm> Alarms { get; set; }
>>>>>>> main

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}
