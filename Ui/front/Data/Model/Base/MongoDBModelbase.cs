using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.Model;

public class MongoDBModelbase
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
}

