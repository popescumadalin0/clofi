using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayout.Models;

public class Alarm
{
    public int Id { get; set; }
    public DateTime AlarmTime { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public User User { get; set; }
}