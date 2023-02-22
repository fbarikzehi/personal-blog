using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.Model.Base;

public class BsonModelbase
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Username { get; set; } = null!;

    public string HashPassword { get; set; }


}