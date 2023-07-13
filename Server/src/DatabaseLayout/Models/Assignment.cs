using System;

namespace DatabaseLayout.Models;

public class Assignment
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DeadLine { get; set; }
    public DateTime StartTime { get; set; } = DateTime.Now;
    public int OrderPriority { get; set; }
    public User User { get; set; }
}