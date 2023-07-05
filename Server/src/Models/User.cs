namespace Models.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public byte[] UsernameHash { get; set; }
    public byte[] UsernameSalt { get; set; }
    public RefreshToken RefreshToken { get; set; }




}