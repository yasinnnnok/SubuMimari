using AutoMapper;
using SUBU.DataAccess.EntityFramework.UnitOfWork;
using SUBU.Entities.EntityFramework.Database1;
using SUBU.Models.diger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ilk UnitofWork Servisimiz. DataAccess'te repo ları tek tek eklemek gerekiyor.ilk unitofWork ü kullanıyor.
namespace SUBU.Services.EntityFramework.Managers.diger;

public interface IAlbumServiceUow
{
    Album Create(AlbumCreate model);
    T Find<T>(int id);
    IEnumerable<T> List<T>();
}

public class AlbumServiceUow : IAlbumServiceUow
{
    private readonly IDatabase1UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AlbumServiceUow(IDatabase1UnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Album Create(AlbumCreate model)
    {
        Album album = _unitOfWork.AlbumRepository.Add(_mapper.Map<Album>(model));
        Album album2 = _unitOfWork.AlbumRepository.Add(_mapper.Map<Album>(model));
        Song song = _unitOfWork.SongRepository.Add(new Song() { Title = "asdasd", Duration = 300 });

        album.Songs = new List<Song>();
        album.Songs.Add(song);

        _unitOfWork.Commit();

        return album;
    }

    public T Find<T>(int id)
    {
        return _mapper.Map<T>(_unitOfWork.AlbumRepository.Get(id));
    }

    public IEnumerable<T> List<T>()
    {
        return _mapper.Map<List<T>>(_unitOfWork.AlbumRepository.GetAll());
    }
}
