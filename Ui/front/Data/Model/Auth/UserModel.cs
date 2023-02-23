namespace Data.Model;

public class UserModel : MongoDBModelbase
{
    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;
}