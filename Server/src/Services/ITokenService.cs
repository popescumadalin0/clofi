
using Models.Models;


namespace Services
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
        public void CreateUsernameHash(string username, out byte[] usernameHash, out byte[] usernameSalt);
        public bool VerifyUsernameHash(string username, byte[] usernameHash, byte[] usernameSalt);
    }
}
