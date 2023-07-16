using SDK.Models;
using System.IdentityModel.Tokens.Jwt;

namespace Services.Interfaces
{
    public interface ITokenService
    {
        public JwtSecurityToken GenerateToken(UserLoginRequest user);
        public void CreateUsernameHash(string username, out byte[] usernameHash, out byte[] usernameSalt);
        public bool VerifyUsernameHash(string username, byte[] usernameHash, byte[] usernameSalt);
        public bool IsValidToken(string token);
    }
}
