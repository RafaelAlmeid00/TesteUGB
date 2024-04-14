
namespace UGB.Services;
using BCrypt.Net;
public class Crypto
{
    private readonly string _hash;
    private readonly string _password;

    public Crypto(string hash, string password)
    {
        _hash = hash;
        _password = password;
    }
    public string Encripty()
    {
        var passwordHash = BCrypt.HashPassword(_password);
        return passwordHash;
    }

    public bool Decrypt()
    {
        var verifyPassword = BCrypt.Verify(_password, _hash);
        return verifyPassword;
    }
}