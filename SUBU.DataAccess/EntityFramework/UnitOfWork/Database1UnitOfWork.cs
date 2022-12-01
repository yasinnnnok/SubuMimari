using SUBU.DataAccess.Base.UnitOfWork;
using SUBU.DataAccess.EntityFramework.Context;
using SUBU.DataAccess.EntityFramework.Repositories;
using System.Runtime.ConstrainedExecution;

//Her Repo için ayrı ayrı property ekleyerek yapılıyor.

//UnitOfwork context oluşturup hepsinde tek bir newlenmiş contexti kullanmak.
//Her repoya aynı contexti, aynı instance, aynı newlenmişi kullanıyoruz. Böylece hepsi aynı contexti işleyecek.
//Ne zaman Save lersek o zaman tek bir transictionda insert,update olacak.
//Biri başarısız olursa hiçbiri işlemeyecek.

namespace SUBU.DataAccess.EntityFramework.UnitOfWork
{

    //classtaki metodların imzaları burada. Commit metodunu ise ayrı bir interfacede yazdık.
    public interface IDatabase1UnitOfWork : IUnitOfWork
    {
        IAlbumRepository AlbumRepository { get; }
        ISongRepository SongRepository { get; }
        IArtistRepository ArtistRepository { get; }
    }
    //Classı 1 kere oluşturalım. Context'i yazalım. Hepsinde bu context kullanılsın.
    //Repositorylerin hangisi kullanılıyorsa o newlensin.

    public class Database1UnitOfWork : IDatabase1UnitOfWork
    {
        //context oluşturalım.
        private readonly Database1Context _context;

        public Database1UnitOfWork(Database1Context context)
        {
            _context = context;
        }

        //Bu kısım standart 
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

        //Standartı kullanarak Son oluşturduk.
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

        //Standartı kullanarak Artisti kullnacağız.
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
