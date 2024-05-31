using System.Security.Cryptography;

namespace Abigeapp.Application.Compartido;

public class Cifrador
{
    private const int SaltSize = 128 / 8;
    private const int KeySize = 256 / 8;
    private const int Iterations = 10000;
    private static readonly HashAlgorithmName HashAlgorithmName = HashAlgorithmName.SHA256;
    private const char Delimiter = ';';

    public static string Encriptar(string plainKey)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(plainKey, salt, Iterations, HashAlgorithmName, KeySize);

        return string.Join(Delimiter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
    }

    public static bool Verificar(string hashedKey, string plainKey)
    {
        var elements = hashedKey.Split(Delimiter);
        var salt = Convert.FromBase64String(elements[0]);
        var hash = Convert.FromBase64String(elements[1]);
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(plainKey, salt, Iterations, HashAlgorithmName, KeySize);

        return CryptographicOperations.FixedTimeEquals(hash, hashToCompare);
    }
}
