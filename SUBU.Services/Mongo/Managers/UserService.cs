using AutoMapper;
using MongoDB.Bson;
using SUBU.DataAccess.Mongo.Repositories;
using SUBU.Entities.Mongo;
using SUBU.Services.Mongo.Managers.Abstract;

namespace SUBU.Services.Mongo.Managers
{
    public interface IUserService : IMongoService<User, ObjectId>
    {
        User Authenticate(string username, string password);
    }

    public class UserService : MongoService<User, ObjectId, IMongoUserRepository>, IUserService
    {
        public UserService(IMongoUserRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public User Authenticate(string username, string password)
        {
            User user = Query().FirstOrDefault(x => x.Username == username && x.Password == password);

            return user;
        }
    }
}
