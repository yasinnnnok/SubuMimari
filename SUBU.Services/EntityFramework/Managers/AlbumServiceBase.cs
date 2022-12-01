using AutoMapper;
using SUBU.DataAccess.EntityFramework.Repositories;
using SUBU.Entities.EntityFramework.Database1;
using SUBU.Services.EntityFramework.Abstract;

//ServisBaseden miras alan yapımız. Save'i kendimiz yapıyoruz.
namespace SUBU.Services.EntityFramework.Managers
{
    //ServisBaseden türeterek hiç yazmadan insert,update,delete işlemleri gelecektir.
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
