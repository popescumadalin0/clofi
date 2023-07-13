using System;
namespace DatabaseLayout.Models;

public class Alarm
{
    public int Id { get; set; }
    public DateTime AlarmTime { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public User User { get; set; }
}