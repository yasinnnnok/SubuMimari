using SUBU.DataAccess.Base.EntityFramework;
using SUBU.DataAccess.EntityFramework.Context;
using SUBU.Entities.EntityFramework.Database1;

namespace SUBU.DataAccess.EntityFramework.Repositories;

public interface IAlbumRepository : IEFRepository<Album, int>
{
    //IEnumerable<Album> GetTestAlbum();
}

public class AlbumRepository : EFRepository<Album, int, Database1Context>, IAlbumRepository
{
    public AlbumRepository(Database1Context context) : base(context)
    {

    }

    //AlbumRepo ya özel metodları burada yazabilirsin. 
    //bu metodn yaptığını Querable ile Serviste yapabilirsin. O yüzden  ekledik.
    public IEnumerable<Album> GetTestAlbum()
    {
        //  bu şekilde kullanabilrsin.
        return this._table.Where(x => x.Name == "test"); //.FirstOrDefault();

        //Quarable metodu: select* from gibi hazır.BaseRepoda yapmıştık.Bu serviste kullanaiblirsin direk.
        //return Queryable().Where(x => x.Name == "test").ToList();
    }
}
