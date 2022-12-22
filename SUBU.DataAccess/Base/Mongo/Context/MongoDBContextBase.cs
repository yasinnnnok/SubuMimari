using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace SUBU.DataAccess.Base.Mongo.Context;

public abstract class MongoDBContextBase
{
    public IMongoClient Client { get; protected set; }
    public IMongoDatabase Database { get; protected set; }

    protected readonly IConfiguration _configuration;

    public MongoDBContextBase(IConfiguration configuration, string connectionString)
    {
        _configuration = configuration;
        Client = new MongoClient(connectionString);
    }

    public MongoDBContextBase(IConfiguration configuration, string connectionString, string databaseName)
    {
        _configuration = configuration;
        Client = new MongoClient(connectionString);
        Database = Client.GetDatabase(databaseName);
    }
}
