using WebApplication1.Ozet.Entities;

namespace WebApplication1.Ozet.DataAccess
{
    public interface IAlbumRepository
    {
        Album Insert(Album album);
    }

    public class AlbumRepository : IAlbumRepository
    {
        private DatabaseContext _databaseContext;

        public AlbumRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public virtual Album Insert(Album album)
        {
            _databaseContext.Albums.Add(album);
            return album;
        }
    }
}
