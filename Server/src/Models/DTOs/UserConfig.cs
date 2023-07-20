using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DTOs;

public class UserConfig
{
    public int Id { get; set; }
    public string Language { get; set; }
    public int Volume { get; set; }
    public bool NightMode { get; set; }
}