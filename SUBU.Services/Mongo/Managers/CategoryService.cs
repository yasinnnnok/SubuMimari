using AutoMapper;
using MongoDB.Bson;
using SUBU.DataAccess.Mongo.Repositories;
using SUBU.Entities.Base;
using SUBU.Entities.Mongo;
using SUBU.Services.Mongo.Managers.Abstract;

namespace SUBU.Services.Mongo.Managers;

public interface ICategoryService: IMongoService<Category, ObjectId>
{
    
}

public class CategoryService : MongoService<Category, ObjectId, IMongoCategoryRepository>, ICategoryService
{
    public CategoryService(IMongoCategoryRepository repository, IMapper mapper) : base(repository, mapper)
    {
        
    }
}
