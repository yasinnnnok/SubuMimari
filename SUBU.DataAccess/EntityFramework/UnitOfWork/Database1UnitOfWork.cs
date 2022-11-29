using SUBU.DataAccess.Base.UnitOfWork;
using SUBU.DataAccess.EntityFramework.Context;
using SUBU.DataAccess.EntityFramework.Repositories;

namespace SUBU.DataAccess.EntityFramework.UnitOfWork
{

    public interface IDatabase1UnitOfWork : IUnitOfWork
    {
        IAlbumRepository AlbumRepository { get; }
        ISongRepository SongRepository { get; }
        IArtistRepository ArtistRepository { get; }
    }

    public class Database1UnitOfWork : IDatabase1UnitOfWork
    {
        private readonly Database1Context _context;

        public Database1UnitOfWork(Database1Context context)
        {
            _context = context;
        }


        private IAlbumRepository albumRepository;

        public IAlbumRepository AlbumRepository
        {
            get
            {
                if (albumRepository == null)
                {
                    albumRepository = new AlbumRepository(_context);
                }

                return albumRepository;
            }
        }

        private ISongRepository songRepository;

        public ISongRepository SongRepository
        {
            get
            {
                if (songRepository == null)
                {
                    songRepository = new SongRepository(_context);
                }

                return songRepository;
            }
        }

        private IArtistRepository artistRepository;

        public IArtistRepository ArtistRepository
        {
            get
            {
                if (artistRepository == null)
                {
                    artistRepository = new ArtistRepository(_context);
                }

                return artistRepository;
            }
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
