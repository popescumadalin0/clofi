﻿using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DatabaseLayout.Context;

public interface IClofiContext
{
    DbSet<User> Users { get; set; }
    DbSet<Note> Notes { get; set; }
    DbSet<Assignment> Assignments { get; set; }
    DbSet<UserConfig> UserConfigs { get; set; }
    DbSet<Alarm> Alarms { get; set; }
    Task<int> SaveChangesAsync();
}
