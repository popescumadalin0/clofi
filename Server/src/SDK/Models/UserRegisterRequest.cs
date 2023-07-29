using System.ComponentModel.DataAnnotations;

namespace SDK.Models;
public class UserRegisterRequest
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required, Compare("Password")]
    public string ConfirmPassword { get; set; }
    [Required]
    public string Description { get; set; }

}

