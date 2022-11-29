using MongoDB.Bson;
using MongoDB.Driver;
using SUBU.DataAccess.Base.Mongo.Attributes;
using SUBU.DataAccess.Base.Mongo.Context;
using SUBU.Entities.Base;
using System.Linq.Expressions;
using System.Reflection;

namespace SUBU.DataAccess.Base.Mongo.Repository
{
    public interface IMongoRepository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        bool Any();
        long Delete(TKey id);
        TEntity Find(TKey id);
        List<TEntity> FindAll<TValue>(Expression<Func<TEntity, TValue>> filter, TValue value);
        TEntity Insert(TEntity entity);
        List<TEntity> List();
        IQueryable<TEntity> Queryable();
        long Update(TKey id, TEntity entity);
    }

    public abstract class MongoRepository<TEntity, TKey> : IMongoRepository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        private readonly MongoDBContextBase _context;
        private IMongoCollection<TEntity> _collection;

        public MongoRepository(MongoDBContextBase context)
        {
            _context = context;
            string collectionName = this.GetType().GetCustomAttribute<CollectionAttribute>().Name;

            _collection = context.Database.GetCollection<TEntity>(collectionName);
        }

        public TEntity Insert(TEntity entity)
        {
            _collection.InsertOne(entity);
            return entity;
        }

        public bool Any()
        {
            return _collection.CountDocuments(new BsonDocument()) > 0;
        }

        public long Delete(TKey id)
        {
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq(x => x.Id, id);
            var result = _collection.DeleteOne(filter);
            return result.DeletedCount;
        }

        public TEntity Find(TKey id)
        {
            var filter = Builders<TEntity>.Filter.Eq(x => x.Id, id);
            return _collection.Find(filter).FirstOrDefault();
        }

        public List<TEntity> FindAll<TValue>(Expression<Func<TEntity, TValue>> filter, TValue value)
        {
            return _collection.Find(Builders<TEntity>.Filter.Eq(filter, value)).ToList();
        }

        public List<TEntity> List()
        {
            return _collection.Find(new BsonDocument()).ToList();
        }

        public IQueryable<TEntity> Queryable()
        {
            return _collection.AsQueryable<TEntity>();
        }

        public long Update(TKey id, TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq(x => x.Id, id);
            var result = _collection.ReplaceOne(filter, entity);

            return result.ModifiedCount;
        }
    }
}
