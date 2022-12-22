using AutoMapper;
using MongoDB.Bson;
using SUBU.DataAccess.Mongo.Repositories;
using SUBU.Entities.Mongo;
using SUBU.Services.Mongo.Managers.Abstract;

namespace SUBU.Services.Mongo.Managers;

public interface IMongoUserService : IMongoService<UserMongo, ObjectId>
{
    UserMongo Authenticate(string username, string password);
}

public class MongoUserService : MongoService<UserMongo, ObjectId, IMongoUserRepository>, IMongoUserService
{
    public MongoUserService(IMongoUserRepository repository, IMapper mapper) : base(repository, mapper)
    {

    }

    public UserMongo Authenticate(string username, string password)
    {
        UserMongo user = Query().FirstOrDefault(x => x.Username == username && x.Password == password);

        return user;
    }
}
