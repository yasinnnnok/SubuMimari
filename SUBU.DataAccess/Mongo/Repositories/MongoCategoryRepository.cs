using MongoDB.Bson;
using SUBU.DataAccess.Base.Mongo.Attributes;
using SUBU.DataAccess.Base.Mongo.Context;
using SUBU.DataAccess.Base.Mongo.Repository;
using SUBU.Entities.Mongo;

namespace SUBU.DataAccess.Mongo.Repositories
{
    public interface IMongoCategoryRepository: IMongoRepository<Category, ObjectId>
    {

    }

    [Collection("categories")]
    public class MongoCategoryRepository : MongoRepository<Category, ObjectId>, IMongoCategoryRepository
    {
        public MongoCategoryRepository(MongoDBContextBase context) : base(context)
        {

        }
    }
}
