using AutoMapper;
using SUBU.DataAccess.Base.Mongo.Repository;
using SUBU.Entities.Base;

namespace SUBU.Services.Mongo.Managers.Abstract
{
    public interface IMongoService<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        TEntity Create(TEntity entity);
        TEntity Create<T>(T model);
        long Delete(TKey id);
        TEntity Find(TKey id);
        T Find<T>(TKey id);
        IEnumerable<TEntity> List();
        IEnumerable<T> List<T>();
        IQueryable<TEntity> Query();
        long Update(TKey id, TEntity model);
        long Update<T>(TKey id, T model);
    }

    public class MongoService<TEntity, TKey, TRepository> : IMongoService<TEntity, TKey> where TEntity : EntityBase<TKey>
            where TRepository : IMongoRepository<TEntity, TKey>
    {
        private readonly TRepository _repository;
        private readonly IMapper _mapper;

        public MongoService(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual TEntity Create(TEntity entity)
        {
            return _repository.Insert(entity);
        }

        public virtual TEntity Create<T>(T model)
        {
            if (_mapper == null)
                throw new NullReferenceException("AutoMapper parameter can not be null to get generic type result. Use non-generic 'Create' method.");

            TEntity entity = _repository.Insert(_mapper.Map<TEntity>(model));
            return entity;
        }

        public virtual long Delete(TKey id)
        {
            return _repository.Delete(id);
        }

        public virtual TEntity Find(TKey id)
        {
            return _repository.Find(id);
        }

        public virtual T Find<T>(TKey id)
        {
            if (_mapper == null)
                throw new NullReferenceException("AutoMapper parameter can not be null to get generic type result. Use non-generic 'Get' method.");

            return _mapper.Map<T>(_repository.Find(id));
        }

        public virtual IEnumerable<TEntity> List()
        {
            return _repository.List();
        }

        public virtual IEnumerable<T> List<T>()
        {
            if (_mapper == null)
                throw new NullReferenceException("AutoMapper parameter can not be null to get generic type result. Use non-generic 'List' method.");

            return _repository.List().Select(x => _mapper.Map<T>(x)).ToList();
        }

        public virtual IQueryable<TEntity> Query()
        {
            return _repository.Queryable();
        }

        public virtual long Update(TKey id, TEntity model)
        {
            model.Id = id;
            return _repository.Update(id, model);
        }

        public virtual long Update<T>(TKey id, T model)
        {
            if (_mapper == null)
                throw new NullReferenceException("AutoMapper parameter can not be null to get generic type result. Use non-generic 'Update' method.");

            var entity = _repository.Find(id);
            _mapper.Map(model, entity);

            return _repository.Update(id, entity);
        }
    }
}
