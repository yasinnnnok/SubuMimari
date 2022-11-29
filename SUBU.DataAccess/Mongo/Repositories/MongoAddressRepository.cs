using MongoDB.Bson;
using SUBU.DataAccess.Base.Mongo.Attributes;
using SUBU.DataAccess.Base.Mongo.Context;
using SUBU.DataAccess.Base.Mongo.Repository;
using SUBU.Entities.Mongo;

namespace SUBU.DataAccess.Mongo.Repositories
{
    public interface IMongoAddressRepository : IMongoRepository<Address, ObjectId>
    {

    }

    [Collection("addresses")]
    public class MongoAddressRepository : MongoRepository<Address, ObjectId>, IMongoAddressRepository
    {
        public MongoAddressRepository(MongoDBContextBase context) : base(context)
        {

        }
    }
}
