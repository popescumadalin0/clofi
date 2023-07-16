using System.IdentityModel.Tokens.Jwt;

namespace SDK.Models
{
    public class UserLoginResponse
    {
        public string Username { get; set; } = string.Empty;
        public JwtSecurityToken Token { get; set; }
        public JwtSecurityToken RefreshToken { get; set; }
    }
}
