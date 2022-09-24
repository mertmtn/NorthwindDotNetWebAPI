using Northwind.Core.DataAccess.Rdbms.EntityFramework;
using Northwind.Data.Abstract;
using Northwind.Entity.Concrete;

namespace Northwind.Data.Concrete.EntityFramework
{
    public class EfProductDal : EfGenericRepository<Product, NorthwindDbContext>, IProductDal
    {

    }
}
