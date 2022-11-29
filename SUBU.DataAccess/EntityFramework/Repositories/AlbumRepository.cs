using SUBU.DataAccess.Base.EntityFramework;
using SUBU.DataAccess.EntityFramework.Context;
using SUBU.Entities.EntityFramework.Database1;

namespace SUBU.DataAccess.EntityFramework.Repositories
{
    public interface IAlbumRepository : IEFRepository<Album, int>
    {
        //IEnumerable<Album> GetTestAlbum();
    }

    public class AlbumRepository : EFRepository<Album, int, Database1Context>, IAlbumRepository
    {
        public AlbumRepository(Database1Context context) : base(context)
        {
            
        }

        //public IEnumerable<Album> GetTestAlbum()
        //{
        //bu şekilde kullanabilrsin.
        //    //return this._table.Where(x => x.Name == "test"); //.FirstOrDefault();
        
        //Tolist ten sonra srogu yapma.
        //    //return this.GetAll().ToList().Where(x => x.Name == "test");

        //Quarable metodu: select * from gibi hazır.BaseRepoda yapmıştık.
        //    return Queryable().Where(x => x.Name == "test").ToList();
        //}
    }
}
