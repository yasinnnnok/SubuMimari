using AutoMapper;
using WebApplication1.Ozet.DataAccess;
using WebApplication1.Ozet.Entities;
using WebApplication1.Ozet.Models;

namespace WebApplication1.Ozet.Services
{
    public interface IAlbumService
    {
        Album Create(Album album);
        Album Create(AlbumCreate album);
    }

    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        public AlbumService(IAlbumRepository albumRepository, IMapper mapper)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        public virtual Album Create(Album album)
        {
            return _albumRepository.Insert(album);          
        }

        public virtual Album Create(AlbumCreate albumCreate)
        {
            return _albumRepository.Insert(_mapper.Map<Album>(albumCreate));
        }
    }

    public class AlbumService2 : AlbumService
    {
        public AlbumService2(IAlbumRepository albumRepository, IMapper mapper) : base(albumRepository, mapper)
        {
        }

        public override Album Create(AlbumCreate album)
        {
            return base.Create(album);
        }
    }
}
