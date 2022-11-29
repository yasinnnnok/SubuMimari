using AutoMapper;
using SUBU.DataAccess.EntityFramework.Repositories;
using SUBU.DataAccess.EntityFramework.UnitOfWork;
using SUBU.Entities.EntityFramework.Database1;
using SUBU.Models;

namespace SUBU.Services.EntityFramework.Managers
{
    public interface IArtistService
    {
        ArtistQuery Create(ArtistCreate model);
        void Delete(int id);
        IEnumerable<ArtistQuery> ListAll();
        ArtistQuery FindById(int id);
        ArtistQuery Update(int id, ArtistUpdate model);
        ArtistQuery Update(int id, ArtistAliveUpdate model);
    }

    public class ArtistService : IArtistService
    {
        private readonly IDatabase1UnitOfWork2 _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IArtistRepository _repository;

        public ArtistService(IDatabase1UnitOfWork2 unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            _repository = _unitOfWork.GetRepository<IArtistRepository>();
        }

        public IEnumerable<ArtistQuery> ListAll()
        {
            return _repository.GetAll().ToList()
                .Select(x => _mapper.Map<ArtistQuery>(x))
                .ToList();
        }

        public ArtistQuery FindById(int id)
        {
            return _mapper.Map<ArtistQuery>(_repository.Get(id));
        }

        public ArtistQuery Create(ArtistCreate model)
        {
            Artist artist = _repository.Add(_mapper.Map<Artist>(model));
            _repository.Save();

            return _mapper.Map<ArtistQuery>(artist);
        }

        public ArtistQuery Update(int id, ArtistUpdate model)
        {
            Artist artist = _repository.Get(id);
            _repository.Update(id, _mapper.Map(model, artist));
            _repository.Save();

            return _mapper.Map<ArtistQuery>(artist);
        }

        public ArtistQuery Update(int id, ArtistAliveUpdate model)
        {
            Artist artist = _repository.Get(id);
            _repository.Update(id, _mapper.Map(model, artist));
            _repository.Save();

            return _mapper.Map<ArtistQuery>(artist);
        }

        public void Delete(int id)
        {
            _repository.Remove(id);
            _repository.Save();
        }
    }
}
