namespace SDK.Models;

public class UserLoginResponse
{
    public string Username { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}