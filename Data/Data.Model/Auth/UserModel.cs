using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.Model;

public class User : BsonModelbase
{

    public string Username { get; set; } = null!;

    public string HashPassword { get; set; }


}