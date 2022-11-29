using AutoMapper;
using SUBU.DataAccess.EntityFramework.Repositories;
using SUBU.Entities.EntityFramework.Database1;
using SUBU.Services.EntityFramework.Abstract;

namespace SUBU.Services.EntityFramework.Managers
{
    public interface IAlbumServiceQuick : IServiceBase<Album, int>
    {

    }

    public class AlbumServiceQuick : ServiceBaseQuick<Album, int, IAlbumRepository>, IAlbumServiceQuick
    {
        public AlbumServiceQuick(IAlbumRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }


    }
}
