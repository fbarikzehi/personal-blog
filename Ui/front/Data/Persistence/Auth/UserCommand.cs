using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using Data.Model;

namespace Data.Persistence;

public class UserCommand : MongoDBConnector<UserModel>, ICommand<UserModel>
{

    public UserCommand() : base("blog", "acount_users")
    {

    }

    public UserModel Create(UserModel model)
    {
        _collection.InsertOneAsync(model);
        return model;
    }


    public UserModel Update()
    {
        throw new NotImplementedException();
    }

    public UserModel Delete()
    {
        throw new NotImplementedException();
    }

    public UserModel Get(UserModel model)
    {
        return _collection.Find(x => x.Username == model.Username).FirstOrDefault();
    }

    public IEnumerable<UserModel> ReadMany()
    {
        throw new NotImplementedException();
    }
}