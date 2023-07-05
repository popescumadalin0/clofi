using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayout.Models;

public class UserConfig
{
    public int Id { get; set; }
    public string Language { get; set; }
    public int Volume { get; set; }
    public bool NightMode { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}