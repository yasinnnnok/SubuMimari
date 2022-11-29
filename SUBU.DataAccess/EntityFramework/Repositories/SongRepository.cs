using SUBU.DataAccess.Base.EntityFramework;
using SUBU.DataAccess.EntityFramework.Context;
using SUBU.Entities.EntityFramework.Database1;

namespace SUBU.DataAccess.EntityFramework.Repositories
{
    public interface ISongRepository : IEFRepository<Song, int>
    {

    }

    public class SongRepository : EFRepository<Song, int, Database1Context>, ISongRepository
    {
        public SongRepository(Database1Context context) : base(context)
        {
        }
    }

}
