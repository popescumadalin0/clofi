namespace Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(string userName, int durationMin);
    void CreateUsernameHash(string username, out byte[] usernameHash, out byte[] usernameSalt);
    bool VerifyUsernameHash(string username, byte[] usernameHash, byte[] usernameSalt);
    bool IsValidToken(string token);
    int GetExpirationTimeFromJwtInMinutes(string token);
}