namespace Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(string userName, int durationMin);
    bool IsValidToken(string token);
    int GetExpirationTimeFromJwtInMinutes(string token);
}