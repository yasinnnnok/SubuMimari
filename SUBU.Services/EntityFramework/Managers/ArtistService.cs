using AutoMapper;
using SUBU.DataAccess.EntityFramework.Repositories;
using SUBU.DataAccess.EntityFramework.UnitOfWork;
using SUBU.Entities.EntityFramework.Database1;
using SUBU.Models;

namespace SUBU.Services.EntityFramework.Managers;

//AlbumServiceUow2 gibi kullanılıyor.
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
    //her seferinde GetRepository yazmayalım diye ekliyoruz.        
    private readonly IArtistRepository _repository;

    public ArtistService(IDatabase1UnitOfWork2 unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        //herseferinde GetRepository yazmayalım diye ekliyoruz.
        //return _mapper.Map<T>(_unitOfWork.GetRepository<IAlbumRepository>()
        _repository = _unitOfWork.GetRepository<IArtistRepository>();
    }

    //Listeyi dmnerkende ArtistQuert dönüyoruz. Listeyi select ile dönüp öyle maplemeliyiz
    public IEnumerable<ArtistQuery> ListAll()
    {
       //liste mapleme şekli.(select ile)
        return _repository.GetAll().ToList()
            .Select(x => _mapper.Map<ArtistQuery>(x))
            .ToList();


     
    }

    //ide den bulup ArtistQuery dönecek
    public ArtistQuery FindById(int id)
    {
        return _mapper.Map<ArtistQuery>(_repository.Get(id));
    }

    //ArtistCreate alıp oluşturacak ve ArtistQuery dönecek
    public ArtistQuery Create(ArtistCreate model)
    {
        Artist artist = _repository.Add(_mapper.Map<Artist>(model));
        _repository.Save();

        return _mapper.Map<ArtistQuery>(artist);
    }

    //ArtistUpdate alıp. ArtistQuery dönecek
    public ArtistQuery Update(int id, ArtistUpdate model)
    {
        Artist artist = _repository.Get(id);
        _repository.Update(id, _mapper.Map(model, artist));
        _repository.Save();

        return _mapper.Map<ArtistQuery>(artist);
    }

    //ArtistAliveUpdate alacak ArtisQuery dönecek.
    public ArtistQuery Update(int id, ArtistAliveUpdate model)
    {
        Artist artist = _repository.Get(id);
        //map i bu şekilde kullanıyoruz. modelii artiste maple. (newlemeden)
        _repository.Update(id, _mapper.Map(model, artist));
        _repository.Save();

        return _mapper.Map<ArtistQuery>(artist);
    }

    //id yi al sil,kaydet.
    public void Delete(int id)
    {
        _repository.Remove(id);
        _repository.Save();
    }
}
