using Microsoft.Extensions.Configuration;
using SUBU.DataAccess.Base.Mongo.Context;

namespace SUBU.DataAccess.Mongo.Context
{
    public class MongoDBContext : MongoDBContextBase
    {
        public MongoDBContext(IConfiguration configuration) :
            base(configuration,
                 configuration.GetConnectionString("MongoDDBConnection"), configuration.GetConnectionString("MongoDDBConnection").Split('/').Last())
        {
        }
    }
}
