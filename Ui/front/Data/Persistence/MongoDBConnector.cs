
using MongoDB.Driver;

namespace Data.Persistence;

public class MongoDBConnector<TModel>
{
    public string ConnectionUri { get; } = "mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.7.1";

    public readonly IMongoCollection<TModel> _collection;

    public MongoDBConnector(string databaseName, string collectionName)
    {
        MongoClient client = new(ConnectionUri);
        IMongoDatabase database = client.GetDatabase(databaseName);
        _collection = database.GetCollection<TModel>(collectionName);
    }
}