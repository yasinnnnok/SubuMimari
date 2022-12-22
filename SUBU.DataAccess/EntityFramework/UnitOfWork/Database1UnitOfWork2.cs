using SUBU.DataAccess.Base.UnitOfWork;
using SUBU.DataAccess.EntityFramework.Context;

namespace SUBU.DataAccess.EntityFramework.UnitOfWork;

//Generic yapı. Her Repo için ayrı ayrı property eklemeye gerek kalmıyor. Bunun için "UnitOfWorkGeneric" den türüyor.
public interface IDatabase1UnitOfWork2: IUnitOfWorkGeneric
{

}

public class Database1UnitOfWork2 : UnitOfWorkGeneric<Database1Context>, IDatabase1UnitOfWork2
{
    public Database1UnitOfWork2(Database1Context context, IServiceProvider serviceProvider) : base(context, serviceProvider)
    {
    }
}
