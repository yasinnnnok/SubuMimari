using SUBU.DataAccess.Base.EntityFramework;
using SUBU.DataAccess.EntityFramework.Context;
using SUBU.Entities.EntityFramework.Database1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBU.DataAccess.EntityFramework.Repositories;

public interface IProductRepository : IEFRepository<Product, int>
{
	
}
public class ProductRepository : EFRepository<Product, int, Database1Context>, IProductRepository
{
	public ProductRepository(Database1Context context) : base(context)
	{
	}
}
