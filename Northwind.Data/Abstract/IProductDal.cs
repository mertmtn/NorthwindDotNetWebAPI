using Northwind.Core.DataAccess;
using Northwind.Entity.Concrete;

namespace Northwind.Data.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {

    }
}
