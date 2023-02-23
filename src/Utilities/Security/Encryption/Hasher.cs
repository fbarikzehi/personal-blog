namespace Utilities.Security.Encryption;

public class Hasher : IHasher
{
    public virtual string HashPassword(string value)
    {
        return Cryptographer.Hash(value);
    }

    public virtual VerificationResultEnum VerifyHashed(string hashedValue, string value)
    {
        return (Cryptographer.Verify(hashedValue, value) ? VerificationResultEnum.Success : VerificationResultEnum.Failed);
    }
}
