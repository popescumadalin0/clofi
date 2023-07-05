using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseLayout.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int? ConfigId { get; set; }
    public UserConfig Config { get; set; }
    public ICollection<Assignment> Tasks { get; set; }
    public ICollection<Note> Notes { get; set; }
    public ICollection<Alarm> Alarms { get; set; }
}