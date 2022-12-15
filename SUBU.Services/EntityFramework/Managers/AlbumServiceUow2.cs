using AutoMapper;
using SUBU.DataAccess.EntityFramework.Repositories;
using SUBU.DataAccess.EntityFramework.UnitOfWork;
using SUBU.Entities.EntityFramework.Database1;
using SUBU.Models.diger;

//Gerniec UnitofWork servisimiz. Repoları otomatik oluşturuyor unitofWork için.
namespace SUBU.Services.EntityFramework.Managers
{
    public interface IAlbumServiceUow2
    {
        Album Create(AlbumCreate model);
        T Find<T>(int id);
        IEnumerable<T> List<T>();
    }
   
    public class AlbumServiceUow2 : IAlbumServiceUow2
    {
        //IDatabase1UnitOfWork2 -DataAcces katmanı UnitofWorkümüz
        private readonly IDatabase1UnitOfWork2 _unitOfWork;
        private readonly IMapper _mapper;

        public AlbumServiceUow2(IDatabase1UnitOfWork2 unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Album Create(AlbumCreate model)
        {
            //denemek için 2 kere album giriyoruz.UnitofWork üretilmiş olanı bir daha üretmiyor.
            Album album = _unitOfWork.GetRepository<IAlbumRepository>()
                .Add(_mapper.Map<Album>(model));

            Album album2 = _unitOfWork.GetRepository<IAlbumRepository>()
                .Add(_mapper.Map<Album>(model));

            Song song = _unitOfWork.GetRepository<ISongRepository>()
                .Add(new Song() { Title = "asdasd", Duration = 300 });

            album.Songs = new List<Song>();
            album.Songs.Add(song);

            _unitOfWork.Commit();

            return album;
        }

        public T Find<T>(int id)
        {
            return _mapper.Map<T>(_unitOfWork.GetRepository<IAlbumRepository>()
                .Get(id));
        }

        public IEnumerable<T> List<T>()
        {
            return _mapper.Map<List<T>>(_unitOfWork.GetRepository<IAlbumRepository>()
                .GetAll());
        }
    }
}
