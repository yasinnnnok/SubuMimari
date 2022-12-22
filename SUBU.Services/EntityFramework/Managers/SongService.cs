using AutoMapper;
using SUBU.DataAccess.EntityFramework.Repositories;
using SUBU.Entities.EntityFramework.Database1;
using SUBU.Models.diger;

namespace SUBU.Services.EntityFramework.Managers;

public interface ISongService
{
    Song Create(SongCreate model);
    int Save();
}

public class SongService : ISongService
{
    private readonly ISongRepository _songRepository;
    private readonly IMapper _mapper;

    public SongService(ISongRepository songRepository, IMapper mapper)
    {
        _songRepository = songRepository;
        _mapper = mapper;
    }

    public Song Create(SongCreate model)
    {
        Song song = _songRepository.Add(_mapper.Map<Song>(model));
        
        return song;
    }

    public int Save()
    {
        return _songRepository.Save();
    }
}
