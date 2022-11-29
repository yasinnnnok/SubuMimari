using MongoDB.Bson;
using SUBU.DataAccess.Base.Mongo.Attributes;
using SUBU.DataAccess.Base.Mongo.Context;
using SUBU.DataAccess.Base.Mongo.Repository;
using SUBU.Entities.Mongo;

namespace SUBU.DataAccess.Mongo.Repositories
{
    public interface IMongoUserRepository : IMongoRepository<User, ObjectId>
    {

    }

    [Collection("users")]
    public class MongoUserRepository : MongoRepository<User, ObjectId>, IMongoUserRepository
    {
        public MongoUserRepository(MongoDBContextBase context) : base(context)
        {

        }
    }
}
