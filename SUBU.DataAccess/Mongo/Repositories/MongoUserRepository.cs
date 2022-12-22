using MongoDB.Bson;
using SUBU.DataAccess.Base.Mongo.Attributes;
using SUBU.DataAccess.Base.Mongo.Context;
using SUBU.DataAccess.Base.Mongo.Repository;
using SUBU.Entities.Mongo;

namespace SUBU.DataAccess.Mongo.Repositories;

public interface IMongoUserRepository : IMongoRepository<UserMongo, ObjectId>
{

}

[Collection("users")]
public class MongoUserRepository : MongoRepository<UserMongo, ObjectId>, IMongoUserRepository
{
    public MongoUserRepository(MongoDBContextBase context) : base(context)
    {

    }
}
