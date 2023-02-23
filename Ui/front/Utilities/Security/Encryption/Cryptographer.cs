using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Utilities.Security.Encryption;

internal static class Cryptographer
{
    private const int Iterations = 1000;
    private const int SubkeyLength = 256 / 8;
    private const int SaltSize = 128 / 8;
    private static readonly HashAlgorithmName AlgorithmName = HashAlgorithmName.SHA512;

    public static string Hash(string password)
    {
        if (string.IsNullOrEmpty(password)) throw new ArgumentNullException("Password cannot be null");

        byte[] salt;
        byte[] subkey;
        using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltSize, Iterations, AlgorithmName))
        {
            salt = rfc2898DeriveBytes.Salt;
            subkey = rfc2898DeriveBytes.GetBytes(SubkeyLength);
        }

        var outputBytes = new byte[1 + SaltSize + SubkeyLength];
        Buffer.BlockCopy(salt, 0, outputBytes, 1, SaltSize);
        Buffer.BlockCopy(subkey, 0, outputBytes, 1 + SaltSize, SubkeyLength);
        return Convert.ToBase64String(outputBytes);
    }

    public static bool Verify(string hashedPassword, string password)
    {
        if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword)) return false;

        var hashedPasswordBytes = Convert.FromBase64String(hashedPassword);
        if (hashedPasswordBytes.Length != 1 + SaltSize + SubkeyLength || hashedPasswordBytes[0] != 0x00) return false;

        var salt = new byte[SaltSize];
        Buffer.BlockCopy(hashedPasswordBytes, 1, salt, 0, SaltSize);
        var storedSubkey = new byte[SubkeyLength];
        Buffer.BlockCopy(hashedPasswordBytes, 1 + SaltSize, storedSubkey, 0, SubkeyLength);

        byte[] generatedSubkey;
        using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, Iterations, AlgorithmName))
            generatedSubkey = deriveBytes.GetBytes(SubkeyLength);

        return ByteArraysEqual(storedSubkey, generatedSubkey);
    }

    [MethodImpl(MethodImplOptions.NoOptimization)]
    private static bool ByteArraysEqual(byte[] a, byte[] b)
    {
        if (ReferenceEquals(a, b)) return true;

        if (a == null || b == null || a.Length != b.Length) return false;

        var isEqual = true;
        for (var i = 0; i < a.Length; i++)
            isEqual &= a[i] == b[i];

        return isEqual;
    }
}
