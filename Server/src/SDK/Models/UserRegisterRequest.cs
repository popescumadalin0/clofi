using System.ComponentModel.DataAnnotations;

namespace SDK.Models;

public class UserRegisterRequest
{
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [Required] public string Username { get; set; }
    [Required] public string Password { get; set; }
    [Required, Compare("Password")] public string ConfirmPassword { get; set; }
}