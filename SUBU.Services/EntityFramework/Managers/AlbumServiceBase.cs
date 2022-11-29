using AutoMapper;
using SUBU.DataAccess.EntityFramework.Repositories;
using SUBU.Entities.EntityFramework.Database1;
using SUBU.Services.EntityFramework.Abstract;

namespace SUBU.Services.EntityFramework.Managers
{
    public interface IAlbumServiceBase : IServiceBase<Album, int>
    {

    }

    public class AlbumServiceBase : ServiceBase<Album, int, IAlbumRepository>, IAlbumServiceBase
    {
        public AlbumServiceBase(IAlbumRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }


    }


}
