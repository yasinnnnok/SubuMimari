using SUBU.DataAccess.Base.EntityFramework;
using SUBU.DataAccess.EntityFramework.Context;
using SUBU.Entities.EntityFramework.Database1;

namespace SUBU.DataAccess.EntityFramework.Repositories
{
    public interface IArtistRepository : IEFRepository<Artist, int>
    {

    }

    public class ArtistRepository : EFRepository<Artist, int, Database1Context>, IArtistRepository
    {
        public ArtistRepository(Database1Context context) : base(context)
        {

        }
    }

}
