using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseLayout.Models;

public class UserConfig
{
    [ForeignKey(nameof(User))]
    public int Id { get; private set; }
    public string Language { get; set; }
    public int Volume { get; set; }
    public bool NightMode { get; set; }
    public virtual User User { get; set; }
}