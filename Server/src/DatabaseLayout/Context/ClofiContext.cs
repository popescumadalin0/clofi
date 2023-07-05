using System.Net;
using System.Threading.Tasks;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayout.Context;

public class ClofiContext : DbContext, IClofiContext
{
    public ClofiContext(DbContextOptions options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<UserConfig> UserConfigs { get; set; }
    public DbSet<Alarm> Alarms { get; set; }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<UserConfig>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Config)
            .WithOne(c => c.User)
            .HasForeignKey<User>(u => u.ConfigId);

        modelBuilder.Entity<UserConfig>()
            .HasOne(c => c.User)
            .WithOne(u => u.Config)
            .HasForeignKey<UserConfig>(c => c.UserId);
    }
}
