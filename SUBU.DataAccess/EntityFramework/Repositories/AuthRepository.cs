using SUBU.DataAccess.Base.EntityFramework;
using SUBU.DataAccess.EntityFramework.Context;
using SUBU.Entities.EntityFramework.Database1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBU.DataAccess.EntityFramework.Repositories
{

    public interface IAuthRepository : IEFRepository<Login, int>
    {

    }
    public class AuthRepository : EFRepository<Login, int, Database1Context>, IAuthRepository
    {
        public AuthRepository(Database1Context context) : base(context)
        {
        }
    }


}
