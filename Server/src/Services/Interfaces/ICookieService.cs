namespace Server.Interfaces;

public interface ICookieService
{
    void SetCookie(string key, string value, int? expirationInMinutes = null);
    string GetCookie(string key);
    void DeleteCookie(string key);
}