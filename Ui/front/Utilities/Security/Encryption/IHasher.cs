
namespace Utilities.Security.Encryption;
public interface IHasher
{
    /// <summary>
    /// Create new hash from a password
    /// </summary>
    /// <param name="password"></param>
    /// <returns>string: hashed password</returns>
    string HashPassword(string password);

    /// <summary>
    ///  Verify that a given password matches the hashed password
    /// </summary>
    /// <param name="hashedPassword"></param>
    /// <param name="providedPassword"></param>
    /// <returns>Enum: PasswordVerificationResult</returns>
    VerificationResultEnum VerifyHashed(string hashedValue, string value);
}
