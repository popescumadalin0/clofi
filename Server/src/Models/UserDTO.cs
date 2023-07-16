
namespace Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] UsernameHash { get; set; }
        public byte[] UsernameSalt { get; set; }
        public string RefreshToken { get; set; }
        public string Token { get; set; }
    }
}