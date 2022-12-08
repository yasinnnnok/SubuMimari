using SUBU.DataAccess.Base.EntityFramework;
using SUBU.DataAccess.EntityFramework.Context;
using SUBU.Entities.EntityFramework.Database1;
using SUBU.Entities.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBU.DataAccess.EntityFramework.Repositories
{
 

    public interface IUserRepository : IEFRepository<UsersRole, int>
    {

    }
    public class UserRepository : EFRepository<UsersRole, int, Database1Context>, IUserRepository
    {
        public UserRepository(Database1Context context) : base(context)
        {
        }
    }
}
