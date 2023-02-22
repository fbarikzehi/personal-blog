using Data.Model.Base;

namespace Data.Model;

public class User : MongoDBModelbase
{
    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; }
}